--delete from Data4TestDEPivotGrid

declare
	@n int,
	@maxN int = 5,
	@y smallint,
	@q tinyint,
	@m tinyint,
	@d tinyint

set @y = 2013
while @y <= 2015
	begin
		set @m = 1
		while @m <= 12
			begin
				set @d = 1
				while @d <= 31
					begin
						set @n = 1
						while @n <= @maxN
							begin
								insert into Data4TestDEPivotGrid
								([year], [quarter], [month], [day], name, [value])
								values
								(
									@y,
									case
										when @m between 1 and 3
											then 1
										when @m between 4 and 6
											then 2
										when @m between 7 and 9
											then 3
										when @m between 10 and 12
											then 4
									end,
									@m,
									@d,
									N'name ' + convert(nvarchar(255), @n),
									cast(@y as money) * cast(@m as money) * cast(@d as money) * cast(@n as money)
								)
								
								set @n += 1
							end
						set @d += 1
					end
				set @m += 1
			end
		set @y +=1
	end

select * from Data4TestDEPivotGrid