select
  chr(65)||chr(97)||chr(66)||chr(98)||chr(67)||chr(99)||chr(69)||chr(101)||chr(72)||chr(104)||chr(73)||chr(105)||chr(75)||chr(107)||chr(77)||chr(109)||chr(79)||chr(111)||chr(80)||chr(112)||chr(81)||chr(113)||chr(84)||chr(116)||chr(88)||chr(120)||chr(89)||chr(121) as EngStr,
  chr(192)||chr(224)||chr(194)||chr(226)||chr(209)||chr(241)||chr(197)||chr(229)||chr(205)||chr(237)||chr(178)||chr(179)||chr(202)||chr(234)||chr(204)||chr(236)||chr(206)||chr(238)||chr(208)||chr(240)||chr(206)||chr(238)||chr(210)||chr(242)||chr(213)||chr(245)||chr(211)||chr(243) as CyrStr,
  N'AaBbCcEeHhIiKkMmOoPpQqTtXxYy' as EngN,
  N'ÀàÂâÑñÅåÍí²³ÊêÌìÎîĞğÎîÒòÕõÓó' as CyrN,
  translate('AaBbCcEeHhIiKkMmOoPpQqTtXxYy','AaBbCcEeHhIiKkMmOoPpQqTtXxYy','ÀàÂâÑñÅåÍí²³ÊêÌìÎîĞğÎîÒòÕõÓó') as Eng2Cyr,
  translate(N'AaBbCcEeHhIiKkMmOoPpQqTtXxYy',N'AaBbCcEeHhIiKkMmOoPpQqTtXxYy',N'ÀàÂâÑñÅåÍí²³ÊêÌìÎîĞğÎîÒòÕõÓó') as Eng2CyrN
from dual;

select
  translate('A a','Aa ','Àà') as Eng2Cyr,
  translate(N'A a',N'Aa ',N'Àà') as Eng2CyrN
from dual;

select
  regexp_replace('   A    a   ',' ','')
from dual;

select
  regexp_replace('   A    a   ','[[:blank:]]','')
from dual;

select
  regexp_replace('1   A    a   9','[[:alpha:]]','')
from dual;

select
  regexp_replace('1   A    a   9','[^[:alpha:]]','')
from dual;