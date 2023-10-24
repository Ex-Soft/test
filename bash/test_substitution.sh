#!/bin/bash

# https://www.cyberciti.biz/tips/bash-shell-parameter-substitution-2.html
# https://tldp.org/LDP/Bash-Beginners-Guide/html/sect_10_03.html
# https://www.gnu.org/software/bash/manual/html_node/Shell-Parameter-Expansion.html

# ${VAR:-WORD}

DEBUG_MODE="${DEBUG:-false}"
echo "${DEBUG_MODE}"

DEBUG=true
DEBUG_MODE="${DEBUG:-false}"
echo "${DEBUG_MODE}"
