#!/bin/bash
for filename in ./*.txt; do
  echo $filename
  sed -i "s/Version: [0-9]*\.[0-9]*\.[0-9]*/Version: 2.0.0/" $filename
done

