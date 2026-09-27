-- @start TIMESTAMP, @end TIMESTAMP. Money grouped by original currency; no implicit FX.
SELECT currency,COUNT(DISTINCT impression_id) AS impressions,
 SUM(value_micros) AS estimated_ad_revenue_micros,
 SAFE_DIVIDE(SUM(value_micros),COUNT(DISTINCT impression_id))*1000/1000000 AS estimated_ecpm
FROM `YOUR_PROJECT.YOUR_DATASET.olw_ad_revenue`
WHERE paid_at >= @start AND paid_at < @end AND NOT is_test
GROUP BY currency;

SELECT currency,SUM(gross_micros) AS gross_purchase_micros,
 SUM(refund_micros) AS refund_micros,
 SUM(net_settlement_micros) AS reported_net_settlement_micros,
 COUNTIF(net_settlement_micros IS NULL) AS unsettled_records
FROM `YOUR_PROJECT.YOUR_DATASET.olw_purchase_ledger`
WHERE occurred_at >= @start AND occurred_at < @end AND NOT is_test
GROUP BY currency;
-- Ad estimates and store net settlements are different sources and timing. Reconcile provider reports.
