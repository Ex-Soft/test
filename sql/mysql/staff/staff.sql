create table if not exists Staff (
    Id int not null auto_increment,
    Name varchar(256) null,
    Salary decimal(18, 4) null,
    Dep int null,
    BirthDate date null,
    constraint pkStaff primary key (Id)
) character set 'utf8';
