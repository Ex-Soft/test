local app = app.libsonnet;

function(envvariables='envvariables') {
  local smthValues = {
    envvariables: envvariables
  },

  apiVersion: 'v1',
  kind: 'List',
  
  items: [
    app.Foo(smthValues)
  ]
}
