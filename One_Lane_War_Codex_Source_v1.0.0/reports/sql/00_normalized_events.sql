-- BigQuery Standard SQL. TEMPLATE; replace project/dataset/export names.
-- Verify against the actual exported schema before deployment. No live data queried here.
CREATE OR REPLACE VIEW `YOUR_PROJECT.YOUR_DATASET.olw_events` AS
WITH raw AS (
  SELECT user_pseudo_id, event_timestamp, event_name, event_params,
         app_info.version AS app_version
  FROM `YOUR_PROJECT.analytics_PROPERTY_ID.events_*`
  WHERE _TABLE_SUFFIX BETWEEN FORMAT_DATE('%Y%m%d', DATE_SUB(CURRENT_DATE(), INTERVAL 90 DAY))
                          AND FORMAT_DATE('%Y%m%d', CURRENT_DATE())
), mapped AS (
 SELECT user_pseudo_id AS user_key, TIMESTAMP_MICROS(event_timestamp) AS event_timestamp,
        event_name, app_version,
        (SELECT value.string_value FROM UNNEST(event_params) WHERE key='event_id' LIMIT 1) AS event_id,
        (SELECT value.string_value FROM UNNEST(event_params) WHERE key='environment' LIMIT 1) AS environment,
        (SELECT value.string_value FROM UNNEST(event_params) WHERE key='balance_version' LIMIT 1) AS balance_version,
        (SELECT value.string_value FROM UNNEST(event_params) WHERE key='run_id' LIMIT 1) AS run_id,
        (SELECT value.string_value FROM UNNEST(event_params) WHERE key='attempt_id' LIMIT 1) AS attempt_id,
        (SELECT value.string_value FROM UNNEST(event_params) WHERE key='encounter_id' LIMIT 1) AS encounter_id,
        JSON_OBJECT(
          ARRAY(SELECT key FROM UNNEST(event_params)),
          ARRAY(SELECT COALESCE(value.string_value, CAST(value.int_value AS STRING),
                    CAST(value.double_value AS STRING), CAST(value.float_value AS STRING))
                FROM UNNEST(event_params))
        ) AS params_json
 FROM raw
)
SELECT *, environment != 'PROD' OR environment IS NULL AS is_test
FROM mapped;
-- Auto-event environment tagging and tester registry joins need verified adapter mapping;
-- never simply discard automatic first_open because it lacks a custom parameter.
-- Deduplicate custom events by event_id in the materialized reporting layer.
