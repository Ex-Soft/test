#!/bin/bash

echo;
echo "$0 $@ ($#)";
i=1;
for arg in "$@"
do
	echo "\$$i: $arg";
	i=$((i + 1));
done

