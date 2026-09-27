-- @start TIMESTAMP, @end TIMESTAMP. Deduplicate before aggregation.
WITH ended AS (
 SELECT * EXCEPT(rn) FROM (
  SELECT *,ROW_NUMBER() OVER(PARTITION BY event_id ORDER BY event_timestamp) rn
  FROM `YOUR_PROJECT.YOUR_DATASET.olw_events`
  WHERE event_timestamp >= @start AND event_timestamp < @end
    AND event_name='battle_end' AND NOT is_test AND event_id IS NOT NULL
 ) WHERE rn=1
)
SELECT app_version,balance_version,encounter_id,COUNT(*) AS ended_attempts,
 COUNTIF(JSON_VALUE(params_json,'$.outcome')='WIN') AS wins,
 COUNTIF(JSON_VALUE(params_json,'$.outcome')='DRAW') AS draws,
 SAFE_DIVIDE(COUNTIF(JSON_VALUE(params_json,'$.outcome')='WIN'),COUNT(*)) AS win_rate,
 APPROX_QUANTILES(SAFE_CAST(JSON_VALUE(params_json,'$.duration_s') AS FLOAT64),100)[OFFSET(50)] AS median_seconds,
 AVG(SAFE_CAST(JSON_VALUE(params_json,'$.supply_wasted') AS FLOAT64)) AS mean_supply_wasted
FROM ended GROUP BY app_version,balance_version,encounter_id;
-- Actual outcome code mapping must match the transport enum; do not silently recode losses.
