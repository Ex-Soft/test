drop table test_types;

create table test_types
(
    id int not null auto_increment,
    f_datetime datetime,
    f_timestamp timestamp,
    f_varchar255 varchar(255) character set utf8,
    constraint pkTestTypes primary key (id)
) character set 'utf8';