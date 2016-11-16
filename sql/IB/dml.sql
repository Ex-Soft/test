with Entries as
(
   select
     Id,
     Val
   from
     TableForPaging
   order by Val
)
select first 7 skip 0
/* select first 7 skip 7 */
/* select first 7 skip 14 */
/* select first 7 skip 21 */
/* select first PageSize skip (PageNo-1)*PageSize */
  *
from
  Entries;

oB!
--------------------

select first 7 skip 0
/* select first 7 skip 7 */
/* select first 7 skip 14 */
/* select first 7 skip 21 */
/* select first PageSize skip (PageNo-1)*PageSize */
  *
from
  TableForPaging
order by Val;

oB!