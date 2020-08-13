local app = import 'app.libsonnet';

function(v1='v1value', v2='v2value', envvariables='envvariables', version='50') {
  local smthValues = {
    v1: v1,
    v2: v2,
    envvariables: envvariables,
    version: version
  },

  apiVersion: 'v1',
  kind: 'List',
  
  items: [
    app.Foo(smthValues)
  ]
}
