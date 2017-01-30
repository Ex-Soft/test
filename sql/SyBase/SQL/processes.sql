select
p.spid,
p.fid,
p.status,
suser_name(p.suid) as login,
db_name(p.dbid) as db_name,
object_name(l.id,l.dbid) as table_name,
p.program_name,
object_name(p.id,p.dbid) as procedure_name,
p.cmd,
p.stmtnum,
p.linenum,
p.cpu,
p.physical_io,
p.memusage,
p.blocked,
l.class,
v.name as name_L,
vlc.name as name_L2,
p.time_blocked,
l.page,
l.row,
p.tran_name,
p.priority,
p.loggedindatetime,
p.hostname,
p.ipaddr
from
master..sysprocesses p
left outer join master..syslocks l on p.spid = l.spid
left outer join master..spt_values v on l.type = v.number and v.type = 'L'
left outer join master..spt_values vlc on l.context + 2049 = vlc.number and vlc.type = 'L2'
where
(p.spid!=0)
and (p.spid!=@@SPID)