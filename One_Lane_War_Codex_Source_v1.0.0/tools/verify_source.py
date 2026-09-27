#!/usr/bin/env python3
"""Verify sealed source files and semantic invariants. No Unity/network/assets generated.
Python3.10+ standard library. --no-manifest is for source-package assembly only.
"""
from __future__ import annotations
import argparse,hashlib,json,re,sys,zipfile
from pathlib import Path
from html.parser import HTMLParser
ROOT=Path(__file__).resolve().parents[1]

def main():
 p=argparse.ArgumentParser(description=__doc__);p.add_argument('--no-manifest',action='store_true');p.add_argument('--output',type=Path);args=p.parse_args()
 checks=[]
 def check(name,ok,detail=''):checks.append({'name':name,'pass':bool(ok),'detail':detail})
 def read(path):return json.loads((ROOT/path).read_text(encoding='utf-8'))
 def sha(path):return hashlib.sha256(path.read_bytes()).hexdigest()
 def safe(path):
  target=(ROOT/path).resolve()
  return ROOT==target or ROOT in target.parents
 try:
  authority=read('SOURCE_AUTHORITY.json');check('current source identity',authority['source_id']=='OLW-SOURCE-1.0.0')
  for f in sorted(ROOT.rglob('*.json')):
   if any(s in f.parts for s in ['Game','ImplementationEvidence','Services','.git','__pycache__']):continue
   try:json.loads(f.read_text());check('JSON '+str(f.relative_to(ROOT)),True)
   except Exception as e:check('JSON '+str(f.relative_to(ROOT)),False,str(e))
  for f in (ROOT/'records').glob('*.jsonl'):
   rows=[json.loads(x) for x in f.read_text().splitlines() if x.strip()];check('JSONL '+f.name,bool(rows));check('unique decision IDs',len({r['id'] for r in rows})==len(rows))
  data={p.stem:json.loads(p.read_text()) for p in (ROOT/'data').glob('*.json')}
  for n,c in [('units',6),('upgrades',24),('encounters',36),('expeditions',9),('boss_variants',2),('products',2),('assets',148),('analytics_events',35),('qa_cases',155),('build_gates',11),('tasks',12)]:
   v=data[n];check(n+' count',len(v)==c,str(len(v)));check(n+' unique IDs',len({x['id'] for x in v})==len(v))
  check('184 English strings',len(data['strings_en']['strings'])==184)
  envelope=read('templates/SAVE_S1_EXAMPLE.json')
  check('example envelope hash',hashlib.sha256(envelope['payload_json'].encode('utf-8')).hexdigest()==envelope['payload_sha256'])
  check('new-save payload agrees with envelope',json.loads(envelope['payload_json'])==read('tests/fixtures/save_payload_new.json'))
  for fname in ['save_payload_new.json','save_payload_draft.json']:
   save=read('tests/fixtures/'+fname)
   check(fname+' valid wallet',isinstance(save['medals'],int) and 0<=save['medals']<=9223372036854775807)
   check(fname+' valid selected loadout',len(set(save['selected_loadout']))==4 and set(save['selected_loadout'])<=set(save['unlocked_units']))
   if save['active_run']:
    run=save['active_run']
    check(fname+' seed bounds',0<run['seed']<=4294967295 and 0<run['prng_state']<=4294967295)
    check(fname+' offers selected disjoint',not set(run['offers'])&set(run['selected_upgrades']))

  check('22 Bibles',len(list((ROOT/'bibles').glob('*.md')))==22)
  for name in ['START_HERE.md','START_CODEX.md','AGENTS.md','INDEX.html','ALL_BIBLES.md','records/COVERAGE_MATRIX.json','contracts/state_machines.json','contracts/analytics_transport.json','contracts/service_api.json']:
   check('required '+name,(ROOT/name).is_file())
  U={x['id']:x for x in data['units']};A={x['id']:x for x in data['assets']};E={x['id']:x for x in data['encounters']};B={x['id']:x for x in data['boss_variants']}
  for u in U.values():
   check(u['id']+' values',all(u[k]>0 for k in ['hp','damage','base_damage','supply_cost','range_m','move_speed_m_s']))
   check(u['id']+' timing',0<u['windup_ticks']<u['attack_period_ticks'] and abs(u['attack_period_s']*20-u['attack_period_ticks'])<1e-8)
   check(u['id']+' asset',u['master_asset_id'] in A)
  check('four starters',sum(u['unlocked_initially'] for u in U.values())==4)
  for a in data['upgrades']:
   check(a['id']+' references',a['requires_equipped_unit'] in (None,*U) and a['icon_asset_id'] in A)
   check(a['id']+' one rank',a['max_rank']==1)
  ids=[]
  for x in data['expeditions']:
   ids+=x['encounter_ids'];check(x['id']+' assignment',len(x['encounter_ids'])==4 and all(i in E for i in x['encounter_ids']) and [E[i]['battle_index'] for i in x['encounter_ids']]==[1,2,3,4])
  check('36 encounters once',len(ids)==len(set(ids))==36)
  for e in E.values():
   check(e['id']+' queue',all(i in U for i in e['enemy_spawn_queue']) and e['policy']=='FINITE_ORDERED_QUEUE')
   check(e['id']+' budget',sum(U[i]['supply_cost'] for i in e['enemy_spawn_queue'])==e['enemy_total_supply_budget'])
   check(e['id']+' environment',e['environment_asset_id'] in A)
   if e['boss_variant']:
    b=B[e['boss_variant']];ix=e['boss_queue_index_zero_based'];check(e['id']+' boss',0<=ix<len(e['enemy_spawn_queue']) and e['enemy_spawn_queue'][ix]==b['base_unit'] and e['battle_index']==4)
  for a in A.values():
   check(a['id']+' planned not generated',a['status']=='PLANNED_NOT_GENERATED' and a['source_path'] is None and a['sha256'] is None)
   check(a['id']+' dependency',all(i in A for i in a.get('depends_on',[])))
  for e in data['analytics_events']:
   check(e['id']+' parameter budget',len(e['parameters'])+len(e['common_envelope'])+4<=25)
   check(e['id']+' sensitive fields absent',not any(p in e['parameters'] for p in ['purchase_token','email','password','precise_location']))
  rules=data['game_rules'];check('offline single player',rules['offline_core'] and not rules['player_accounts'] and not rules['cloud_progression'])
  check('no forced ads',rules['scope']['forced_ads']==0)
  check('balance unvalidated disclosure',rules['balance_status']=='LOCKED_DESIGN_NOT_GAMEPLAY_VALIDATED')
  check('toolchain not falsely built',data['toolchain_lock']['joint_compatibility_status']=='NOT_BUILT')
  check('no runtime QA fabricated',all(x['status']=='NOT_RUN' and x['evidence'] is None for x in data['qa_cases']))
  check('no phase fabricated',all(x['status']=='NOT_RUN' and x['evidence'] is None for x in data['build_gates']))
  stages={x['id']:x for x in data['build_gates']};tasks={x['id']:x for x in data['tasks']};seen=set()
  for g in data['build_gates']:
   check(g['id']+' topological order',all(d in seen for d in g['depends_on']));seen.add(g['id']);check(g['id']+' task',g['primary_task'] in tasks)
  check('placeholder-before-final generation',stages['PH07']['depends_on']==['PH06'] and stages['PH08']['depends_on']==['PH07'])
  check('no task auto-authorized',all(not x['execution_authorized'] for x in tasks.values()))
  qaids={q['id'] for q in data['qa_cases']}
  for t in tasks.values():
   check(t['id']+' file',(ROOT/'tasks'/f"{t['id']}.md").is_file())
   check(t['id']+' dependencies',all(d in tasks for d in t['depends_on']))
   check(t['id']+' bibles',all((ROOT/b).is_file() for b in t['required_bibles']))
   check(t['id']+' QA refs',all(q in qaids for q in t['qa_ids']))
  check('capture count28',len(data['screenshot_pack']['captures'])==28)
  for a in data['visual_references']['references']:
   f=ROOT/a['path'];check(a['id']+' reference bytes',f.is_file() and sha(f)==a['sha256']);check(a['id']+' style not numeric',not a['runtime_capture'] and not a['numerical_authority'])
  inputs=read('records/SOURCE_INPUTS.json')
  for a in inputs['retained_b001_files']:
   check('B001 preserved '+a['path'],sha(ROOT/a['path'])==a['sha256'])
  for h in inputs['history']:
   f=ROOT/h['path'];check('history '+h['name'],f.is_file() and sha(f)==h['sha256'])
   with zipfile.ZipFile(f) as z:check('history ZIP CRC '+h['name'],z.testzip() is None)
  # Relative links and HTMLanchors only; do not probe network from validation.
  class Links(HTMLParser):
   def __init__(self):super().__init__();self.ids=[];self.hrefs=[]
   def handle_starttag(self,tag,attrs):
    a=dict(attrs)
    if 'id' in a:self.ids.append(a['id'])
    if tag=='a' and 'href' in a:self.hrefs.append(a['href'])
  h=Links();h.feed((ROOT/'INDEX.html').read_text());check('HTML unique IDs',len(h.ids)==len(set(h.ids)))
  for link in set(h.hrefs):
   if link.startswith('#'):check('HTML anchor '+link,link[1:] in h.ids)
   elif '://' not in link and not link.startswith('mailto:'):check('HTML local link '+link,(ROOT/link.split('#')[0]).exists())
  check('no font files',not any(p.suffix.lower() in {'.ttf','.otf','.woff','.woff2'} for p in ROOT.rglob('*') if p.is_file()))
  if not args.no_manifest:
   mf=ROOT/'SOURCE_MANIFEST.json';check('manifest exists',mf.is_file())
   if mf.is_file():
    manifest=read('SOURCE_MANIFEST.json');check('manifest excludes itself',all(r['path']!='SOURCE_MANIFEST.json' for r in manifest['files']))
    check('manifest unique paths',len({r['path'] for r in manifest['files']})==len(manifest['files']))
    check('manifest source identity',manifest.get('source_id')=='OLW-SOURCE-1.0.0')
    exclusions=set(manifest.get('excluded_paths',[]))
    expected={str(f.relative_to(ROOT)) for f in ROOT.rglob('*') if f.is_file() and not any(s in f.parts for s in ['Game','ImplementationEvidence','Services','.git','__pycache__']) and f.suffix!='.pyc'}
    check('manifest complete source coverage',{r['path'] for r in manifest['files']}==expected-exclusions)

    for row in manifest['files']:
     check('safe manifest path '+row['path'],safe(row['path']))
     f=ROOT/row['path'];check('sealed '+row['path'],f.is_file() and f.stat().st_size==row['bytes'] and sha(f)==row['sha256'])
  report={'scope':'SOURCE FILES/REFERENCES/STRUCTURE ONLY;NOT UNITY OR GAME TESTS','manifest_checked':not args.no_manifest,'checks':len(checks),'passed':sum(c['pass'] for c in checks),'failed':sum(not c['pass'] for c in checks),'results':checks}
  if args.output:
   args.output.parent.mkdir(parents=True,exist_ok=True);args.output.write_text(json.dumps(report,indent=2)+'\n')
  print(json.dumps({k:report[k] for k in ['scope','manifest_checked','checks','passed','failed']},indent=2))
  for fail in [c for c in checks if not c['pass']]:print('FAIL:',fail['name'],fail['detail'],file=sys.stderr)
  return int(report['failed']>0)
 except Exception as exc:
  print('SOURCE VALIDATION ERROR:',str(exc),file=sys.stderr);return 2
if __name__=='__main__':raise SystemExit(main())
