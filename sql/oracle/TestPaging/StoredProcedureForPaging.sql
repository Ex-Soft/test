create or replace procedure StoredProcedureForPaging
(
  cur out sys_refcursor,
  start_in int,
  limit_in int
)
as
begin
  open cur for
    select
      p.*
    from (select
            t.*,
            row_number() over (order by t.Val desc) as rn
          from
            TableForPaging t
         ) p
    where
      (p.rn>start_in) and (p.rn<=(start_in+limit_in));
end;