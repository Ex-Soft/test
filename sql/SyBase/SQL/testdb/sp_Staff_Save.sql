use testdb
go

if exists (select 1
           from  sysobjects
           where
             id=object_id('sp_Staff_Save')
             and type='P')
   drop procedure sp_Staff_Save
go

create procedure sp_Staff_Save
  @ID D_Staff_ID=null,
  @Name D_Staff_Name=null,
  @Salary money=null,
  @Dep int=null,
  @BirthDate datetime=null,
  @NEW_ID smallint output
as
begin
  declare
    @ReturnValue int,
    @IdExists bit

  set @ReturnValue=0
  set @IdExists=0

  if @ID is not null
    begin
      if exists(select 1
                from
                  Staff
                where
                  ID=@ID)
        set @IdExists=1
    end

  if @IdExists=1
    begin
      update
        Staff
      set
        Name=coalesce(@Name,Name),
        Salary=coalesce(@Salary,Salary),
        Dep=coalesce(@Dep,Dep),
        BirthDate=coalesce(@BirthDate,BirthDate)
      where
        ID=@ID
      set @ReturnValue=@@error
      set @NEW_ID=@ID
    end
  else
    begin
      if @ID is null
        select @NEW_ID=max(ID)+1 from Staff
      else
        set @NEW_ID=@ID
      insert into Staff
      (ID, Name, Salary, Dep, BirthDate)
      values
      (@NEW_ID, @Name, @Salary, @Dep, @BirthDate)
      set @ReturnValue=@@error
    end

  return @ReturnValue
end
go