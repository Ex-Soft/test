use master
go

if exists (select 1
            from  sysdatabases
            where  dbid = db_id('testdb'))
   drop database testdb
go

create database testdb
go

use testdb
go

create table Staff(
  ID smallint constraint NotNullConstraintId not null constraint pkStaff primary key,
  Name varchar(50) null,
  Salary money null)
go

insert into staff (ID, Name, Salary) values (1, 'Ленин Владимир Ильич', 10000)
insert into staff (ID, Name, Salary) values (2, 'Сталин Иосиф Иссарионович', 300)
insert into staff (ID, Name, Salary) values (3, 'Хрущев Никита Сергеевич', 5000)
insert into staff (ID, Name, Salary) values (4, 'Брежнев Леонид Ильич', 1500)
insert into staff (ID, Name, Salary) values (5, 'Иванов Иван Иванович', 3000)
insert into staff (ID, Name, Salary) values (6, 'Петров Петр Петрович', 5000)
insert into staff (ID, Name, Salary) values (7, 'Сидоров Сидор Сидорович', 1500)
insert into staff (ID, Name, Salary) values (8, 'Васильев Василий Василиевич', 3000)
commit

create table TestTypes
(FBinary binary(2) null,
 FBit bit,
 FChar char(10) null,
 FDate date null,
 /* FDaten daten null, */
 FDatetime datetime null,
 FDecimal_18_2 decimal(18,2) null,
 FDecimal_18_0 decimal(18,0) null,
 FDoublePrecision double precision null,
 FFloat float null,
 FImage image null,
 FInt int null,
 FMoney money null,
 FNchar nchar(10) null,
 FNumeric_18_2 numeric(18,2) null,
 FNumeric_18_0 numeric(18,0) null,
 FNvarchar nvarchar(10) null,
 FReal real null,
 FSmalldatetime smalldatetime null,
 FSmallint smallint null,
 FSmallmoney smallmoney null,
 FSysname sysname null,
 FText text null,
 FTime time null,
/* FTimen timen null, */
 FTimestamp timestamp null,
 FTinyint tinyint null,
 FUnichar unichar(10) null,
 FUnivarchar univarchar(10) null,
 FVarbinary varbinary(2) null,
 FVarchar varchar(10) null
)
go

create procedure mathtutor
  @mult1 int,
  @mult2 int,
  @result int output
as
  declare
    @RetVal int

  select @result=@mult1 * @mult2
  select @RetVal=@result

  return(@RetVal)

create procedure sp_SalaryMaxList
  @MaxCount int
as
  select Name, Salary
  from Staff S
  where (select count(distinct Salary)
         from Staff
         where Salary > S.Salary
        ) < @MaxCount
  order by Salary desc
return

create procedure TestTransaction
  @WithSelfTransaction tinyint,
  @TransactionCount int output,
  @TransactionState int output,
  @TransactionChained int output
as
begin
  declate
    @RetValue int

  if @WithSelfTransaction=1
    begin transaction

  set @TransactionCount=@@trancount
  set @RetValue=@@trancount
  set @TransactionState=@@transtate
  set @TransactionChained=@@tranchained

  if @WithSelfTransaction=1
    commit transaction

  return(@RetValue)
end
go