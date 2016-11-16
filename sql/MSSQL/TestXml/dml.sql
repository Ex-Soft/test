declare
  @x xml

set @x=N'<root><item id="1">11</item><item id="2">22</item></root>'

------------------------------------------------------------
select
  n.v.query('.')
from
  @x.nodes('root') as n(v)

-- <root><item id="1">11</item><item id="2">22</item></root>
------------------------------------------------------------

select
  n.v.query('.')
from
  @x.nodes('root/item') as n(v)

-- <item id="1">11</item>
-- <item id="2">22</item>
------------------------------------------------------------

select
  n.v.query('.')
from
  @x.nodes('root/item/node()') as n(v)

-- 11
-- 22
------------------------------------------------------------

select
  n.v.query('.')
from
  @x.nodes('root/item/text()') as n(v)

-- 11
-- 22
------------------------------------------------------------

select
  n.v.value('@id','int')
from
  @x.nodes('root/item') as n(v)

-- 1
-- 2
------------------------------------------------------------

select
  n.v.value('(item)[1]','int')
from
  @x.nodes('root') as n(v)

-- 11
------------------------------------------------------------

select
  n.v.value('(item/node())[1]','int')
from
  @x.nodes('root') as n(v)

-- 11
------------------------------------------------------------

select
  n.v.value('(item/text())[1]','int')
from
  @x.nodes('root') as n(v)

-- 11
------------------------------------------------------------

select
  n.v.value('.','int')
from
  @x.nodes('root/item') as n(v)

-- 11
-- 22
------------------------------------------------------------

select
  n.v.value('.','int')
from
  @x.nodes('root/*') as n(v)

-- 11
-- 22
------------------------------------------------------------

declare
  @idoc int

exec sp_xml_preparedocument @idoc OUTPUT, @x

select
  *
from
  openxml(@idoc, 'root/item', 1)
with
  (item int 'text()')

-- 11
-- 22
------------------------------------------------------------

select
  s.*
from
  Staff s
  join @x.nodes('root') as n(v) on v.value('(item/text())[1]','int') = s.ID

-- 11
------------------------------------------------------------

select
  s.*
from
  Staff s
  join @x.nodes('root/item') as n(v) on v.value('@id','int') = s.ID

-- 1
-- 2
------------------------------------------------------------
