using System;
using System.Collections.Generic;
using System.Linq;

namespace OneLaneWar.Tests
{
    // These fixtures execute the shipping model. Internal access is limited to constructing
    // labelled synthetic initial states; expected outcomes do not call a second simulator.
    public static class ModelFixtures
    {
        public static Func<string, byte[]> Read;
        public static readonly SortedDictionary<string, Action> Cases = new SortedDictionary<string, Action>(StringComparer.Ordinal);
        static readonly string[] Starter = { "militia", "shieldguard", "crossbowman", "grenadier" };
        static void Equal<T>(T expected, T actual, string context = "")
        { if (!EqualityComparer<T>.Default.Equals(expected, actual)) throw new Exception(context + " expected=" + expected + " actual=" + actual); }
        static void True(bool value, string context) { if (!value) throw new Exception(context); }
        static void Throws(Action action) { try { action(); } catch (ArgumentException) { return; } catch (FormatException) { return; } catch (InvalidOperationException) { return; } throw new Exception("Expected rejection"); }
        static Content Data() { return Content.Load(Read); }
        static CombatModel Empty(string[] upgrades = null, string[] loadout = null)
        {
            var c = Data(); c.Encounters["c01_e01_b01"].enemy_spawn_queue = new string[0];
            return new CombatModel(c, "c01_e01_b01", loadout ?? Starter, upgrades ?? new string[0], 17);
        }
        static Actor Put(CombatModel m, Side side, string id, decimal x, string[] upgrades = null, string boss = null)
        {
            var stats = Stats.Build(m.Content, id, (upgrades ?? new string[0]).Select(u => m.Content.Upgrades[u]), boss);
            var actor = m.Spawn(side, stats, boss); actor.X = Fixed.Scaled(x); return actor;
        }
        static void Until(CombatModel m, int tick) { while (m.Tick < tick && m.Result == Outcome.Active) m.Step(); }
        static void Hit(CombatModel m, Actor a, int damage) { m.Damage.Clear(); m.AddDamage(9999, a.Id, damage); m.ResolveDamage(); }
        static Stats Stat(string id, params string[] upgrades) { var c = Data(); return Stats.Build(c, id, upgrades.Select(u => c.Upgrades[u])); }
        static void Add(string name, Action body) { Cases.Add(name, body); }

        static ModelFixtures()
        {
            Add("content.canonical_counts_and_hash", () => { var c = Data(); Equal(6, c.UnitIds.Length); Equal(24, c.UpgradeIds.Length); Equal(36, c.EncounterIds.Length); Equal(Content.ManifestHash, c.SourceHash); });
            Add("content.modified_bytes_rejected", () => Throws(() => Content.Load(path => path == "data/units.json" ? Read(path).Concat(new byte[] { 32 }).ToArray() : Read(path))));
            Add("content.unknown_reference_rejected", () => { var c = Data(); c.Encounters.Values.First().enemy_spawn_queue[0] = "unknown"; Throws(() => c.Validate()); });
            Add("content.bad_selection_rejected", () => { var c = Data(); Throws(() => new CombatModel(c, "missing", Starter, new string[0], 1)); Throws(() => new CombatModel(c, "c01_e01_b01", Starter, new[] { "u17" }, 1)); Throws(() => new CombatModel(c, "c01_e01_b01", Starter, new[] { "u19", "u19" }, 1)); Throws(() => new CombatModel(c, "c01_e01_b01", new[] { "militia", "militia", "brute", "ram" }, new string[0], 1)); });
            Add("content.all_15_loadouts_have_18_upgrades", () => { var c = Data(); var units = c.UnitIds; int count = 0; for (int a = 0; a < 3; a++) for (int b = a + 1; b < 4; b++) for (int d = b + 1; d < 5; d++) for (int e = d + 1; e < 6; e++) { Equal(18, c.Eligible(new[] { units[a], units[b], units[d], units[e] }).Length); count++; } Equal(15, count); });
            Add("content.all_authored_queues_and_boss_replacements", () => {
                var c = Data(); int bosses = 0;
                foreach (var e in c.Encounters.Values)
                {
                    var m = new CombatModel(c, e.id, Starter, new string[0], 1); int index = 0;
                    while (m.Tick < 3599 && index < e.enemy_spawn_queue.Length)
                    {
                        m.Step(); if (m.EnemyQueueIndex > index)
                        {
                            var born = m.Actors.Single(); Equal(e.enemy_spawn_queue[index], born.Stats.Unit);
                            if (e.boss_queue_index_zero_based == index) { Equal(e.boss_variant, born.Boss); bosses++; }
                            index++; m.Actors.Clear(); // Explicit funding/queue fixture, no congestion or battle proof.
                        }
                    }
                    Equal(e.enemy_spawn_queue.Length, index, e.id);
                }
                Equal(6, bosses);
            });
            Add("numeric.exact_decimal_half_up_and_ceiling", () => { Equal(1L, Fixed.Scaled(0.000001m)); Throws(() => Fixed.Scaled(0.0000001m)); Equal(218L, Fixed.Round(435, 2)); Equal(115L, Fixed.Ceil(1150000, 10000)); Throws(() => Fixed.Ceil(1, 0)); });
            Add("battle.empty_lane_and_no_tick_zero_income", () => { var m = Empty(); m.Step(); Equal(100000000L, m.Supply(Side.Player)); Until(m, 20); Equal(106000000L, m.Supply(Side.Player)); Equal(900, m.BaseHp(Side.Player)); Equal(0L, m.Counters.AttemptedDamage); });
            Add("deploy.same_tick_cooldown_is_atomic", () => { var m = Empty(); m.Enqueue(new CombatCommand(0, 0, CommandKind.Deploy, "militia")); m.Enqueue(new CombatCommand(0, 1, CommandKind.Deploy, "militia")); m.Step(); Equal(1, m.Alive(Side.Player)); Equal(80000000L, m.Supply(Side.Player)); Equal("DEPLOY_COOLDOWN", m.CommandResults()[1].Reason); });
            Add("deploy.insufficient_and_unequipped_spend_nothing", () => { var m = Empty(loadout: new[] { "militia", "shieldguard", "brute", "ram" }); m.Enqueue(new CombatCommand(0, 0, CommandKind.Deploy, "brute")); m.Enqueue(new CombatCommand(0, 1, CommandKind.Deploy, "crossbowman")); m.Step(); Equal(100000000L, m.Supply(Side.Player)); Equal(0, m.Alive(Side.Player)); Equal("SUPPLY", m.CommandResults()[0].Reason); Equal("NOT_EQUIPPED", m.CommandResults()[1].Reason); });
            Add("deploy.cooldown_exact_six_ticks", () => { var m = Empty(); foreach (int t in new[] { 0, 5, 6 }) m.Enqueue(new CombatCommand(t, t, CommandKind.Deploy, "militia")); Until(m, 6); Equal(2L, m.Counters.PaidDeployments); Equal(61800000L, m.Supply(Side.Player)); });
            Add("deploy.cap_includes_living_bonus_and_releases_next_tick", () => { var m = Empty(); for (int i = 0; i < 24; i++) Put(m, Side.Player, "militia", 1); m.Enqueue(new CombatCommand(0, 0, CommandKind.Deploy, "militia")); m.Step(); Equal("POPULATION_CAP", m.CommandResults()[0].Reason); Equal(100000000L, m.Supply(Side.Player)); });
            Add("commands.reject_duplicate_sequence_and_past_tick", () => { var m = Empty(); m.Enqueue(new CombatCommand(0, 3, CommandKind.Rally)); Throws(() => m.Enqueue(new CombatCommand(0, 3, CommandKind.Rally))); m.Step(); Throws(() => m.Enqueue(new CombatCommand(0, 4, CommandKind.Rally))); });
            Add("formation.three_slots_reserve_turnover", () => { var m = Empty(); var allies = Enumerable.Range(0, 4).Select(_ => Put(m, Side.Player, "militia", 10)).ToArray(); Put(m, Side.Enemy, "brute", 11); m.Step(); Equal(3, allies.Count(x => x.Slot >= 0)); True(allies[3].Attack == null, "Reserve started attack"); allies[0].Hp = 0; m.Step(); long x = allies[3].X; m.Step(); True(allies[3].Slot >= 0, "Vacancy not filled"); True(Math.Abs(allies[3].X - x) <= 62500, "Slot assignment teleported"); });
            Add("formation.opposing_fast_units_proportional_clamp", () => { var m = Empty(); var a = Put(m, Side.Player, "militia", 10); var b = Put(m, Side.Enemy, "militia", 10.6m); a.Stats = a.Stats.Copy(); b.Stats = b.Stats.Copy(); a.Stats.Range = b.Stats.Range = 0; a.Stats.Speed = b.Stats.Speed = 2500000; m.Step(); Equal(10050000L, a.X); Equal(10550000L, b.X); Equal(500000L, b.X - a.X); });
            Add("formation.melee_passes_friendly_ranged", () => { var m = Empty(); var a = Put(m, Side.Player, "militia", 10); var b = Put(m, Side.Player, "crossbowman", 10.1m); Until(m, 20); True(a.X > b.X, "Friendly ranged blocked melee"); });
            Add("formation.ranged_only_targetable", () => { var m = Empty(); var a = Put(m, Side.Player, "militia", 10); var b = Put(m, Side.Enemy, "crossbowman", 11); Until(m, 4); True(b.Hp < b.Stats.Hp, "Ranged body was immune"); Equal(b.Id, a.Attack.Target); });
            Add("formation.body_blocks_ram_base_target", () => { var m = Empty(); var a = Put(m, Side.Player, "ram", 26.7m); var b = Put(m, Side.Enemy, "militia", 27.5m); Until(m, 11); Equal(b.Id, a.Attack.Target); Equal(650, m.BaseHp(Side.Enemy)); Equal(56, b.Hp); });
            Add("spawn_contact.canonical_fortress_reinforcement", () => {
                var m = new CombatModel(Data(), "c01_e01_b01", Starter, new string[0], 17);
                Actor enemy = null;
                while (m.Tick < 1000 && enemy == null)
                {
                    m.Step(); enemy = m.Actors.FirstOrDefault(a => a.Side == Side.Enemy && a.Attack != null && a.Attack.Target == -1);
                }
                True(enemy != null, "Canonical queue did not reach player fortress");
                m.Enqueue(new CombatCommand(m.Tick + 1, 0, CommandKind.Deploy, "militia")); m.Step();
                var own = m.Actors.Single(a => a.Side == Side.Player);
                Console.WriteLine("SPAWN_PRESSURE encounter=" + m.EncounterId + " tick=" + m.Tick + " command=" + m.CommandResults()[0].Reason + " player_x=" + own.X + " enemy_x=" + enemy.X + " required_gap=" + (own.Stats.HalfWidth + enemy.Stats.HalfWidth));
                True(m.InSpawnContact(own, enemy), "Missing AMEND-005 spawn contact");
                Equal("ACCEPTED", m.CommandResults()[0].Reason); Equal(800000L, own.X);
                Equal(enemy.Id, m.Target(own)); Equal(own.Id, m.Target(enemy));
                long ownX = own.X, enemyX = enemy.X; int hp = m.BaseHp(Side.Player);
                Until(m, enemy.Attack.ImpactTick); Equal(hp, m.BaseHp(Side.Player), "Committed base impact bypassed defender");
                Equal(ownX, own.X); Equal(enemyX, enemy.X);
            });
            Add("spawn_contact.reverse_centres_hold_and_resume_after_death", () => {
                var m = Empty(); var e = Put(m, Side.Enemy, "militia", 0.7m);
                var p = m.Spawn(Side.Player, Stat("militia"), null); m.Step();
                Equal(e.Id, m.Target(p)); Equal(p.Id, m.Target(e)); Equal(800000L, p.X); Equal(700000L, e.X);
                True(m.InSpawnContact(p, e), "Reverse-centre contact not registered");
                e.Hp = 0; m.Step(); p.Attack = null; long x = p.X; m.Step(); True(p.X > x, "Movement did not resume on next tick");
            });
            Add("spawn_contact.nearest_then_id_priority_before_forward", () => {
                var m = Empty(); var first = Put(m, Side.Enemy, "militia", 0.7m); var second = Put(m, Side.Enemy, "militia", 0.9m);
                var farther = Put(m, Side.Enemy, "militia", 1.1m); var p = m.Spawn(Side.Player, Stat("militia"), null);
                Equal(first.Id, m.Target(p)); m.Actors.Remove(first); Equal(second.Id, m.Target(p));
                m.Step(); Equal(800000L, p.X); Equal(900000L, second.X); Equal(1100000L, farther.X);
            });
            Add("spawn_contact.enemy_queue_symmetric", () => {
                var c = Data(); var m = new CombatModel(c, "c01_e01_b01", Starter, new string[0], 17);
                Until(m, 159); var p = Put(m, Side.Player, "militia", 27.3m); m.Step(); var e = m.Actors.Single(a => a.Side == Side.Enemy);
                Equal(27200000L, e.X); Equal(27300000L, p.X); Equal(p.Id, m.Target(e)); Equal(e.Id, m.Target(p));
                True(m.InSpawnContact(e, p), "Enemy fixed spawn did not register contact"); Equal(1, m.EnemyQueueIndex);
            });
            Add("spawn_contact.reserves_do_not_attack_or_gain_slots", () => {
                var m = Empty(); for (int i = 0; i < 3; i++) Put(m, Side.Player, "militia", 10);
                m.Step(); var e = Put(m, Side.Enemy, "militia", 0.7m); var p = m.Spawn(Side.Player, Stat("militia"), null);
                m.Step(); Equal(-1, p.Slot); True(p.Attack == null, "Contact granted a reserve attack"); Equal(800000L, p.X);
                Equal(p.Id, m.Target(e));
            });
            Add("spawn_contact.no_movement_created_exception_or_crossing", () => {
                var m = Empty(); var p = Put(m, Side.Player, "militia", 10); var e = Put(m, Side.Enemy, "militia", 10.6m);
                p.Stats = p.Stats.Copy(); e.Stats = e.Stats.Copy(); p.Stats.Range = e.Stats.Range = 0; p.Stats.Speed = e.Stats.Speed = 2500000;
                Until(m, 3); Equal(500000L, e.X - p.X); True(!m.InSpawnContact(p, e), "Movement created spawn exception");
            });
            Add("spawn_contact.conscription_cap_supply_accounting", () => {
                var m = Empty(new[] { "u01" }); for (int i = 0; i < 19; i++) Put(m, Side.Player, "militia", 10);
                for (int i = 0; i < 4; i++) m.Enqueue(new CombatCommand(i * 6, i, CommandKind.Deploy, "militia")); Until(m, 23);
                var e = Put(m, Side.Enemy, "brute", 0.8m); m.Enqueue(new CombatCommand(24, 4, CommandKind.Deploy, "militia")); m.Step();
                Equal(24, m.Alive(Side.Player)); True(m.BonusOwed, "Missing one owed bonus at cap"); Equal(7200000L, m.Supply(Side.Player));
                var paid = m.Actors.Last(a => a.Side == Side.Player); True(m.InSpawnContact(paid, e), "Paid spawn not in contact");
                m.Actors.Remove(m.Actors.First(a => a.Side == Side.Player)); m.Step();
                Equal(24, m.Alive(Side.Player)); Equal(1L, m.Counters.BonusSpawns); Equal(7500000L, m.Supply(Side.Player));
                True(m.InSpawnContact(m.Actors.Last(a => a.Side == Side.Player), e), "Owed bonus omitted contact");
                True(!m.BonusOwed, "Owed bonus repeated"); m.Enqueue(new CombatCommand(30, 5, CommandKind.Deploy, "militia")); Until(m, 30);
                Equal("POPULATION_CAP", m.CommandResults()[0].Reason); Equal(5L, m.Counters.PaidDeployments);
            });
            Add("spawn_contact.released_grenade_base_impact_is_blocked", () => {
                var m = Empty(); var shooter = Put(m, Side.Enemy, "grenadier", 4);
                Until(m, 10); True(m.Projectiles.Any(p => p.TargetBase == -1), "Expected released base throw");
                var p = m.Spawn(Side.Player, Stat("militia"), null); p.Attack = new Attack { EndTick = 100, ImpactTick = 99 };
                Until(m, 20); Equal(900, m.BaseHp(Side.Player));
            });
            Add("spawn_contact.reverse_crossbow_hits_after_release_not_immediately", () => {
                var m = Empty(); var e = Put(m, Side.Enemy, "militia", 0.7m); var p = m.Spawn(Side.Player, Stat("crossbowman"), null);
                Until(m, 7); Equal(70, e.Hp); Equal(-1, m.Projectiles.Single().Direction);
                m.Step(); Equal(20, e.Hp); Equal(800000L, p.X); Equal(700000L, e.X);
            });
            Add("melee.target_death_causes_miss_not_retarget", () => { var m = Empty(); var a = Put(m, Side.Player, "militia", 10); var b = Put(m, Side.Enemy, "militia", 11); var c = Put(m, Side.Enemy, "militia", 11.1m); m.Step(); Equal(b.Id, a.Attack.Target); m.Actors.Remove(b); Until(m, 4); Equal(70, c.Hp); });
            Add("melee.same_tick_mutual_kill", () => { var m = Empty(); var a = Put(m, Side.Player, "militia", 10); var b = Put(m, Side.Enemy, "militia", 11); a.Hp = b.Hp = 11; Until(m, 4); Equal(0, m.Actors.Count); Equal(2L, m.Counters.Deaths); Equal(22L, m.Counters.HpDamage); });
            Add("bolt.no_travel_on_release_tick", () => { var m = Empty(); var a = Put(m, Side.Player, "crossbowman", 10); Put(m, Side.Enemy, "shieldguard", 14); Until(m, 7); var p = m.Projectiles.Single(); Equal(a.X, p.X); m.Step(); Equal(a.X + 600000, p.X); });
            Add("bolt.shooter_death_does_not_remove_projectile", () => { var m = Empty(); var a = Put(m, Side.Player, "crossbowman", 10); var b = Put(m, Side.Enemy, "shieldguard", 14); Until(m, 7); m.Actors.Remove(a); Until(m, 14); Equal(193, b.Hp); });
            Add("bolt.target_death_and_swept_intersection", () => { var m = Empty(); Put(m, Side.Player, "crossbowman", 10); var b = Put(m, Side.Enemy, "militia", 14); Until(m, 7); long end = m.Projectiles.Single().End; m.Actors.Remove(b); var c = Put(m, Side.Enemy, "militia", 12.1m); Until(m, 12); Equal(20, c.Hp); True(end > c.X, "Replacement outside committed path"); });
            Add("bolt.does_not_chase_past_extent", () => { var m = Empty(); Put(m, Side.Player, "crossbowman", 10); var b = Put(m, Side.Enemy, "militia", 14); Until(m, 7); b.X = Fixed.Scaled(20); Until(m, 20); Equal(70, b.Hp); Equal(0, m.Projectiles.Count); });
            Add("grenade.commits_ground_position_and_no_friendly_fire", () => { var m = Empty(); Put(m, Side.Player, "grenadier", 10); var b = Put(m, Side.Enemy, "militia", 14); Until(m, 10); var p = m.Projectiles.Single(); var friendly = Put(m, Side.Player, "militia", (decimal)p.End / Fixed.Scale); b.X = Fixed.Scaled(20); Until(m, p.ArrivalTick); Equal(70, b.Hp); Equal(70, friendly.Hp); });
            Add("grenade.radius_edge_and_no_base_splash_bypass", () => { var m = Empty(); var p = new Projectile { Id = 1, Source = 99, Side = Side.Player, BornTick = -1, ArrivalTick = 0, Lob = true, End = Fixed.Scaled(27.5m), Splash = Fixed.Scale, Damage = 36 }; m.Projectiles.Add(p); var a = Put(m, Side.Enemy, "militia", 26.5m); var b = Put(m, Side.Enemy, "militia", 26.499999m); a.Attack = b.Attack = new Attack { EndTick = 10, ImpactTick = 9 }; m.Step(); Equal(34, a.Hp); Equal(70, b.Hp); Equal(650, m.BaseHp(Side.Enemy)); });
            Add("barrier.first_hit_same_tick_budget_and_expiry", () => { var m = Empty(); var a = Put(m, Side.Player, "shieldguard", 1, new[] { "u04" }); Until(m, 200); True(!a.BarrierUsed, "Untriggered barrier expired"); m.Damage.Clear(); m.AddDamage(1, a.Id, 50); m.AddDamage(2, a.Id, 50); m.ResolveDamage(); Equal(218, a.Hp); Equal(0, a.Barrier); Equal(360, a.BarrierExpiry); Hit(m, a, 10); Equal(211, a.Hp); Until(m, 360); Hit(m, a, 10); Equal(204, a.Hp); });
            Add("barrier.exact_expiry_with_remaining_budget", () => { var m = Empty(); var a = Put(m, Side.Player, "shieldguard", 1, new[] { "u04" }); m.Step(); Hit(m, a, 4); Equal(71, a.Barrier); Until(m, 159); Equal(71, a.Barrier); m.Step(); Equal(0, a.Barrier); Hit(m, a, 4); Equal(239, a.Hp); });
            Add("damage.minimum_one_and_overkill_diagnostics", () => { var m = Empty(); var a = Put(m, Side.Player, "shieldguard", 1); m.Step(); Hit(m, a, 1); Equal(239, a.Hp); Hit(m, a, 1000); Equal(0, a.Hp); Equal(240L, m.Counters.HpDamage); Equal(1001L, m.Counters.AttemptedDamage); });
            Add("rally.initial_boundary_duplicate_and_expiry", () => { var m = Empty(); m.Enqueue(new CombatCommand(239, 0, CommandKind.Rally)); m.Enqueue(new CombatCommand(240, 1, CommandKind.Rally)); m.Enqueue(new CombatCommand(240, 2, CommandKind.Rally)); Until(m, 239); Equal("RALLY_COOLDOWN", m.CommandResults()[0].Reason); m.Step(); True(m.RallyActive, "No Rally at tick 240"); Equal("RALLY_COOLDOWN", m.CommandResults()[1].Reason); Equal(840, m.RallyReadyTick); Until(m, 339); True(m.RallyActive, "Expired early"); m.Step(); True(!m.RallyActive, "Expired late"); });
            Add("rally.snapshots_existing_attack", () => { var m = Empty(new[] { "u09" }); Until(m, 238); var a = Put(m, Side.Player, "crossbowman", 10, new[] { "u09" }); Put(m, Side.Enemy, "brute", 14); m.Step(); Equal(269, a.Attack.EndTick); m.Enqueue(new CombatCommand(240, 0, CommandKind.Rally)); m.Step(); Equal(269, a.Attack.EndTick); Until(m, 269); Equal(293, a.Attack.EndTick); Equal(274, a.Attack.ImpactTick); });
            Add("pause.overlapping_reasons_and_no_catchup", () => { var m = Empty(); var clock = new TickScheduler(m); m.SetPause("PLAYER", true); m.SetPause("BACKGROUND", true); m.SetPause("BACKGROUND", false); Equal(0, clock.Advance(200, 10)); Equal(-1, m.Tick); Throws(() => m.Enqueue(new CombatCommand(0, 0, CommandKind.Rally))); m.SetPause("PLAYER", false); Equal(1, clock.Advance(0.05m, 1)); Equal(0, m.Tick); Equal(100000000L, m.Supply(Side.Player)); });
            Add("end.overtime_exact_tick_3000", () => { var m = Empty(); Until(m, 2999); m.Damage.Clear(); m.AddDamage(1, -2, 10); m.ResolveDamage(); Equal(640, m.BaseHp(Side.Enemy)); m.Step(); m.Damage.Clear(); m.AddDamage(1, -2, 10); m.ResolveDamage(); Equal(620, m.BaseHp(Side.Enemy)); });
            Add("end.queue_cutoff_at_3600", () => { var c = Data(); var e = c.Encounters["c01_e01_b01"]; e.enemy_first_deployment_earliest_s = 180; var m = new CombatModel(c, e.id, Starter, new string[0], 1); Until(m, 3601); Equal(0, m.EnemyQueueIndex); });
            Add("end.hard_finish_fractions_and_draw", () => { var m = Empty(); Until(m, 4200); Equal(Outcome.Draw, m.Result); Equal(4200, m.Tick); True(!m.Step(), "Terminal model advanced"); });
            Add("end.due_impact_before_hard_finish", () => { var m = Empty(); Until(m, 4199); m.Projectiles.Add(new Projectile { Id = 1, Source = 99, Side = Side.Player, BornTick = 4199, ArrivalTick = 4200, TargetBase = -2, BaseDamage = 10, Lob = true }); m.Step(); Equal(630, m.BaseHp(Side.Enemy)); Equal(Outcome.PlayerWin, m.Result); });
            Add("end.simultaneous_base_destruction_draw", () => { var m = Empty(); m.Projectiles.Add(new Projectile { Id = 1, Source = 1, Side = Side.Player, BornTick = -1, ArrivalTick = 0, TargetBase = -2, BaseDamage = 1000, Lob = true }); m.Projectiles.Add(new Projectile { Id = 2, Source = 2, Side = Side.Enemy, BornTick = -1, ArrivalTick = 0, TargetBase = -1, BaseDamage = 1000, Lob = true }); m.Step(); Equal(Outcome.Draw, m.Result); });
            Add("replay.30_60fps_1_2_4_10x_identical", Replay);
            Add("upgrade.u01_conscription_nonrecursive_and_owed_cap", () => {
                var m = Empty(new[] { "u01" }); for (int i = 0; i < 19; i++) Put(m, Side.Player, "militia", 1);
                for (int i = 0; i < 5; i++) m.Enqueue(new CombatCommand(i * 6, i, CommandKind.Deploy, "militia"));
                Until(m, 24); Equal(24, m.Alive(Side.Player)); True(m.BonusOwed, "Missing owed bonus"); Equal(0L, m.Counters.BonusSpawns);
                m.Actors.RemoveAt(0); m.Step(); Equal(24, m.Alive(Side.Player)); Equal(1L, m.Counters.BonusSpawns); True(!m.BonusOwed, "Bonus not consumed"); Equal(5L, m.Counters.PaidDeployments);
            });
            Add("upgrade.u02_scrap_blades", () => { var s = Stat("militia", "u02"); Equal(14, s.Damage); Equal(14, s.BaseDamage); Equal(11, Stat("militia", "u08").Damage); });
            Add("upgrade.u03_thick_coats", () => Equal(88, Stat("militia", "u03").Hp));
            Add("upgrade.u04_first_into_battle_modified_hp", () => { var s = Stat("shieldguard", "u04", "u06", "u22"); Equal(336, s.Hp); Equal(101, s.Barrier); });
            Add("upgrade.u05_reinforced_shields", () => { var m = Empty(); var a = Put(m, Side.Player, "shieldguard", 1, new[] { "u05" }); m.Step(); Hit(m, a, 10); Equal(235, a.Hp); });
            Add("upgrade.u06_heavy_boots", () => { var s = Stat("shieldguard", "u06"); Equal(312, s.Hp); Equal(810000L, s.Speed); });
            Add("upgrade.u07_piercing_bolts_one_secondary_independent_armor", () => { var m = Empty(); Put(m, Side.Player, "crossbowman", 10, new[] { "u07" }); var a = Put(m, Side.Enemy, "shieldguard", 12); var b = Put(m, Side.Enemy, "shieldguard", 12.5m); var c = Put(m, Side.Enemy, "shieldguard", 12.9m); foreach (var x in new[] { a, b, c }) x.Attack = new Attack { EndTick = 100, ImpactTick = 99 }; Until(m, 11); Equal(193, a.Hp); Equal(213, b.Hp); Equal(240, c.Hp); });
            Add("upgrade.u08_tighter_windlass", () => { var s = Stat("crossbowman", "u08"); Equal(63, s.Damage); Equal(31, s.BaseDamage); });
            Add("upgrade.u09_quick_reload", () => { var m = Empty(); var a = Put(m, Side.Player, "crossbowman", 10, new[] { "u09" }); Put(m, Side.Enemy, "brute", 14); m.Step(); Equal(30, a.Attack.EndTick); Equal(6, a.Attack.ImpactTick); });
            Add("upgrade.u10_packed_powder", () => Equal(1500000L, Stat("grenadier", "u10").Splash));
            Add("upgrade.u11_heavy_charges", () => { var s = Stat("grenadier", "u11"); Equal(45, s.Damage); Equal(23, s.BaseDamage); });
            Add("upgrade.u12_fast_fuses", () => { var m = Empty(); var a = Put(m, Side.Player, "grenadier", 10, new[] { "u12" }); Put(m, Side.Enemy, "brute", 14); m.Step(); Equal(40, a.Attack.EndTick); Equal(9, a.Attack.ImpactTick); Equal(8000000L, a.Stats.ProjectileSpeed); });
            Add("upgrade.u13_sweeping_club_two_secondaries", () => { var m = Empty(); Put(m, Side.Player, "brute", 10, new[] { "u13" }); var a = Put(m, Side.Enemy, "shieldguard", 11); var b = Put(m, Side.Enemy, "shieldguard", 11.3m); var c = Put(m, Side.Enemy, "shieldguard", 11.5m); var d = Put(m, Side.Enemy, "shieldguard", 11.7m); foreach (var x in new[] { a, b, c, d }) x.Attack = new Attack { EndTick = 100, ImpactTick = 99 }; Until(m, 9); Equal(178, a.Hp); Equal(217, b.Hp); Equal(217, c.Hp); Equal(240, d.Hp); });
            Add("upgrade.u14_iron_belly", () => Equal(600, Stat("brute", "u14").Hp));
            Add("upgrade.u15_brutal_force", () => Equal(81, Stat("brute", "u15").Damage));
            Add("upgrade.u16_splintering_head_third_direct_hit", () => { var m = Empty(); var a = Put(m, Side.Player, "ram", 27, new[] { "u16" }); Until(m, 90); Equal(350, m.BaseHp(Side.Enemy)); m.Step(); Equal(50, m.BaseHp(Side.Enemy)); Equal(3, a.BaseHits); var b = Put(m, Side.Player, "ram", 26, new[] { "u16" }); Equal(0, b.BaseHits); });
            Add("upgrade.u17_siege_engineering_additive_cost", () => { var s = Stat("ram", "u17", "u22"); Equal(218, s.BaseDamage); Equal(115, s.Cost); Equal(15, s.Damage); });
            Add("upgrade.u18_reinforced_frame", () => Equal(525, Stat("ram", "u18").Hp));
            Add("upgrade.u19_war_economy", () => { var m = Empty(new[] { "u19" }); Until(m, 20); Equal(106900000L, m.Supply(Side.Player)); });
            Add("upgrade.u20_deep_stores", () => { var m = Empty(new[] { "u20" }); m.Step(); Equal(125000000L, m.Supply(Side.Player)); Until(m, 500); Equal(250000000L, m.Supply(Side.Player)); });
            Add("upgrade.u21_war_drums", () => { var m = Empty(new[] { "u21" }); m.Enqueue(new CombatCommand(240, 0, CommandKind.Rally)); Until(m, 379); True(m.RallyActive, "War Drums ended early"); m.Step(); True(!m.RallyActive, "War Drums ended late"); });
            Add("upgrade.u22_field_training", () => { var s = Stat("militia", "u02", "u03", "u22"); Equal(95, s.Hp); Equal(15, s.Damage); });
            Add("upgrade.u23_rapid_orders_preserves_initial_delay", () => { var m = Empty(new[] { "u23" }); Equal(240, m.RallyReadyTick); m.Enqueue(new CombatCommand(240, 0, CommandKind.Rally)); Until(m, 240); Equal(740, m.RallyReadyTick); });
            Add("upgrade.u24_forced_march_additive_with_boots", () => Equal(945000L, Stat("shieldguard", "u06", "u24").Speed));
            Add("boss.bulwark_resolved_stats_barrier", () => { var m = Empty(); var a = Put(m, Side.Enemy, "shieldguard", 20, boss: "boss_bulwark"); Equal(480, a.Hp); Equal(12, a.Stats.Damage); m.Step(); Hit(m, a, 50); Equal(97, a.Barrier); Equal(480, a.Hp); });
            Add("boss.powder_captain_resolved_stats", () => { var m = Empty(); var a = Put(m, Side.Enemy, "grenadier", 20, boss: "boss_powder"); Equal(158, a.Hp); Equal(41, a.Stats.Damage); Equal(21, a.Stats.BaseDamage); Equal(1500000L, a.Stats.Splash); });
            Add("interaction.militia_hp_damage_and_field_training", () => { var m = Empty(); var a = Put(m, Side.Player, "militia", 10, new[] { "u02", "u03", "u22" }); var b = Put(m, Side.Enemy, "shieldguard", 11); b.Attack = new Attack { EndTick = 100, ImpactTick = 99 }; Until(m, 4); Equal(95, a.Hp); Equal(228, b.Hp); });
            Add("interaction.boots_march_and_barrier_from_modified_hp", () => { var m = Empty(); var a = Put(m, Side.Player, "shieldguard", 10, new[] { "u04", "u06", "u22", "u24" }); m.Step(); Equal(10047250L, a.X); Equal(336, a.Hp); Hit(m, a, 50); Equal(336, a.Hp); Equal(54, a.Barrier); });
            Add("interaction.windlass_reload_delivers_modified_bolt", () => { var m = Empty(); var a = Put(m, Side.Player, "crossbowman", 10, new[] { "u08", "u09" }); var b = Put(m, Side.Enemy, "shieldguard", 12); b.Attack = new Attack { EndTick = 100, ImpactTick = 99 }; Until(m, 9); Equal(180, b.Hp); Equal(30, a.Attack.EndTick); });
            Add("interaction.powder_charges_fuses_splash_edge", () => { var m = Empty(); Put(m, Side.Player, "grenadier", 10, new[] { "u10", "u11", "u12" }); var a = Put(m, Side.Enemy, "militia", 14); var b = Put(m, Side.Enemy, "militia", 15.5m); var outside = Put(m, Side.Enemy, "militia", 15.500001m); foreach (var x in new[] { a, b, outside }) x.Attack = new Attack { EndTick = 100, ImpactTick = 99 }; Until(m, 19); Equal(25, a.Hp); Equal(25, b.Hp); Equal(70, outside.Hp); });
            Add("interaction.brute_belly_force_and_sweep", () => { var m = Empty(); var a = Put(m, Side.Player, "brute", 10, new[] { "u13", "u14", "u15" }); var b = Put(m, Side.Enemy, "shieldguard", 11); var c = Put(m, Side.Enemy, "shieldguard", 11.5m); foreach (var x in new[] { b, c }) x.Attack = new Attack { EndTick = 100, ImpactTick = 99 }; Until(m, 9); Equal(600, a.Hp); Equal(162, b.Hp); Equal(211, c.Hp); });
            Add("interaction.ram_engineering_frame_training_paid_and_base", () => { var m = Empty(new[] { "u17", "u18", "u20", "u22" }, new[] { "militia", "shieldguard", "brute", "ram" }); m.Enqueue(new CombatCommand(0, 0, CommandKind.Deploy, "ram")); m.Step(); var a = m.Actors.Single(); Equal(10000000L, m.Supply(Side.Player)); Equal(567, a.Hp); a.X = Fixed.Scaled(27); Until(m, 12); Equal(432, m.BaseHp(Side.Enemy)); });
            Add("formation.unequal_speed_mirror_stable", () => { foreach (bool mirror in new[] { false, true }) { var m = Empty(); var a = Put(m, Side.Player, "militia", 10); var b = Put(m, Side.Enemy, "militia", 10.6m); a.Stats = a.Stats.Copy(); b.Stats = b.Stats.Copy(); a.Stats.Range = b.Stats.Range = 0; a.Stats.Speed = mirror ? 1000000 : 2000000; b.Stats.Speed = mirror ? 2000000 : 1000000; m.Step(); long fastMove = mirror ? 10600000L - b.X : a.X - 10000000L; True(Math.Abs(fastMove - 66667) <= 1, "Proportional mirrored travel"); Equal(500000L, b.X - a.X); } });
        }
        static void Replay()
        {
            string expected = null;
            foreach (int fps in new[] { 30, 60 }) foreach (int speed in new[] { 1, 2, 4, 10 })
            {
                var m = new CombatModel(Data(), "c01_e01_b01", Starter, new[] { "u01", "u04", "u07", "u19" }, 17);
                long sequence = 0;
                for (int t = 0; t < 3600; t += 25) m.Enqueue(new CombatCommand(t, sequence++, CommandKind.Deploy, Starter[(t / 25) % 4]));
                for (int t = 240; t < 4000; t += 600) m.Enqueue(new CombatCommand(t, sequence++, CommandKind.Rally));
                var clock = new TickScheduler(m); int frames = 0;
                while (m.Result == Outcome.Active && frames++ < 20000) clock.Advance(1m / fps, speed);
                True(m.Result != Outcome.Active, "Replay did not finish"); string hash = m.StateHash();
                if (expected == null) expected = hash; else Equal(expected, hash, fps + "fps " + speed + "x");
                Console.WriteLine("REPLAY fps=" + fps + " speed=" + speed + " tick=" + m.Tick + " outcome=" + m.Result + " sha256=" + hash);
            }
        }
    }
}
