#!/bin/bash

echo;
echo "$0 $@ ($#)";

echo;
echo "${@:1}";
echo "${@:2}";

echo;
echo "${@:1:1}";
echo "${@:2:$1}";

a=( "${@:2:$1}" ); shift "$(( $1 + 1 ))"
b=( "${@:2:$1}" ); shift "$(( $1 + 1 ))"
c=( "${@:2:$1}" ); shift "$(( $1 + 1 ))"

echo;
declare -p a b c

echo;
echo ${a[@]};
echo ${b[@]};
echo ${c[@]};

