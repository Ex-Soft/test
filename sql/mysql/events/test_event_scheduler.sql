-- https://buddhiamigo.medium.com/scheduled-events-with-aws-aurora-part-1-99f4e18d1658

drop table test_event_scheduler;

create table test_event_scheduler
(
    id int not null auto_increment,
    dt datetime,
    constraint pkTestEventScheduler primary key (id)
) character set 'utf8';
