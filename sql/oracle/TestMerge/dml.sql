http://www.oracle-base.com/articles/10g/MergeEnhancements10g.php

merge into TableSecondary dest
  using TablePrimary src
    on (dest.Id = src.Id)
  when not matched then
    insert (Id, Val)
    values (src.Id, src.Val);

merge into TableSecondary dest
  using TablePrimary src
    on (dest.Id = src.Id)
  when matched then
    update set dest.Val = src.Val;

merge into TableSecondary dest
  using TablePrimary src
    on (dest.Id = src.Id)
  when matched then
    update set dest.Val = src.Val
  when not matched then
    insert (Id, Val)
    values (src.Id, src.Val);

merge into TableSecondary dest
  using TablePrimary src
    on (dest.Id = src.Id)
  when not matched then
    insert (Id, Val)
    values (src.Id, src.Val)
    where (src.Id=4);

merge into TableSecondary dest
  using TablePrimary src
    on (dest.Id = src.Id)
  when matched then
    update set dest.Val = src.Val
    where (src.Id=3);

merge into TableSecondary dest
  using TablePrimary src
    on (dest.Id = src.Id)
  when matched then
    update set dest.Val = src.Val
    where (src.Id=3)
  when not matched then
    insert (Id, Val)
    values (src.Id, src.Val)
    where (src.Id=4);

merge into TableSecondary dest
  using TablePrimary src
    on (dest.Id = src.Id)
  when matched then
    update set dest.Val = src.Val
    where (src.Id=3)
  delete where (src.Id<>3);
