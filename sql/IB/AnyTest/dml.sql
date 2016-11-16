select
    Length_Of_File,
    MD5,
    count(*)
from
    AnyTest
group by Length_Of_File, MD5
having count(*) > 1;

select
    *
from
    AnyTest outerTable
where exists (
    select
        innerTable.MD5,
        count(*)
    from
        AnyTest innerTable
    where
        innerTable.Length_Of_File = outerTable.Length_Of_File
    group by innerTable.MD5
    having count(*) > 1
);
