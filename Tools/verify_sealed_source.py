"""OLW-AMEND-002 coverage/hash check; never writes to the sealed package."""
import hashlib
import json
from pathlib import Path
import subprocess

ROOT = Path(__file__).resolve().parents[1]
SOURCE = ROOT / 'One_Lane_War_Codex_Source_v1.0.0'
BASE = 'c8130bfb304b40047c703b44ff3db19bc5cae89d'
EXPECTED = '6c5ab38839a42dfe9a8c0085860d13bf05899441b2a389f3b6d243b552a16d90'

def verify():
    manifest_bytes = (SOURCE / 'SOURCE_MANIFEST.json').read_bytes()
    manifest = json.loads(manifest_bytes)
    failures = []
    if hashlib.sha256(manifest_bytes).hexdigest() != EXPECTED:
        failures.append('Manifest differs from owner-pinned SHA256')
    records = manifest['files']
    listed = {r['path'] for r in records}
    actual = {p.relative_to(SOURCE).as_posix() for p in SOURCE.rglob('*')
              if p.is_file() and '__pycache__' not in p.parts and p.suffix != '.pyc'}
    if len(listed) != len(records):
        failures.append('Duplicate manifest paths')
    if actual != listed | set(manifest['excluded_paths']):
        failures.append('Coverage: ' + repr(sorted(actual ^ (listed | set(manifest['excluded_paths'])))))
    for record in records:
        path = SOURCE / record['path']
        if not path.is_file():
            failures.append('Missing: ' + record['path'])
            continue
        raw = path.read_bytes()
        if len(raw) != record['bytes'] or hashlib.sha256(raw).hexdigest() != record['sha256']:
            failures.append('Size/hash mismatch: ' + record['path'])
    # Also protect the two manifest-excluded files against the actual Git baseline.
    for name in manifest['excluded_paths']:
        old = subprocess.run(['git', 'show', BASE + ':' + SOURCE.name + '/' + name],
                             cwd=ROOT, capture_output=True, check=True).stdout
        if old != (SOURCE / name).read_bytes():
            failures.append('Baseline byte mismatch: ' + name)
    print(json.dumps({'status': 'FAIL' if failures else 'PASS', 'manifest_sha256': EXPECTED,
                      'manifest_files': len(records), 'excluded_baseline_files': 2,
                      'scope': 'SEALED SOURCE BYTES ONLY; NOT RUNTIME', 'failures': failures}, indent=2))
    return bool(failures)

if __name__ == '__main__':
    raise SystemExit(verify())
