@echo off

set V1=V1Value
set V2=V2Value
set LC_PROJECT_NAME=PROJECT_NAME
set env=env
set version=1

jsonnet main.jsonnet --tla-str v1=%V1% --tla-str v2=%V2% --tla-str envvariables=%LC_PROJECT_NAME%.%env%.variables.%version% --tla-code version=%version% -o result.json
