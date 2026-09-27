"""Install only the archives selected by the exact Unity release metadata.

Run after Tools' download commands; elevation is required for Program Files.
No SDK version resolution, editor replacement, or source-package writes occur.
"""
import base64
import hashlib
import json
from pathlib import Path
import zipfile

ROOT = Path(__file__).resolve().parent.parent
CACHE = ROOT / 'Builds/T001'
UNITY = Path('C:/Program Files/Unity/Hub/Editor/6000.3.21f1')
EVIDENCE = ROOT / 'ImplementationEvidence/OLW-CORE-001/resume005'
module = json.loads((CACHE / 'android-module.json').read_text(encoding='utf-8-sig'))
assert 'c02631ffc030' in module['url']
components = [module['subModules'][0]] + module['subModules'][1]['subModules']
records = []
for component in components:
    name = component['id']
    archive = CACHE / (name + '.zip')
    digest = hashlib.sha256(archive.read_bytes()).hexdigest()
    if name.startswith('android-open-jdk'):
        assert digest in component['url'], 'Bundled JDK digest mismatch'
    if component.get('integrity'):
        algorithm, expected = component['integrity'].split('-', 1)
        assert base64.b64encode(hashlib.new(algorithm, archive.read_bytes()).digest()).decode() == expected
    destination = Path(component['destination'].replace('{UNITY_PATH}', str(UNITY)))
    strip = False
    if name == 'android-ndk-r27c': strip = True
    if name.startswith('android-sdk-build-tools') or name.startswith('android-sdk-command-line-tools'):
        destination = Path(component['extractedPathRename']['to'].replace('{UNITY_PATH}', str(UNITY))); strip = True
    if name.startswith('cmake-'):
        destination = Path(component['extractedPathRename']['to'].replace('{UNITY_PATH}', str(UNITY)))
    assert destination.resolve().is_relative_to(UNITY.resolve())
    count = 0
    with zipfile.ZipFile(archive) as z:
        for entry in z.infolist():
            parts = Path(entry.filename).parts[1:] if strip else Path(entry.filename).parts
            if not parts: continue
            target = destination.joinpath(*parts).resolve()
            assert target.is_relative_to(destination.resolve()), 'Unsafe archive member'
            if entry.is_dir(): target.mkdir(parents=True, exist_ok=True); continue
            data = z.read(entry)
            if target.exists():
                assert target.read_bytes() == data, 'Refusing to overwrite different installed file: ' + str(target)
            else:
                target.parent.mkdir(parents=True, exist_ok=True); target.write_bytes(data)
            count += 1
    record = dict(id=name, url=component['url'], sha256=digest, bytes=archive.stat().st_size, destination=str(destination), files=count)
    records.append(record); print(name, 'OK', count, flush=True)
(EVIDENCE / 'installed-components.json').write_text(json.dumps(records, indent=2) + '\n', encoding='utf-8')
print('T001_COMPONENT_INSTALL_COMPLETE', flush=True)
