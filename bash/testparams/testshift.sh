#!/bin/bash

echo;
echo "$0 $@ ($#)";

# 1st
echo "\$1: $1";

# 2nd
shift 1;
echo "\$1: $1";

# 4th
shift 2;
echo "\$1: $1";

