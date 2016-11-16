select
  *
from
  user_objects
where
  (lower(object_name)='tbl_demands');

select
  *
from
  user_tab_columns
where
  (lower(table_name)='tbl_demands');

select
  *
from
  all_tab_columns
where
  (lower(owner)='aspnetuser')
  and (lower(table_name)='tbl_demands');

select
  uc.*
from
  user_constraints uc
where
  uc.CONSTRAINT_NAME='SYS_C0015292';

alter table TBL_ZONDER_CALENDAR_DELIVERIES modify contragent_id null;
alter table TBL_ZONDER_CALENDAR_DELIVERIES modify (contragent_id null);

alter table TBL_ZONDER_CALENDAR_DELIVERIES modify vehicle_no not null;
alter table TBL_ZONDER_CALENDAR_DELIVERIES modify (vehicle_no not null enable);