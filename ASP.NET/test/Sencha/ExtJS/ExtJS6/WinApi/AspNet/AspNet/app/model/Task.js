Ext.define('AspNetApp.model.Task', {
    extend: 'Ext.data.Model',

    schema: {
        namespace: 'AspNetApp.model'
    },

    idProperty: "Id",

    fields: [
            { name: "Id", type: "int" },
            "TaskName",
            { name: "Date", type: "date", dateFormat: "c" },
            { name: "Begin", type: "date", dateFormat: "c" },
            { name: "End", type: "date", dateFormat: "c" }
    ]
});
