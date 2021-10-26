#!/bin/bash

./positionalparameters.sh 1st 2dn 3rd 4th 5th
./flags.sh -f 'John Smith' -a 25 -u john
./loopconstruct.sh 1st 2dn 3rd 4th 5th
./shiftoperator.sh 1st 2dn 3rd 4th 5th
./testshift.sh 1st 2nd 3rd 4th 5th

export arr1=( "1st" "2nd" "3rd" "4th" "5th" )
export arr2=( "5th" "4th" "3rd" "2nd" "1st" )
export arr3=( "one" "two" "three" "four" "five" )
./testparamsbyarraywithsize.sh "${#arr1[@]}" "${arr1[@]}" "${#arr2[@]}" "${arr2[@]}" "${#arr3[@]}" "${arr3[@]}"
./testparamsbyarraywithsize.sh "${#arr1[@]}" "${arr1[@]}" "" "${#arr3[@]}" "${arr3[@]}"
