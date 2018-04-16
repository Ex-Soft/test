require([
    "dojo/_base/xhr",
    "dojox/grid/DataGrid",
    "dojo/store/Memory",
    "dojo/store/JsonRest",
    "dojo/data/ObjectStore",
    "dojo/date/locale",
    "dijit/form/Button",
    "dojo/domReady!"
], function (xhr, DataGrid, Memory, JsonRest, ObjectStore, locale, Button) {
    var
        formatDate = function (inDatum) {
            return locale.format(new Date(inDatum), this.constraint);
        },
        store1 = new JsonRest({
            target: "api/Data",
            idProperty: "Id"
        }),
        objectStore1 = new ObjectStore({
            objectStore: store1
        }),
        grid1 = new DataGrid({
            store: objectStore1,
            structure: [
                { name: "Id", field: "Id" },
                { name: "FString", field: "FString" },
                { name: "FDecimal", field: "FDecimal" },
                { name: "FDateTime", field: "FDateTime", formatter: formatDate, constraint: { formatLength: 'long', selector: "date" }}
            ]
        }, "idGrid1"),
        store2 = new Memory({
            idProperty: "Id"
        }),
        objectStore2 = new ObjectStore({
            objectStore: store2
        }),
        grid2 = new DataGrid({
            store: objectStore2,
            structure: [
                { name: "Id", field: "Id" },
                { name: "FString", field: "FString" },
                { name: "FDecimal", field: "FDecimal" },
                { name: "FDateTime", field: "FDateTime", formatter: formatDate, constraint: { formatLength: 'long', selector: "date" } }
            ]
        }, "idGrid2"),
        deferred = xhr("GET", {
            url: "api/Data",
            handleAs: "json",
            load: function (response, ioArgs) {
                if (window.console && console.log)
                    console.log("load(%o)", arguments);

                if (Array.isArray(response)) {
                    response.forEach(function (item) {
                        objectStore2.newItem(item);
                    });

                    objectStore2.save();
                }
            },
            error: function (response, ioArgs) {
                if (window.console && console.log) {
                    console.log("error(%o)", arguments);
                    console.log("response.message \"%s\"", response.message); // message: "Unable to load api/Data status: 500"
                    console.log("response.response %o", response.response); // Object { url: "api/Data", options: {…}, getHeader: getHeader(), xhr: XMLHttpRequest, loaded: 16, total: 16, status: 500, text: "\"blah-blah-blah\"", data: "\"blah-blah-blah\"" }
                    console.log("response.responseText \"%s\"", response.responseText); // responseText: "\"blah-blah-blah\""
                    console.log("response.status \"%s\"", response.status); // status: 500
                    console.log("response.xhr %o", response.xhr); // XMLHttpRequest { onreadystatechange: null, readyState: 4, timeout: 0, withCredentials: false, upload: XMLHttpRequestUpload, responseURL: "http://localhost:50158/api/Data", status: 500, statusText: "Internal Server Error", responseType: "", response: "\"blah-blah-blah\"" }
                }
            }
        }),
        btnAdd = new Button({
            onClick: function (e) {
                if (window.console && console.log)
                    console.log(objectStore2);

                var newId = objectStore2.objectStore.data.length + 1;
                objectStore2.newItem({ Id: newId, FString: "FString# " + newId, FDecimal: newId, FDateTime: new Date() });
                objectStore2.save();
            }
        }, "btnAdd");

    deferred.then(function () {
        if (window.console && console.log)
            console.log("resolvedCallback(%o)", arguments);
    }, function () {
        if (window.console && console.log)
            console.log("errorCollback(%o)", arguments);
    }, function () {
        if (window.console && console.log)
            console.log("progressCollback(%o)", arguments);
    });

    grid1.startup();
    grid2.startup();
});
