#!/usr/bin/perl
die "Too few parameters" unless @ARGV;

$name="WORLD";

print "Hello, world!!!\n";
print "Hello,
 world!!!\n";
print "Hello, world!!!\n";
print 'Hello, world!!!\n';
print "Hello, $name!!!\n";
print 'Hello, $name!!!\n';

$file_name=$ARGV[0];
open(INPUT_FILE,$file_name) or die "Can't open file \"$file_name\" (Message: \"$!\")";
@content=<INPUT_FILE>;
close(INPUT_FILE) or die $!;

print "\n";
$len=@content;
print "The length = $len\n";
if($len>0)
{
   for($i=0; $i<$len; ++$i)
   {
      print "$content[$i]";
   }
   print "\n";

   for $temp (@content)
   {
      print $temp;
   }
   print "\n";

   foreach $temp (@content)
   {
      print $temp;
   }
   print "\n";

   foreach (@content)
   {
      print $_;
   }
   print "\n";
}

@animals = ("camel", "llama", "owl", "cat");
@numbers = (23, 42, 69);
@mixed   = ("camel", 42, 1.23);

print "$animals[0]\n";
print "$animals[1]\n";

print "$mixed[$#mixed]\n";

@sub_anumals=@animals[1..$#animals];
$len=@sub_animals;
print "The length = $len\n";
if($len>0)
{
   foreach (@sub_animals)
   {
      print "$_\n";
   }
   print "\n";
}

$temp=@animals[1..$#animals];
print "$temp\n";

print "\n";
foreach (@animals[1..$#animals])
{
   print "$_\n";
}
print "\n";

#$test_reg_ex="/ad\\d*\\.";
#$test_reg_ex='/ad\d*\.';
$test_reg_ex='/ad[0-9]*\.';

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
   #if($result=$tmpstr=~m/\/ad\d*\./i)
   {
        print "result=$result, current match is $&, position=",pos($tmpstr),"\n";
   }
}