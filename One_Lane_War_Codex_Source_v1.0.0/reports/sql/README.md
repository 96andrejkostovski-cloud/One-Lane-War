# BigQuery reporting templates — not deployed or executed here

These SQL files target the normalized tables/views in `contracts/analytics_transport.json`. Replace `YOUR_PROJECT.YOUR_DATASET` and supply query parameters from approved configuration. They are reviewed templates, not claims of deployed dashboards or tested live SQL. PH05 must validate the actual Firebase export schema, identifiers, consent handling, cost and query output with a known journey.

`00_normalized_events.sql` illustrates the current export mapping for event basics. Additional normalized installs/activity/ad/purchase views require the documented mappings; purchase finance uses the verified backend/provider ledger, not just client event prices. The `performance_summary` qualifying-gameplay sample supplies ten-second foreground-play eligibility without adding a36th custom event.

Use partition/date filters and bounded ranges. Empty denominators return NULL, not invented zero success. Never turn unknown source into Play organic or gross price into net receipt. Separate development/test users. Raw90-day retention means older aggregate cohorts require previously stored appropriate non-identifying aggregates. No scheduled job is created by these templates.
