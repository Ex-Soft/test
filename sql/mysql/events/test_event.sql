drop event test_event;

create event test_event
on schedule every 1 minute starts '2022-03-25T16:45:00+02:00'
on completion preserve
do insert into test_event_scheduler (dt) values (current_timestamp);

alter event test_event disable;
