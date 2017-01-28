use testdb
go

/*==============================================================*/
/* Stored procedure: sp_WithRowCount                            */
/*==============================================================*/
if exists (select 1
           from sysobjects
           where id=object_id('sp_WithRowCount')
                 and type='P')
   drop procedure sp_WithRowCount
go

/*==============================================================*/
/* Stored procedure: sp_AfterInsert                             */
/*==============================================================*/
if exists (select 1
           from sysobjects
           where id=object_id('sp_AfterInsert')
                 and type='P')
   drop procedure sp_AfterInsert
go

/*==============================================================*/
/* Table: TestError                                             */
/*==============================================================*/
if exists (select 1
           from sysobjects
           where id=object_id('TestError')
                 and type='U')
   drop table TestError
go 

create table TestError
(
   Id numeric(18) identity constraint NotNullId not null constraint pkTestError primary key,
   UniqueValue integer constraint NotNullUniqueValue not null,
   constraint ukTestErrorUniqueValue unique (UniqueValue)
)
go

/*==============================================================*/
/* Stored procedure: sp_AfterInsert                             */
/*==============================================================*/
create procedure sp_AfterInsert
  @Id numeric(18),
  @UniqueValue integer,
  @NewId numeric(18) output
as
begin
  declare
    @OldId numeric(18),
    @RetVal integer,
    @tmpError integer,
    @tmpStr varchar(256)

  select @OldId=null

  select @OldId=Id
  from TestError
  where Id=@Id

  if @OldId is not null
    begin
      update TestError
      set UniqueValue=@UniqueValue
      where Id=@Id

      select @tmpError=@@error
      select @tmpStr="update @@error: '"||convert(varchar(256),@tmpError)||"'"
      print @tmpStr

      select @Retval=@tmpError

      if @tmpError!=0
        select @NewId=0
      else
        select @NewId=@Id
    end
  else
    begin
      insert into TestError (UniqueValue) values (@UniqueValue)

      select @tmpError=@@error
      select @tmpStr="insert @@error: '"||convert(varchar(256),@tmpError)||"'"
      print @tmpStr

      select @Retval=@tmpError

      if @tmpError!=0
        select @NewId=0
      else
        select @NewId=@@identity
    end

  return(@RetVal)
end
go

/*==============================================================*/
/* Stored procedure: sp_WithRowCount                            */
/*==============================================================*/
create procedure sp_WithRowCount
  @Id numeric(18),
  @UniqueValue integer,
  @NewId numeric(18) output
as
begin
  declare
    @OldId numeric(18),
    @RetVal integer,
    @tmpError integer,
    @tmpStr varchar(256)

  select @OldId=null

  select @OldId=Id
  from TestError
  where Id=@Id

  if @OldId is not null
    begin
      update TestError
      set UniqueValue=@UniqueValue
      where Id=@Id

      if @@rowcount!=1
        begin
          select @tmpError=@@error
          select @tmpStr="update @@error: '"||convert(varchar(256),@tmpError)||"' (@@rowcounr!=1)"
          print @tmpStr

          select @Retval=@tmpError
          select @NewId=0
        end
      else
        begin
          select @tmpError=@@error
          select @tmpStr="update @@error: '"||convert(varchar(256),@tmpError)||"' (@@rowcounr==1)"
          print @tmpStr

          select @Retval=0
          select @NewId=@Id
        end
    end
  else
    begin
      insert into TestError (UniqueValue) values (@UniqueValue)

      if @@rowcount!=1
        begin
          select @tmpError=@@error
          select @tmpStr="insert @@error: '"||convert(varchar(256),@tmpError)||"' (@@rowcounr!=1)"
          print @tmpStr

          select @Retval=@tmpError
          select @NewId=0
        end
      else
        begin
          select @tmpError=@@error
          select @tmpStr="insert @@error: '"||convert(varchar(256),@tmpError)||"' (@@rowcounr==1)"
          print @tmpStr

          select @Retval=0
          select @NewId=@@identity
        end
    end

  return(@RetVal)
end
go

------------------------------------------------------------

/*==============================================================*/
/* Stored procedure: sp_AfterInsert                             */
/*==============================================================*/
delete from TestError
commit

declare
  @Id numeric(18),
  @UniqueValue integer,
  @NewId numeric(18),
  @RetVal integer

select @Id=0
select @UniqueValue=1

-- нормальный insert
exec @RetVal=sp_AfterInsert @Id,
  @UniqueValue,
  @NewId
select @RetVal, @Id, @UniqueValue, @NewId

-- insert с violation of PRIMARY or UNIQUE KEY constraint
exec @RetVal=sp_AfterInsert @Id,
  @UniqueValue,
  @NewId
select @RetVal, @Id, @UniqueValue, @NewId

/*==============================================================*/
/* Stored procedure: sp_WithRowCount                            */
/*==============================================================*/
delete from TestError
commit
declare
  @Id numeric(18),
  @UniqueValue integer,
  @NewId numeric(18),
  @RetVal integer

select @Id=0
select @UniqueValue=1

-- нормальный insert
exec @RetVal=sp_WithRowCount @Id,
  @UniqueValue,
  @NewId
select @RetVal, @Id, @UniqueValue, @NewId

-- insert с violation of PRIMARY or UNIQUE KEY constraint
exec @RetVal=sp_WithRowCount @Id,
  @UniqueValue,
  @NewId
select @RetVal, @Id, @UniqueValue, @NewId
