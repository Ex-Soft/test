#!/bin/bash

echo;
echo "$0 $@ ($#)";
i=1;
j=$#;
while [ $i -le $j ] 
do
	echo "\$1: $1";#
	i=$((i + 1));
	shift 1;
done

