#!/usr/bin/env python3
"""Independent B001 arithmetic and draft oracle. NOT a combat simulator.
Python 3.10+, standard library. Read-only unless a caller explicitly saves output.
"""
from __future__ import annotations
from decimal import Decimal
from pathlib import Path
from typing import Any, Iterable
import hashlib
import json

ROOT = Path(__file__).resolve().parents[1]
SCALE = 1_000_000
BP = 10_000
HZ = 20

def load(name: str) -> Any:
    return json.loads((ROOT / 'data' / f'{name}.json').read_text(encoding='utf-8'))

def scaled(value: Any, scale: int = SCALE) -> int:
    n = Decimal(str(value)) * scale
    if n != n.to_integral_value():
        raise ValueError(f'{value!r} cannot be represented at scale {scale}')
    return int(n)

def ceildiv(a: int, b: int) -> int:
    if a < 0 or b <= 0:
        raise ValueError('ceildiv expects a nonnegative numerator and positive divisor')
    return (a + b - 1) // b

def half_up_ratio(a: int, b: int) -> int:
    if a < 0 or b <= 0:
        raise ValueError('half_up_ratio expects nonnegative/positive integers')
    return (2 * a + b) // (2 * b)

def modified_unit(unit: dict[str, Any], upgrades: Iterable[dict[str, Any]], rally: bool=False) -> dict[str, int]:
    hp = damage = base = rate = move = cost = 0
    reduction = unit['flat_damage_reduction']
    for upgrade in upgrades:
        if upgrade['requires_equipped_unit'] not in (None, unit['id']):
            continue
        op, value = upgrade['operator'], upgrade['value']
        extra = upgrade['additional_rules']
        if op == 'hp_add_pct': hp += scaled(value, BP)
        elif op == 'damage_add_pct': damage += scaled(value, BP)
        elif op == 'hp_and_damage_add_pct': hp += scaled(value, BP); damage += scaled(value, BP)
        elif op == 'base_damage_add_pct': base += scaled(value, BP)
        elif op == 'attack_rate_add_pct': rate += scaled(value, BP)
        elif op == 'move_speed_add_pct': move += scaled(value, BP)
        elif op == 'flat_reduction_add': reduction += int(value)
        move += scaled(extra.get('movement_add_pct', 0), BP)
        cost += scaled(extra.get('supply_cost_add_pct', 0), BP)
    rate += 3000 if rally else 0
    period = max(7, ceildiv(unit['attack_period_ticks'] * BP, BP + rate))
    windup = min(period - 1, max(1, ceildiv(unit['windup_ticks'] * BP, BP + rate)))
    return {
        'hp': half_up_ratio(unit['hp'] * (BP + hp), BP),
        'damage': half_up_ratio(unit['damage'] * (BP + damage), BP),
        'base_damage': half_up_ratio(unit['base_damage'] * (BP + damage + base), BP),
        'cost': ceildiv(unit['supply_cost'] * (BP + cost), BP),
        'period_ticks': period, 'windup_ticks': windup,
        'move_micro_m_s': min(2_500_000, max(250_000, half_up_ratio(scaled(unit['move_speed_m_s']) * (BP + move), BP))),
        'flat_reduction': reduction,
    }

def damage_after_reduction(damage: int, reduction: int, barrier: int=0) -> tuple[int, int]:
    if damage <= 0 or reduction < 0 or barrier < 0:
        raise ValueError('A valid positive impact and nonnegative defenses are required')
    mitigated = max(1, damage - reduction)
    absorbed = min(barrier, mitigated)
    return mitigated - absorbed, barrier - absorbed

class XorShift32:
    """Unsigned xorshift32; unbiased bounded draw; zero seed prohibited."""
    def __init__(self, seed: int):
        if not 1 <= seed <= 0xFFFFFFFF: raise ValueError('seed must be uint32 nonzero')
        self.state = seed
    def next(self) -> int:
        x = self.state
        x ^= (x << 13) & 0xFFFFFFFF
        x ^= x >> 17
        x ^= (x << 5) & 0xFFFFFFFF
        self.state = x & 0xFFFFFFFF
        return self.state
    def bounded(self, bound: int) -> int:
        # XorShift32 produces 1..2^32-1, not zero. Subtract one for an
        # exactly uniform 0..2^32-2 domain before rejection sampling.
        if not 1 <= bound <= 0xFFFFFFFF: raise ValueError('invalid bound')
        domain = 0xFFFFFFFF
        limit = domain - domain % bound
        while True:
            value = self.next() - 1
            if value < limit: return value % bound
    def choose_remove(self, pool: list[Any]) -> Any:
        if not pool: raise ValueError('empty choice pool')
        return pool.pop(self.bounded(len(pool)))
    def shuffle(self, values: list[Any]) -> None:
        for index in range(len(values) - 1, 0, -1):
            other = self.bounded(index + 1)
            values[index], values[other] = values[other], values[index]

def draft_offer(loadout: list[str], chosen: list[str], draft_index: int, rng: XorShift32,
                upgrades: list[dict[str, Any]] | None=None) -> list[str]:
    if len(loadout) != 4 or len(set(loadout)) != 4: raise ValueError('four distinct units required')
    if draft_index not in (1, 2, 3, 4): raise ValueError('draft index must be1..4')
    if len(chosen) != draft_index - 1 or len(set(chosen)) != len(chosen): raise ValueError('invalid chosen upgrade count')
    catalog = load('upgrades') if upgrades is None else upgrades
    known = {u['id']: u for u in catalog}
    if any(i not in known or known[i]['requires_equipped_unit'] not in (None,*loadout) for i in chosen):
        raise ValueError('chosen upgrade is unknown/ineligible')
    eligible = sorted((u for u in catalog if u['requires_equipped_unit'] in (None,*loadout) and u['id'] not in chosen), key=lambda u:u['id'])
    if len(eligible) < 3: raise ValueError('not enough eligible choices')
    result: list[dict[str, Any]] = []
    def reserve(predicate):
        pool = [u for u in eligible if predicate(u)]
        if pool:
            selected = rng.choose_remove(pool); eligible.remove(selected); result.append(selected)
    if draft_index == 1: reserve(lambda u:u['kind']=='behavior')
    else:
        reserve(lambda u:u['requires_equipped_unit'] is not None)
        reserve(lambda u:u['requires_equipped_unit'] is None)
    while len(result) < 3: result.append(rng.choose_remove(eligible))
    rng.shuffle(result)
    return [u['id'] for u in result]

def funding_schedule(encounter: dict[str, Any], units: dict[str, dict[str, Any]] | None=None) -> list[int]:
    """Earliest funded deployment ticks; no actor cap, damage, travel or enemies."""
    if units is None: units = {u['id']:u for u in load('units')}
    bank = scaled(encounter['enemy_supply_start']); rate = scaled(encounter['enemy_supply_rate_per_s'])
    cap = scaled(encounter['enemy_supply_cap'])
    next_tick = scaled(encounter['enemy_first_deployment_earliest_s'], HZ)
    gap = scaled(encounter['enemy_min_deployment_gap_s'], HZ)
    expiry = scaled(encounter['enemy_orders_expire_at_s'], HZ)
    remainder = index = 0; ticks: list[int] = []
    for tick in range(expiry):
        if tick:
            gain, remainder = divmod(rate + remainder, HZ)
            bank = min(cap, bank + gain)
        if index < len(encounter['enemy_spawn_queue']) and tick >= next_tick:
            cost = units[encounter['enemy_spawn_queue'][index]]['supply_cost'] * SCALE
            if bank >= cost:
                bank -= cost; ticks.append(tick); index += 1; next_tick = tick + gap
    return ticks

def economy_route(with_ads: bool=False) -> list[dict[str, Any]]:
    economy = load('economy'); exps = load('expeditions'); encs = {e['id']:e for e in load('encounters')}
    costs = {**economy['troop_unlocks'], **{b['id']:b['cost_medals'] for b in economy['cosmetic_banners']}}
    owned: set[str] = set(); seen: set[str] = set(); wallet = total = 0; rows=[]
    for run in range(1, 101):
        exp=exps[min(run-1,len(exps)-1)]
        battle=sum(encs[i]['win_medals'] for i in exp['encounter_ids'])
        reward=battle+exp['completion_medals']+(exp['first_clear_medals'] if exp['id'] not in seen else 0)
        seen.add(exp['id']); bonus=battle//2 if with_ads and run>1 and len(owned)<len(costs) else 0
        wallet+=reward+bonus; total+=reward+bonus; new=[]
        for item in economy['purchase_priority']:
            if item in owned: continue
            if wallet<costs[item]: break
            wallet-=costs[item];owned.add(item);new.append(item)
        rows.append(dict(clear=run,expedition=exp['id'],ordinary_reward=reward,bonus=bonus,total_earned=total,wallet=wallet,new_unlocks=new))
        if len(owned)==len(costs): return rows
    raise RuntimeError('economy route did not exhaust catalogue in100 full wins')

def validate_save_envelope(obj: dict[str, Any]) -> bool:
    if set(obj) != {'format','envelope_version','payload_json','payload_sha256'}: return False
    if obj['format']!='OLW_SAVE_ENVELOPE' or obj['envelope_version']!=1: return False
    if not isinstance(obj['payload_json'],str): return False
    if hashlib.sha256(obj['payload_json'].encode('utf-8')).hexdigest()!=obj['payload_sha256']: return False
    try: payload=json.loads(obj['payload_json'])
    except (ValueError,TypeError): return False
    return isinstance(payload,dict) and payload.get('schema_version')==1
