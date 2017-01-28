
-----------------------------------------------------------------------------
-- DDL for Database 'testdb'
-----------------------------------------------------------------------------
print '<<<<< CREATING Database - testdb >>>>>'
go

use master
go

IF EXISTS (SELECT 1 FROM sysdatabases WHERE name = 'testdb')
	drop database testdb

IF (@@error != 0)
BEGIN
	PRINT "Error CREATING database 'testdb'"
	SELECT syb_quit()
END
go

create database testdb on testdb = 10
go


-----------------------------------------------------------------------------
-- DDL for Default 'testdb.dbo.DATE_MIN'
-----------------------------------------------------------------------------

print '<<<<< CREATING Default - "testdb.dbo.DATE_MIN" >>>>>'
go 

use testdb
go

setuser 'dbo'
go 

set quoted_identifier on
go 

/*==============================================================*/
/* Default: DATE_MIN                                            */
/* Version:                                                     */
/*   03.10.2008                                                 */
/*==============================================================*/
create default DATE_MIN as '00010101'                                                                                                                                          
go 

set quoted_identifier off
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Default 'testdb.dbo.DATE_MAX'
-----------------------------------------------------------------------------

print '<<<<< CREATING Default - "testdb.dbo.DATE_MAX" >>>>>'
go 

setuser 'dbo'
go 

set quoted_identifier on
go 

/*==============================================================*/
/* Default: DATE_MAX                                            */
/* Version:                                                     */
/*   03.10.2008                                                 */
/*==============================================================*/
create default DATE_MAX as '99991231'                                                                                                                                          
go 

set quoted_identifier off
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_SYSNAME'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_SYSNAME" >>>>>'
go 

exec  sp_addtype 'D_SYSNAME' , 'varchar(30)' , nonull
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_Staff_ID'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_Staff_ID" >>>>>'
go 

exec  sp_addtype 'D_Staff_ID' , 'smallint' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_Staff_Name'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_Staff_Name" >>>>>'
go 

exec  sp_addtype 'D_Staff_Name' , 'varchar(50)' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_NUMERIC10_0'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_NUMERIC10_0" >>>>>'
go 

exec  sp_addtype 'D_NUMERIC10_0' , 'numeric(10,0)' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_NUMERIC18_0'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_NUMERIC18_0" >>>>>'
go 

exec  sp_addtype 'D_NUMERIC18_0' , 'numeric(18,0)' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_PARAM_TYPE'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_PARAM_TYPE" >>>>>'
go 

exec  sp_addtype 'D_PARAM_TYPE' , 'tinyint' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_RECORD_STATE'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_RECORD_STATE" >>>>>'
go 

exec  sp_addtype 'D_RECORD_STATE' , 'tinyint' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_CLIENT_RELATION'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_CLIENT_RELATION" >>>>>'
go 

exec  sp_addtype 'D_CLIENT_RELATION' , 'numeric(18,0)' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_RECORD_MODIFY_TIMESTAMP'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_RECORD_MODIFY_TIMESTAMP" >>>>>'
go 

exec  sp_addtype 'D_RECORD_MODIFY_TIMESTAMP' , 'datetime' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_INSUR_PARAM'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_INSUR_PARAM" >>>>>'
go 

exec  sp_addtype 'D_INSUR_PARAM' , 'smallint' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for UserDefinedDatatype 'testdb.D_INSUR_PRODUCT'
-----------------------------------------------------------------------------

print '<<<<< CREATING UserDefinedDatatype - "testdb.D_INSUR_PRODUCT" >>>>>'
go 

exec  sp_addtype 'D_INSUR_PRODUCT' , 'smallint' , null
go 

SETUSER
go


-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableWithTriggerIUDHistory'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableWithTriggerIUDHistory" >>>>>'
go

setuser 'dbo'
go 

create table TableWithTriggerIUDHistory (
	Id                              numeric(18,0)                    not null  ,
	Value                           varchar(256)                     not null  ,
	RecordModify                    datetime                         not null   
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Staff'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Staff" >>>>>'
go

setuser 'dbo'
go 

create table Staff (
	ID                              smallint                         not null  ,
	Name                            varchar(50)                          null  ,
	Salary                          money                                null  ,
	Dep                             int                                  null  ,
	BirthDate                       datetime                             null  ,
	NullField                       numeric(18,2)                        null  ,
		CONSTRAINT pkStaff PRIMARY KEY CLUSTERED ( ID )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Doc'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Doc" >>>>>'
go

setuser 'dbo'
go 

create table Doc (
	Id                              int                              not null  ,
	DocNo                           varchar(20)                          null  ,
	DocSeries                       varchar(5)                           null  ,
		CONSTRAINT pkDoc PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableWithTriggerIUD'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableWithTriggerIUD" >>>>>'
go

setuser 'dbo'
go 

create table TableWithTriggerIUD (
	Id                              numeric(18,0)                    identity  ,
	Value                           varchar(256)                     not null  ,
	RecordModify                    datetime                         not null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Trigger 'testdb.dbo.Trigger4TableWithTriggerIUD'
-----------------------------------------------------------------------------

print '<<<<< CREATING Trigger - "testdb.dbo.Trigger4TableWithTriggerIUD" >>>>>'
go 

setuser 'dbo'
go 

create trigger Trigger4TableWithTriggerIUD 
on TableWithTriggerIUD 
for insert, update, delete  
as  
begin  
  insert into TableWithTriggerIUDHistory 
  select 
    Id, 
    Value||' (from inserted)', 
    RecordModify 
  from inserted  
  
  insert into TableWithTriggerIUDHistory  
  select 
    Id, 
    Value||' (from deleted)', 
    RecordModify 
  from deleted  
end  
                                                                                                                                      
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestTypes'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestTypes" >>>>>'
go

setuser 'dbo'
go 

create table TestTypes (
	FBinary                         binary(2)                            null  ,
	FBit                            bit                              not null  ,
	FChar                           char(10)                             null  ,
	FDate                           date                                 null  ,
	FDatetime                       datetime                             null  ,
	FDecimal_18_2                   decimal(18,2)                        null  ,
	FDoublePrecision                float(16)                            null  ,
	FFloat                          float(16)                            null  ,
	FImage                          image                                null  ,
	FInt                            int                                  null  ,
	FMoney                          money                                null  ,
	FNchar                          nchar(10)                            null  ,
	FNumeric_18_2                   numeric(18,2)                        null  ,
	FNvarchar                       nvarchar(10)                         null  ,
	FReal                           real                                 null  ,
	FSmalldatetime                  smalldatetime                        null  ,
	FSmallint                       smallint                             null  ,
	FSmallmoney                     smallmoney                           null  ,
	FSysname                        sysname(1)                           null  ,
	FText                           text                                 null  ,
	FTime                           time                                 null  ,
	FTimestamp                      timestamp                            null  ,
	FTinyint                        tinyint                              null  ,
	FUnichar                        unichar(10)                          null  ,
	FUnivarchar                     univarchar(10)                       null  ,
	FVarbinary                      varbinary(2)                         null  ,
	FVarchar                        varchar(10)                          null  ,
	FDecimal_18_0                   decimal(18,0)                        null  ,
	FNumeric_18_0                   numeric(18,0)                        null  ,
	FDecimal_10_0                   decimal(10,0)                        null  ,
	FNumeric_10_0                   numeric(10,0)                        null  ,
	FDecimal_4_0                    decimal(4,0)                         null  ,
	FDecimal_4_2                    decimal(4,2)                         null  ,
	FNumeric_4_0                    numeric(4,0)                         null  ,
	FNumeric_4_2                    numeric(4,2)                         null  ,
	FNumeric_10_6                   numeric(10,6)                        null  ,
	FDecimal_10_6                   decimal(10,6)                        null  ,
	FNumeric_22_4                   numeric(22,4)                        null  ,
	FDecimal_22_4                   decimal(22,4)                        null  ,
	FNumeric_24_6                   numeric(24,6)                        null  ,
	FDecimal_24_6                   decimal(24,6)                        null  ,
	FDecimal_18_4                   decimal(18,4)                        null  ,
	FNumeric_18_4                   numeric(18,4)                        null   
)
lock datarows
 on 'default'
partition by roundrobin 1
go 

sp_placeobject 'default', 'dbo.TestTypes.tTestTypes'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableWithTriggerUDHistory'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableWithTriggerUDHistory" >>>>>'
go

setuser 'dbo'
go 

create table TableWithTriggerUDHistory (
	Id                              numeric(18,0)                    not null  ,
	Value                           varchar(256)                     not null  ,
	RecordModify                    datetime                         not null   
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableWithTriggerUD'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableWithTriggerUD" >>>>>'
go

setuser 'dbo'
go 

create table TableWithTriggerUD (
	Id                              numeric(18,0)                    identity  ,
	Value                           varchar(256)                     not null  ,
	RecordModify                    datetime                         not null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Trigger 'testdb.dbo.Trigger4TableWithTriggerUD'
-----------------------------------------------------------------------------

print '<<<<< CREATING Trigger - "testdb.dbo.Trigger4TableWithTriggerUD" >>>>>'
go 

setuser 'dbo'
go 

create trigger Trigger4TableWithTriggerUD  
on TableWithTriggerUD 
for update, delete  
as  
begin  
  insert into TableWithTriggerUDHistory 
  select 
    Id, 
    Value||' (from inserted)', 
    RecordModify 
  from inserted  
  
  insert into TableWithTriggerUDHistory  
  select 
    Id, 
    Value||' (from deleted)', 
    RecordModify 
  from deleted  
end  
                                                                                                                                                 
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Student'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Student" >>>>>'
go

setuser 'dbo'
go 

create table Student (
	ID                              numeric(18,0)                    identity  ,
	StudentID                       numeric(18,0)                    not null  ,
	PredmetId                       numeric(18,0)                    not null  ,
	FDateTime                       datetime                             null  ,
	Status                          char(2)                          not null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Test'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Test" >>>>>'
go

setuser 'dbo'
go 

create table Test (
	Id                              numeric(18,0)                    identity  ,
	Value                           varchar(256)                     not null   
)
lock datarows
with identity_gap = 5 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.DateBetween'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.DateBetween" >>>>>'
go

setuser 'dbo'
go 

create table DateBetween (
	Id                              tinyint                          not null  ,
	DateBegin                       date                                 null  ,
	DateEnd                         date                                 null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.EmptyTable'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.EmptyTable" >>>>>'
go

setuser 'dbo'
go 

create table EmptyTable (
	Id                              numeric(18,0)                    identity   
)
lock datarows
with exp_row_size = 1, identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TESTCHAR'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TESTCHAR" >>>>>'
go

setuser 'dbo'
go 

create table TESTCHAR (
	ID                              numeric(18,0)                    identity  ,
	RUSSIAN_LETTERS                 char(30)                             null  ,
	UKRAINIAN_LETTERS               char(30)                             null   
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestIdentity'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestIdentity" >>>>>'
go

setuser 'dbo'
go 

create table TestIdentity (
	Id                              numeric(2,0)                     identity  ,
	Value                           varchar(255)                     not null  ,
		CONSTRAINT pkTestIdentity PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
with identity_gap = 5 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.ContragentDetailWGenIdDate'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.ContragentDetailWGenIdDate" >>>>>'
go

setuser 'dbo'
go 

create table ContragentDetailWGenIdDate (
	GenId                           numeric(18,0)                    identity  ,
	Name                            varchar(1024)                    not null  ,
	RecordModify                    datetime                         not null   
)
lock datarows
with identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.ContragentMasterWGenIdDate'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.ContragentMasterWGenIdDate" >>>>>'
go

setuser 'dbo'
go 

create table ContragentMasterWGenIdDate (
	Id                              numeric(18,0)                    not null  ,
	GenId                           numeric(18,0)                    not null   
)
lock datarows
with exp_row_size = 1 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.T1'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.T1" >>>>>'
go

setuser 'dbo'
go 

create table T1 (
	Id                              numeric(2,0)                     identity  ,
	Value                           varchar(255)                     not null  ,
		CONSTRAINT pkT1 PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
with identity_gap = 20 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.ContragentWGenIdDate'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.ContragentWGenIdDate" >>>>>'
go

setuser 'dbo'
go 

create table ContragentWGenIdDate (
	Id                              numeric(18,0)                    not null  ,
	GenId                           numeric(18,0)                    identity  ,
	Name                            varchar(1024)                    not null  ,
	RecordModify                    datetime                         not null   
)
lock datarows
with identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.T2'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.T2" >>>>>'
go

setuser 'dbo'
go 

create table T2 (
	Id                              numeric(2,0)                     identity  ,
	Value                           varchar(255)                     not null  ,
	ValueInt                        int                                  null  ,
		CONSTRAINT pkT2 PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
with identity_gap = 20 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableProjects'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableProjects" >>>>>'
go

setuser 'dbo'
go 

create table TableProjects (
	id                              numeric(18,0)                    identity  ,
	date_create                     date                             not null  ,
	name_project                    varchar(256)                     not null  ,
	year_project                    int                              not null   
)
lock datarows
with identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Insurant'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Insurant" >>>>>'
go

setuser 'dbo'
go 

create table Insurant (
	CentId                          smallint                         not null  ,
	InstId                          smallint                         not null  ,
	NodeId                          smallint                         not null  ,
	PersonId                        int                              not null  ,
	NameN                           varchar(100)                         null  ,
	PersonType                      int                              not null  ,
		CONSTRAINT pkInsurance PRIMARY KEY CLUSTERED ( CentId, InstId, NodeId, PersonId )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.T3'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.T3" >>>>>'
go

setuser 'dbo'
go 

create table T3 (
	Id                              numeric(2,0)                     identity  ,
	Value                           varchar(255)                     not null  ,
		CONSTRAINT pkT3 PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
with identity_gap = 20 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.NaturPerson'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.NaturPerson" >>>>>'
go

setuser 'dbo'
go 

create table NaturPerson (
	CentId                          smallint                         not null  ,
	InstId                          smallint                         not null  ,
	NodeId                          smallint                         not null  ,
	PersonId                        int                              not null  ,
	PasspNo                         varchar(20)                          null  ,
		CONSTRAINT pkNaturPerson PRIMARY KEY CLUSTERED ( CentId, InstId, NodeId, PersonId )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestDefault'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestDefault" >>>>>'
go

setuser 'dbo'
go 

create table TestDefault (
	Id                              int                              identity  ,
	DateBeginWODefault              date                              not null  ,
	DateEndWODefault                date                              not null  ,
	DateBeginWDefault               date                            DEFAULT  '00010101' 
  not null  ,
	DateEndWDefault                 date                            DEFAULT  '99991231' 
  not null   
)
lock datarows
with exp_row_size = 1, identity_gap = 10 on 'default'
go 


sp_bindefault 'dbo.DATE_MIN', 'TestDefault.DateBeginWODefault'
go 

sp_bindefault 'dbo.DATE_MAX', 'TestDefault.DateEndWODefault'
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.JuridPerson'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.JuridPerson" >>>>>'
go

setuser 'dbo'
go 

create table JuridPerson (
	CentId                          smallint                         not null  ,
	InstId                          smallint                         not null  ,
	NodeId                          smallint                         not null  ,
	PersonId                        int                              not null  ,
	ChiefPostN                      varchar(40)                          null  ,
		CONSTRAINT pkJuridPerson PRIMARY KEY CLUSTERED ( CentId, InstId, NodeId, PersonId )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.cat'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.cat" >>>>>'
go

setuser 'dbo'
go 

create table cat (
	idcat                           numeric(18,0)                    identity  ,
	titlecat                        varchar(256)                     not null  ,
		CONSTRAINT pkCat PRIMARY KEY CLUSTERED ( idcat )  on 'default' 
)
lock datarows
with identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.sec'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.sec" >>>>>'
go

setuser 'dbo'
go 

create table sec (
	idsec                           numeric(18,0)                    identity  ,
	idcat                           numeric(18,0)                    not null  ,
	name                            varchar(256)                     not null  ,
	titlesec                        varchar(256)                     not null  ,
		CONSTRAINT pkSec PRIMARY KEY CLUSTERED ( idsec )  on 'default' 
)
lock datarows
with identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestGroupBy'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestGroupBy" >>>>>'
go

setuser 'dbo'
go 

create table TestGroupBy (
	Id1                             int                              not null  ,
	Id2                             int                              not null  ,
	Id3                             int                              not null  ,
	Val                             int                              not null   
)
lock datarows
with exp_row_size = 1 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.poll'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.poll" >>>>>'
go

setuser 'dbo'
go 

create table poll (
	idpoll                          numeric(18,0)                    identity  ,
	idsec                           numeric(18,0)                    not null  ,
	value                           int                              not null  ,
		CONSTRAINT pkPoll PRIMARY KEY CLUSTERED ( idpoll )  on 'default' 
)
lock datarows
with exp_row_size = 1, identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestNotExists'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestNotExists" >>>>>'
go

setuser 'dbo'
go 

create table TestNotExists (
	Id                              numeric(18,0)                    not null  ,
	Val                             varchar(256)                     not null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableCreatedFromSP'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableCreatedFromSP" >>>>>'
go

setuser 'dbo'
go 

create table TableCreatedFromSP (
	id                              tinyint                          not null   
)
lock datarows
with exp_row_size = 1 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableAnyTest'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableAnyTest" >>>>>'
go

setuser 'dbo'
go 

create table TableAnyTest (
	Id                              numeric(18,0)                    identity  ,
	Name                            varchar(256)                         null  ,
		CONSTRAINT pkTableAnyTest PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Test_Test_Table'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Test_Test_Table" >>>>>'
go

setuser 'dbo'
go 

create table Test_Test_Table (
	ID                              numeric(18,0)                    identity  ,
	Name                            varchar(256)                         null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableWUniqueKey'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableWUniqueKey" >>>>>'
go

setuser 'dbo'
go 

create table TableWUniqueKey (
	Id                              numeric(18,0)                    not null  ,
	Value                           varchar(254)                     not null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Index 'TableWUniqueKeyId'
-----------------------------------------------------------------------------

print '<<<<< CREATING Index - "TableWUniqueKeyId" >>>>>'
go 

create unique nonclustered index TableWUniqueKeyId 
on testdb.dbo.TableWUniqueKey(Id)
go 


-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.DetailsDetailsTable'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.DetailsDetailsTable" >>>>>'
go

setuser 'dbo'
go 

create table DetailsDetailsTable (
	IdMaster                        numeric(2,0)                     not null  ,
	IdDetailsLevelI                 numeric(2,0)                     not null  ,
	Id                              numeric(2,0)                     not null  ,
	Value                           varchar(255)                         null  ,
		CONSTRAINT pkDetailsDetailsTable PRIMARY KEY CLUSTERED ( IdMaster, IdDetailsLevelI, Id )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestCOALESCE1'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestCOALESCE1" >>>>>'
go

setuser 'dbo'
go 

create table TestCOALESCE1 (
	Id                              numeric(10,0)                    not null  ,
	Value                           varchar(100)                         null  ,
	ValueNumeric10_0                numeric(10,0)                        null  ,
	ValueDNumeric10_0               D_NUMERIC10_0                        null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestCharVarchar'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestCharVarchar" >>>>>'
go

setuser 'dbo'
go 

create table TestCharVarchar (
	Id                              int                              not null  ,
	FChar                           char(32)                             null  ,
	FVarchar                        varchar(32)                          null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestCOALESCE2'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestCOALESCE2" >>>>>'
go

setuser 'dbo'
go 

create table TestCOALESCE2 (
	Id                              numeric(18,0)                    not null  ,
	Value                           varchar(180)                         null  ,
	ValueNumeric18_0                numeric(18,0)                        null  ,
	ValueDNumeric18_0               D_NUMERIC18_0                        null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.UMaster'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.UMaster" >>>>>'
go

setuser 'dbo'
go 

create table UMaster (
	Id                              numeric(18,0)                    identity  ,
	RelationId                      numeric(18,0)                    not null   
)
lock datarows
with exp_row_size = 1, identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestString'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestString" >>>>>'
go

setuser 'dbo'
go 

create table TestString (
	Id                              int                              not null  ,
	Val                             varchar(254)                         null  ,
		CONSTRAINT pkTestString PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestError'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestError" >>>>>'
go

setuser 'dbo'
go 

create table TestError (
	Id                              numeric(18,0)                    identity  ,
	UniqueValue                     int                              not null  ,
		CONSTRAINT ukTestErrorUniqueValue UNIQUE NONCLUSTERED ( UniqueValue )  on 'default',
		CONSTRAINT pkTestError PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
with exp_row_size = 1 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.URelation'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.URelation" >>>>>'
go

setuser 'dbo'
go 

create table URelation (
	RelationId                      numeric(18,0)                    identity  ,
	SmthId                          numeric(18,0)                    not null   
)
lock datarows
with exp_row_size = 1, identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestCursorMain'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestCursorMain" >>>>>'
go

setuser 'dbo'
go 

create table TestCursorMain (
	Id                              numeric(18,0)                    not null  ,
	Val                             numeric(18,0)                    not null  ,
	Cod                             numeric(18,0)                        null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Presidents'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Presidents" >>>>>'
go

setuser 'dbo'
go 

create table Presidents (
	Id                              tinyint                          not null  ,
	FirstName                       varchar(256)                         null  ,
	LastName                        varchar(256)                         null  ,
	FirstNameEn                     varchar(256)                         null  ,
	LastNameEn                      varchar(256)                         null  ,
	Born                            date                                 null  ,
	Died                            date                                 null  ,
	DateBegin                       date                                 null  ,
	DateEnd                         date                                 null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.PARAM_TYPE'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.PARAM_TYPE" >>>>>'
go

setuser 'dbo'
go 

create table PARAM_TYPE (
	PARAM_TYPE_ID                   tinyint                          not null  ,
	PARAM_TYPE_NAME                 varchar(256)                     not null  ,
	RECORD_STATE                    tinyint                              null  ,
	USER_ID                         numeric(18,0)                        null  ,
	RECORD_MODIFY                   datetime                             null  ,
		CONSTRAINT PK_PARAM_TYPE PRIMARY KEY CLUSTERED ( PARAM_TYPE_ID )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.IDS'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.IDS" >>>>>'
go

setuser 'dbo'
go 

create table IDS (
	TABLE_ID                        int                              not null  ,
	VALUE_ID                        numeric(18,0)                    not null  ,
	TABLE_NAME                      D_SYSNAME                            null   
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.PARAM'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.PARAM" >>>>>'
go

setuser 'dbo'
go 

create table PARAM (
	PARAM_TYPE_ID                   tinyint                          not null  ,
	PARAM_ID                        smallint                         not null  ,
	PARAM_NAME                      varchar(256)                     not null  ,
	PARAM_DB_TYPE                   int                                  null  ,
	RECORD_STATE                    tinyint                              null  ,
	USER_ID                         numeric(18,0)                        null  ,
	RECORD_MODIFY                   datetime                             null  ,
		CONSTRAINT PK_PARAM PRIMARY KEY CLUSTERED ( PARAM_TYPE_ID, PARAM_ID )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.CONTRACT_PARAM_TYPE'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.CONTRACT_PARAM_TYPE" >>>>>'
go

setuser 'dbo'
go 

create table CONTRACT_PARAM_TYPE (
	CONTRACT_PARAM_TYPE_ID          D_PARAM_TYPE                     not null  ,
	CONTRACT_PARAM_TYPE_NAME        varchar(40)                      not null  ,
	RECORD_STATE                    D_RECORD_STATE                       null  ,
	USER_ID                         D_CLIENT_RELATION                    null  ,
	RECORD_MODIFY                   D_RECORD_MODIFY_TIMESTAMP            null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestH'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestH" >>>>>'
go

setuser 'dbo'
go 

create table TestH (
	Id                              smallint                         not null  ,
	Id2                             smallint                         not null  ,
	TType                           varchar(100)                         null  ,
	TValue                          int                                  null  ,
		CONSTRAINT pkTestH PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TEST_CHAR'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TEST_CHAR" >>>>>'
go

setuser 'dbo'
go 

create table TEST_CHAR (
	ID                              numeric(18,0)                    identity  ,
	FCHAR                           varchar(512)                         null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.CONTRACT_PARAM'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.CONTRACT_PARAM" >>>>>'
go

setuser 'dbo'
go 

create table CONTRACT_PARAM (
	CONTRACT_PARAM_TYPE_ID          D_PARAM_TYPE                     not null  ,
	CONTRACT_PARAM_ID               D_INSUR_PARAM                    not null  ,
	CONTRACT_PARAM_NAME             varchar(255)                     not null  ,
	CONTRACT_PARAM_SYSNAME          varchar(10)                          null  ,
	RECORD_STATE                    D_RECORD_STATE                       null  ,
	USER_ID                         D_CLIENT_RELATION                    null  ,
	RECORD_MODIFY                   D_RECORD_MODIFY_TIMESTAMP            null  ,
	PARAM_DB_TYPE                   int                                  null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestStringSort'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestStringSort" >>>>>'
go

setuser 'dbo'
go 

create table TestStringSort (
	Val                             varchar(254)                         null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.IMPORT_PAYMENT'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.IMPORT_PAYMENT" >>>>>'
go

setuser 'dbo'
go 

create table IMPORT_PAYMENT (
	PAYMENT_ID                      numeric(18,0)                    identity  ,
	PAY_BANK_PAYMENT_ID             numeric(18,0)                        null  ,
	DATE_RECEIPT                    date                                 null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.CONTRACT_PARAM_VALUES'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.CONTRACT_PARAM_VALUES" >>>>>'
go

setuser 'dbo'
go 

create table CONTRACT_PARAM_VALUES (
	INSURANCE_PRODUCT_ID            D_INSUR_PRODUCT                  not null  ,
	CONTRACT_PARAM_TYPE_ID          D_PARAM_TYPE                     not null  ,
	CONTRACT_PARAM_ID               D_INSUR_PARAM                    not null  ,
	DATE_BEGIN                      date                              not null  ,
	DATE_END                        date                              not null  ,
	CONTRACT_PARAM_VALUE            numeric(18,10)                   not null  ,
	RECORD_STATE                    D_RECORD_STATE                       null  ,
	USER_ID                         D_CLIENT_RELATION                    null  ,
	RECORD_MODIFY                   D_RECORD_MODIFY_TIMESTAMP            null   
)
lock datarows
 on 'default'
go 


sp_bindefault 'dbo.DATE_MIN', 'CONTRACT_PARAM_VALUES.DATE_BEGIN'
go 

sp_bindefault 'dbo.DATE_MAX', 'CONTRACT_PARAM_VALUES.DATE_END'
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableWIdentityMaster'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableWIdentityMaster" >>>>>'
go

setuser 'dbo'
go 

create table TableWIdentityMaster (
	Id                              numeric(18,0)                    identity  ,
	Value                           varchar(254)                     not null   
)
lock datarows
with identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Trigger 'testdb.dbo.Trigger4TableWIdentityMaster'
-----------------------------------------------------------------------------

print '<<<<< CREATING Trigger - "testdb.dbo.Trigger4TableWIdentityMaster" >>>>>'
go 

setuser 'dbo'
go 

create trigger Trigger4TableWIdentityMaster
on TableWIdentityMaster
for insert
as
begin
  insert into TableWIdentityDetails (IdMaster, Value)
  select
    Id,
    Value
  from inserted  
end                                                                 
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.PAY_BANK'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.PAY_BANK" >>>>>'
go

setuser 'dbo'
go 

create table PAY_BANK (
	PAYMENT_ID                      numeric(18,0)                    identity  ,
	PAYMENT_REAL_DATE               datetime                             null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Books'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Books" >>>>>'
go

setuser 'dbo'
go 

create table Books (
	Id                              numeric(5,0)                     identity  ,
	Title                           varchar(64)                      not null  ,
	Number                          smallint                         not null  ,
	Year                            smallint                         not null  ,
	Rating                          decimal(3,1)                     not null  ,
	CGC                             bit                              not null  ,
	LargeCover                      varchar(64)                      not null  ,
	SmallCover                      varchar(64)                      not null  ,
	Comment                         varchar(512)                         null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableWIdentityDetails'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableWIdentityDetails" >>>>>'
go

setuser 'dbo'
go 

create table TableWIdentityDetails (
	Id                              numeric(18,0)                    identity  ,
	IdMaster                        numeric(18,0)                    not null  ,
	Value                           varchar(254)                     not null   
)
lock datarows
with identity_gap = 10 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestDate'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestDate" >>>>>'
go

setuser 'dbo'
go 

create table TestDate (
	FDate                           date                                 null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestMinId'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestMinId" >>>>>'
go

setuser 'dbo'
go 

create table TestMinId (
	Id                              int                              not null  ,
	IdDate                          date                             not null  ,
		CONSTRAINT pkTestMinId PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
with exp_row_size = 1 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.MasterTable'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.MasterTable" >>>>>'
go

setuser 'dbo'
go 

create table MasterTable (
	Id                              numeric(2,0)                     identity  ,
	Value                           varchar(255)                         null  ,
		CONSTRAINT pkMasterTable PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
with identity_gap = 5 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.DetailsTable'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.DetailsTable" >>>>>'
go

setuser 'dbo'
go 

create table DetailsTable (
	IdMaster                        numeric(2,0)                     not null  ,
	Id                              numeric(2,0)                     not null  ,
	Value                           varchar(255)                         null  ,
		CONSTRAINT pkDetailsTable PRIMARY KEY CLUSTERED ( IdMaster, Id )  on 'default' 
)
lock datarows
 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TOV'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TOV" >>>>>'
go

setuser 'dbo'
go 

create table TOV (
	ID                              int                              not null  ,
	CNT                             int                              not null   
)
lock datarows
with exp_row_size = 1 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.CONTRACT'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.CONTRACT" >>>>>'
go

setuser 'dbo'
go 

create table CONTRACT (
	CONTRACT_ID                     numeric(18,0)                    identity  ,
	CONTRACT_NUMBER                 varchar(255)                     not null  ,
	RECORD_STATE                    tinyint                          not null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.Victim'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.Victim" >>>>>'
go

setuser 'dbo'
go 

create table Victim (
	Id                              int                              not null  ,
	Val                             int                              not null   
)
lock datarows
with exp_row_size = 1 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.CIVIL'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.CIVIL" >>>>>'
go

setuser 'dbo'
go 

create table CIVIL (
	CONTRACT_ID                     numeric(18,0)                    not null  ,
	IS_REPORTING                    bit                              not null  ,
	RECORD_STATE                    tinyint                          not null   
)
lock datarows
with exp_row_size = 1 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.T4'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.T4" >>>>>'
go

setuser 'dbo'
go 

create table T4 (
	GroupId                         int                              not null  ,
	Id                              int                              not null  ,
	Val                             varchar(256)                     not null  ,
		CONSTRAINT pkT4 PRIMARY KEY CLUSTERED ( GroupId, Id )  on 'default' 
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TestCPKWIdentity'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TestCPKWIdentity" >>>>>'
go

setuser 'dbo'
go 

create table TestCPKWIdentity (
	FIdentity                       numeric(2,0)                     identity  ,
	FInt                            int                              not null  ,
	Value                           varchar(256)                         null  ,
		CONSTRAINT pkTestCPKWIdentity PRIMARY KEY CLUSTERED ( FIdentity, FInt )  on 'default' 
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TT1'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TT1" >>>>>'
go

setuser 'dbo'
go 

create table TT1 (
	Id                              int                              not null  ,
	Val                             varchar(256)                     not null  ,
		CONSTRAINT pkTT1 PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TT2'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TT2" >>>>>'
go

setuser 'dbo'
go 

create table TT2 (
	Id                              int                              not null  ,
	TT1_Id                          int                              not null  ,
	FInt                            int                                  null  ,
	FDate                           date                                 null  ,
	FStr                            varchar(256)                         null  ,
		CONSTRAINT pkTT2 PRIMARY KEY CLUSTERED ( Id )  on 'default' 
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TT3'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TT3" >>>>>'
go

setuser 'dbo'
go 

create table TT3 (
	TT2_Id                          int                              not null  ,
	FInt                            int                                  null  ,
	FDate                           date                                 null  ,
	FStr                            varchar(256)                         null   
)
lock datarows
 on 'default'
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for Table 'testdb.dbo.TableLog'
-----------------------------------------------------------------------------
print '<<<<< CREATING Table - "testdb.dbo.TableLog" >>>>>'
go

setuser 'dbo'
go 

create table TableLog (
	Id                              numeric(18,0)                    identity  ,
	FDateTime                       datetime                             null  ,
	spid                            int                                  null  ,
	Message                         varchar(255)                         null   
)
lock datarows
with identity_gap = 10 on 'default'
partition by roundrobin 1
go 


setuser
go 

-----------------------------------------------------------------------------
-- DDL for View 'testdb.dbo.v_GroupUsers'
-----------------------------------------------------------------------------

print '<<<<< CREATING View - "testdb.dbo.v_GroupUsers" >>>>>'
go 

setuser 'dbo'
go 

create view v_GroupUsers 
as  
select  
  cast(PARAM_NAME as tinyint) as GroupUsersId, 
  PARAM_ID as OrdNo, 
  RECORD_STATE as RecordState, 
  USER_ID as UserId, 
  RECORD_MODIFY as RecordModify 
from  
  PARAM  
where  
  (PARAM_TYPE_ID=24)  
  and (RECORD_STATE=100) 
                                                                                                                                                                                                                                               
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for View 'testdb.dbo.v_GroupParams'
-----------------------------------------------------------------------------

print '<<<<< CREATING View - "testdb.dbo.v_GroupParams" >>>>>'
go 

setuser 'dbo'
go 

create view v_GroupParams 
as  
select  
  cast(PARAM_NAME as tinyint) as GroupParamsId, 
  PARAM_ID as OrdNo, 
  RECORD_STATE as RecordState, 
  USER_ID as UserId, 
  RECORD_MODIFY as RecordModify 
from  
  PARAM  
where  
  (PARAM_TYPE_ID=25)  
  and (RECORD_STATE=100) 
                                                                                                                                                                                                                                             
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for View 'testdb.dbo.v_GroupParamsGroupUsers'
-----------------------------------------------------------------------------

print '<<<<< CREATING View - "testdb.dbo.v_GroupParamsGroupUsers" >>>>>'
go 

setuser 'dbo'
go 

create view v_GroupParamsGroupUsers 
as  
select  
  PARAM_ID as OrdNo, 
  cast(PARAM_NAME as tinyint) as GroupParamsId, 
  cast(PARAM_DB_TYPE as tinyint) as GroupUsersId, 
  RECORD_STATE as RecordState, 
  USER_ID as UserId, 
  RECORD_MODIFY as RecordModify 
from  
  PARAM  
where  
  (PARAM_TYPE_ID=26)  
  and (RECORD_STATE=100) 
                                                                                                                                                                                
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for View 'testdb.dbo.v_MemberUserIdMemberParamId'
-----------------------------------------------------------------------------

print '<<<<< CREATING View - "testdb.dbo.v_MemberUserIdMemberParamId" >>>>>'
go 

setuser 'dbo'
go 

create view v_MemberUserIdMemberParamId 
as 
select 
  GUM.MemberUserId, 
  GUM.GroupUsersId, 
  GPGU.GroupParamsId, 
  GPM.MemberParamId, 
  GPM.ParamTypeId 
from 
  v_GroupUsersMembers GUM 
  join v_GroupParamsGroupUsers GPGU on (GPGU.GroupUsersId=GUM.GroupUsersId) 
  join v_GroupParamsMembers GPM on (GPM.GroupParamsId=GPGU.GroupParamsId) 
                                                                                                                                                                      
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for View 'testdb.dbo.v_GroupUsersMembers'
-----------------------------------------------------------------------------

print '<<<<< CREATING View - "testdb.dbo.v_GroupUsersMembers" >>>>>'
go 

setuser 'dbo'
go 

create view v_GroupUsersMembers 
as  
select  
  P.PARAM_TYPE_ID as GroupUsersId, 
  P.PARAM_ID as OrdNo, 
  cast(P.PARAM_NAME as numeric(18,0)) as MemberUserId, 
  P.RECORD_STATE as RecordState, 
  P.USER_ID as UserId, 
  P.RECORD_MODIFY as RecordModify 
from  
  v_GroupUsers GU 
  join PARAM P on (P.PARAM_TYPE_ID=GU.GroupUsersId) 
where  
  (P.RECORD_STATE=100) 
                                                                                                                                               
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for View 'testdb.dbo.v_GroupParamsMembers'
-----------------------------------------------------------------------------

print '<<<<< CREATING View - "testdb.dbo.v_GroupParamsMembers" >>>>>'
go 

setuser 'dbo'
go 

create view v_GroupParamsMembers 
as  
select  
  P.PARAM_TYPE_ID as GroupParamsId, 
  P.PARAM_ID as OrdNo, 
  cast(P.PARAM_NAME as tinyint) as MemberParamId, 
  P.PARAM_DB_TYPE as ParamTypeId, 
  P.RECORD_STATE as RecordState, 
  P.USER_ID as UserId, 
  P.RECORD_MODIFY as RecordModify 
from  
  v_GroupParams GP 
  join PARAM P on (P.PARAM_TYPE_ID=GP.GroupParamsId) 
where  
  (P.RECORD_STATE=100) 
                                                                                                             
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for View 'testdb.dbo.sysquerymetrics'
-----------------------------------------------------------------------------

print '<<<<< CREATING View - "testdb.dbo.sysquerymetrics" >>>>>'
go 

setuser 'dbo'
go 

create view sysquerymetrics (uid, gid, hashkey, id, sequence, exec_min, exec_max, exec_avg, elap_min, elap_max, elap_avg, lio_min, lio_max, lio_avg, pio_min, pio_max, pio_avg, cnt, abort_cnt, qtext) as select  a.uid, -a.gid, a.hashkey, a.id, a.sequence, convert(int, substring(b.text, charindex('e1', b.text) + 3, charindex('e2', b.text) - charindex('e1', b.text) - 4)), convert(int, substring(b.text, charindex('e2', b.text) + 3, charindex('e3', b.text) - charindex('e2', b.text) - 4)), convert(int, substring(b.text, charindex('e3', b.text) + 3, charindex('t1', b.text) - charindex('e3', b.text) - 4)), convert(int, substring(b.text, charindex('t1', b.text) + 3, charindex('t2', b.text) - charindex('t1', b.text) - 4)), convert(int, substring(b.text, charindex('t2', b.text) + 3, charindex('t3', b.text) - charindex('t2', b.text) - 4)), convert(int, substring(b.text, charindex('t3', b.text) + 3, charindex('l1', b.text) - charindex('t3', b.text) - 4)), convert(int, substring(b.text, charindex('l1', b.text) + 3, charindex('l2', b.text) - charindex('l1', b.text) - 4)), convert(int, substring(b.text, charindex('l2', b.text) + 3, charindex('l3', b.text) - charindex('l2', b.text) - 4)), convert(int, substring(b.text, charindex('l3', b.text) + 3, charindex('p1', b.text) - charindex('l3', b.text) - 4)), convert(int, substring(b.text, charindex('p1', b.text) + 3, charindex('p2', b.text) - charindex('p1', b.text) - 4)), convert(int, substring(b.text, charindex('p2', b.text) + 3, charindex('p3', b.text) - charindex('p2', b.text) - 4)), convert(int, substring(b.text, charindex('p3', b.text) + 3, charindex('c', b.text) - charindex('p3', b.text) - 4)), convert(int, substring(b.text, charindex('c', b.text) + 2, charindex('ac', b.text) - charindex('c', b.text) - 3)), convert(int, substring(b.text, charindex('ac', b.text) + 3, char_length(b.text) - charindex('ac', b.text) - 2)), a.text from sysqueryplans a, sysqueryplans b where (a.type = 10) and (b.type =1000) and (a.id = b.id) and a.uid = b.uid and a.gid = b.gid                  
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for View 'testdb.dbo.vDoc'
-----------------------------------------------------------------------------

print '<<<<< CREATING View - "testdb.dbo.vDoc" >>>>>'
go 

setuser 'dbo'
go 

set quoted_identifier on
go 

create view vDoc
as
select
  D.Id,
  D.DocNo,
  D.DocSeries,
  D.DocSeries||(case when (D.DocSeries is not null) and (D.DocNo is not null) then ' ' end)||(case when D.DocNo is not null then 'N ' end)||D.DocNo as DocFullByStd,
  D.DocSeries+(case when (D.DocSeries is not null) and (D.DocNo is not null) then ' ' end)+(case when D.DocNo is not null then 'N ' end)+D.DocNo as DocFullByPlus
from
  Doc D                                                                                                              
go 

set quoted_identifier off
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestDisconnect'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestDisconnect" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestDisconnect 
  @SLEEP char(8)=null, 
  @WITH_TRANSACTION tinyint=null 
as 
begin 
  declare  
    @ReturnValue int, 
    @tmpStr varchar(1024)  
  
  set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') started @ '||convert(varchar(64),getdate(),109)  
  insert into TableLog 
  (FDateTime, spid, Message) 
  values 
  (getdate(), @@spid, @tmpStr) 
 
  set @ReturnValue=@@error 
  if(@ReturnValue!=0) 
    return(@ReturnValue) 
 
  if @WITH_TRANSACTION is not null 
    begin 
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') attempting to start transaction @ '||convert(varchar(64),getdate(),109)  
      insert into TableLog 
      (FDateTime, spid, Message) 
      values 
      (getdate(), @@spid, @tmpStr) 
 
      set @ReturnValue=@@error 
      if(@ReturnValue!=0) 
        return(@ReturnValue) 
 
      begin transaction TestDisconnect 
 
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') transaction started @ '||convert(varchar(64),getdate(),109)  
      insert into TableLog 
      (FDateTime, spid, Message) 
      values 
      (getdate(), @@spid, @tmpStr) 
 
      set @ReturnValue=@@error 
      if(@ReturnValue!=0) 
        begin 
          rollback transaction TestDisconnect 
          return(@ReturnValue) 
        end 
    end 
 
  if @SLEEP is not null  
    begin  
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') WAITFOR started @ '||convert(varchar(64),getdate(),109)  
      insert into TableLog 
      (FDateTime, spid, Message) 
      values 
      (getdate(), @@spid, @tmpStr) 
 
      set @ReturnValue=@@error 
      if(@ReturnValue!=0) 
        begin 
          if @WITH_TRANSACTION is not null 
            rollback transaction TestDisconnect 
          return(@ReturnValue) 
        end 
 
       waitfor delay @SLEEP  
  
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') WAITFOR finished @ '||convert(varchar(64),getdate(),109)  
      insert into TableLog 
      (FDateTime, spid, Message) 
      values 
      (getdate(), @@spid, @tmpStr) 
 
      set @ReturnValue=@@error 
      if(@ReturnValue!=0) 
        begin 
          if @WITH_TRANSACTION is not null 
            rollback transaction TestDisconnect 
          return(@ReturnValue) 
        end 
    end  
 
  set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') select started @ '||convert(varchar(64),getdate(),109)  
  insert into TableLog 
  (FDateTime, spid, Message) 
  values 
  (getdate(), @@spid, @tmpStr) 
 
  set @ReturnValue=@@error 
  if(@ReturnValue!=0) 
    begin 
      if @WITH_TRANSACTION is not null 
        rollback transaction TestDisconnect 
      return(@ReturnValue) 
    end 
 
  select Staff.ID, Staff.Name, Staff.Salary, Staff.Dep, Staff.BirthDate from Staff 
 
  set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') select finished @ '||convert(varchar(64),getdate(),109)  
  insert into TableLog 
  (FDateTime, spid, Message) 
  values 
  (getdate(), @@spid, @tmpStr) 
 
  set @ReturnValue=@@error 
  if(@ReturnValue!=0) 
    begin 
      if @WITH_TRANSACTION is not null 
        rollback transaction TestDisconnect 
      return(@ReturnValue) 
    end 
 
  if @WITH_TRANSACTION is not null 
    begin 
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') attempting to commit transaction @ '||convert(varchar(64),getdate(),109)  
      insert into TableLog 
      (FDateTime, spid, Message) 
      values 
      (getdate(), @@spid, @tmpStr) 
 
      set @ReturnValue=@@error 
      if(@ReturnValue!=0) 
        begin 
          rollback transaction TestDisconnect 
          return(@ReturnValue) 
        end 
 
      commit transaction TestDisconnect 
 
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') transaction commited @ '||convert(varchar(64),getdate(),109)  
      insert into TableLog 
      (FDateTime, spid, Message) 
      values 
      (getdate(), @@spid, @tmpStr) 
 
      set @ReturnValue=@@error 
      if(@ReturnValue!=0) 
        return(@ReturnValue) 
    end 
 
  set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') finished @ '||convert(varchar(64),getdate(),109)  
  insert into TableLog 
  (FDateTime, spid, Message) 
  values 
  (getdate(), @@spid, @tmpStr) 
 
  set @ReturnValue=@@error 
 
  return(@ReturnValue) 
end 
                                                                                                                                                                     
go 


sp_procxmode 'TestDisconnect', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_SalaryMaxList'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_SalaryMaxList" >>>>>'
go 

setuser 'dbo'
go 

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
go 


sp_procxmode 'sp_SalaryMaxList', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes  
  @FDecimal_4_0 decimal(4,0), 
  @FDecimal_4_2 decimal(4,2), 
  @FDecimal_5_0 decimal(5,0), 
  @FDecimal_5_2 decimal(5,2), 
  @FDecimal_8_0 decimal(8,0), 
  @FDecimal_8_2 decimal(8,2), 
  @FDecimal_9_0 decimal(9,0), 
  @FDecimal_9_2 decimal(9,2), 
  @FDecimal_10_0 decimal(10,0), 
  @FDecimal_10_2 decimal(10,2), 
  @FDecimal_18_0 decimal(18,0), 
  @FDecimal_18_2 decimal(18,2), 
  @FNumeric_4_0 numeric(4,0), 
  @FNumeric_4_2 numeric(4,2), 
  @FNumeric_5_0 numeric(5,0), 
  @FNumeric_5_2 numeric(5,2), 
  @FNumeric_8_0 numeric(8,0), 
  @FNumeric_8_2 numeric(8,2), 
  @FNumeric_9_0 numeric(9,0), 
  @FNumeric_9_2 numeric(9,2), 
  @FNumeric_10_0 numeric(10,0), 
  @FNumeric_10_2 numeric(10,2), 
  @FNumeric_18_0 numeric(18,0), 
  @FNumeric_18_2 numeric(18,2), 
  @FMoney money, 
  @FDecimal_4_0_out decimal(4,0) output, 
  @FDecimal_4_2_out decimal(4,2) output, 
  @FDecimal_5_0_out decimal(5,0) output, 
  @FDecimal_5_2_out decimal(5,2) output, 
  @FDecimal_8_0_out decimal(8,0) output, 
  @FDecimal_8_2_out decimal(8,2) output, 
  @FDecimal_9_0_out decimal(9,0) output, 
  @FDecimal_9_2_out decimal(9,2) output, 
  @FDecimal_10_0_out decimal(10,0) output, 
  @FDecimal_10_2_out decimal(10,2) output, 
  @FDecimal_18_0_out decimal(18,0) output, 
  @FDecimal_18_2_out decimal(18,2) output, 
  @FNumeric_4_0_out numeric(4,0) output, 
  @FNumeric_4_2_out numeric(4,2) output, 
  @FNumeric_5_0_out numeric(5,0) output, 
  @FNumeric_5_2_out numeric(5,2) output, 
  @FNumeric_8_0_out numeric(8,0) output, 
  @FNumeric_8_2_out numeric(8,2) output, 
  @FNumeric_9_0_out numeric(9,0) output, 
  @FNumeric_9_2_out numeric(9,2) output, 
  @FNumeric_10_0_out numeric(10,0) output, 
  @FNumeric_10_2_out numeric(10,2) output, 
  @FNumeric_18_0_out numeric(18,0) output, 
  @FNumeric_18_2_out numeric(18,2) output, 
  @FMoney_out money output 
as  
begin 
  declare 
    @RetVal int 
 
  select @FDecimal_4_0_out = @FDecimal_4_0 
  select @FDecimal_4_2_out = @FDecimal_4_2 
  select @FDecimal_5_0_out = @FDecimal_5_0 
  select @FDecimal_5_2_out = @FDecimal_5_2 
  select @FDecimal_8_0_out = @FDecimal_8_0 
  select @FDecimal_8_2_out = @FDecimal_8_2 
  select @FDecimal_9_0_out = @FDecimal_9_0 
  select @FDecimal_9_2_out = @FDecimal_9_2 
  select @FDecimal_10_0_out = @FDecimal_10_0 
  select @FDecimal_10_2_out = @FDecimal_10_2 
  select @FDecimal_18_0_out = @FDecimal_18_0 
  select @FDecimal_18_2_out = @FDecimal_18_2 
  select @FNumeric_4_0_out = @FNumeric_4_0 
  select @FNumeric_4_2_out = @FNumeric_4_2 
  select @FNumeric_5_0_out = @FNumeric_5_0 
  select @FNumeric_5_2_out = @FNumeric_5_2 
  select @FNumeric_8_0_out = @FNumeric_8_0 
  select @FNumeric_8_2_out = @FNumeric_8_2 
  select @FNumeric_9_0_out = @FNumeric_9_0 
  select @FNumeric_9_2_out = @FNumeric_9_2 
  select @FNumeric_10_0_out = @FNumeric_10_0 
  select @FNumeric_10_2_out = @FNumeric_10_2 
  select @FNumeric_18_0_out = @FNumeric_18_0 
  select @FNumeric_18_2_out = @FNumeric_18_2 
  select @FMoney_out = @FMoney 
 
  select @RetVal=65535  
  
  return(@RetVal) 
end 
                                                                                                                                                                                                                                                             
go 


sp_procxmode 'sp_TestTypes', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Decimal_4_0'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Decimal_4_0" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Decimal_4_0 
  @FDecimal_4_0 decimal(4,0), 
  @FDecimal_4_0_out decimal(4,0) output 
as  
begin 
  declare 
    @RetVal int 
 
  select @FDecimal_4_0_out = @FDecimal_4_0 
 
  select @RetVal=65535  
  
  return(@RetVal) 
end 

go 


sp_procxmode 'sp_TestTypes_Decimal_4_0', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Decimal_4_2'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Decimal_4_2" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Decimal_4_2 
  @FDecimal_4_2 decimal(4,2), 
  @FDecimal_4_2_out decimal(4,2) output 
as  
begin 
  declare 
    @RetVal int 
 
  select @FDecimal_4_2_out = @FDecimal_4_2 
 
  select @RetVal=65535  
  
  return(@RetVal) 
end 

go 


sp_procxmode 'sp_TestTypes_Decimal_4_2', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.LockDatarowsSet'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.LockDatarowsSet" >>>>>'
go 

setuser 'dbo'
go 

/*==============================================================*/ 
/* Stored procedure: LockDatarowsSet                            */ 
/* Version:                                                     */ 
/*   26.12.2006                                                 */ 
/*==============================================================*/ 
create procedure LockDatarowsSet 
  @WriteToServerLog int=null 
as 
begin 
  declare 
    @tmpName varchar(30), 
    @tmpId int, 
    @tmpSysStat2 int, 
    @tmpStr varchar(1023), 
    @RetValue int 
 
  create table #TablesList ( 
    name varchar(30), 
    id int, 
    sysstat2 int 
  ) 
  set @RetValue=@@error 
  if (@RetValue!=0) 
    return(@RetValue) 
 
  insert into #TablesList 
  (name, id, sysstat2) 
  select 
    name, 
    id, 
    sysstat2 
  from 
    sysobjects 
  where 
   (type='U') 
  order by name 
 
  declare TablesListCursor cursor 
  for select name, id, sysstat2 
  from #TablesList 
  for read only 
 
  open TablesListCursor 
  fetch TablesListCursor into @tmpName, @tmpId, @tmpSysStat2 
  while (@@sqlstatus=0) 
    begin 
      set @tmpStr='name='''||@tmpName||''' id='||convert(varchar(32),@tmpId)||' sysstat2='||convert(varchar(32),@tmpSysStat2) 
      print @tmpStr 
      if @WriteToServerLog is not null 
        dbcc logprint(@tmpStr) 
 
      if (@tmpSysStat2&32768=32768) 
         or (@tmpSysStat2&2048=2048) 
        begin 
          set @tmpStr=null 
 
          if (@tmpSysStat2&32768=32768) 
            begin 
              if char_length(@tmpStr) is not null 
                set @tmpStr=@tmpStr||' ' 
              set @tmpStr=@tmpStr||'lock datarows (@tmpSysStat2&0x8000=0x8000)' 
            end 
 
          if (@tmpSysStat2&2048=2048) 
            begin 
              if char_length(@tmpStr) is not null 
                set @tmpStr=@tmpStr||' ' 
              set @tmpStr=@tmpStr||'proxy-table (@tmpSysStat2&0x800=0x800)' 
            end 
 
          print @tmpStr 
 
          if @WriteToServerLog is not null 
            dbcc logprint(@tmpStr) 
 
          goto NothingToDo 
        end 
 
      set @tmpStr='alter table '||@tmpName||' lock datarows' 
      print @tmpStr 
      exec (@tmpStr) 
 
      NothingToDo: 
      fetch TablesListCursor into @tmpName, @tmpId, @tmpSysStat2 
    end 
 
  close TablesListCursor 
  deallocate cursor TablesListCursor 
 
  drop table #TablesList 
 
  return(0) 
end 
                                                                                                                                                  
go 


sp_procxmode 'LockDatarowsSet', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Numeric_4_0'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Numeric_4_0" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Numeric_4_0 
  @FNumeric_4_0 numeric(4,0), 
  @FNumeric_4_0_out numeric(4,0) output 
as  
begin 
  declare 
    @RetVal int 
 
  select @FNumeric_4_0_out = @FNumeric_4_0 
 
  select @RetVal=65535  
  
  return(@RetVal) 
end 
 
                                                                                                                                                                                                                                                             
go 


sp_procxmode 'sp_TestTypes_Numeric_4_0', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Numeric_4_2_T'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Numeric_4_2_T" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Numeric_4_2_T 
  @FNumeric_4_2 numeric(4,2), 
  @FNumeric_4_2_out numeric(4,2) output 
as  
begin 
  declare 
    @RetVal int 
 
  update TestTypes set FNumeric_4_2 = @FNumeric_4_2 
  if @@rowcount!=0 
    begin 
      select @FNumeric_4_2_out = FNumeric_4_2 from TestTypes where FNumeric_4_2=@FNumeric_4_2 
      select @RetVal=65535 
    end 
  else 
    begin 
      select @RetVal=-100 
    end 
 
  return(@RetVal) 
end 
                                                      
go 


sp_procxmode 'sp_TestTypes_Numeric_4_2_T', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Money'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Money" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Money 
  @FMoney money, 
  @FMoney_out money output 
as  
begin 
  declare 
    @RetVal int 
 
  select @FMoney_out = @FMoney 
 
  select @RetVal=65535  
  
  return(@RetVal) 
end 
 
                                          
go 


sp_procxmode 'sp_TestTypes_Money', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.SelectFromStaff'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.SelectFromStaff" >>>>>'
go 

setuser 'dbo'
go 

create procedure SelectFromStaff  
  @Name varchar(50), 
  @Salary money,  
  @Dep int,  
  @BirthDate datetime  
  
with recompile  
  
as  
begin  
  select Staff.ID, Staff.Name, Staff.Salary, Staff.Dep, Staff.BirthDate 
  from  
    Staff  
  where  
    (Name like @Name or @Name is null) 
    and (Salary=@Salary or @Salary is null)  
    and (Dep=@Dep or @Dep is null)  
    and (BirthDate=@BirthDate or @BirthDate is null)  
end                                                                           
go 


sp_procxmode 'SelectFromStaff', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Numeric_4_2'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Numeric_4_2" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Numeric_4_2 
  @FNumeric_4_2 numeric(4,2), 
  @FNumeric_4_2_out numeric(4,2) output 
as  
begin 
  declare 
    @RetVal int 
 
  select @FNumeric_4_2_out =@FNumeric_4_2 
 
  select @RetVal=65535  
  
  return(@RetVal) 
end 
 
go 


sp_procxmode 'sp_TestTypes_Numeric_4_2', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestDBCCLogprint'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestDBCCLogprint" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestDBCCLogprint   
  @Message varchar(255)   
as   
begin   
  declare   
    @tmpStr varchar(1023),   
    @RetValue int   
   
  set @tmpStr=convert(varchar(64),getdate(),109)||' TestDBCCLogprint: '''||coalesce(@Message,'NULL')||''''   
  
  print @tmpStr  
   
  dbcc logprint(@tmpStr)   
     
  set @RetValue=@@error   
   
  return(@RetValue)   
end                                                                                                                                         
go 


sp_procxmode 'TestDBCCLogprint', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestTmpTable'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestTmpTable" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestTmpTable 
as 
begin 
  create table #TmpTable( 
    Id numeric(2,0) not null, 
    ValueT1 varchar(255) null, 
    ValueT2 varchar(255) null, 
    ValueT3 varchar(255) null 
  ) 
 
  insert into #TmpTable 
    (Id, ValueT1) 
  select  
    Id, Value 
  from T1 
 
  update #TmpTable 
  set 
    ValueT2=T2.Value 
  from 
    #TmpTable T1, 
    T2 
  where 
    T1.Id=T2.Id 
 
  update #TmpTable 
  set 
    ValueT3=T3.Value 
  from 
    #TmpTable T1, 
    T3 
  where 
    T1.Id=T3.Id 
 
  select #TmpTable.Id, #TmpTable.ValueT1, #TmpTable.ValueT2, #TmpTable.ValueT3 
  from #TmpTable 
  order by Id 
end 
                                                                                                                                          
go 


sp_procxmode 'TestTmpTable', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_SalaryMaxList3'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_SalaryMaxList3" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_SalaryMaxList3   
as   
begin   
  declare 
    @ReturnValue int 
   
  select Name, Salary   
  from Staff S   
  where (select count(distinct Salary)   
         from Staff   
         where Salary > S.Salary   
        ) < 3   
  order by Salary desc   
   
  set @ReturnValue=@@rowcount 
 
  return(@ReturnValue) 
end                                                                                                                                                                         
go 


sp_procxmode 'sp_SalaryMaxList3', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_SalaryMaxListNULL'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_SalaryMaxListNULL" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_SalaryMaxListNULL   
as   
begin   
  declare 
    @ReturnValue int 
   
  select 
    Name, Salary   
  from 
    Staff   
  where 
    ID<0 
 
  set @ReturnValue=@@rowcount 
 
  return(@ReturnValue) 
end                              
go 


sp_procxmode 'sp_SalaryMaxListNULL', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_AnyTest'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_AnyTest" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_AnyTest  
with recompile  
as   
begin  
  declare  
    @tmpInt int,  
    @tmpString varchar(1024)  
  
  set @tmpInt=3  
  
  if (@tmpInt & 0x2) = 0x2  
    begin  
      set @tmpString='(@tmpInt & 0x2) = 0x2'  
      print @tmpString  
  
      if exists (select 1  
                 from  
                   sysobjects  
                 where  
                   id=object_id('TableAnyTest')  
                   and type='U') 
        begin 
          set @tmpString='delete from TableAnyTest' 
          print @tmpString 
          exec (@tmpString) 
        end  
 
      if not exists (select 1  
                     from  
                       sysobjects  
                     where  
                       id=object_id('TableAnyTest')  
                       and type='U')  
        create table TableAnyTest (  
          Id numeric(18) identity,  
          Name varchar(256) null,  
          constraint pkTableAnyTest primary key (Id)  
        )  
      else 
        begin 
          select @tmpInt=count(*) from TableAnyTest 
          set @tmpString='count(*)='||convert(varchar(32),@tmpInt) 
          print @tmpString 
          if @tmpInt>0 
            delete from TableAnyTest  
        end 
 
      insert into TableAnyTest (Name) values ('Иванов Иван Иванович')  
      insert into TableAnyTest (Name) values ('Петров Петр Петрович')  
      insert into TableAnyTest (Name) values ('Сидоров Сидор Сидорович')  
      insert into TableAnyTest (Name) values ('Васильев Василий Васильевич')  
    end  
end 
                                                                                                                                                                                                                                 
go 


sp_procxmode 'sp_AnyTest', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_AfterInsert'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_AfterInsert" >>>>>'
go 

setuser 'dbo'
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


sp_procxmode 'sp_AfterInsert', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_WithRowCount'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_WithRowCount" >>>>>'
go 

setuser 'dbo'
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


sp_procxmode 'sp_WithRowCount', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_Staff_Save'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_Staff_Save" >>>>>'
go 

setuser 'dbo'
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


sp_procxmode 'sp_Staff_Save', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestNULL'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestNULL" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestNULL 
as 
begin 
  create table #TestNULLTable( 
    ID1 integer, 
    ID2 integer null) 
 
  insert into #TestNULLTable (ID1, ID2) values (1,1) 
  insert into #TestNULLTable (ID1, ID2) values (2,2) 
  insert into #TestNULLTable (ID1) values (3) 
 
  delete from #TestNULLTable where ID2!=2 
 
  select #TestNULLTable.ID1, #TestNULLTable.ID2 from #TestNULLTable 
end 
                                                                                                                         
go 


sp_procxmode 'TestNULL', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestTransaction'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestTransaction" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestTransaction 
  @WithSelfTransaction tinyint, 
  @TransactionCount int output, 
  @TransactionState int output, 
  @TransactionChained int output 
as 
begin 
  declare 
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


sp_procxmode 'TestTransaction', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_SalaryMaxList34'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_SalaryMaxList34" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_SalaryMaxList34 
as 
begin 
 
  select Name, Salary 
  from Staff S 
  where (select count(distinct Salary) 
         from Staff 
         where Salary > S.Salary 
        ) < 3 
  order by Salary desc 
 
  select Name, Salary 
  from Staff S 
  where (select count(distinct Salary) 
         from Staff 
         where Salary > S.Salary 
        ) < 4 
  order by Salary desc 
 
end 
                                                                                                         
go 


sp_procxmode 'sp_SalaryMaxList34', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.get_GROUP_PARAMS'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.get_GROUP_PARAMS" >>>>>'
go 

setuser 'dbo'
go 

create procedure get_GROUP_PARAMS 
  @ParamTypeId int, 
  @UserId numeric(18,0)=null 
as 
begin 
  declare 
    @ActiveRecord tinyint 
 
  set @ActiveRecord=100 
 
  if @ParamTypeId=1 
    begin 
      if (@UserId is null) 
        select 
          PT.PARAM_TYPE_ID as GroupParamId, 
          PT.PARAM_TYPE_NAME as GroupParamName 
        from 
          PARAM_TYPE PT 
        where 
          PT.RECORD_STATE=@ActiveRecord 
        order by PT.PARAM_TYPE_NAME 
      else 
        select 
          PT.PARAM_TYPE_ID as GroupParamId, 
          PT.PARAM_TYPE_NAME as GroupParamName 
        from 
          v_MemberUserIdMemberParamId MUMP 
          join PARAM_TYPE PT on (MUMP.MemberParamId=PT.PARAM_TYPE_ID) 
        where 
         (MUMP.ParamTypeId=@ParamTypeId) 
         and (MUMP.MemberUserId=@UserId) 
         and (PT.RECORD_STATE=@ActiveRecord) 
        order by PT.PARAM_TYPE_NAME 
    end 
end 
                                                                                                             
go 


sp_procxmode 'get_GROUP_PARAMS', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_SalaryMaxListWReturnOnly'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_SalaryMaxListWReturnOnly" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_SalaryMaxListWReturnOnly  
  @MaxCount int  
as 
begin  
  declare 
    @RC int, 
    @tmpString varchar(256) 
 
  select Name, Salary  
  from Staff S  
  where (select count(distinct Salary)  
         from Staff  
         where Salary > S.Salary  
        ) < @MaxCount  
  order by Salary desc 
 
  set @RC=@@rowcount 
  set @tmpString='@@rowcount='||convert(varchar(256),@RC) 
  print @tmpString 
  return(@RC) 
end 
                                                                   
go 


sp_procxmode 'sp_SalaryMaxListWReturnOnly', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_SalaryMaxListWReturn_Output'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_SalaryMaxListWReturn_Output" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_SalaryMaxListWReturn_Output 
  @MaxCount int, 
  @RC int output  
as 
begin  
  declare 
    @tmpString varchar(256) 
 
  select Name, Salary  
  from Staff S  
  where (select count(distinct Salary)  
         from Staff  
         where Salary > S.Salary  
        ) < @MaxCount  
  order by Salary desc 
 
  set @RC=@@rowcount 
  set @tmpString='@@rowcount='||convert(varchar(256),@RC) 
  print @tmpString 
  return(@RC) 
end 
                                                            
go 


sp_procxmode 'sp_SalaryMaxListWReturn_Output', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.DelNotDigitAndLetter'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.DelNotDigitAndLetter" >>>>>'
go 

setuser 'dbo'
go 

/*==============================================================*/ 
/* Stored procedure: DelNotDigitAndLetter                       */ 
/* Version:                                                     */ 
/*   09.08.2007                                                 */ 
/*==============================================================*/ 
create procedure DelNotDigitAndLetter 
  @aStr varchar(1024), 
  @aStrOut varchar(1024) output 
as 
begin 
  declare 
    @len smallint, 
    @i smallint, 
    @code tinyint 
 
  set @aStrOut=null 
  set @len=char_length(@aStr) 
  set @i=1 
 
  while @i<=@len 
    begin 
      set @code=ascii(substring(@aStr,@i,1)) 
      if (@code>=48 and @code<=57) /* 0..9 */ 
         or (@code>=65 and @code<=90) /* A..Z */ 
         or (@code>=97 and @code<=122) /* a..z */ 
         or (@code>=192 and @code<=223) /* А..Я */ 
         or (@code>=224 and @code<=255) /* а..я */ 
         or @code=165 or @code=180 /* CYRILLIC LETTER GE WITH UPTURN */ 
         or @code=129 or @code=131 /* CYRILLIC LETTER GJE */ 
         or @code=128 or @code=144 /* CYRILLIC LETTER DJE */ 
         or @code=170 or @code=186 /* CYRILLIC LETTER UKRAINIAN IE */ 
         or @code=168 or @code=184 /* CYRILLIC LETTER IO */ 
         or @code=189 or @code=190 /* CYRILLIC LETTER DZE */ 
         or @code=178 or @code=179 /* CYRILLIC LETTER BYELORUSSIAN-UKRAINIAN I */ 
         or @code=175 or @code=191 /* CYRILLIC LETTER YI */ 
         or @code=163 or @code=188 /* CYRILLIC LETTER JE */ 
         or @code=141 or @code=157 /* CYRILLIC LETTER KJE */ 
         or @code=138 or @code=154 /* CYRILLIC LETTER LJE */ 
         or @code=140 or @code=156 /* CYRILLIC LETTER NJE */ 
         or @code=142 or @code=158 /* CYRILLIC LETTER TSHE */ 
         or @code=161 or @code=162 /* CYRILLIC LETTER SHORT U */ 
         or @code=143 or @code=159 /* CYRILLIC LETTER DZHE */ 
        set @aStrOut=@aStrOut+char(@code) 
      set @i=@i+1 
    end 
end 
                                                                                
go 


sp_procxmode 'DelNotDigitAndLetter', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.CyrillicExists'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.CyrillicExists" >>>>>'
go 

setuser 'dbo'
go 

/*==============================================================*/ 
/* Stored procedure: CyrillicExists                             */ 
/* Version:                                                     */ 
/*   09.08.2007                                                 */ 
/*==============================================================*/ 
create procedure CyrillicExists 
  @aStr varchar(1024) 
as 
begin 
  declare 
    @len smallint, 
    @i smallint, 
    @code tinyint, 
    @Result int 
 
  set @Result=0 
 
  set @len=char_length(@aStr) 
  set @i=1 
 
  while @i<=@len 
    begin 
      set @code=ascii(substring(@aStr,@i,1)) 
      if (@code>=192 and @code<=223) /* А..Я */ 
         or (@code>=224 and @code<=255) /* а..я */ 
         or @code=165 or @code=180 /* CYRILLIC LETTER GE WITH UPTURN */ 
         or @code=129 or @code=131 /* CYRILLIC LETTER GJE */ 
         or @code=128 or @code=144 /* CYRILLIC LETTER DJE */ 
         or @code=170 or @code=186 /* CYRILLIC LETTER UKRAINIAN IE */ 
         or @code=168 or @code=184 /* CYRILLIC LETTER IO */ 
         or @code=189 or @code=190 /* CYRILLIC LETTER DZE */ 
         or @code=178 or @code=179 /* CYRILLIC LETTER BYELORUSSIAN-UKRAINIAN I */ 
         or @code=175 or @code=191 /* CYRILLIC LETTER YI */ 
         or @code=163 or @code=188 /* CYRILLIC LETTER JE */ 
         or @code=141 or @code=157 /* CYRILLIC LETTER KJE */ 
         or @code=138 or @code=154 /* CYRILLIC LETTER LJE */ 
         or @code=140 or @code=156 /* CYRILLIC LETTER NJE */ 
         or @code=142 or @code=158 /* CYRILLIC LETTER TSHE */ 
         or @code=161 or @code=162 /* CYRILLIC LETTER SHORT U */ 
         or @code=143 or @code=159 /* CYRILLIC LETTER DZHE */ 
        begin 
          set @Result=1 
          break 
        end 
 
      set @i=@i+1 
    end 
 
  return(@Result) 
end 
                                                                                                                                                                                                             
go 


sp_procxmode 'CyrillicExists', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.UpdateTestTypes'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.UpdateTestTypes" >>>>>'
go 

setuser 'dbo'
go 

create procedure UpdateTestTypes 
  @Decimal_18_4 decimal(18,4) 
as 
begin 
  update TestTypes set FDecimal_18_4=@Decimal_18_4 
end 
                                                                                                                          
go 


sp_procxmode 'UpdateTestTypes', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_WithInputOutput'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_WithInputOutput" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_WithInputOutput  
  @InputParam int,  
  @InputOutputParam int output,  
  @OutputParam int output   
as     
begin   
  declare 
    @tmpStr varchar(1024) 
 
  set @tmpStr='sp_WithInputOutput(@InputParam='||convert(varchar(64),@InputParam)||', @InputOutputParam='||convert(varchar(64),@InputOutputParam)||', @OutputParam='||convert(varchar(64),@OutputParam)||')' 
  print @tmpStr 
   
  set @InputParam=@InputOutputParam  
  set @OutputParam=@InputOutputParam  
  set @InputOutputParam=999 
 
  set @tmpStr='sp_WithInputOutput(@InputParam='||convert(varchar(64),@InputParam)||', @InputOutputParam='||convert(varchar(64),@InputOutputParam)||', @OutputParam='||convert(varchar(64),@OutputParam)||')' 
  print @tmpStr 
 
end 
                     
go 


sp_procxmode 'sp_WithInputOutput', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.UpdateIDS'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.UpdateIDS" >>>>>'
go 

setuser 'dbo'
go 

create procedure UpdateIDS  
  @TABLE_ID int,  
  @VALUE_ID numeric(18,0),  
  @TABLE_NAME D_SYSNAME,  
  @SLEEP char(8)=null  
as  
begin  
  
  declare  
    @ReturnValue int, 
    @tmpStr varchar(1024)  
  
  set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') started @ '||convert(varchar(64),getdate(),109)  
  print @tmpStr  
  
  if exists (select 1  
             from IDS  
             where  
               TABLE_ID=@TABLE_ID)  
    begin  
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') UPDATE started @ '||convert(varchar(64),getdate(),109)  
      print @tmpStr  
  
      update  
        IDS  
      set  
        VALUE_ID=@VALUE_ID,  
        TABLE_NAME=@TABLE_NAME  
      where  
        TABLE_ID=@TABLE_ID  
      set @ReturnValue=@@error 
 
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') UPDATE finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')' 
      print @tmpStr  
    end  
  else  
    begin  
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') INSERT started @ '||convert(varchar(64),getdate(),109)  
      print @tmpStr  
  
      insert into IDS  
      (TABLE_ID, VALUE_ID, TABLE_NAME)  
      values  
      (@TABLE_ID, @VALUE_ID, @TABLE_NAME)  
      set @ReturnValue=@@error 
 
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') INSERT finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')' 
      print @tmpStr  
    end  
  if @SLEEP is not null  
    begin  
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') WAITFOR started @ '||convert(varchar(64),getdate(),109)  
      print @tmpStr  
  
      waitfor delay @SLEEP  
  
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') WAITFOR finished @ '||convert(varchar(64),getdate(),109)  
      print @tmpStr  
    end  
  
  set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')'  
  print @tmpStr 
 
  return(@ReturnValue) 
end 
                                                                                                          
go 


sp_procxmode 'UpdateIDS', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.UpdateWTIDS'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.UpdateWTIDS" >>>>>'
go 

setuser 'dbo'
go 

create procedure UpdateWTIDS   
  @TABLE_ID int,   
  @VALUE_ID numeric(18,0),   
  @TABLE_NAME D_SYSNAME,   
  @SLEEP char(8)=null,  
  @WITH_TRANSACTION tinyint=null  
as   
begin   
   
  declare  
    @ReturnValue int,  
    @tmpStr varchar(1024)   
   
  set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') started @ '||convert(varchar(64),getdate(),109) 
  print @tmpStr   
  
  if @WITH_TRANSACTION is not null  
    begin  
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') begin transaction @ '||convert(varchar(64),getdate(),109)   
      print @tmpStr   
  
      begin transaction  
    end  
  
  if exists (select 1   
             from IDS   
             where   
               TABLE_ID=@TABLE_ID)   
    begin   
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') UPDATE started @ '||convert(varchar(64),getdate(),109)   
      print @tmpStr   
   
      update   
        IDS   
      set   
        VALUE_ID=@VALUE_ID,   
        TABLE_NAME=@TABLE_NAME   
      where   
        TABLE_ID=@TABLE_ID   
      set @ReturnValue=@@error 
 
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') UPDATE finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')' 
      print @tmpStr 
 
      if (@WITH_TRANSACTION is not null) 
         and @ReturnValue!=0 
        begin 
          set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') rollback transaction @ '||convert(varchar(64),getdate(),109)   
          print @tmpStr   
  
          rollback transaction 
 
          return(@ReturnValue) 
        end 
    end   
  else   
    begin   
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') INSERT started @ '||convert(varchar(64),getdate(),109)   
      print @tmpStr   
   
      insert into IDS   
      (TABLE_ID, VALUE_ID, TABLE_NAME)   
      values   
      (@TABLE_ID, @VALUE_ID, @TABLE_NAME)   
      set @ReturnValue=@@error 
 
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') INSERT finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')' 
      print @tmpStr 
 
      if (@WITH_TRANSACTION is not null) 
         and @ReturnValue!=0 
        begin 
          set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') rollback transaction @ '||convert(varchar(64),getdate(),109)   
          print @tmpStr   
  
          rollback transaction 
 
          return(@ReturnValue) 
        end 
    end   
 
  if @SLEEP is not null   
    begin   
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') WAITFOR started @ '||convert(varchar(64),getdate(),109)   
      print @tmpStr   
   
      waitfor delay @SLEEP   
   
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') WAITFOR finished @ '||convert(varchar(64),getdate(),109)   
      print @tmpStr   
    end   
  
  if @WITH_TRANSACTION is not null  
    begin  
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') commit transaction @ '||convert(varchar(64),getdate(),109)   
      print @tmpStr   
  
      commit transaction  
    end  
   
  set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')' 
  print @tmpStr   
end                                                                                                                                                       
go 


sp_procxmode 'UpdateWTIDS', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Decimal_10_6'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Decimal_10_6" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Decimal_10_6 
  @FDecimal_10_6 decimal(10,6),   
  @FDecimal_10_6_out decimal(10,6) output   
as    
begin   
  declare   
    @RetVal int, 
    @tmpStr varchar(1024) 
 
  set @tmpStr='sp_TestTypes_Decimal_10_6: @FDecimal_10_6='||convert(varchar(64),@FDecimal_10_6) 
  print @tmpStr 
  dbcc logprint(@tmpStr) 
  set @FDecimal_10_6_out = @FDecimal_10_6   
  set @tmpStr='sp_TestTypes_Decimal_10_6: @FDecimal_10_6='||convert(varchar(64),@FDecimal_10_6)||' @FDecimal_10_6_out='||convert(varchar(64),@FDecimal_10_6_out) 
  print @tmpStr 
  dbcc logprint(@tmpStr) 
   
  set @RetVal=65535    
    
  return(@RetVal)   
end 
                                                                                                                    
go 


sp_procxmode 'sp_TestTypes_Decimal_10_6', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestGetDate'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestGetDate" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestGetDate 
  @aDate date 
as  
begin   
  select @aDate 
  return(0) 
end                                                                                                                                                                   
go 


sp_procxmode 'TestGetDate', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Numeric_10_6'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Numeric_10_6" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Numeric_10_6 
  @FNumeric_10_6 numeric(10,6),   
  @FNumeric_10_6_out numeric(10,6) output   
as    
begin   
  declare   
    @RetVal int, 
    @tmpStr varchar(1024) 
 
  set @tmpStr='sp_TestTypes_Numeric_10_6: @FNumeric_10_6='||convert(varchar(64),@FNumeric_10_6) 
  print @tmpStr 
  dbcc logprint(@tmpStr) 
  set @FNumeric_10_6_out =@FNumeric_10_6   
  set @tmpStr='sp_TestTypes_Numeric_10_6: @FNumeric_10_6='||convert(varchar(64),@FNumeric_10_6)||' @FNumeric_10_6_out='||convert(varchar(64),@FNumeric_10_6_out) 
  print @tmpStr 
  dbcc logprint(@tmpStr) 
 
  select @RetVal=65535    
    
  return(@RetVal)   
end 
                                                                                                                    
go 


sp_procxmode 'sp_TestTypes_Numeric_10_6', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.mathtutor'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.mathtutor" >>>>>'
go 

setuser 'dbo'
go 

create procedure mathtutor  
  @mult1 int,  
  @mult2 int,  
  @result int output  
as  
begin 
  declare  
    @RetVal int, 
    @tmpStr varchar(256) 
  
  set @tmpStr='@result='||convert(varchar(256),@result) 
  print @tmpStr 
 
  set @result=@mult1 * @mult2  
  set @RetVal=@result  
  
  return(@RetVal) 
end 
                                                                                                                                                                                                    
go 


sp_procxmode 'mathtutor', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_ReturnOnly'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_ReturnOnly" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_ReturnOnly 
as   
begin    
  return(9)  
end 
                                                                                                                                                                                            
go 


sp_procxmode 'sp_ReturnOnly', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestParamDirection'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestParamDirection" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestParamDirection  
  @FirstOutput numeric(18,0) output,  
  @First numeric(18,0)  
as  
begin  
  declare  
    @ReturnValue int  
  
  set @ReturnValue=0  
  
  return(@ReturnValue)  
end                                                
go 


sp_procxmode 'TestParamDirection', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_ReturnAndOutputAndSelect'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_ReturnAndOutputAndSelect" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_ReturnAndOutputAndSelect 
  @OutParam int output 
as   
begin 
  declare 
    @tmpInt int 
 
  set @tmpInt=9 
 
  set @OutParam=@tmpInt 
  select @tmpInt 
  return(@tmpInt)  
end 
                                                       
go 


sp_procxmode 'sp_ReturnAndOutputAndSelect', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_ReturnAndOutput'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_ReturnAndOutput" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_ReturnAndOutput 
  @OutParam int output 
as   
begin 
  declare 
    @tmpInt int 
 
  set @tmpInt=9 
 
  set @OutParam=@tmpInt 
  return(@tmpInt)  
end 
                                                                                  
go 


sp_procxmode 'sp_ReturnAndOutput', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.UpdateTestTypes_D_10_6'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.UpdateTestTypes_D_10_6" >>>>>'
go 

setuser 'dbo'
go 

create procedure UpdateTestTypes_D_10_6
  @Decimal_10_6 decimal(10,6) 
as 
begin 
  update TestTypes set FDecimal_10_6=@Decimal_10_6 
end                                                                                                                      
go 


sp_procxmode 'UpdateTestTypes_D_10_6', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.UpdateTestTypes_N_10_6'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.UpdateTestTypes_N_10_6" >>>>>'
go 

setuser 'dbo'
go 

create procedure UpdateTestTypes_N_10_6
  @Numeric_10_6 numeric(10,6) 
as 
begin 
  update TestTypes set FNumeric_10_6=@Numeric_10_6
end                                                                                                                       
go 


sp_procxmode 'UpdateTestTypes_N_10_6', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Decimal_18_8'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Decimal_18_8" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Decimal_18_8 
  @FDecimal_18_8 decimal(18,8), 
  @FDecimal_18_8_out decimal(18,8) output 
as  
begin 
  declare 
    @RetVal int 
 
  select @FDecimal_18_8_out = @FDecimal_18_8 
 
  select @RetVal=65535  
  
  return(@RetVal) 
end                                                                                                                                                                                                                                                          
go 


sp_procxmode 'sp_TestTypes_Decimal_18_8', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestTypes_Numeric_18_8'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestTypes_Numeric_18_8" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestTypes_Numeric_18_8 
  @FNumeric_18_8 numeric(18,8), 
  @FNumeric_18_8_out numeric(18,8) output 
as  
begin 
  declare 
    @RetVal int 
 
  select @FNumeric_18_8_out = @FNumeric_18_8 
 
  select @RetVal=65535  
  
  return(@RetVal) 
end                                                                                                                                                                                                                                                          
go 


sp_procxmode 'sp_TestTypes_Numeric_18_8', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_ReturnAndOutputVarChar255'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_ReturnAndOutputVarChar255" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_ReturnAndOutputVarChar255
  @OutParam varchar(255) output 
as   
begin 
  declare 
    @tmpInt int 
 
  set @tmpInt=9 
 
  set @OutParam='stub'
  return(@tmpInt)  
end                                                                    
go 


sp_procxmode 'sp_ReturnAndOutputVarChar255', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_ReturnAndOutputVarChar256'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_ReturnAndOutputVarChar256" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_ReturnAndOutputVarChar256
  @OutParam varchar(256) output 
as   
begin 
  declare 
    @tmpInt int 
 
  set @tmpInt=9 
 
  set @OutParam='stub'
  return(@tmpInt)  
end                                                                    
go 


sp_procxmode 'sp_ReturnAndOutputVarChar256', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_ReturnAndOutputVarChar257'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_ReturnAndOutputVarChar257" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_ReturnAndOutputVarChar257
  @OutParam varchar(257) output 
as   
begin 
  declare 
    @tmpInt int 
 
  set @tmpInt=9 
 
  set @OutParam='stub'
  return(@tmpInt)  
end                                                                    
go 


sp_procxmode 'sp_ReturnAndOutputVarChar257', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_ReturnAndOutputVarChar258'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_ReturnAndOutputVarChar258" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_ReturnAndOutputVarChar258
  @OutParam varchar(258) output 
as   
begin 
  declare 
    @tmpInt int 
 
  set @tmpInt=9 
 
  set @OutParam='stub'
  return(@tmpInt)  
end                                                                    
go 


sp_procxmode 'sp_ReturnAndOutputVarChar258', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestCreateTableInSp'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestCreateTableInSp" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestCreateTableInSp
as
begin
  if not exists (select 1
                 from
                 sysobjects
                 where
                   id=object_id('TableCreatedFromSP')
                   and type='U')
    create table TableCreatedFromSP(
      id tinyint not null
    ) lock datarows
end                                                                                                                                                                                                
go 


sp_procxmode 'TestCreateTableInSp', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestExec'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestExec" >>>>>'
go 

setuser 'dbo'
go 

/*==============================================================*/
/* Stored procedure: TestExec                                   */
/*==============================================================*/
create procedure TestExec
  @SLEEP char(8)=null
as
begin
  declare
    @rc int,
    @tmpString varchar(1024),
    @max int

  set @max=5

  set @tmpString='select * from Staff order by ID'
  exec (@tmpString)
  set @rc=@@rowcount
  set @tmpString='@@rowcount='||convert(varchar(32),@rc)
  print @tmpString

  set @tmpString='set rowcount 5'
  exec (@tmpString)/* Adaptive Server has expanded all '*' elements in the following statement */ 
  select Staff.ID, Staff.Name, Staff.Salary, Staff.Dep, Staff.BirthDate from Staff order by ID
  set @rc=@@rowcount
  set @tmpString='@@rowcount='||convert(varchar(32),@rc)
  print @tmpString

  set @tmpString='set rowcount 0'
  exec (@tmpString)/* Adaptive Server has expanded all '*' elements in the following statement */ 
  select Staff.ID, Staff.Name, Staff.Salary, Staff.Dep, Staff.BirthDate from Staff order by ID
  set @rc=@@rowcount
  set @tmpString='@@rowcount='||convert(varchar(32),@rc)
  print @tmpString

  set rowcount @max/* Adaptive Server has expanded all '*' elements in the following statement */ 
  select Staff.ID, Staff.Name, Staff.Salary, Staff.Dep, Staff.BirthDate from Staff order by ID
  set @rc=@@rowcount
  set @tmpString='@@rowcount='||convert(varchar(32),@rc)
  print @tmpString

  if @SLEEP is not null
    begin
      set @tmpString='begin waitfor delay '''||@SLEEP||''''
      print @tmpString
      waitfor delay @SLEEP
      print 'end waitfor'
    end

  set rowcount 0
end                                                                                                                                      
go 


sp_procxmode 'TestExec', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_Staff'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_Staff" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_Staff
as 
begin
  /* Adaptive Server has expanded all '*' elements in the following statement */ select Staff.ID, Staff.Name, Staff.Salary, Staff.Dep, Staff.BirthDate, Staff.NullField from Staff order by ID
end                         
go 


sp_procxmode 'sp_Staff', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestCursorInsert'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestCursorInsert" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestCursorInsert
as 
begin
  declare
    @Id numeric(18,0),
    @Val numeric(18,0),
    @i int,
    @tmpStr varchar(254)

  set @i=0

  declare TestCursorInsert cursor
  for
    select
      Id,
      Val
    from
      TestCursorMain
    for update of Val

  open TestCursorInsert
  fetch TestCursorInsert into @Id, @Val
  while (@@sqlstatus=0)
    begin
      set @tmpStr='@Id='||coalesce(convert(varchar(32),@Id),'NULL')||', @Val='||coalesce(convert(varchar(32),@Val),'NULL')
      print @tmpStr

      set @i=@i+1
      if @i>100
        begin
          print '>100'
          goto ClearAll
        end

      update
        TestCursorMain
      set
        Val=Val*2
      where
        current of TestCursorInsert

      insert into TestCursorMain (Id, Val) values (@Id*2, @Val*3)

      fetch TestCursorInsert into @Id, @Val
    end

  ClearAll:
  close TestCursorInsert
  deallocate TestCursorInsert
end                                                                                         
go 


sp_procxmode 'sp_TestCursorInsert', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.SaveTest'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.SaveTest" >>>>>'
go 

setuser 'dbo'
go 

create procedure SaveTest
   @Id numeric(18,0),
   @Value varchar(256),
   @IdNew numeric(18,0) output
as
begin
   declare
     @ReturnValue int

   if(not exists (select 1 from Test where Id=@Id))
     begin
       insert into Test
       (Value)
       values
       (@Value)

       set @ReturnValue=@@error
       set @IdNew=@@identity
     end
   else
     begin
       update
         Test
       set
         Value=@Value
       where
         Id=@id

       set @ReturnValue=@@error
       set @IdNew=@Id
     end

    return(@ReturnValue)
end                                                                                                                                                                                                                      
go 


sp_procxmode 'SaveTest', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_Staff_Report'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_Staff_Report" >>>>>'
go 

setuser 'dbo'
go 

set quoted_identifier on
go 

create procedure sp_Staff_Report
as 
begin
  declare
    @ReportNo int,
    @ReportDate date,
    @ReportName varchar(1024)

  set @ReportNo=13
  set @ReportDate=getdate()
  set @ReportName='Report'

  select
    @ReportNo as ReportNo,
    @ReportDate as ReportDate,
    @ReportName as ReportName

  /* Adaptive Server has expanded all '*' elements in the following statement */ select
    Staff.ID, Staff.Name, Staff.Salary, Staff.Dep, Staff.BirthDate, Staff.NullField
  from
    Staff
  order by Dep asc, Salary desc
end                                                                                                                                                                                                                                                   
go 


sp_procxmode '"sp_Staff_Report"', unchained
go 

set quoted_identifier off
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_MaxFromEmptyTable'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_MaxFromEmptyTable" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_MaxFromEmptyTable
  @MaxId numeric(18,0) output
as 
begin
  select @MaxId=max(Id) from EmptyTable
end                                                                                                                                      
go 


sp_procxmode 'sp_MaxFromEmptyTable', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestTmpTable2Child'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestTmpTable2Child" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestTmpTable2Child
as
begin
  set nocount on

  declare
    @SPName varchar(254),
    @tmpString varchar(254)

  set @SPName='TestTmpTable2Child'

  set @tmpString=@SPName||' insert into # (begin)'
  print @tmpString
  insert into #TestTmpTable2 (Id, Val) values (1, 'A')
  insert into #TestTmpTable2 (Id, Val) values (2, 'B')
  insert into #TestTmpTable2 (Id, Val) values (3, 'C')
  set @tmpString=@SPName||' insert into # (end)'
  print @tmpString
end                                        
go 


sp_procxmode 'TestTmpTable2Child', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.TestTmpTable2Parent'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.TestTmpTable2Parent" >>>>>'
go 

setuser 'dbo'
go 

create procedure TestTmpTable2Parent
as
begin
  set nocount on

  declare
    @SPName varchar(254),
    @tmpString varchar(254)

  set @SPName='TestTmpTable2Parent'

  set @tmpString=@SPName||' create table # (begin)'
  print @tmpString
  create table #TestTmpTable2(
    Id numeric(18,0),
    Val varchar(254)
  )
  set @tmpString=@SPName||' create table # (end)'
  print @tmpString

  set @tmpString=@SPName||' exec SP (begin)'
  print @tmpString
  execute TestTmpTable2Child
  set @tmpString=@SPName||' exec SP (end)'
  print @tmpString

  set @tmpString=@SPName||' select * from # (begin)'
  print @tmpString
  /* Adaptive Server has expanded all '*' elements in the following statement */ select
    #TestTmpTable2.Id, #TestTmpTable2.Val
  from
    #TestTmpTable2
  set @tmpString=@SPName||' select * from # (end)'
  print @tmpString

  drop table #TestTmpTable2
end                                                                                                                                                     
go 


sp_procxmode 'TestTmpTable2Parent', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_Select_NULL'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_Select_NULL" >>>>>'
go 

setuser 'dbo'
go 

set quoted_identifier on
go 

create procedure sp_Select_NULL
  @IsSelectNull bit=0
as 
begin
  create table #tmpTable(
    Id int null,
    Name varchar(256) null)

  insert into #tmpTable (Name) values ('Иванов Иван Иванович')
  insert into #tmpTable (Name) values ('Петров Петр Петрович')
  insert into #tmpTable (Name) values ('Сидоров Сидор Сидорович')
  insert into #tmpTable (Name) values ('Александров Александр Александрович')

  if @IsSelectNull=1
    select Id, Name from #tmpTable
  else
    select Name from #tmpTable

  drop table #tmpTable
end                                                                                                                                                                                                                                             
go 


sp_procxmode '"sp_Select_NULL"', unchained
go 

set quoted_identifier off
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_WithDefaultParam'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_WithDefaultParam" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_WithDefaultParam
  @Param1 int=null,  
  @Param2 int=null,  
  @Param3 int=null
as   
begin  
  declare  
    @RetVal int

  set @RetVal=0   

  select @Param1, @Param2, @Param3
   
  return(@RetVal)  
end                              
go 


sp_procxmode 'sp_WithDefaultParam', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- DDL for Stored Procedure 'testdb.dbo.sp_TestCursorInsert2'
-----------------------------------------------------------------------------

print '<<<<< CREATING Stored Procedure - "testdb.dbo.sp_TestCursorInsert2" >>>>>'
go 

setuser 'dbo'
go 

create procedure sp_TestCursorInsert2
as 
begin
  declare
    @Id numeric(18,0),
    @Val numeric(18,0),
    @i int,
    @tmpStr varchar(254)

  set @i=0

  declare TestCursorInsert cursor
  for
    select
      Id,
      Val
    from
      TestCursorMain
    where
      Cod=1
    for update of Val

  open TestCursorInsert
  fetch TestCursorInsert into @Id, @Val
  while (@@sqlstatus=0)
    begin
      set @tmpStr='@Id='||coalesce(convert(varchar(32),@Id),'NULL')||', @Val='||coalesce(convert(varchar(32),@Val),'NULL')
      print @tmpStr

      set @i=@i+1
      if @i>100
        begin
          print '>100'
          goto ClearAll
        end

      update
        TestCursorMain
      set
        Val=Val*2
      where
        current of TestCursorInsert

      insert into TestCursorMain (Id, Val, Cod) values (@Id*2, @Val*3, 3)

      fetch TestCursorInsert into @Id, @Val
    end

  ClearAll:
  close TestCursorInsert
  deallocate TestCursorInsert
end                                                          
go 


sp_procxmode 'sp_TestCursorInsert2', unchained
go 

setuser
go 

-----------------------------------------------------------------------------
-- Dependent DDL for Object(s)
-----------------------------------------------------------------------------
use testdb
go

exec sp_changedbowner 'sa'
go

exec master.dbo.sp_dboption testdb, 'select into/bulkcopy', true
go

exec master.dbo.sp_dboption testdb, 'trunc log on chkpt', true
go

exec master.dbo.sp_dboption testdb, 'abort tran on log full', true
go

checkpoint
go

use testdb
go 

sp_addthreshold testdb, 'logsegment', 16, sp_thresholdaction
go 

Grant Select on dbo.sysalternates to public
go

Grant Select on dbo.sysattributes to public
go

Grant Select on dbo.syscolumns to public
go

Grant Select on dbo.syscomments to public
go

Grant Select on dbo.sysconstraints to public
go

Grant Select on dbo.sysdepends to public
go

Grant Select on dbo.sysindexes to public
go

Grant Select on dbo.sysjars to public
go

Grant Select on dbo.syskeys to public
go

Grant Select on dbo.syslogs to public
go

Grant Select on dbo.sysobjects(cache) to public
go

Grant Select on dbo.sysobjects(ckfirst) to public
go

Grant Select on dbo.sysobjects(crdate) to public
go

Grant Select on dbo.sysobjects(deltrig) to public
go

Grant Select on dbo.sysobjects(erlchgts) to public
go

Grant Select on dbo.sysobjects(expdate) to public
go

Grant Select on dbo.sysobjects(id) to public
go

Grant Select on dbo.sysobjects(identburnmax) to public
go

Grant Select on dbo.sysobjects(indexdel) to public
go

Grant Select on dbo.sysobjects(instrig) to public
go

Grant Select on dbo.sysobjects(loginame) to public
go

Grant Select on dbo.sysobjects(name) to public
go

Grant Select on dbo.sysobjects(objspare) to public
go

Grant Select on dbo.sysobjects(schemacnt) to public
go

Grant Select on dbo.sysobjects(seltrig) to public
go

Grant Select on dbo.sysobjects(spacestate) to public
go

Grant Select on dbo.sysobjects(sysstat) to public
go

Grant Select on dbo.sysobjects(sysstat2) to public
go

Grant Select on dbo.sysobjects(type) to public
go

Grant Select on dbo.sysobjects(uid) to public
go

Grant Select on dbo.sysobjects(updtrig) to public
go

Grant Select on dbo.sysobjects(userstat) to public
go

Grant Select on dbo.sysobjects(versionts) to public
go

Grant Select on dbo.syspartitionkeys to public
go

Grant Select on dbo.syspartitions to public
go

Grant Select on dbo.sysprocedures to public
go

Grant Select on dbo.sysprotects to public
go

Grant Select on dbo.sysqueryplans to public
go

Grant Select on dbo.sysreferences to public
go

Grant Select on dbo.sysroles to public
go

Grant Select on dbo.syssegments to public
go

Grant Select on dbo.sysslices to public
go

Grant Select on dbo.sysstatistics to public
go

Grant Select on dbo.systabstats to public
go

Grant Select on dbo.systhresholds to public
go

Grant Select on dbo.systypes to public
go

Grant Select on dbo.sysusermessages to public
go

Grant Select on dbo.sysusers to public
go

Grant Select on dbo.sysxtypes to public
go

alter table testdb.dbo.NaturPerson
add constraint fkNaturPerson FOREIGN KEY (CentId,InstId,NodeId,PersonId) REFERENCES testdb.dbo.Insurant(CentId,InstId,NodeId,PersonId)
go

alter table testdb.dbo.JuridPerson
add constraint fkJuridPerson FOREIGN KEY (CentId,InstId,NodeId,PersonId) REFERENCES testdb.dbo.Insurant(CentId,InstId,NodeId,PersonId)
go

alter table testdb.dbo.sec
add constraint fkSec FOREIGN KEY (idcat) REFERENCES testdb.dbo.cat(idcat)
go

alter table testdb.dbo.poll
add constraint fkPoll FOREIGN KEY (idsec) REFERENCES testdb.dbo.sec(idsec)
go

alter table testdb.dbo.DetailsDetailsTable
add constraint fkDDTable_DTable FOREIGN KEY (IdMaster,IdDetailsLevelI) REFERENCES testdb.dbo.DetailsTable(IdMaster,Id)
go

alter table testdb.dbo.DetailsDetailsTable
add constraint fkDDTable_MTable FOREIGN KEY (IdMaster) REFERENCES testdb.dbo.MasterTable(Id)
go

alter table testdb.dbo.DetailsTable
add constraint fkDetailsTable FOREIGN KEY (IdMaster) REFERENCES testdb.dbo.MasterTable(Id)
go

alter table testdb.dbo.TT2
add constraint fkTT1_TT2 FOREIGN KEY (TT1_Id) REFERENCES testdb.dbo.TT1(Id)
go

alter table testdb.dbo.TT3
add constraint fkTT3_TT2 FOREIGN KEY (TT2_Id) REFERENCES testdb.dbo.TT2(Id)
go


