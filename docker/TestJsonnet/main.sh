#!/bin/bash

export V1=V1Value
export V2=V2Value
export LC_PROJECT_NAME=PROJECT_NAME
export env=env
export version=1

jsonnet main.jsonnet \
  --tla=str envvariables=${LC_PROJECT_NAME}.${env}.variables.${version} \
  -o result.json

