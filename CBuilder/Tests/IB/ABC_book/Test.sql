set names WIN1251;

create database "d:\my_doc\cbuilder\tests\ib\abc_book\Test.gdb" user "sysdba" password "masterkey" default character set WIN1251;

create table "Insurant"
(
    "CentId"        smallint constraint "InsurantCentIdNotNull" not null,
    "InstId"        smallint constraint "InsurantInstIdNotNull" not null,
    "NodeId"        smallint constraint "InsurantNodeIdNotNull" not null,
    "PersonId"      integer constraint "InsurantPersonIdNotNull" not null,
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
    "CentId"        smallint constraint "JuridPersonCentIdNotNull" not null,
    "InstId"        smallint constraint "JuridPersonInstIdNotNull" not null,
    "NodeId"        smallint constraint "JuridPersonNodeIdNotNull" not null,
    "PersonId"      integer constraint "JuridPersonPersonIdNotNull" not null,
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
    "CentId"    smallint constraint "NaturPersonCentIdNotNull" not null,    "InstId"    smallint constraint "NaturPersonInstIdNotNull" not null,
    "NodeId"    smallint constraint "NaturPersonNodeIdNotNull" not null,
    "PersonId"  integer constraint "NaturPersonPersonIdNotNull" not null,
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
