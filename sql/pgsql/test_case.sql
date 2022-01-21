;with cte (f1, f2, f3)
as
(
  select f1, f2, f3
  from (
           values ('2021-04-01 00:00:00+03:00'::timestamp with time zone, '2021-04-30 23:59:59+03:00'::timestamp with time zone, false),
                  ('2021-05-01 00:00:00+03:00'::timestamp with time zone, '2021-05-31 23:59:59+03:00'::timestamp with time zone, false),
                  ('2021-06-01 00:00:00+03:00'::timestamp with time zone, '2021-06-30 23:59:59+03:00'::timestamp with time zone, false),
                  ('2021-07-01 00:00:00+03:00'::timestamp with time zone, '2021-07-31 23:59:59+03:00'::timestamp with time zone, true)
       ) tmpTable (f1, f2, f3)
)
select
    f1, f2, f3,
    case
        when f3
            then 'Inactive'
        when '2021-05-15 00:00:00+03:00'::timestamp with time zone between f1 and f2
            then 'Active'
        when '2021-05-15 00:00:00+03:00'::timestamp with time zone < f1
            then 'Scheduled'
        when '2021-05-15 00:00:00+03:00'::timestamp with time zone > f2
            then 'Expired'
    end as f4
from cte;
