#!/usr/bin/perl
die "Too few parameters" unless @ARGV;

$file_name=$ARGV[0];
open(INPUT_FILE,$file_name) or die "Can't open file \"$file_name\" (Message: \"$!\")";
@content=<INPUT_FILE>;
close(INPUT_FILE) or die $!;

#$test_reg_ex="/ad\\d*\\.";
#$test_reg_ex='/ad\d*\.';
#$test_reg_ex='/ad[0-9]*\.';
$test_reg_ex='/*ad[0-9]*\.';

$TestStr="ad17.ad177.ad1777.bannerbank.ru";

while($result=$TestStr=~m/$test_reg_ex/ig)
{
    print "result=$result, current match is $&, position=",pos($TestStr),"\n";
}

$result=$TestStr=~m/$test_reg_ex/i;
if($result)
{
    print "(from (if($result))): $TestStr\n";
}
else
{
    print "No!!!\n";
}

if($result=$TestStr=~m/$test_reg_ex/i)
{
    print "result=$result, current match is $&, position=",pos($TestStr),"\n";
}
else
{
    print "No!!!\n";
}
$TestStr="ad.bannerbank.ru";
$result=$TestStr=~m/$test_reg_ex/i;
if($result)
{
    print "(from (if($result))): $TestStr\n";
}
else
{
    print "No!!!\n";
}

if($result=$TestStr=~m/$test_reg_ex/i)
{
    print "result=$result, current match is $&, position=",pos($TestStr),"\n";
}
else
{
    print "No!!!\n";
}
print "\n";

print "Scan result:\n";
foreach (@content)
{
   $tmpstr=$_;
   print "$tmpstr";

   $result=$tmpstr=~m/$test_reg_ex/i;
   if($result)
   {
     print "(from (if($result))): $tmpstr";
   }
   
   if($result=$tmpstr=~m/$test_reg_ex/i)
   {
        print "result=$result, current match is $&, position=",pos($tmpstr),"\n";
   }
}