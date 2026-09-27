using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OneLaneWar
{
    public enum Side { Player, Enemy }
    public enum Outcome { Active, PlayerWin, EnemyWin, Draw }
    public enum CommandKind { Deploy, Rally }
    public sealed class CombatCommand
    {
        public readonly int Tick; public readonly long Sequence; public readonly CommandKind Kind; public readonly string Unit;
        public CombatCommand(int tick, long sequence, CommandKind kind, string unit = null) { Tick = tick; Sequence = sequence; Kind = kind; Unit = unit; }
    }
    public sealed class CommandResult
    {
        public readonly long Sequence; public readonly int Tick; public readonly string Reason;
        internal CommandResult(CombatCommand command, string reason) { Sequence = command.Sequence; Tick = command.Tick; Reason = reason; }
    }
    public sealed class ActorView
    {
        public readonly int Id, Hp, MaxHp, Barrier, Slot; public readonly Side Side; public readonly string Unit, Boss;
        public readonly long X; public readonly bool Attacking;
        internal ActorView(Actor a) { Id = a.Id; Hp = a.Hp; MaxHp = a.Stats.Hp; Barrier = a.Barrier; Slot = a.Slot; Side = a.Side; Unit = a.Stats.Unit; Boss = a.Boss; X = a.X; Attacking = a.Attack != null; }
    }
    public sealed class ProjectileView
    {
        public readonly int Id; public readonly long X, Destination; public readonly Side Side; public readonly bool Lob;
        internal ProjectileView(Projectile p) { Id = p.Id; X = p.X; Destination = p.End; Side = p.Side; Lob = p.Lob; }
    }
    internal sealed class Attack
    {
        internal int Target, ImpactTick, EndTick, Damage, BaseDamage; internal long TargetX;
        internal bool Released;
    }
    internal sealed class Actor
    {
        internal int Id, Hp, Barrier, BarrierExpiry = -1, Slot = -1, BaseHits;
        internal bool BarrierUsed; internal Side Side; internal string Boss;
        internal long X, MoveRemainder; internal Stats Stats; internal Attack Attack;
        internal int Direction { get { return Side == Side.Player ? 1 : -1; } }
    }
    internal sealed class Projectile
    {
        internal int Id, Source, BornTick, ArrivalTick, TargetBase, Damage, BaseDamage;
        internal long X, End, LaunchX, Speed, Remainder, Splash;
        internal Side Side; internal bool Lob; internal int Pierce, PierceFactor; internal long PierceRange;
        internal int TravelDirection;
        internal int Direction { get { return TravelDirection != 0 ? TravelDirection : Side == Side.Player ? 1 : -1; } }
    }
    internal sealed class DamageEvent
    {
        internal int Source, Target, Amount, Order;
    }
    public sealed class Diagnostics
    {
        public long Commands { get; internal set; }
        public long PaidDeployments { get; internal set; }
        public long BonusSpawns { get; internal set; }
        public long CapRejections { get; internal set; }
        public long SupplyWaste { get; internal set; }
        public long AttemptedDamage { get; internal set; }
        public long BarrierDamage { get; internal set; }
        public long HpDamage { get; internal set; }
        public long BaseDamage { get; internal set; }
        public long Deaths { get; internal set; }
        public int PeakPopulation { get; internal set; }
    }

    // All mutation occurs in this model. Views receive detached, read-only snapshots.
    public sealed class CombatModel
    {
        internal readonly Content Content;
        internal readonly EncounterDefinition Encounter;
        internal readonly List<Actor> Actors = new List<Actor>();
        internal readonly List<Projectile> Projectiles = new List<Projectile>();
        internal readonly List<DamageEvent> Damage = new List<DamageEvent>();
        // AMEND-005: only creation may introduce hostile overlap. Pair IDs persist
        // until the bodies separate or die; movement never creates these exceptions.
        readonly HashSet<long> spawnContacts = new HashSet<long>();
        readonly List<CombatCommand> commands = new List<CombatCommand>();
        readonly List<CommandResult> results = new List<CommandResult>();
        readonly HashSet<string> pauses = new HashSet<string>(StringComparer.Ordinal);
        readonly string[] loadout, selected;
        readonly SortedDictionary<string, Stats> playerStats = new SortedDictionary<string, Stats>(StringComparer.Ordinal);
        readonly long[] supply = new long[2], income = new long[2], caps = new long[2], incomeRemainder = new long[2];
        readonly int[] baseHp = new int[2], baseMax = new int[2];
        int nextActor = 1, nextProjectile = 1, nextDeploy, nextEnemyDeploy, rallyExpiry = -1, rallyReady;
        int rallyDuration, rallyCooldown, paidMilitia, enemySpent;
        long lastCommandSequence = -1; bool owedMilitia;
        public int Tick { get; private set; } = -1;
        public uint Seed { get; private set; }
        public Outcome Result { get; private set; }
        public int EnemyQueueIndex { get; private set; }
        public bool Paused { get { return pauses.Count != 0; } }
        public bool RallyActive { get { return Tick >= 0 && Tick < rallyExpiry; } }
        public int RallyReadyTick { get { return rallyReady; } }
        public bool BonusOwed { get { return owedMilitia; } }
        public string EncounterId { get { return Encounter.id; } }
        public string[] Loadout { get { return (string[])loadout.Clone(); } }
        public string[] PauseReasons { get { return pauses.OrderBy(x => x, StringComparer.Ordinal).ToArray(); } }
        public Diagnostics Counters { get; private set; } = new Diagnostics();
        public int BaseHp(Side side) { return baseHp[(int)side]; }
        public int BaseMax(Side side) { return baseMax[(int)side]; }
        public long Supply(Side side) { return supply[(int)side]; }
        public long SupplyCap(Side side) { return caps[(int)side]; }
        public int Cost(string id) { return playerStats[id].Cost; }
        public int Alive(Side side) { return Actors.Count(x => x.Side == side); }
        public ActorView[] ActorViews() { return Actors.Select(x => new ActorView(x)).ToArray(); }
        public ProjectileView[] ProjectileViews() { return Projectiles.Select(x => new ProjectileView(x)).ToArray(); }
        public CommandResult[] CommandResults() { return results.ToArray(); }
        public bool BossRevealed { get { return Encounter.boss_variant != null && Tick >= nextEnemyDeploy - Ticks(Encounter.boss_reveal_lead_s) && EnemyQueueIndex == Encounter.boss_queue_index_zero_based; } }

        public CombatModel(Content content, string encounter, string[] units, string[] upgrades, uint seed)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content)); content.ValidateLoadout(units);
            if (seed == 0) throw new ArgumentException("Nonzero seed required"); Seed = seed;
            if (!content.Encounters.TryGetValue(encounter, out Encounter)) throw new ArgumentException("CONTENT_ENCOUNTER: " + encounter);
            loadout = (string[])units.Clone(); selected = (string[])(upgrades ?? new string[0]).Clone();
            if (selected.Length > 4 || selected.Distinct().Count() != selected.Length || selected.Any(x => !content.Eligible(loadout).Contains(x))) throw new ArgumentException("CONTENT_UPGRADE_SELECTION");
            var chosen = selected.Select(x => content.Upgrades[x]).ToArray();
            foreach (var id in units) playerStats.Add(id, Stats.Build(content, id, chosen));
            var r = content.Rules;
            supply[0] = Fixed.Scaled(r.supply.start); caps[0] = Fixed.Scaled(r.supply.cap); income[0] = Fixed.Scaled(r.supply.rate_per_s);
            supply[1] = Fixed.Scaled(Encounter.enemy_supply_start); caps[1] = Fixed.Scaled(Encounter.enemy_supply_cap); income[1] = Fixed.Scaled(Encounter.enemy_supply_rate_per_s);
            rallyDuration = Ticks(r.rally.duration_s); rallyCooldown = Ticks(r.rally.cooldown_s); rallyReady = Ticks(r.rally.initial_cooldown_s);
            foreach (var upgrade in chosen)
            {
                switch (upgrade.Operator)
                {
                    case "supply_rate_add_pct": income[0] = Fixed.Round(checked(income[0] * (Fixed.Bp + Fixed.Scaled(upgrade.value, Fixed.Bp))), Fixed.Bp); break;
                    case "supply_cap_add": caps[0] += Fixed.Scaled(upgrade.value); supply[0] += Fixed.Scaled(upgrade.additional_rules.starting_supply_add); break;
                    case "rally_duration_add_s": rallyDuration += Ticks(upgrade.value); break;
                    case "rally_cooldown_add_s": rallyCooldown += Ticks(upgrade.value); break;
                }
            }
            baseHp[0] = baseMax[0] = Encounter.player_base_hp; baseHp[1] = baseMax[1] = Encounter.enemy_base_hp;
            nextEnemyDeploy = Ticks(Encounter.enemy_first_deployment_earliest_s);
        }
        int Ticks(decimal seconds) { return (int)Fixed.Scaled(seconds, Content.Rules.simulation_hz); }
        internal long Front(Side side) { return Fixed.Scaled(Content.Rules.base_fronts_m[(int)side]); }
        static Side Other(Side side) { return side == Side.Player ? Side.Enemy : Side.Player; }
        static int BaseId(Side side) { return -1 - (int)side; }
        internal Actor Find(int id) { return Actors.FirstOrDefault(x => x.Id == id); }
        public void SetPause(string reason, bool active)
        {
            if (string.IsNullOrEmpty(reason)) throw new ArgumentException(nameof(reason));
            if (active) pauses.Add(reason); else pauses.Remove(reason);
        }
        public void Enqueue(CombatCommand command)
        {
            if (command == null || command.Tick <= Tick || command.Sequence <= lastCommandSequence) throw new ArgumentException("COMMAND_ORDER");
            if (Paused || Result != Outcome.Active) throw new InvalidOperationException("COMMAND_INACTIVE");
            lastCommandSequence = command.Sequence; commands.Add(command);
        }
        public bool Step()
        {
            if (Paused || Result != Outcome.Active) return false;
            Tick++; Damage.Clear(); results.Clear();
            spawnContacts.RemoveWhere(key => !Overlaps(Find((int)(key >> 32)), Find((int)(key & uint.MaxValue))));
            foreach (var actor in Actors) if (actor.BarrierExpiry == Tick) actor.Barrier = 0;
            if (Tick > 0) for (int side = 0; side < 2; side++)
            {
                long total = checked(income[side] + incomeRemainder[side]);
                long gain = total / Content.Rules.simulation_hz; incomeRemainder[side] = total % Content.Rules.simulation_hz;
                if (side == 0) Counters.SupplyWaste += Math.Max(0, supply[side] + gain - caps[side]);
                supply[side] = Math.Min(caps[side], supply[side] + gain);
            }
            if (owedMilitia && Alive(Side.Player) < Content.Rules.max_alive_units_per_side)
            { Spawn(Side.Player, playerStats["militia"], null); owedMilitia = false; Counters.BonusSpawns++; }
            foreach (var command in commands.Where(x => x.Tick == Tick).OrderBy(x => x.Sequence)) Execute(command);
            commands.RemoveAll(x => x.Tick == Tick);
            EnemyDeploy(); AssignSlots(); Move(); AdvanceAttacks(); AdvanceProjectiles(); ResolveDamage();
            Counters.Deaths += Actors.Count(x => x.Hp <= 0); Actors.RemoveAll(x => x.Hp <= 0);
            ResolveOutcome(); return true;
        }
        void Execute(CombatCommand command)
        {
            Counters.Commands++; string reason;
            if (command.Kind == CommandKind.Rally)
            {
                reason = Tick < rallyReady ? "RALLY_COOLDOWN" : "ACCEPTED";
                if (reason == "ACCEPTED") { rallyExpiry = Tick + rallyDuration; rallyReady = Tick + rallyCooldown; }
            }
            else if (command.Kind != CommandKind.Deploy) reason = "UNKNOWN_COMMAND";
            else if (command.Unit == null || !playerStats.ContainsKey(command.Unit)) reason = "NOT_EQUIPPED";
            else if (Tick < nextDeploy) reason = "DEPLOY_COOLDOWN";
            else if (Alive(Side.Player) >= Content.Rules.max_alive_units_per_side) { reason = "POPULATION_CAP"; Counters.CapRejections++; }
            else if (supply[0] < playerStats[command.Unit].Cost * Fixed.Scale) reason = "SUPPLY";
            else
            {
                var stats = playerStats[command.Unit]; supply[0] -= stats.Cost * Fixed.Scale;
                Spawn(Side.Player, stats, null); nextDeploy = Tick + Ticks(Content.Rules.supply.deployment_cooldown_s);
                Counters.PaidDeployments++; reason = "ACCEPTED";
                if (stats.Conscription > 0 && ++paidMilitia % stats.Conscription == 0)
                {
                    if (Alive(Side.Player) < Content.Rules.max_alive_units_per_side) { Spawn(Side.Player, stats, null); Counters.BonusSpawns++; }
                    else owedMilitia = true;
                }
            }
            results.Add(new CommandResult(command, reason));
        }
        void EnemyDeploy()
        {
            if (Tick >= Ticks(Encounter.enemy_orders_expire_at_s) || EnemyQueueIndex >= Encounter.enemy_spawn_queue.Length || Tick < nextEnemyDeploy || Alive(Side.Enemy) >= Content.Rules.max_alive_units_per_side) return;
            string unit = Encounter.enemy_spawn_queue[EnemyQueueIndex]; string boss = EnemyQueueIndex == Encounter.boss_queue_index_zero_based ? Encounter.boss_variant : null;
            var stats = Stats.Build(Content, unit, new UpgradeDefinition[0], boss);
            if (supply[1] < stats.Cost * Fixed.Scale || enemySpent + stats.Cost > Encounter.enemy_total_supply_budget) return;
            supply[1] -= stats.Cost * Fixed.Scale; enemySpent += stats.Cost;
            Spawn(Side.Enemy, stats, boss); EnemyQueueIndex++; nextEnemyDeploy = Tick + Ticks(Encounter.enemy_min_deployment_gap_s);
        }
        internal Actor Spawn(Side side, Stats stats, string boss)
        {
            var a = new Actor { Id = nextActor++, Side = side, Stats = stats, Boss = boss, Hp = stats.Hp, X = Fixed.Scaled(Content.Rules.spawn_positions_m[(int)side]) };
            foreach (var b in Actors.Where(b => b.Side != side && Overlaps(a, b))) spawnContacts.Add(ContactKey(a, b));
            Actors.Add(a); Counters.PeakPopulation = Math.Max(Counters.PeakPopulation, Actors.Count); return a;
        }
        static long ContactKey(Actor a, Actor b) { return ((long)Math.Min(a.Id, b.Id) << 32) | (uint)Math.Max(a.Id, b.Id); }
        static bool Overlaps(Actor a, Actor b) { return a != null && b != null && a.Hp > 0 && b.Hp > 0 && Math.Abs(a.X - b.X) < a.Stats.HalfWidth + b.Stats.HalfWidth; }
        internal bool InSpawnContact(Actor a, Actor b) { return spawnContacts.Contains(ContactKey(a, b)) && Overlaps(a, b); }
        void AssignSlots()
        {
            foreach (Side side in Enum.GetValues(typeof(Side)))
            {
                var eligible = Actors.Where(a => a.Side == side && a.Stats.Melee).ToArray();
                for (int slot = 0; slot < Content.Rules.max_melee_engagement_slots_per_side; slot++)
                {
                    if (eligible.Any(a => a.Slot == slot)) continue;
                    var actor = eligible.Where(a => a.Slot < 0).OrderByDescending(a => a.X * a.Direction).ThenBy(a => a.Id).FirstOrDefault();
                    if (actor != null) actor.Slot = slot;
                }
            }
        }
        internal long Gap(Actor a, int target)
        {
            if (target < 0) return Math.Max(0, Math.Abs(a.X - Front((Side)(-target - 1))) - a.Stats.HalfWidth);
            var b = Find(target); return b == null ? long.MaxValue : Math.Max(0, Math.Abs(a.X - b.X) - a.Stats.HalfWidth - b.Stats.HalfWidth);
        }
        internal int Target(Actor a)
        {
            var contact = Actors.Where(b => b.Side != a.Side && InSpawnContact(a, b)).OrderBy(b => Math.Abs(b.X - a.X)).ThenBy(b => b.Id).FirstOrDefault();
            if (contact != null) return contact.Id;
            var target = Actors.Where(b => b.Side != a.Side && (b.X - a.X) * a.Direction >= 0).OrderBy(b => Math.Abs(b.X - a.X)).ThenBy(b => b.Id).FirstOrDefault();
            return target == null ? BaseId(Other(a.Side)) : target.Id;
        }
        bool Reach(Actor a, int target) { return Gap(a, target) <= a.Stats.Range + Fixed.Scaled(Content.Rules.formation_contract.range_tolerance_m); }
        bool CanAttack(Actor a) { return !a.Stats.Melee || a.Slot >= 0; }
        void Move()
        {
            var moves = new Dictionary<int, long>();
            foreach (var a in Actors)
            {
                if (Actors.Any(b => b.Side != a.Side && InSpawnContact(a, b)) || (a.Attack != null && Tick < a.Attack.EndTick) || (CanAttack(a) && Reach(a, Target(a)))) { moves[a.Id] = 0; continue; }
                long total = checked(a.Stats.Speed + a.MoveRemainder);
                moves[a.Id] = total / Content.Rules.simulation_hz; a.MoveRemainder = total % Content.Rules.simulation_hz;
                moves[a.Id] = Math.Min(moves[a.Id], Math.Max(0, (Front(Other(a.Side)) - a.X) * a.Direction - a.Stats.HalfWidth));
            }
            // Friendly ranks constrain only their own role. Melee can pass friendly ranged.
            foreach (Side side in Enum.GetValues(typeof(Side))) foreach (bool melee in new[] { true, false })
            {
                var row = Actors.Where(a => a.Side == side && a.Stats.Melee == melee).OrderByDescending(a => a.X * a.Direction).ThenBy(a => a.Id).ToArray();
                int stride = melee ? Content.Rules.max_melee_engagement_slots_per_side : 1;
                long spacing = Fixed.Scaled(melee ? Content.Rules.formation_contract.friendly_group_spacing_m : Content.Rules.formation_contract.ranged_queue_spacing_m);
                for (int i = stride; i < row.Length; i++)
                {
                    var a = row[i]; var leader = row[i - stride];
                    moves[a.Id] = Math.Min(moves[a.Id], Math.Max(0, (leader.X - a.X) * a.Direction + moves[leader.Id] - spacing));
                }
            }
            // Proposals come from the same tick; pair resolution can only reduce them.
            foreach (var blue in Actors.Where(a => a.Side == Side.Player)) foreach (var red in Actors.Where(a => a.Side == Side.Enemy))
            {
                if (blue.X > red.X) continue;
                long gap = Math.Max(0, red.X - blue.X - blue.Stats.HalfWidth - red.Stats.HalfWidth);
                long total = moves[blue.Id] + moves[red.Id];
                if (total <= gap) continue;
                long b = checked(gap * moves[blue.Id]) / total, r = checked(gap * moves[red.Id]) / total;
                if (b + r < gap) { if (blue.Id < red.Id && moves[blue.Id] > b) b++; else r++; }
                moves[blue.Id] = b; moves[red.Id] = r;
            }
            foreach (var a in Actors) a.X += moves[a.Id] * a.Direction;
        }
        void AdvanceAttacks()
        {
            foreach (var a in Actors)
            {
                var attack = a.Attack;
                if (attack != null && Tick == attack.ImpactTick && !attack.Released) { Release(a, attack); attack.Released = true; }
                if (attack != null && Tick >= attack.EndTick) a.Attack = null;
                if (a.Attack != null || !CanAttack(a)) continue;
                int target = Target(a); if (!Reach(a, target)) continue;
                long rate = a.Stats.RateBp + (a.Side == Side.Player && RallyActive ? Fixed.Scaled(Content.Rules.rally.attack_rate_bonus, Fixed.Bp) : 0);
                int period = (int)Math.Max(7, Fixed.Ceil(a.Stats.Period * Fixed.Bp, Fixed.Bp + rate));
                int windup = (int)Math.Min(period - 1, Math.Max(1, Fixed.Ceil(a.Stats.Windup * Fixed.Bp, Fixed.Bp + rate)));
                a.Attack = new Attack { Target = target, TargetX = target < 0 ? Front(Other(a.Side)) : Find(target).X, ImpactTick = Tick + windup, EndTick = Tick + period, Damage = a.Stats.Damage, BaseDamage = a.Stats.BaseDamage };
            }
        }
        void Release(Actor a, Attack attack)
        {
            if (a.Stats.ProjectileSpeed == 0)
            {
                if (attack.Target > 0 && Find(attack.Target) == null) return;
                if (!Reach(a, attack.Target)) return;
                if (attack.Target < 0 && Target(a) != attack.Target) return;
                AddDamage(a.Id, attack.Target, attack.Target < 0 ? attack.BaseDamage : attack.Damage);
                if (attack.Target < 0 && a.Stats.RamEvery > 0 && ++a.BaseHits % a.Stats.RamEvery == 0)
                    AddDamage(a.Id, attack.Target, (int)Fixed.Round((long)attack.BaseDamage * a.Stats.RamFactor, Fixed.Bp));
                if (attack.Target > 0 && a.Stats.Sweep > 0)
                {
                    var primary = Find(attack.Target);
                    foreach (var b in Actors.Where(b => b.Side != a.Side && b.Id != primary.Id && Math.Abs(b.X - primary.X) <= a.Stats.SweepRange).OrderBy(b => Math.Abs(b.X - primary.X)).ThenBy(b => b.Id).Take(a.Stats.Sweep))
                        AddDamage(a.Id, b.Id, (int)Fixed.Round((long)attack.Damage * a.Stats.SweepFactor, Fixed.Bp));
                }
                return;
            }
            // A ranged windup snapshots damage; ground/bolt extent is committed at release.
            var liveTarget = attack.Target > 0 ? Find(attack.Target) : null;
            long end = liveTarget != null ? liveTarget.X : attack.TargetX;
            bool legalBase = attack.Target < 0 && Target(a) == attack.Target && Reach(a, attack.Target);
            if (attack.Target < 0 && !legalBase) return;
            var p = new Projectile { Id = nextProjectile++, Source = a.Id, Side = a.Side, BornTick = Tick, X = a.X, LaunchX = a.X, End = end,
                Speed = a.Stats.ProjectileSpeed, Damage = attack.Damage, BaseDamage = attack.BaseDamage, Splash = a.Stats.Splash,
                Lob = a.Stats.Splash > 0, TargetBase = legalBase ? attack.Target : 0,
                Pierce = a.Stats.Pierce, PierceRange = a.Stats.PierceRange, PierceFactor = a.Stats.PierceFactor };
            p.TravelDirection = end == a.X ? a.Direction : Math.Sign(end - a.X);
            p.ArrivalTick = Tick + (int)Math.Max(1, Fixed.Ceil(checked(Math.Abs(end - p.X) * Content.Rules.simulation_hz), p.Speed));
            Projectiles.Add(p);
        }
        void AdvanceProjectiles()
        {
            var finished = new List<Projectile>();
            foreach (var p in Projectiles)
            {
                if (p.BornTick == Tick) continue;
                if (p.Lob)
                {
                    if (Tick < p.ArrivalTick) continue;
                    foreach (var b in Actors.Where(b => b.Side != p.Side && Math.Abs(b.X - p.End) <= p.Splash)) AddDamage(p.Source, b.Id, p.Damage);
                    if (p.TargetBase < 0 && !ProjectileBaseBlocked(p)) AddDamage(p.Source, p.TargetBase, p.BaseDamage);
                    finished.Add(p); continue;
                }
                long start = p.X, total = checked(p.Speed + p.Remainder), distance = total / Content.Rules.simulation_hz;
                p.Remainder = total % Content.Rules.simulation_hz;
                long remaining = Math.Max(0, (p.End - start) * p.Direction);
                p.X += Math.Min(distance, remaining) * p.Direction;
                long low = Math.Min(start, p.X), high = Math.Max(start, p.X);
                var hit = Actors.Where(b => b.Side != p.Side && b.X + b.Stats.HalfWidth >= low && b.X - b.Stats.HalfWidth <= high)
                    .OrderBy(b => (b.X - start) * p.Direction).ThenBy(b => b.Id).FirstOrDefault();
                if (hit != null)
                {
                    AddDamage(p.Source, hit.Id, p.Damage);
                    foreach (var second in Actors.Where(b => b.Side != p.Side && b.Id != hit.Id && (b.X - hit.X) * p.Direction >= 0 && (b.X - hit.X) * p.Direction <= p.PierceRange)
                        .OrderBy(b => (b.X - hit.X) * p.Direction).ThenBy(b => b.Id).Take(p.Pierce))
                        AddDamage(p.Source, second.Id, (int)Fixed.Round((long)p.Damage * p.PierceFactor, Fixed.Bp));
                    finished.Add(p);
                }
                else if (p.X == p.End)
                {
                    if (p.TargetBase < 0 && !ProjectileBaseBlocked(p)) AddDamage(p.Source, p.TargetBase, p.BaseDamage);
                    finished.Add(p);
                }
            }
            foreach (var p in finished) Projectiles.Remove(p);
        }
        bool ProjectileBaseBlocked(Projectile p)
        {
            long low = Math.Min(p.LaunchX, p.End), high = Math.Max(p.LaunchX, p.End);
            return Actors.Any(a => a.Side != p.Side && a.Hp > 0 && a.X + a.Stats.HalfWidth >= low && a.X - a.Stats.HalfWidth <= high);
        }
        internal void AddDamage(int source, int target, int amount)
        {
            if (amount <= 0) return;
            Damage.Add(new DamageEvent { Source = source, Target = target, Amount = amount, Order = Damage.Count });
        }
        internal void ResolveDamage()
        {
            foreach (var hit in Damage.OrderBy(d => d.Source).ThenBy(d => d.Order))
            {
                int amount = hit.Amount; Counters.AttemptedDamage += amount;
                if (hit.Target < 0)
                {
                    if (Tick >= Ticks(Content.Rules.battle.soft_time_limit_s)) amount = checked(amount * 2);
                    int side = -hit.Target - 1, actual = Math.Min(baseHp[side], amount);
                    baseHp[side] -= actual; Counters.BaseDamage += actual; continue;
                }
                var a = Find(hit.Target); if (a == null) continue;
                amount = Math.Max(1, amount - a.Stats.Reduction);
                if (!a.BarrierUsed && a.Stats.Barrier > 0)
                { a.BarrierUsed = true; a.Barrier = a.Stats.Barrier; a.BarrierExpiry = Tick + a.Stats.BarrierTicks; }
                int absorbed = Math.Min(a.Barrier, amount); a.Barrier -= absorbed; amount -= absorbed; Counters.BarrierDamage += absorbed;
                int hpLost = Math.Min(a.Hp, amount); a.Hp -= hpLost; Counters.HpDamage += hpLost;
            }
        }
        void ResolveOutcome()
        {
            if (baseHp[0] == 0 || baseHp[1] == 0) Result = baseHp[0] == baseHp[1] ? Outcome.Draw : baseHp[1] == 0 ? Outcome.PlayerWin : Outcome.EnemyWin;
            else if (Tick >= Ticks(Content.Rules.battle.hard_time_limit_s))
            {
                long p = (long)baseHp[0] * baseMax[1], e = (long)baseHp[1] * baseMax[0];
                Result = p == e ? Outcome.Draw : p > e ? Outcome.PlayerWin : Outcome.EnemyWin;
            }
            if (Result != Outcome.Active) { commands.Clear(); Projectiles.Clear(); }
        }

        // Versioned little-endian serialization includes future-affecting state and queued input.
        public string StateHash()
        {
            using (var stream = new MemoryStream()) using (var w = new BinaryWriter(stream))
            {
                w.Write("OLW-COMBAT-2-AMEND005"); w.Write(Content.SourceHash); w.Write(Encounter.id); w.Write(Seed); w.Write(Tick); w.Write((int)Result);
                w.Write(spawnContacts.Count); foreach (var key in spawnContacts.OrderBy(x => x)) w.Write(key);
                foreach (var s in loadout) w.Write(s); w.Write(selected.Length); foreach (var s in selected) w.Write(s);
                w.Write(pauses.Count); foreach (var p in PauseReasons) w.Write(p);
                w.Write(nextActor); w.Write(nextProjectile); w.Write(nextDeploy); w.Write(nextEnemyDeploy); w.Write(EnemyQueueIndex); w.Write(enemySpent);
                w.Write(rallyReady); w.Write(rallyExpiry); w.Write(paidMilitia); w.Write(owedMilitia); w.Write(lastCommandSequence);
                for (int i = 0; i < 2; i++) { w.Write(baseHp[i]); w.Write(supply[i]); w.Write(incomeRemainder[i]); }
                w.Write(Actors.Count);
                foreach (var a in Actors.OrderBy(x => x.Id))
                {
                    w.Write(a.Id); w.Write((int)a.Side); w.Write(a.Stats.Unit); w.Write(a.Boss ?? ""); w.Write(a.X); w.Write(a.Hp); w.Write(a.MoveRemainder);
                    w.Write(a.Slot); w.Write(a.Barrier); w.Write(a.BarrierUsed); w.Write(a.BarrierExpiry); w.Write(a.BaseHits); w.Write(a.Attack != null);
                    if (a.Attack != null) { var x = a.Attack; w.Write(x.Target); w.Write(x.TargetX); w.Write(x.ImpactTick); w.Write(x.EndTick); w.Write(x.Damage); w.Write(x.BaseDamage); w.Write(x.Released); }
                }
                w.Write(Projectiles.Count);
                foreach (var p in Projectiles.OrderBy(x => x.Id))
                {
                    w.Write(p.Id); w.Write(p.Source); w.Write((int)p.Side); w.Write(p.BornTick); w.Write(p.ArrivalTick); w.Write(p.TargetBase);
                    w.Write(p.X); w.Write(p.End); w.Write(p.LaunchX); w.Write(p.Speed); w.Write(p.Remainder); w.Write(p.Damage); w.Write(p.BaseDamage); w.Write(p.Splash); w.Write(p.Lob);
                    w.Write(p.Pierce); w.Write(p.PierceRange); w.Write(p.PierceFactor); w.Write(p.TravelDirection);
                }
                w.Write(commands.Count); foreach (var c in commands.OrderBy(x => x.Tick).ThenBy(x => x.Sequence)) { w.Write(c.Tick); w.Write(c.Sequence); w.Write((int)c.Kind); w.Write(c.Unit ?? ""); }
                w.Write(Counters.Commands); w.Write(Counters.PaidDeployments); w.Write(Counters.BonusSpawns); w.Write(Counters.CapRejections); w.Write(Counters.SupplyWaste);
                w.Write(Counters.AttemptedDamage); w.Write(Counters.BarrierDamage); w.Write(Counters.HpDamage); w.Write(Counters.BaseDamage); w.Write(Counters.Deaths); w.Write(Counters.PeakPopulation);
                w.Flush(); return Fixed.Hash(stream.ToArray());
            }
        }
    }

    public sealed class TickScheduler
    {
        readonly CombatModel model; decimal accumulator;
        public TickScheduler(CombatModel model) { this.model = model; }
        public void ResetElapsed() { accumulator = 0; }
        public int Advance(decimal seconds, int speed, int maxSteps = 200)
        {
            if (seconds < 0 || (speed != 1 && speed != 2 && speed != 4 && speed != 10)) throw new ArgumentException();
            if (model.Paused || model.Result != Outcome.Active) { accumulator = 0; return 0; }
            accumulator += seconds * speed; int count = 0;
            while (accumulator >= 0.05m && count < maxSteps && model.Result == Outcome.Active)
            { if (!model.Step()) break; accumulator -= 0.05m; count++; }
            return count;
        }
    }
}
