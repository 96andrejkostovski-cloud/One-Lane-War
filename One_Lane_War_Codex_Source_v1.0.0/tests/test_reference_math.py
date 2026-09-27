"""Source/arithmetic fixtures only. No Unity or game simulation is invoked."""
import unittest,sys,json,copy,itertools
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1];sys.path.insert(0,str(ROOT/'tools'))
from reference_math import *
U={u['id']:u for u in load('units')};A={u['id']:u for u in load('upgrades')}
class Arithmetic(unittest.TestCase):
    def test_half_up(self):self.assertEqual(half_up_ratio(435,2),218)
    def test_ceil_cost(self):self.assertEqual(ceildiv(1150000,10000),115)
    def test_invalid_divisor(self):
        with self.assertRaises(ValueError):ceildiv(1,0)
    def test_decimal_exact(self):self.assertEqual(scaled('0.000001'),1)
    def test_decimal_reject_loss(self):
        with self.assertRaises(ValueError):scaled('0.0000001')
    def test_militia_baseline(self):
        s=modified_unit(U['militia'],[]);self.assertEqual((s['hp'],s['damage'],s['period_ticks'],s['windup_ticks']),(70,11,16,4))
    def test_crossbow_rally_reload(self):
        s=modified_unit(U['crossbowman'],[A['u09']],True);self.assertEqual((s['period_ticks'],s['windup_ticks']),(24,5))
    def test_ram_additive_base(self):
        s=modified_unit(U['ram'],[A['u17'],A['u22']]);self.assertEqual((s['base_damage'],s['cost'],s['damage']),(218,115,15))
    def test_shield_modified_barrier(self):
        s=modified_unit(U['shieldguard'],[A['u06'],A['u22'],A['u04']]);self.assertEqual(s['hp'],336);self.assertEqual(half_up_ratio(s['hp']*3000,10000),101)
    def test_eligible_only(self):self.assertEqual(modified_unit(U['militia'],[A['u08']]),modified_unit(U['militia'],[]))
    def test_movement_groups(self):self.assertEqual(modified_unit(U['shieldguard'],[A['u06'],A['u24']])['move_micro_m_s'],945000)
    def test_defense_absorption(self):self.assertEqual(damage_after_reduction(50,3,72),(0,25))
    def test_defense_overflow(self):self.assertEqual(damage_after_reduction(50,3,25),(22,0))
    def test_minimum_damage(self):self.assertEqual(damage_after_reduction(1,5),(1,0))
    def test_splash_and_base_source(self):self.assertEqual((U['grenadier']['damage'],U['grenadier']['base_damage'],U['grenadier']['splash_radius_m']),(36,18,1.0))
class Draft(unittest.TestCase):
    def test_xorshift_known_vector(self):
        r=XorShift32(1);self.assertEqual([r.next() for _ in range(3)],[270369,67634689,2647435461])
    def test_zero_rejected(self):
        with self.assertRaises(ValueError):XorShift32(0)
    def test_bound_one(self):self.assertEqual(XorShift32(1).bounded(1),0)
    def test_all_army_eligibility(self):
        for army in itertools.combinations(U,4):self.assertEqual(len([a for a in A.values() if a['requires_equipped_unit'] in (None,*army)]),18)
    def test_first_behavior(self):
        army=list(U)[:4]
        for seed in range(1,51):
            offer=draft_offer(army,[],1,XorShift32(seed));self.assertEqual(len(set(offer)),3);self.assertTrue(any(A[i]['kind']=='behavior' for i in offer))
    def test_all_four_drafts(self):
        for army in itertools.combinations(U,4):
            r=XorShift32(17);chosen=[]
            for d in range(1,5):
                offer=draft_offer(list(army),chosen,d,r);self.assertFalse(set(offer)&set(chosen));self.assertTrue(all(A[i]['requires_equipped_unit'] in (None,*army) for i in offer))
                if d>1:self.assertTrue(any(A[i]['requires_equipped_unit'] is None for i in offer))
                chosen.append(offer[0])
    def test_replay_state(self):
        r=XorShift32(99);army=list(U)[:4];state=r.state;a=draft_offer(army,[],1,r);b=draft_offer(army,[],1,XorShift32(state));self.assertEqual(a,b)
    def test_bad_loadout(self):
        with self.assertRaises(ValueError):draft_offer(['militia']*4,[],1,XorShift32(1))
class SourceRoutes(unittest.TestCase):
    def test_all_funding(self):
        for e in load('encounters'):
            t=funding_schedule(e,U);self.assertEqual(len(t),len(e['enemy_spawn_queue']));self.assertEqual(t[-1]/20,e['minimum_funding_only_last_deployment_s'])
    def test_intro_schedule(self):self.assertEqual(funding_schedule(load('encounters')[0],U)[0],160)
    def test_noad_milestones(self):
        rows=economy_route();self.assertEqual(len(rows),12);self.assertEqual({k:r['clear'] for r in rows for k in r['new_unlocks']},{'brute':1,'ram':2,'banner_oak':4,'banner_barrel':7,'banner_iron':12})
    def test_ad_route(self):self.assertEqual(len(economy_route(True)),10);self.assertEqual(economy_route(True)[0]['bonus'],0)
    def test_first_campaign_total(self):self.assertEqual(economy_route()[8]['total_earned'],990)
    def test_total_sinks(self):self.assertEqual(load('economy')['total_medal_sinks'],1320)
    def test_save_example(self):self.assertTrue(validate_save_envelope(json.loads((ROOT/'templates/SAVE_S1_EXAMPLE.json').read_text())))
    def test_save_corruption(self):
        x=json.loads((ROOT/'templates/SAVE_S1_EXAMPLE.json').read_text());x['payload_json']+=' ';self.assertFalse(validate_save_envelope(x))
    def test_newer_envelope(self):
        x=json.loads((ROOT/'templates/SAVE_S1_EXAMPLE.json').read_text());x['envelope_version']=2;self.assertFalse(validate_save_envelope(x))
    def test_qa_not_run(self):self.assertTrue(all(q['status']=='NOT_RUN' and q['evidence'] is None for q in load('qa_cases')))
    def test_no_final_assets(self):self.assertTrue(all(a['source_path'] is None and a['sha256'] is None for a in load('assets')))
    def test_workflow_order(self):
        g={x['id']:x for x in load('build_gates')};self.assertEqual(g['PH07']['depends_on'],['PH06']);self.assertEqual(g['PH08']['depends_on'],['PH07'])
if __name__=='__main__':unittest.main()
