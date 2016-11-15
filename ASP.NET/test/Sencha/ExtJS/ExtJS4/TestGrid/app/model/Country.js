Ext.define("TG.model.Country", {
    extend: "Ext.data.Model",
    idProperty: "Id",
    fields: [
        { name: "Id", type: "int" },
        "Value"
    ]
});
