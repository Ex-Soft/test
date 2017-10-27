/*
if object_id(N'refStoredProcedures', N'u') is not null
	drop table refStoredProcedures
go

create table refStoredProcedures
(
   id int not null constraint pk_refStoredProcedures primary key,
   spName nvarchar(255) not null default (N''),
)
go
*/

/*
insert into refStoredProcedures (id, spName) values (0, N'')
insert into refStoredProcedures (id, spName) values (1, N'spNameI')
insert into refStoredProcedures (id, spName) values (2, N'spNameI2XML')
insert into refStoredProcedures (id, spName) values (3, N'spNameII')
insert into refStoredProcedures (id, spName) values (4, N'spNameII2XML')
insert into refStoredProcedures (id, spName) values (5, N'spNameIII')
insert into refStoredProcedures (id, spName) values (6, N'spNameIII2XML')
insert into refStoredProcedures (id, spName) values (7, N'spNameIV')
*/

/*
select * from refStoredProcedures

if object_id(N'refAISchedules', N'u') is not null
	drop table refAISchedules
go

create table refAISchedules
(
   id int not null constraint pk_refAISchedules primary key,
   idStoredProcedure int not null constraint fk_refAISchedules_idStoredProcedure_refStoredProcedures references refStoredProcedures (id),
   idXMLStoredProcedure int not null constraint fk_refAISchedules_idXMLStoredProcedure_refStoredProcedures references refStoredProcedures (id)
)
go
*/

/*
if object_id(N'tr_refAISchedules_Update_idXMLStoredProcedure', N'tr') is not null
	drop trigger tr_refAISchedules_Update_idXMLStoredProcedure
go

create trigger tr_refAISchedules_Update_idXMLStoredProcedure on refAISchedules for insert, update
as
begin
	set nocount on;

	if update(idStoredProcedure)
		print N'update(idStoredProcedure)'

	print columns_updated()

	if (columns_updated() & 1) = 1
		print N'(columns_updated() & 1) = 1'
	if (columns_updated() & 2) = 2
		print N'(columns_updated() & 2) = 2'
	if (columns_updated() & 4) = 4
		print N'(columns_updated() & 4) = 4'
	if (columns_updated() & 8) = 8
		print N'(columns_updated() & 8) = 8'
	if (columns_updated() & 16) = 16
		print N'(columns_updated() & 16) = 16'

	declare @order int

	select @order = power(2, column_id - 1) from sys.columns where object_id = object_id(N'refAISchedules', N'u') and name = N'idStoredProcedure'

	if (columns_updated() & @order) = @order
	begin
		print N'update'

		update
			refAISchedules
		set
			idXMLStoredProcedure = coalesce((select top 1 id from refStoredProcedures where spName = (select spName + N'2XML' from refStoredProcedures where id = inserted.idStoredProcedure)), 0)
		from
			refAISchedules dest
			join inserted inserted on inserted.id = dest.id;
	end;
end;
*/

/*
if object_id(N'AI.tr_refAISchedules_Update_idXMLStoredProcedure', N'tr') is not null
	drop trigger AI.tr_refAISchedules_Update_idXMLStoredProcedure
go

create trigger AI.tr_refAISchedules_Update_idXMLStoredProcedure on AI.refAISchedules for insert, update
as
begin
	set nocount on;

	merge into AI.refAISchedules as tgt
	using
	(
		select
			id as id,
			coalesce((select top 1 id from dbo.refStoredProcedures where spName = (select spName + N'2XML' from dbo.refStoredProcedures where id = inserted.idStoredProcedure)), 0) as idXMLStoredProcedure
		from
			inserted inserted
	) as src
	on tgt.id = src.id
	when matched
		then update set idXMLStoredProcedure = src.idXMLStoredProcedure;
end;
*/

/*
insert into refAISchedules (id, idStoredProcedure, idXMLStoredProcedure) values (1, 1, 0)
insert into refAISchedules (id, idStoredProcedure, idXMLStoredProcedure) values (2, 3, 0)
insert into refAISchedules (id, idStoredProcedure, idXMLStoredProcedure) values (3, 5, 0)
insert into refAISchedules (id, idXMLStoredProcedure, idStoredProcedure) values (5, 0, 7)
*/

/* update refAISchedules set idXMLStoredProcedure = 0 */
/* update refAISchedules set idXMLStoredProcedure = 0, idStoredProcedure = 0 */
/* update refAISchedules set idStoredProcedure = idStoredProcedure */
/* update refAISchedules set idStoredProcedure = id */
/* update refAISchedules set id = 3 where id = 2 */
/* update refAISchedules set id = 5 where id = 4 */

/*
update refAISchedules set idStoredProcedure = 1 where id = 1
*/

select
	*
from
	refAISchedules aiSchedules
	left join refStoredProcedures storedProcedures on storedProcedures.id = aiSchedules.idStoredProcedure
	left join refStoredProcedures storedProcedures2Xml on storedProcedures2Xml.id = aiSchedules.idXMLStoredProcedure