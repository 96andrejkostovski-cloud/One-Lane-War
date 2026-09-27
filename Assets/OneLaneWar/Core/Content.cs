using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OneLaneWar
{
    // Decimal is used only at import. All authoritative battle values are integers.
    public static class Fixed
    {
        public const long Scale = 1000000, Bp = 10000;
        public static long Scaled(decimal value, long scale = Scale)
        {
            decimal result = value * scale;
            if (result != decimal.Truncate(result)) throw new FormatException("Unrepresentable fixed value");
            return checked((long)result);
        }
        public static long Ceil(long a, long b) { if (a < 0 || b <= 0) throw new ArgumentException(); return checked((a + b - 1) / b); }
        public static long Round(long a, long b) { if (a < 0 || b <= 0) throw new ArgumentException(); return checked((2 * a + b) / (2 * b)); }
        public static string Hash(byte[] bytes) { using (var sha = SHA256.Create()) return BitConverter.ToString(sha.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant(); }
    }

    public sealed class UnitDefinition
    {
        public string id, name, combat_role;
        public int supply_cost, hp, damage, base_damage, attack_period_ticks, windup_ticks, flat_damage_reduction;
        public decimal range_m, move_speed_m_s, splash_radius_m, projectile_speed_m_s, collision_half_width_m;
    }
    public sealed class UpgradeExtra
    {
        public decimal movement_add_pct, supply_cost_add_pct, duration_s, secondary_damage_factor,
            max_extra_distance_m, radius_m, bonus_damage_factor, starting_supply_add;
    }
    public sealed class UpgradeDefinition
    {
        public string id, name, requires_equipped_unit, kind;
        [JsonProperty("operator")] public string Operator;
        public decimal value;
        public UpgradeExtra additional_rules;
    }
    public sealed class BossResolved
    {
        public int hp, damage, base_damage, supply_cost, attack_period_ticks, windup_ticks, barrier_hp;
        public decimal move_speed_m_s, splash_radius_m;
    }
    public sealed class BossDefinition { public string id, base_unit; public BossResolved resolved_b001; }
    public sealed class EncounterDefinition
    {
        public string id, expedition_id, boss_variant, pattern_id;
        public int player_base_hp, enemy_base_hp, enemy_total_supply_budget, battle_index;
        public decimal enemy_supply_start, enemy_supply_rate_per_s, enemy_supply_cap,
            enemy_first_deployment_earliest_s, enemy_min_deployment_gap_s, enemy_orders_expire_at_s, boss_reveal_lead_s;
        public int? boss_queue_index_zero_based;
        public string[] enemy_spawn_queue;
    }
    public sealed class SupplyRules { public decimal start, rate_per_s, cap, deployment_cooldown_s; }
    public sealed class RallyRules { public decimal attack_rate_bonus, duration_s, cooldown_s, initial_cooldown_s; }
    public sealed class BattleRules { public decimal soft_time_limit_s, hard_time_limit_s, enemy_orders_expire_at_s; }
    public sealed class FormationRules { public decimal friendly_group_spacing_m, ranged_queue_spacing_m, range_tolerance_m; }
    public sealed class GameRules
    {
        public int simulation_hz, max_alive_units_per_side, max_melee_engagement_slots_per_side;
        public decimal lane_length_m;
        public decimal[] spawn_positions_m, base_fronts_m;
        public SupplyRules supply; public RallyRules rally; public BattleRules battle;
        public FormationRules formation_contract;
    }

    public sealed class Content
    {
        public const string ManifestHash = "6c5ab38839a42dfe9a8c0085860d13bf05899441b2a389f3b6d243b552a16d90";
        public static readonly string[] RegistryNames = { "game_rules", "units", "upgrades", "encounters", "boss_variants" };
        internal GameRules Rules;
        internal SortedDictionary<string, UnitDefinition> Units;
        internal SortedDictionary<string, UpgradeDefinition> Upgrades;
        internal SortedDictionary<string, EncounterDefinition> Encounters;
        internal SortedDictionary<string, BossDefinition> Bosses;
        public string SourceHash { get; private set; }
        public string[] UnitIds { get { return Units.Keys.ToArray(); } }
        public string[] UpgradeIds { get { return Upgrades.Keys.ToArray(); } }
        public string[] EncounterIds { get { return Encounters.Keys.ToArray(); } }
        public string UpgradeName(string id) { return Upgrades[id].name; }
        public string UnitName(string id) { return Units[id].name; }
        public string[] UpgradesForUnits(string[] units) { return Upgrades.Values.Where(u => u.requires_equipped_unit == null || units.Contains(u.requires_equipped_unit)).Select(u => u.id).ToArray(); }
        public string[] Eligible(string[] loadout) { ValidateLoadout(loadout); return Upgrades.Values.Where(u => u.requires_equipped_unit == null || loadout.Contains(u.requires_equipped_unit)).Select(u => u.id).ToArray(); }
        internal void ValidateLoadout(string[] ids)
        {
            if (ids == null || ids.Length != 4 || ids.Distinct().Count() != 4 || ids.Any(id => !Units.ContainsKey(id)))
                throw new ArgumentException("CONTENT_LOADOUT: four distinct known units required");
        }
        public static Content Load(Func<string, byte[]> read)
        {
            var manifestBytes = read("SOURCE_MANIFEST.json");
            if (Fixed.Hash(manifestBytes) != ManifestHash) throw new FormatException("CONTENT_MANIFEST_HASH");
            var manifest = JObject.Parse(Encoding.UTF8.GetString(manifestBytes));
            var json = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var name in RegistryNames)
            {
                var path = "data/" + name + ".json";
                var record = manifest["files"].Single(r => (string)r["path"] == path);
                var bytes = read(path);
                if (bytes.Length != (int)record["bytes"] || Fixed.Hash(bytes) != (string)record["sha256"])
                    throw new FormatException("CONTENT_HASH: " + path);
                json[name] = Encoding.UTF8.GetString(bytes);
            }
            var settings = new JsonSerializerSettings { FloatParseHandling = FloatParseHandling.Decimal };
            var content = new Content {
                SourceHash = ManifestHash,
                Rules = JsonConvert.DeserializeObject<GameRules>(json["game_rules"], settings),
                Units = Index(JsonConvert.DeserializeObject<UnitDefinition[]>(json["units"], settings), x => x.id),
                Upgrades = Index(JsonConvert.DeserializeObject<UpgradeDefinition[]>(json["upgrades"], settings), x => x.id),
                Encounters = Index(JsonConvert.DeserializeObject<EncounterDefinition[]>(json["encounters"], settings), x => x.id),
                Bosses = Index(JsonConvert.DeserializeObject<BossDefinition[]>(json["boss_variants"], settings), x => x.id)
            };
            content.Validate(); return content;
        }
        static SortedDictionary<string, T> Index<T>(IEnumerable<T> records, Func<T, string> id)
        {
            var result = new SortedDictionary<string, T>(StringComparer.Ordinal);
            foreach (var record in records) { var key = id(record); if (string.IsNullOrEmpty(key) || result.ContainsKey(key)) throw new FormatException("CONTENT_DUPLICATE_ID"); result.Add(key, record); }
            return result;
        }
        internal void Validate()
        {
            if (Units.Count != 6 || Upgrades.Count != 24 || Encounters.Count != 36 || Bosses.Count != 2 || Rules.simulation_hz != 20) throw new FormatException("CONTENT_COUNTS");
            foreach (var u in Units.Values)
                if (u.hp <= 0 || u.supply_cost <= 0 || u.attack_period_ticks <= u.windup_ticks || u.windup_ticks <= 0 || (u.combat_role != "melee" && u.combat_role != "ranged")) throw new FormatException("CONTENT_UNIT: " + u.id);
            foreach (var u in Upgrades.Values)
                if (u.requires_equipped_unit != null && !Units.ContainsKey(u.requires_equipped_unit)) throw new FormatException("CONTENT_UPGRADE_REFERENCE");
            foreach (var e in Encounters.Values)
            {
                if (e.enemy_spawn_queue.Any(u => !Units.ContainsKey(u)) || e.enemy_spawn_queue.Sum(u => Units[u].supply_cost) != e.enemy_total_supply_budget) throw new FormatException("CONTENT_QUEUE: " + e.id);
                if (e.boss_variant != null && (!Bosses.ContainsKey(e.boss_variant) || !e.boss_queue_index_zero_based.HasValue || e.boss_queue_index_zero_based < 0 || e.boss_queue_index_zero_based >= e.enemy_spawn_queue.Length || e.enemy_spawn_queue[e.boss_queue_index_zero_based.Value] != Bosses[e.boss_variant].base_unit || e.battle_index != 4)) throw new FormatException("CONTENT_BOSS: " + e.id);
            }
        }
    }

    internal sealed class Stats
    {
        internal string Unit; internal bool Melee;
        internal int Hp, Damage, BaseDamage, Cost, Period, Windup, Reduction, RateBp;
        internal long Speed, Range, HalfWidth, Splash, ProjectileSpeed;
        internal int Barrier, BarrierTicks, Conscription, Pierce, Sweep, RamEvery;
        internal long PierceRange, SweepRange; internal int PierceFactor, SweepFactor, RamFactor;

        internal Stats Copy() { return (Stats)MemberwiseClone(); }
        internal static Stats Build(Content content, string id, IEnumerable<UpgradeDefinition> upgrades, string boss = null)
        {
            var u = content.Units[id]; long hp = 0, damage = 0, baseBonus = 0, rate = 0, move = 0, cost = 0, splash = 0, barrierBp = 0;
            var s = new Stats { Unit = id, Melee = u.combat_role == "melee", Reduction = u.flat_damage_reduction, Range = Fixed.Scaled(u.range_m), HalfWidth = Fixed.Scaled(u.collision_half_width_m), ProjectileSpeed = Fixed.Scaled(u.projectile_speed_m_s) };
            foreach (var upgrade in upgrades.Where(x => x.requires_equipped_unit == null || x.requires_equipped_unit == id))
            {
                var v = upgrade.value; var x = upgrade.additional_rules;
                switch (upgrade.Operator)
                {
                    case "hp_add_pct": hp += Fixed.Scaled(v, Fixed.Bp); break;
                    case "damage_add_pct": damage += Fixed.Scaled(v, Fixed.Bp); break;
                    case "hp_and_damage_add_pct": hp += Fixed.Scaled(v, Fixed.Bp); damage += Fixed.Scaled(v, Fixed.Bp); break;
                    case "base_damage_add_pct": baseBonus += Fixed.Scaled(v, Fixed.Bp); break;
                    case "attack_rate_add_pct": rate += Fixed.Scaled(v, Fixed.Bp); break;
                    case "move_speed_add_pct": move += Fixed.Scaled(v, Fixed.Bp); break;
                    case "flat_reduction_add": s.Reduction += (int)v; break;
                    case "splash_radius_add_pct": splash += Fixed.Scaled(v, Fixed.Bp); break;
                    case "first_damage_barrier_maxhp_pct": barrierBp = Fixed.Scaled(v, Fixed.Bp); s.BarrierTicks = (int)Fixed.Scaled(x.duration_s, content.Rules.simulation_hz); break;
                    case "paid_militia_every": s.Conscription = (int)v; break;
                    case "additional_pierce_targets": s.Pierce = (int)v; s.PierceFactor = (int)Fixed.Scaled(x.secondary_damage_factor, Fixed.Bp); s.PierceRange = Fixed.Scaled(x.max_extra_distance_m); break;
                    case "extra_melee_targets": s.Sweep = (int)v; s.SweepFactor = (int)Fixed.Scaled(x.secondary_damage_factor, Fixed.Bp); s.SweepRange = Fixed.Scaled(x.radius_m); break;
                    case "base_hits_per_bonus": s.RamEvery = (int)v; s.RamFactor = (int)Fixed.Scaled(x.bonus_damage_factor, Fixed.Bp); break;
                    case "supply_rate_add_pct": case "supply_cap_add": case "rally_duration_add_s": case "rally_cooldown_add_s": break;
                    default: throw new FormatException("CONTENT_OPERATOR: " + upgrade.Operator);
                }
                move += Fixed.Scaled(x.movement_add_pct, Fixed.Bp); cost += Fixed.Scaled(x.supply_cost_add_pct, Fixed.Bp);
            }
            s.Hp = (int)Fixed.Round(checked(u.hp * (Fixed.Bp + hp)), Fixed.Bp);
            s.Damage = (int)Fixed.Round(checked(u.damage * (Fixed.Bp + damage)), Fixed.Bp);
            s.BaseDamage = (int)Fixed.Round(checked(u.base_damage * (Fixed.Bp + damage + baseBonus)), Fixed.Bp);
            s.Cost = (int)Math.Max(1, Fixed.Ceil(checked(u.supply_cost * (Fixed.Bp + cost)), Fixed.Bp));
            s.Speed = Math.Max(250000, Math.Min(2500000, Fixed.Round(checked(Fixed.Scaled(u.move_speed_m_s) * (Fixed.Bp + move)), Fixed.Bp)));
            s.Splash = Fixed.Round(checked(Fixed.Scaled(u.splash_radius_m) * (Fixed.Bp + splash)), Fixed.Bp);
            s.Period = u.attack_period_ticks; s.Windup = u.windup_ticks; s.RateBp = (int)rate;
            s.Barrier = (int)Fixed.Round(checked(s.Hp * barrierBp), Fixed.Bp);
            if (boss != null)
            {
                var b = content.Bosses[boss]; if (b.base_unit != id) throw new ArgumentException("CONTENT_BOSS_UNIT"); var r = b.resolved_b001;
                s.Hp = r.hp; s.Damage = r.damage; s.BaseDamage = r.base_damage; s.Cost = r.supply_cost;
                s.Period = r.attack_period_ticks; s.Windup = r.windup_ticks; s.Speed = Fixed.Scaled(r.move_speed_m_s);
                s.Barrier = r.barrier_hp; if (s.Barrier > 0) s.BarrierTicks = 160;
                if (r.splash_radius_m > 0) s.Splash = Fixed.Scaled(r.splash_radius_m);
            }
            return s;
        }
    }
}
