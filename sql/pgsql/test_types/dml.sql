-- https://habr.com/ru/company/ozontech/blog/645173/

select * from testdb.test_types;
select * from testdb.test_types test_types where test_types.f_date between '2021-10-27'::date and '2021-10-28'::date;
select * from testdb.test_types test_types where test_types.f_time_wo_tz between '10:57:00'::time without time zone and '13:00:00'::time without time zone;
select * from testdb.test_types test_types where test_types.f_time_w_tz between '10:57:00+03:00'::time with time zone and '13:00:00+03:00'::time with time zone;
select * from testdb.test_types test_types where test_types.f_time_w_tz between '07:57:00+00:00'::time with time zone and '10:00:00+00:00'::time with time zone;
select * from testdb.test_types test_types where test_types.f_timestamp_wo_tz::time without time zone between '11:00:00'::time without time zone and '11:30:00'::time without time zone;
select * from testdb.test_types test_types where cast(test_types.f_timestamp_wo_tz as time without time zone) between '11:00:00'::time without time zone and '11:30:00'::time without time zone;
select * from testdb.test_types test_types where test_types.f_timestamp_w_tz::time with time zone between '11:00:00+03:00'::time with time zone and '11:30:00+03:00'::time with time zone;
select * from testdb.test_types test_types where cast(test_types.f_timestamp_w_tz as time with time zone) between '11:00:00+03:00'::time with time zone and '11:30:00+03:00'::time with time zone;

------------------------------------------------------------

select * from testdb.test_types;

update testdb.test_types set f_integer = null where id = 1;

do $$
    declare p_integer testdb.test_types.f_integer%TYPE := 3;
begin

    update
        testdb.test_types
    set
        f_integer = case
                        when p_integer is null
                            then
                                case
                                    when f_integer is null
                                        then
                                            1
                                        else
                                            f_integer
                                end
                            else
                                p_integer
                    end
    where
        id = 1;

end;
$$;

------------------------------------------------------------
