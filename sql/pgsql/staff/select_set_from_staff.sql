create or replace function testdb.select_set_from_staff(department testdb.staff.dep%TYPE)
returns setof testdb.staff
language sql
as $$
    select *
    from testdb.staff staff
    where staff.dep = department;
$$;
