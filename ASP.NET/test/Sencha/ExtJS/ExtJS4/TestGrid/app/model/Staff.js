Ext.define("TG.model.Staff", {
    extend: "Ext.data.Model",
    idProperty: "Id",
    fields: [
        { name: "Id", type: "int" },
        "Name",
        { name: "Salary", type: "float" },
        { name: "Dep", type: "int" },
        { name: "BirthDate", type: "date", dateFormat: "MS" }
    ]
});
