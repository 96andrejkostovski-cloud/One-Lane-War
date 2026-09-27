-- BigQuery Standard SQL. Named parameters:
-- @cohort_start TIMESTAMP, @cohort_end TIMESTAMP, @as_of TIMESTAMP, @day INT64 (1,7,30).
WITH installs AS (
 SELECT user_key, first_observed_open
 FROM `YOUR_PROJECT.YOUR_DATASET.olw_installs`
 WHERE first_observed_open >= @cohort_start AND first_observed_open < @cohort_end
   AND NOT is_test AND consent_observed
   AND TIMESTAMP_DIFF(@as_of, first_observed_open, SECOND) >= (@day + 1) * 86400
), active AS (
 SELECT DISTINCT i.user_key
 FROM installs i JOIN `YOUR_PROJECT.YOUR_DATASET.olw_activity` a USING(user_key)
 WHERE a.activity_at >= @cohort_start AND a.activity_at < @as_of
   AND NOT a.is_test AND a.sample_kind='qualifying_gameplay'
   AND a.foreground_gameplay_ms >= 10000
   AND TIMESTAMP_DIFF(a.activity_at,i.first_observed_open,SECOND) >= @day * 86400
   AND TIMESTAMP_DIFF(a.activity_at,i.first_observed_open,SECOND) < (@day+1) * 86400
)
SELECT COUNT(*) AS mature_measurable_installs, COUNT(a.user_key) AS qualifying_returns,
       SAFE_DIVIDE(COUNT(a.user_key),COUNT(*)) AS return_rate,
       COUNT(*) >= 200 AS meets_internal_interpretation_sample
FROM installs i LEFT JOIN active a USING(user_key);
-- Report consent missingness, observed identity/reinstall limitations and uncertainty separately.
