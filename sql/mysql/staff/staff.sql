create table if not exists staff (
    id int not null auto_increment,
    name varchar(256) null,
    salary decimal(18, 4) null,
    dep int null,
    birth_date date null,
    constraint pkStaff primary key (id)
) character set 'utf8';
