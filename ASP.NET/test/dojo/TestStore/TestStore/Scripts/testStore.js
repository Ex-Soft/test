require([
    "dojox/grid/DataGrid",
    "dojo/store/JsonRest",
    "dojo/data/ObjectStore",
    "dojo/date/locale",
    "dojo/domReady!"
], function (DataGrid, JsonRest, ObjectStore, locale) {
    var
        store = new JsonRest({
            target: "api/Data",
            idProperty: "Id"
        }),
        formatDate = function(inDatum) {
            return locale.format(new Date(inDatum), this.constraint);
        },
        grid = new DataGrid({
            store: new ObjectStore({ objectStore: store }),
            structure: [
                { name: "Id", field: "Id" },
                { name: "FString", field: "FString" },
                { name: "FDecimal", field: "FDecimal" },
                { name: "FDateTime", field: "FDateTime", formatter: formatDate, constraint: { formatLength: 'long', selector: "date" }}
            ]
    }, "GridId");
    grid.startup();
});
