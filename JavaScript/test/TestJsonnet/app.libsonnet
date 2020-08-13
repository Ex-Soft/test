{
    Foo(smthValues):: {
      v1: smthValues.v1,
      v2: smthValues.v2,
      smthValues: smthValues,
      version: smthValues.version,
      smthValuesEnvVariables: smthValues.envvariables,
      valueFromV1: {
        name: "V1",
        valueFrom: {
          configMapKeyRef: {
            name: smthValues.envvariables,
            key: "V1"
          }
        }
      }
    }
}