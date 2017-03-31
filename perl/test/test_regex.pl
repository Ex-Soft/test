#!/usr/bin/perl

$TestStr="aaab";
$TestStr=~m/a*b/;
print "\$\` = $`\n";
print "\$\& = $&\n"; #aaab
print "\$\' = $'\n";
print "\n";

$TestStr="aaab";
$TestStr=~m/a*?b/;
print "\$\` = $`\n";
print "\$\& = $&\n"; #aaab
print "\$\' = $'\n";
print "\n";

$TestStr="aaabbbcccddd";

$TestStr=~m/b+c+/;
print "\$\` = $`\n"; #aaa
print "\$\& = $&\n"; #bbbccc
print "\$\' = $'\n"; #ddd
print "\n";

$TestStr=~m/b+(?=c+)/;
print "\$\` = $`\n"; #aaa
print "\$\& = $&\n"; #bbb
print "\$\' = $'\n"; #cccddd
print "\n";

$TestStr=~m/b+(?!c+)/;
print "\$\` = $`\n"; #aaa
print "\$\& = $&\n"; #bb
print "\$\' = $'\n"; #bcccddd
print "\n";

$TestStr=~m/(?<=b)b+/;
print "\$\` = $`\n"; #aaab
print "\$\& = $&\n"; #bb
print "\$\' = $'\n"; #cccddd
print "\n";

$TestStr=~m/(?<!b)c+/;
print "\$\` = $`\n"; #aaabbbc
print "\$\& = $&\n"; #cc
print "\$\' = $'\n"; #ddd
print "\n";

$TestStr="[code]code1[/code]\n[code]code2[/code]\n[code]\n\n\ncode3\n[/code]";

$TestStr=~m/\[code\].*?\[\/code\]/;
print "\$\` = $`\n";
print "\$\& = $&\n";
print "\$\' = $'\n";
print "\n";

$TestStr=~m/(?<=\[code\]).*?(?=\[\/code\])/;
print "\$\` = $`\n";
print "\$\& = $&\n";
print "\$\' = $'\n";
print "\n";

while($result=$TestStr=~m/(?<=\[code\])\s*?.*?\s*?(?=\[\/code\])/mg)
{
    print "result=$result, current match is \"$&\", position=",pos($TestStr),"\n";
}

$TestStr="Copyright 2003.";
$TestStr=~m/^.*([0-9][0-9])/;
print "\$\` = $`\n";
print "\$\& = $&\n"; #Copyright 2003
print "\$\' = $'\n";
print "\n";

$TestStr=~m/^.*([0-9]+)/;
print "\$\` = $`\n";
print "\$\& = $&\n"; #Copyright 2003
print "\$\' = $'\n";
print "\n";

$TestStr=~m/^.*([0-9]*)/;
print "\$\` = $`\n";
print "\$\& = $&\n"; #Copyright 2003.
print "\$\' = $'\n";
print "\n";

$TestStr="27.625";
$TestStr=~m/(\.\d\d[1-9]?)\d*/;
print "\$\` = $`\n"; #27
print "\$1 = $1\n"; #.625
print "\$\& = $&\n"; #.625
print "\$\' = $'\n";
print "\n";

$TestStr=~m/(\.\d\d[1-9]?)\d+/;
print "\$\` = $`\n"; #27
print "\$1 = $1\n"; #.62
print "\$\& = $&\n"; #.625
print "\$\' = $'\n";
print "\n";

