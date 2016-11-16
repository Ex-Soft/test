execute ibeblock
as
begin

delete from Staff;

insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (1, 'Ленин Владимир Ильич', 1000, 1, '1870-04-22', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (2, 'Сталин Иосиф Виссарионович', 300, 1, '1878-12-18', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (3, 'Хрущев Никита Сергеевич', 5000, 1, '1894-04-17', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (4, 'Брежнев Леонид Ильич', 1500, 1, '1906-12-19', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (5, 'Андропов Юрий Владимирович', 10000, 1, '1914-06-15', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (6, 'Черненко Константин Устинович', 100.01, 1, '1911-09-24', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (7, 'Горбачев Михаил Сергеевич', 222, 1, '1931-03-02', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (8, 'Кравчук Леонид Макарович', 333, 2, '1934-01-10', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (9, 'Кучма Леонид Данилович', 444, 2, '1938-08-09', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (10, 'Ющенко Виктор Андреевич', 111, 2, '1954-02-23', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (11, 'Янукович Виктор Федорович', 555, 2, '1950-07-09', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (12, 'Порошенко Петро Олексійович', 666, 2, '1965-09-26', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (13, 'Иванов Иван Иванович', 3000, 3, null, null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (14, 'Петров Петр Петрович', 5000, 3, null, null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (15, 'Сидоров Сидор Сидорович', 1500, 3, null, null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (16, 'Васильев Василий Василиевич', 3000, 3, null, null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (17, 'Дем''ян Бэдний', 800, 4, '1883-04-01', null);
insert into Staff (Id, Name, Salary, Dep, BirthDate, NullField) values (18, 'Вашингтон Джордж', 8000, 5, '1732-02-22', null);

end
