use testdb
go

if object_id(N'trTableWithTrigger1WD', N'tr') is not null
	drop trigger trTableWithTrigger1WD
go

create trigger trTableWithTrigger1WD
on TableWithTrigger1WD
for insert, update
as
begin
	set nocount on

	print N'trTableWithTrigger1WD'

	declare
		@idNew bigint,
		@value1New nvarchar(256),
		@value2New nvarchar(256),
		@value3New nvarchar(256),
		@deletedNew bit,
		@idOld bigint,
		@value1Old nvarchar(256),
		@value2Old nvarchar(256),
		@value3Old nvarchar(256),
		@deletedOld bit,
		@idUpd bigint,
		@existsActiveIns bit,
		@existsDeletedIns bit,
		@existsActiveUpd bit,
		@existsDeletedUpd bit,
		@tmpStr nvarchar(max)

	declare #CursorInTrTableWithTrigger1WD cursor for
	select
		i.id,
		i.value1,
		i.value2,
		i.value3,
		i.deleted,
		d.id,
		d.value1,
		d.value2,
		d.value3,
		d.deleted
	from
		inserted i
		left join deleted d on (d.id=i.id)
	for read only

	open #CursorInTrTableWithTrigger1WD
  	fetch from #CursorInTrTableWithTrigger1WD into @idNew, @value1New, @value2New, @value3New, @deletedNew, @idOld, @value1Old, @value2Old, @value3Old, @deletedOld
	while @@fetch_status=0
	begin
		set @tmpStr=N'#CursorInTrTableWithTrigger1WD: idNew='+convert(nvarchar(max), @idNew)+N', value1New='''+coalesce(@value1New, N'NULL')+N''', value2New='''+coalesce(@value2New, N'NULL')+N''', value3New='''+coalesce(@value3New, N'NULL')+N''', deletedNew='+(convert(nvarchar(max), @deletedNew))+N', idOld='+case when @idOld is not null then convert(nvarchar(max), @idOld) else N'NULL' end+N', value1Old='''+coalesce(@value1Old, N'NULL')+N''', value2Old='''+coalesce(@value2Old, N'NULL')+N''', value3Old='''+coalesce(@value3Old, N'NULL')+N''', deletedOld='+case when @deletedOld is not null then convert(nvarchar(max), @deletedOld) else N'NULL' end
		print @tmpStr

		if exists (select 1 from TableWithTrigger2WD where (value1=@value1New) and (value2=@value2New) and (value3=@value3New) and (deleted=0))
			set @existsActiveIns=1
		else
			set @existsActiveIns=0

		if exists (select 1 from TableWithTrigger2WD where (value1=@value1New) and (value2=@value2New) and (value3=@value3New) and (deleted=1))
			set @existsDeletedIns=1
		else
			set @existsDeletedIns=0

		set @tmpStr=N'@existsActiveIns='+convert(nvarchar(max), @existsActiveIns)
		print @tmpStr
		set @tmpStr=N'@existsDeletedIns='+convert(nvarchar(max), @existsDeletedIns)
		print @tmpStr

		if @idOld is null
		begin
			print N'#CursorInTrTableWithTrigger1WD: insert...'

			-- добавляем активную запись, но активная запись уже присутствует
			if (@deletedNew=0) and (@existsActiveIns=1)
			begin
				print N'#CursorInTrTableWithTrigger1WD: (@deletedNew=0) and (@existsActiveIns=1) - skipped...'
				goto next_record
			end

			if (@deletedNew=1) and (@existsDeletedIns=1) -- добавляем запись с пометкой об удалении, но запись с пометкой об удалении уже присутствует
			begin
				print N'#CursorInTrTableWithTrigger1WD: (@deletedNew=1) and (@existsDeletedIns=1)...'

				if (@existsActiveIns=1) -- запись в активном состоянии есть
				begin
					print N'#CursorInTrTableWithTrigger1WD: (@existsActiveIns=1) -> set deleted=1'

					select top 1 @idUpd=id from TableWithTrigger2WD where (value1=@value1New) and (value2=@value2New) and (value3=@value3New) and (deleted=0)

					set @tmpStr=N'#CursorInTrTableWithTrigger1WD: @idUpd='+case when @idUpd is not null then convert(nvarchar(max), @idUpd) else N'NULL' end
					print @tmpStr

					update TableWithTrigger2WD set deleted=1 where (id=@idUpd)
				end
				else -- записи в активном состоянии нет
				begin
					print N'#CursorInTrTableWithTrigger1WD: (@existsActiveIns=0) - skipped...'
				end

				goto next_record
			end

			-- добавляем активную запись, но запись с отметкой об удалении уже присутствует и записи в активном состоянии нет
			if (@deletedNew=0) and (@existsDeletedIns=1) and (@existsActiveIns=0) 
			begin
				print N'#CursorInTrTableWithTrigger1WD: (@deletedNew=0) and (@existsDeletedIns=1) and (@existsActiveIns=0) -> set deleted=0'

				select top 1 @idUpd=id from TableWithTrigger2WD where (value1=@value1New) and (value2=@value2New) and (value3=@value3New) and (deleted=1)

				set @tmpStr=N'#CursorInTrTableWithTrigger1WD: @idUpd='+case when @idUpd is not null then convert(nvarchar(max), @idUpd) else N'NULL' end
				print @tmpStr

				update TableWithTrigger2WD set deleted=0 where (id=@idUpd)

				goto next_record
			end

			-- добавляем запись с отметкой об удалении, активная запись присутствует и записи с отметкой об удалениив нет
			if (@deletedNew=1) and (@existsActiveIns=1) and (@existsDeletedIns=0)
			begin
				print N'#CursorInTrTableWithTrigger1WD: (@deletedNew=1) and (@existsActiveIns=1) and (@existsDeletedIns=0) -> set deleted=1'

				select top 1 @idUpd=id from TableWithTrigger2WD where (value1=@value1New) and (value2=@value2New) and (value3=@value3New) and (deleted=0)

				set @tmpStr=N'#CursorInTrTableWithTrigger1WD: @idUpd='+case when @idUpd is not null then convert(nvarchar(max), @idUpd) else N'NULL' end
				print @tmpStr

				update TableWithTrigger2WD set deleted=1 where (id=@idUpd)

				goto next_record
			end

			if (@existsActiveIns=0) and (@existsDeletedIns=0)
			begin
				print N'#CursorInTrTableWithTrigger1WD: (@existsActiveIns=0) and (@existsDeletedIns=0) -> insert'

				insert into TableWithTrigger2WD
				(id, value1, value2, value3, deleted)
				values
				(@idNew, @value1New, @value2New, @value3New, @deletedNew)

				goto next_record
			end
		end
		else
		begin
			print N'#CursorInTrTableWithTrigger1WD: update...'

			if exists (select 1 from TableWithTrigger2WD where (value1=@value1Old) and (value2=@value2Old) and (value3=@value3Old) and (deleted=0))
				set @existsActiveUpd=1
			else
				set @existsActiveUpd=0

			if exists (select 1 from TableWithTrigger2WD where (value1=@value1Old) and (value2=@value2Old) and (value3=@value3Old) and (deleted=1))
				set @existsDeletedUpd=1
			else
				set @existsDeletedUpd=0

			set @tmpStr=N'@existsActiveUpd='+convert(nvarchar(max), @existsActiveUpd)
			print @tmpStr
			set @tmpStr=N'@existsDeletedUpd='+convert(nvarchar(max), @existsDeletedUpd)
			print @tmpStr

			-- устанавливаем отметку об удалении записи
			if (@deletedOld=0) and (@deletedNew=1) and (@value1New=@value1Old) and (@value2New=@value2Old) and (@value3New=@value3Old)
			begin
				print N'#CursorInTrTableWithTrigger1WD: (@deletedOld=0) and (@deletedNew=1) and (@value1New=@value1Old) and (@value2New=@value2Old) and (@value3New=@value3Old)...'

				if (@existsActiveUpd=1) -- активная запись существует
				begin
					print N'#CursorInTrTableWithTrigger1WD: (@existsActiveUpd=1) -> set deleted=1'
									
					select top 1 @idUpd=id from TableWithTrigger2WD where (value1=@value1Old) and (value2=@value2Old) and (value3=@value3Old) and (deleted=0)

					set @tmpStr=N'#CursorInTrTableWithTrigger1WD: @idUpd='+case when @idUpd is not null then convert(nvarchar(max), @idUpd) else N'NULL' end
					print @tmpStr

					update TableWithTrigger2WD set deleted=1 where (id=@idUpd)
				end
				else
				begin
					if (@existsDeletedUpd=0) -- записи с пометкой об удалении нет
					begin
						print N'#CursorInTrTableWithTrigger1WD: (@existsActiveIns=0) -> insert'

						insert into TableWithTrigger2WD
						(id, value1, value2, value3, deleted)
						values
						(@idNew, @value1New, @value2New, @value3New, @deletedNew)
					end
					else
					begin
						print N'#CursorInTrTableWithTrigger1WD: (@existsActiveUpd=1) -> skipped...'
											
						goto next_record
					end
				end

				goto next_record
			end

			-- снимаем отметку об удалении записи 
			if (@deletedOld=1) and (@deletedNew=0) and (@value1New=@value1Old) and (@value2New=@value2Old) and (@value3New=@value3Old)
			begin
				print N'#CursorInTrTableWithTrigger1WD: (@deletedOld=1) and (@deletedNew=0) and (@value1New=@value1Old) and (@value2New=@value2Old) and (@value3New=@value3Old)...'

				if (@existsActiveIns=0) -- активная запись отсутствует
				begin
					print N'#CursorInTrTableWithTrigger1WD: (@existsActiveIns=0)...'
									
					if (@existsDeletedUpd=1) -- запись с пометкой об удалении присутствует
					begin
						print N'#CursorInTrTableWithTrigger1WD: (@existsDeletedUpd=1) -> set deleted=0'

						select top 1 @idUpd=id from TableWithTrigger2WD where (value1=@value1Old) and (value2=@value2Old) and (value3=@value3Old) and (deleted=1)

						set @tmpStr=N'#CursorInTrTableWithTrigger1WD: @idUpd='+case when @idUpd is not null then convert(nvarchar(max), @idUpd) else N'NULL' end
						print @tmpStr

						update TableWithTrigger2WD set deleted=0 where (id=@idUpd)
					end
					else -- запись с пометкой об удалении отсутсвует
					begin
						print N'#CursorInTrTableWithTrigger1WD: (@existsDeletedUpd=0) -> insert'

						insert into TableWithTrigger2WD
						(id, value1, value2, value3, deleted)
						values
						(@idNew, @value1New, @value2New, @value3New, @deletedNew)
					end
				end
				else
				begin
					print N'#CursorInTrTableWithTrigger1WD: (@existsActiveIns=1) -> skipped...'
									
					goto next_record
				end

				goto next_record
			end

			-- изменяем только данные не изменяя отметку об удалении записи
			if (@deletedOld=@deletedNew) and ((@value1New!=@value1Old) or (@value2New!=@value2Old) or (@value3New!=@value3Old))
			begin
				print N'#CursorInTrTableWithTrigger1WD: (@deletedOld=@deletedNew) and ((@value1New!=@value1Old) or (@value2New!=@value2Old) or (@value3New!=@value3Old))...'
							
				set @idUpd=null
				select top 1 @idUpd=id from TableWithTrigger2WD where (value1=@value1Old) and (value2=@value2Old) and (value3=@value3Old) and (deleted=@deletedOld)

				set @tmpStr=N'#CursorInTrTableWithTrigger1WD: @idUpd='+case when @idUpd is not null then convert(nvarchar(max), @idUpd) else N'NULL' end
				print @tmpStr

				if @idUpd is not null
				begin
					print N'#CursorInTrTableWithTrigger1WD: update...'
									
					update
						TableWithTrigger2WD
					set
						value1=@value1New,
						value2=@value2New,
						value3=@value3New
					where
						(id=@idUpd)
				end
				else
				begin
					print N'#CursorInTrTableWithTrigger1WD: insert...'

					insert into TableWithTrigger2WD
					(id, value1, value2, value3, deleted)
					values
					(@idNew, @value1New, @value2New, @value3New, @deletedNew)
				end

				goto next_record
			end
		end

		next_record:
		fetch from #CursorInTrTableWithTrigger1WD into @idNew, @value1New, @value2New, @value3New, @deletedNew, @idOld, @value1Old, @value2Old, @value3Old, @deletedOld
	end

	close #CursorInTrTableWithTrigger1WD
	deallocate #CursorInTrTableWithTrigger1WD
end
go
