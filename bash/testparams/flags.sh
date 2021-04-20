#!/bin/bash

echo;
echo "$0 $@ ($#)";
while getopts u:a:f: flag
do
	case "${flag}" in
		u) username=${OPTARG};;
		a) age=${OPTARG};;
		f) fullname=${OPTARG};;
	esac
done
echo "-u: $username";
echo "-a: $age";
echo "-f: $fullname";

