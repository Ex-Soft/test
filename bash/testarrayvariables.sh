#!/bin/bash

export arr=( "1st" "2nd" "3rd" "4th" "5th" )
echo "${arr[*]}"
echo "$arr[*]"
echo "${arr[0]}"
echo "${arr[1]}"
echo "${arr[2]}"
echo "${arr[3]}"
echo "${arr[4]}"
echo "length arr[0]: ${#arr}"
echo "length arr: ${#arr[@]}"
echo "arr: ${arr[@]}"

echo
echo "${arr:0}"
echo "${arr:1}"
echo "${arr:2}"

echo
echo "${arr[@]:0}"
echo "${arr[@]:1}"
echo "${arr[@]:2}"
echo "${arr[@]:3}"
echo "${arr[@]:4}"

echo
echo "${arr[@]:2:1}"
echo "${arr[@]:1:3}"

