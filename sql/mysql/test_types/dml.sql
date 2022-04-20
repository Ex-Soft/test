select * from test_types;

select current_time(), current_date(), current_timestamp(), curdate();

select * from test_types where f_datetime < date_add(current_time(), INTERVAL -1 DAY);
select * from test_types where f_datetime < date_add(current_time(), INTERVAL 1 DAY);

select
    str_to_date(null, '%m-%d-%Y') as 'col_null', -- null
    str_to_date('', '%m-%d-%Y') as 'col_empty', -- null
    str_to_date(' ', '%m-%d-%Y') as 'col_space', -- null
    str_to_date('02-28-2022', '%m-%d-%Y') as 'col_date', -- '2022-02-28'
    str_to_date(null, '%m-%d-%Y') < date_add(curdate(), interval -1 day) as 'col_cmp_null', -- null
    str_to_date('', '%m-%d-%Y') < date_add(curdate(), interval -1 day) as 'col_cmp_empty', -- 1
    str_to_date(' ', '%m-%d-%Y') < date_add(curdate(), interval -1 day) as 'col_cmp_space', -- 1
    str_to_date('02-28-2022', '%m-%d-%Y') < date_add(curdate(), interval -7 day) as 'col_cmp_date', -- 1
    null < date_add(curdate(), interval -7 day) as 'col_cmp_null_explicit' -- null
from
    dual;

select
    nullif(trim(null), ''), -- null
    nullif(trim(''), ''), -- null
    nullif(trim(' '), ''), -- null
    str_to_date(nullif(trim(' '), ''), '%m-%d-%Y') < date_add(curdate(), interval -7 day) -- null
from
    dual;