Ext.define('TodoApi.model.Personnel', {
    extend: 'Ext.data.Model',

    schema: {
        namespace: 'TodoApi.model'
    },

    idProperty: "id",

    fields: [
            { name: "id", type: "int" },
            "name",
            "emai",
            "phone"
    ]
});
