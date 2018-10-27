create table if not exists staff (
    id bigint not null auto_increment,
    name varchar(128) null,
    constraint pkStaff primary key (id)
) character set 'utf8';