use testdb
go

if object_id(N'TableWithTrigger2', N'u') is not null
	drop table TableWithTrigger2
go

create table TableWithTrigger2
(
	id bigint not null constraint pkTableWithTrigger2 primary key,
	value1 nvarchar(256) null,
	value2 nvarchar(256) null,
	value3 nvarchar(256) null
)
go

if object_id(N'trTableWithTrigger2', N'tr') is not null
	drop trigger trTableWithTrigger2
go

create trigger trTableWithTrigger2
on TableWithTrigger2
instead of insert, update  
as  
begin
	set nocount on

	print N'trTableWithTrigger2'

	insert into TableWithTrigger2
		(id, value1, value2, value3)
	select
		i.id,
		i.value1,
		i.value2,
		i.value3
	from
		inserted i
		left join deleted d on (d.id=i.id)
	where
		(d.id is null)

	update
		TableWithTrigger2
	set
		value1=i.value1,
		value2=i.value2,
		value3=i.value3
	from
		TableWithTrigger2 dest
		join deleted d on (d.id=dest.id)
		join inserted i on (i.id=d.id)

	declare
		@idNew bigint,
		@value1New nvarchar(256),
		@value2New nvarchar(256),
		@value3New nvarchar(256),
		@idOld bigint,
		@value1Old nvarchar(256),
		@value2Old nvarchar(256),
		@value3Old nvarchar(256),
		@idIns bigint,
		@idUpd bigint,
		@tmpStr nvarchar(max)

	declare #CursorInTrTableWithTrigger2 cursor for
	select
		i.id,
		i.value1,
		i.value2,
		i.value3,
		d.id,
		d.value1,
		d.value2,
		d.value3
	from
		inserted i
		left join deleted d on (d.id=i.id)
	for read only

	open #CursorInTrTableWithTrigger2
  	fetch from #CursorInTrTableWithTrigger2 into @idNew, @value1New, @value2New, @value3New, @idOld, @value1Old, @value2Old, @value3Old
	while @@fetch_status=0
		begin
			set @tmpStr=N'#CursorInTrTableWithTrigger2: idNew='+convert(nvarchar(max), @idNew)+N', value1New='''+coalesce(@value1New, N'NULL')+N''', value2New='''+coalesce(@value2New, N'NULL')+N''', value3New='''+coalesce(@value3New, N'NULL')+N''', idOld='+case when @idOld is not null then convert(nvarchar(max), @idOld) else N'NULL' end+N', value1Old='''+coalesce(@value1Old, N'NULL')+N''', value2Old='''+coalesce(@value2Old, N'NULL')+N''', value3Old='''+coalesce(@value3Old, N'NULL')+N''''
			print @tmpStr
			
			set @idIns=null
			set @idUpd=null
			
			select @idIns=id from TableWithTrigger1 where value1=@value1New and value2=@value2New and value3=@value3New
			
			set @tmpStr=N'#CursorInTrTableWithTrigger2: @idIns='+case when @idIns is not null then convert(nvarchar(max), @idIns) else N'NULL' end
			print @tmpStr

			if @idIns is null and @idOld is not null
				select @idUpd=id from TableWithTrigger1 where value1=@value1Old and value2=@value2Old and value3=@value3Old				

			set @tmpStr=N'#CursorInTrTableWithTrigger2: @idUpd='+case when @idUpd is not null then convert(nvarchar(max), @idUpd) else N'NULL' end
			print @tmpStr

			if @idUpd is not null
				begin
					set @tmpStr=N'#CursorInTrTableWithTrigger2: update id='+convert(nvarchar(max), @idUpd)+N', value1='''+coalesce(@value1New, N'NULL')+N''', value2='''+coalesce(@value2New, N'NULL')+N''', value3='''+coalesce(@value3New, N'NULL')+N''''
					print @tmpStr

					update
						TableWithTrigger1
					set
						value1=@value1New,
						value2=@value2New,
						value3=@value3New
					where
						id=@idUpd
				end
			else
				begin
					if @idIns is null
						begin
							set @tmpStr=N'#CursorInTrTableWithTrigger2: insert id='+convert(nvarchar(max), @idNew)+N', value1='''+coalesce(@value1New, N'NULL')+N''', value2='''+coalesce(@value2New, N'NULL')+N''', value3='''+coalesce(@value3New, N'NULL')+N''''
							print @tmpStr

							insert into TableWithTrigger1
							(id, value1, value2, value3)
							values
							(@idNew, @value1New, @value2New, @value3New)
						end
				end

			fetch from #CursorInTrTableWithTrigger2 into @idNew, @value1New, @value2New, @value3New, @idOld, @value1Old, @value2Old, @value3Old
		end
	close #CursorInTrTableWithTrigger2
	deallocate #CursorInTrTableWithTrigger2
end
go
