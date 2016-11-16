select
  *
from
  TestTableMaxSecondary
order by parent_id asc, dt desc;

select
  parent_id,
  max(dt)
from
  TestTableMaxSecondary ti
group by parent_id;

select
  p.*,
  s.*,
  v.*
from
  TestTableMaxPrimary p
  join TestTableMaxSecondary s on (s.parent_id=p.id)
  join TestTableMaxValues v on (v.id=s.value_id)
where
  (s.parent_id, s.dt) in (select
                            sg.parent_id,
                            max(sg.dt)
                          from
                            TestTableMaxSecondary sg
                          where
                            (sg.parent_id=s.parent_id)
                          group by sg.parent_id
                         )
order by p.id;

select
  p.*,
  s.*,
  v.*
from
  TestTableMaxPrimary p
  join TestTableMaxSecondary s on (s.parent_id=p.id)
  join TestTableMaxValues v on (v.id=s.value_id)
where
  s.dt >= all (select
                 sg.dt
               from
                 TestTableMaxSecondary sg
               where
                 (sg.parent_id=s.parent_id)
              )
order by p.id;

select
  p.*,
  s.*,
  v.*
from
  TestTableMaxPrimary p
  join TestTableMaxSecondary s on (s.parent_id=p.id)
  join TestTableMaxValues v on (v.id=s.value_id)
where
  (s.parent_id, s.dt) in (select
                            sg.parent_id,
                            sg.dt
                          from
                            TestTableMaxSecondary sg
                          where
                            (sg.parent_id=s.parent_id)
                            and (rownum<2)
                          --order by sg.parent_id, sg.dt 
                         )
order by p.id;

select
  p.*,
  s.*,
  v.*
from
  TestTableMaxPrimary p
  join (select
          t.*, 
          row_number() over (partition by parent_id order by dt desc) as rn
        from
          TestTableMaxSecondary t
       ) s on (s.parent_id=p.id) and s.rn = 1
  join TestTableMaxValues v on (v.id=s.value_id)
order by p.id;

select
  t.*, 
  row_number() over (partition by parent_id order by dt desc) as rn
from
  TestTableMaxSecondary t;