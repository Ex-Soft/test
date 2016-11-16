drop procedure "TableVictimIISave";

create or replace procedure "TableVictimIISave" (a "TableVictimII"."Id"%TYPE, b "TableVictimII"."Val"%TYPE, c "TableVictimII"."comment"%TYPE, d out "TableVictimII"."Id"%TYPE)
as
begin
  d:=a+b;
  insert into "TableVictimII"
  ("Id", "Val", "comment")
  values
  (a, b, c);
end;
