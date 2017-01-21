/*set names WIN1251;*/

create database 'e:\soft.src\cbuilder\Tests\IB\TestIB.#1\TestTest.gdb' user 'sysdba' password 'masterkey' default character set WIN1251;
/*
create table "Insurant"
(
    "CentId"        smallint not null,
    "InstId"        smallint not null,
    "NodeId"        smallint not null,
    "PersonId"      integer not null,
    "NameN"         varchar(100),
    "PersonType"    integer not null,
    constraint "pkInsurance" primary key ("CentId", "InstId", "NodeId", "PersonId")
);
commit;
insert into "Insurant" ("CentId", "InstId", "NodeId", "PersonId", "NameN", "PersonType") values (1, 1, 1, 1, '1_1_1_1', 1);
insert into "Insurant" ("CentId", "InstId", "NodeId", "PersonId", "NameN", "PersonType") values (1, 1, 1, 2, '1_1_1_2', 2);
insert into "Insurant" ("CentId", "InstId", "NodeId", "PersonId", "NameN", "PersonType") values (1, 1, 1, 3, '1_1_1_3', 1);
insert into "Insurant" ("CentId", "InstId", "NodeId", "PersonId", "NameN", "PersonType") values (1, 1, 1, 4, '1_1_1_4', 2);
insert into "Insurant" ("CentId", "InstId", "NodeId", "PersonId", "NameN", "PersonType") values (1, 1, 2, 1, '1_1_2_1', 1);
insert into "Insurant" ("CentId", "InstId", "NodeId", "PersonId", "NameN", "PersonType") values (1, 1, 2, 2, '1_1_2_2', 2);
insert into "Insurant" ("CentId", "InstId", "NodeId", "PersonId", "NameN", "PersonType") values (1, 1, 2, 3, '1_1_2_3', 1);
insert into "Insurant" ("CentId", "InstId", "NodeId", "PersonId", "NameN", "PersonType") values (1, 1, 2, 4, '1_1_2_4', 2);
commit;

create table "JuridPerson"
(
    "CentId"        smallint not null,
    "InstId"        smallint not null,
    "NodeId"        smallint not null,
    "PersonId"      integer not null,
    "ChiefPostN"    varchar(40),
    constraint "pkJuridPerson" primary key("CentId", "InstId", "NodeId", "PersonId"),
    constraint "fkJuridPerson" foreign key ("CentId", "InstId", "NodeId", "PersonId") references "Insurant"("CentId", "InstId", "NodeId", "PersonId") on delete cascade on update cascade
);
commit;
insert into "JuridPerson" ("CentId", "InstId", "NodeId", "PersonId", "ChiefPostN") values (1, 1, 1, 1, 'JuridPerson_1_1_1_1');
insert into "JuridPerson" ("CentId", "InstId", "NodeId", "PersonId", "ChiefPostN") values (1, 1, 1, 3, 'JuridPerson_1_1_1_3');
insert into "JuridPerson" ("CentId", "InstId", "NodeId", "PersonId", "ChiefPostN") values (1, 1, 2, 1, 'JuridPerson_1_1_2_1');
insert into "JuridPerson" ("CentId", "InstId", "NodeId", "PersonId", "ChiefPostN") values (1, 1, 2, 3, 'JuridPerson_1_1_2_3');
commit;

create table "NaturPerson"
(
    "CentId"    smallint not null,    "InstId"    smallint not null,
    "NodeId"    smallint not null,
    "PersonId"  integer not null,
    "PasspNo"   varchar(20),
  constraint "pkNaturPerson" primary key("CentId", "InstId", "NodeId", "PersonId"),
  constraint "fkNaturPerson" foreign key ("CentId", "InstId", "NodeId", "PersonId") references "Insurant"("CentId", "InstId", "NodeId", "PersonId") on delete cascade on update cascade
);
commit;
insert into "NaturPerson" ("CentId", "InstId", "NodeId", "PersonId", "PasspNo") values (1, 1, 1, 2, 'NaturPerson_1_1_1_2');
insert into "NaturPerson" ("CentId", "InstId", "NodeId", "PersonId", "PasspNo") values (1, 1, 1, 4, 'NaturPerson_1_1_1_4');
insert into "NaturPerson" ("CentId", "InstId", "NodeId", "PersonId", "PasspNo") values (1, 1, 2, 2, 'NaturPerson_1_1_2_2');
insert into "NaturPerson" ("CentId", "InstId", "NodeId", "PersonId", "PasspNo") values (1, 1, 2, 4, 'NaturPerson_1_1_2_4');
commit;

create table "TestDataTypes"
(
   "CInteger" integer,
   "CSmallInt" smallint,
   "CFloat" float,
   "CDoublePrecision" double precision,
   "CNumeric_4_3" numeric (4,3),
   "CNumeric_5_4" numeric (5,4),
   "CNumeric_9_8" numeric (9,8),
   "CNumeric_10_9" numeric (10,9),
   "CNumeric_18_17" numeric (18,17),
   "CNumeric_18_0" numeric (18,0),
   "CDecimal_4_3" decimal (4,3),
   "CDecimal_5_4" decimal (5,4),
   "CDecimal_9_8" decimal (9,8),
   "CDecimal_10_9" decimal (10,9),
   "CDecimal_18_17" decimal (18,17),
   "CDecimal_18_0" decimal (18,0),
   "CDate" date,
   "CTime" time,
   "CTimeStamp" timestamp,
   "CChar" char (256),
   "CVarChar" varchar (256),
   "CBlob" blob
);
commit;
insert into "TestDataTypes"
(
"CInteger", "CSmallInt", "CFloat", "CDoublePrecision", "CNumeric_4_3", "CNumeric_5_4", "CNumeric_9_8", "CNumeric_10_9", "CNumeric_18_17", "CNumeric_18_0", "CDecimal_4_3", "CDecimal_5_4", "CDecimal_9_8", "CDecimal_10_9", "CDecimal_18_17", "CDecimal_18_0", "CDate", "CTime", "CTimeStamp", "CChar", "CVarChar", "CBlob"
)
values
(
999, 9, 0.1, 0.01, 0.001, 0.0001, 0.00000001, 0.000000001, 0.00000000000000001, 99999999999999999, 0.001, 0.0001, 0.00000001, 0.000000001, 0.00000000000000001, 99999999999999999, current_date, current_time, current_timestamp, 'CChar', 'CVarChar', 'CBlob'
);
commit;

create table "Test"
(
   "TestId" integer not null,
   "TestValue" varchar (256),
   primary key ("TestId")
);
commit;
insert into "Test" ("TestId","TestValue") values (1,'TestValue');
commit;

create table "Centres"
(
   "CentreId" integer not null,
   "Name" varchar (256)
);
commit;
alter table "Centres" add constraint "pkCentre" primary key ("CentreId");
commit;

create table "Polis"
(
   "PolisId" integer constraint "NotNullPolisId" not null constraint "pkPolis" primary key,
   "ContractNo" integer not null,
   "PolisNo" integer not null,
   "Value" varchar (256),
   constraint "ukPolis" unique ("ContractNo","PolisNo")
);
commit;

create table "CertifErsatz"
(
   "CertId" integer constraint "pkCertGen" not null primary key,
   "CentreId" integer not null,
   "InstId" integer not null,
   "NodeId" integer not null,
   "Year" integer not null,
   "Kind" integer not null,
   "Branch" integer not null,
   "ContrNo" integer not null,
   "CertNo" integer not null,
   "Value" varchar (256),
   constraint "ukPolisPolisErsatz" unique ("CentreId","InstId","NodeId","Year","Kind","Branch","ContrNo","CertNo")
);
commit;

create table "CertifHash"
(
   "CertId" integer constraint "pkCertHash" not null primary key,
   "CentreId" integer not null,
   "InstId" integer not null,
   "NodeId" integer not null,
   "Year" integer not null,
   "Kind" integer not null,
   "Branch" integer not null,
   "ContrNo" integer not null,
   "CertNo" integer not null,
   "Value" varchar (256),
   constraint "ukCertifHash" unique ("CentreId","InstId","NodeId","Year","Kind","Branch","ContrNo","CertNo")
);
commit;

create generator "GenCertifId";
set generator "GenCertifId" to 0;


set term ^;

create procedure "SP1" (ArgFirst numeric (18,2), ArgSecond numeric (18,2))
returns (Result numeric (18,2))
as
begin
  Result=ArgFirst+ArgSecond;
  suspend;
end
^

create procedure "SP2" (TestId integer)
returns (TestValue varchar (256))
as
begin
  for
    select "TestValue" from "Test" where ("TestId" = :TestId)
    into :TestValue
  do
  begin
    suspend;
  end
end
^

set term ;^
*/