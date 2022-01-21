#!/bin/bash
a="qwerty"

if [ ! -z "$1" ] && [ "$1" = "qwerty" ] ; then
  echo $a
else
  echo "empty"
fi
