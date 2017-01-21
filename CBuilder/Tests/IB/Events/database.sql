set names WIN1251;

CREATE DATABASE "d:\my_doc\cbuilder\Tests\IB\Events\test.gdb" user "sysdba" password "masterkey" DEFAULT CHARACTER SET WIN1251;

CREATE TABLE "TestTable"
(
   "IntF" integer constraint "pkIntF" not null primary key,
   "StrF" varchar(20),
   "UserId" integer
);

CREATE GENERATOR "Gen";

SET TERM ^ ;

CREATE TRIGGER "InsertBefore" FOR "TestTable"                              
ACTIVE BEFORE INSERT POSITION 0 
as
begin
  new."IntF"=gen_id("Gen",1);
  post_event 'InsertBefore';
end
 ^

CREATE TRIGGER "InsertAfter" FOR "TestTable"                              
ACTIVE AFTER INSERT POSITION 0 
as
begin
  post_event 'InsertAfter';
end
 ^

CREATE TRIGGER "DeleteBefore" FOR "TestTable"                              
ACTIVE BEFORE DELETE POSITION 0 
as
begin
  post_event 'DeleteBefore';
end
 ^

CREATE TRIGGER "DeleteAfter" FOR "TestTable"                              
ACTIVE AFTER DELETE POSITION 0 
as
begin
  post_event 'DeleteAfter';
end
 ^

CREATE TRIGGER "UpdateBefore" FOR "TestTable"                              
ACTIVE BEFORE UPDATE POSITION 0 
as
begin
  post_event 'UpdateBefore';
end
 ^

CREATE TRIGGER "UpdateAfter" FOR "TestTable"                              
ACTIVE AFTER UPDATE POSITION 0 
as
begin
  post_event 'UpdateAfter';
end
 ^

SET TERM ; ^
