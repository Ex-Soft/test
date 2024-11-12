use testdb;
go

delete from Staff;
go

insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'George Washington', 1000, 1, N'17320222', null);
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'John Adams', 2000, 1, N'17351030', null);
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Thomas Jefferson', 3000, 1, N'17430413', null);

insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Кравчук Леонид Макарович', 333, 380, N'19340110', null);
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Кучма Леонид Данилович', 444, 380, N'19380809', null);
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Ющенко Виктор Андреевич', 111, 380, N'19540223', null);
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Янукович Виктор Федорович', 555, 380, N'19500709', null);

insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Ленин Владимир Ильич', 1000, 1, N'18700422', null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Сталин Иосиф Виссарионович', 300, 1, N'18781218', null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Хрущев Никита Сергеевич', 5000, 1, N'18940417', null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Брежнев Леонид Ильич', 1500, 1, N'19061219', null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Андропов Юрий Владимирович', 10000, 1, N'19140615', null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Черненко Константин Устинович', 100.01, 1, N'19110924', null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Горбачев Михаил Сергеевич', 222, 1, N'19310302', null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Иванов Иван Иванович', 3000, 3, null, null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Петров Петр Петрович', 5000, 3, null, null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Сидоров Сидор Сидорович', 1500, 3, null, null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Васильев Василий Василиевич', 3000, 3, null, null)
insert into Staff (Name, Salary, Dep, BirthDate, NullField) values (N'Дем''ян Бэдний', 800, 4, N'18830401', null)
go