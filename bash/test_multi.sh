#!/bin/bash
FILE_NAME="multi.txt"

if [[ ! -d "$FILE_NAME" && ! -f "$FILE_NAME" ]] ; then
  echo "$FILE_NAME doesn't exist"
fi; echo "$(date +%Y-%m-%d-%H-%M-%S-%N)" > "$FILE_NAME"
