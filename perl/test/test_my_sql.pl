#!/usr/bin/perl
use strict;
use DBI;

my $datasrc1='mysql:database=test';
my $datasrc2='mysql:database=test2';
my $dbh1=DBI->connect("dbi:$datasrc1","root","") or die DBI->errstr;
my $dbh2=DBI->connect("dbi:$datasrc2","root","") or die DBI->errstr;
my $sth1=$dbh1->prepare("select id, f2 from tbl1");
$sth1->execute();
while(my ($id,$f2)=$sth1->fetchrow_array())
{
	print "update tbl2 set f2=$f2 where id=$id\n";
	my $sth2=$dbh2->prepare("update tbl2 set f2=$f2 where id=$id");
	$sth2->execute();
}
warn "Problem in retrieving results", $sth1->errstr( ), "\n" if $sth1->err();

$dbh1->disconnect or die DBI->errstr;
$dbh2->disconnect or die DBI->errstr;
