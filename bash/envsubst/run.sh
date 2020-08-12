#!/bin/bash
source .env
cat victim.yml | envsubst > result.yml
# equ
# cat victim.yml | (. .env && envsubst) > result.yml
