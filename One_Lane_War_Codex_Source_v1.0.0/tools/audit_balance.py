#!/usr/bin/env python3
"""Read-only source arithmetic audit. NOT gameplay/Unity/device/service validation."""
from __future__ import annotations
import argparse,itertools,json,sys
from pathlib import Path
from reference_math import load,modified_unit,funding_schedule,economy_route

def run_audit():
    units={u['id']:u for u in load('units')};upgrades=load('upgrades')
    configs=states=0;violations=[];extremes={'max_hp':0,'max_base_hit':0,'min_period_ticks':999,'max_cost':0}
    for army in itertools.combinations(units,4):
        eligible=[u for u in upgrades if u['requires_equipped_unit'] in (None,*army)]
        if len(eligible)!=18: violations.append({'army':army,'reason':'eligibility'})
        for chosen in itertools.combinations(eligible,4):
            configs+=1
            for uid in army:
                for rally in (False,True):
                    s=modified_unit(units[uid],chosen,rally);states+=1
                    if not (s['hp']>0 and s['damage']>0 and s['base_damage']>0 and 0<s['windup_ticks']<s['period_ticks'] and 0<s['cost']<=200 and 250000<=s['move_micro_m_s']<=2500000):
                        violations.append({'army':army,'unit':uid,'upgrades':[u['id'] for u in chosen],'stats':s})
                    extremes['max_hp']=max(extremes['max_hp'],s['hp']);extremes['max_base_hit']=max(extremes['max_base_hit'],s['base_damage'])
                    extremes['min_period_ticks']=min(extremes['min_period_ticks'],s['period_ticks']);extremes['max_cost']=max(extremes['max_cost'],s['cost'])
    funding=[]
    for e in load('encounters'):
        ticks=funding_schedule(e,units)
        ok=len(ticks)==len(e['enemy_spawn_queue']) and ticks[-1]/20==e['minimum_funding_only_last_deployment_s']
        funding.append({'encounter':e['id'],'feasible_no_congestion':ok,'deployment_ticks':ticks})
        if not ok: violations.append({'encounter':e['id'],'reason':'fundingbound'})
    noads=economy_route(False);ads=economy_route(True)
    if len(noads)!=12 or len(ads)!=10:violations.append({'reason':'economyroute'})
    return {'scope':'ARITHMETIC/FUNDING/ECONOMY ONLY; NOT COMBAT SIMULATION','status':'PASS' if not violations else 'FAIL','configurations':configs,'unit_rally_states':states,'extremes':extremes,'funding':funding,'economy_no_ads':noads,'economy_eligible_ads':ads,'violations':violations,'not_run':['Unity','battles','AVD','physicaldevice','liveSDKs','humanplaytests']}

def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--output',type=Path,help='Explicit optional JSON output;default stdout summary only')
    args=p.parse_args();report=run_audit()
    if args.output:
        args.output.parent.mkdir(parents=True,exist_ok=True);args.output.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({k:report[k] for k in ['scope','status','configurations','unit_rally_states','extremes','violations']},indent=2))
    return int(report['status']!='PASS')
if __name__=='__main__':raise SystemExit(main())
