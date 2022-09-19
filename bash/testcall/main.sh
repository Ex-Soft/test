#!/bin/bash

SCRIPT_PATH="./callee.sh"

# https://bash.cyberciti.biz/guide/Logical_Not_!
[ ! -f "$SCRIPT_PATH" ] && { echo "$SCRIPT_PATH doesn't exist"; exit 1; }

echo "main.sh starting..."

"$SCRIPT_PATH"

. "$SCRIPT_PATH"

source "$SCRIPT_PATH"

bash "$SCRIPT_PATH"

eval '"$SCRIPT_PATH"'

OUTPUT=$("$SCRIPT_PATH")
echo $OUTPUT

OUTPUT=`"$SCRIPT_PATH"`
echo $OUTPUT

("$SCRIPT_PATH")

(exec "$SCRIPT_PATH")

echo "main.sh finished"