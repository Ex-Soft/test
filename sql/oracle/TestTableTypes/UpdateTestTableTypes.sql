create or replace procedure UpdateTestTableTypes
(
  Id_in TestTableTypes.Id%type,
  FVarchar2_in TestTableTypes.FVarchar2%type default null,
  FNVarchar2_in TestTableTypes.FNVarchar2%type default null,
  FClob_in TestTableTypes.FClob%type default null,
  FNClob_in TestTableTypes.FNClob%type default null,
  FNumber_in TestTableTypes.FNumber%type default null,
  FNumber_Asterisk_0_in TestTableTypes.FNumber_Asterisk_0%type default null,
  FNumber_18_0_in TestTableTypes.FNumber_18_0%type default null,
  FSmallint_in TestTableTypes.FSmallint%type default null,
  FInt_in TestTableTypes.FInt%type default null
)
as
begin
  update
    TestTableTypes
  set
    FVarchar2=FVarchar2_in,
    FNVarchar2=FNVarchar2_in,
    FClob=FClob_in,
    FNClob=FNClob_in,
    FNumber=FNumber_in,
    FNumber_Asterisk_0=FNumber_Asterisk_0_in,
    FNumber_18_0=FNumber_18_0_in,
    FSmallint=FSmallint_in,
    FInt=FInt_in
  where
    (Id=Id_in);

  if (sql%notfound) then
    insert into TestTableTypes
    (Id, FVarchar2, FNVarchar2, FClob, FNClob, FNumber, FNumber_Asterisk_0, FNumber_18_0, FSmallint, FInt)
    values
    (Id_in, FVarchar2_in, FNVarchar2_in, FClob_in, FNClob_in, FNumber_in, FNumber_Asterisk_0_in, FNumber_18_0_in, FSmallint_in, FInt_in);
  end if;
end;
