#!/bin/bash

# https://medium.com/@DazWilkin/a-jsonnet-builder-for-container-builder-71a0f6c18db7
# git clone https://github.com/google/jsonnet.git && cd jsonnet && make

export V1="V1Value"
export V2="V2Value"
export LC_PROJECT_NAME="PROJECT_NAME"
export env="env"
export version="1"

./jsonnet main.jsonnet \
  --tla-str v1=${V1} \
  --tla-str v2=${V2} \
  --tla-str envvariables=${LC_PROJECT_NAME}.${env}.variables.${version} \
  --tla-code version=${version} \
  -o result.json
