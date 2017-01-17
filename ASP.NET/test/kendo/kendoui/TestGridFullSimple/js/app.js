$(document).ready(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log) {
        console.log("jquery: %s", $.fn.jquery);
        console.log("kendo: %s", kendo.version);
    }
    
    var 
        Staff = kendo.data.Model.define({
            id: "Id",
            fields: {
                "Id": { type: "number", editable: true, defaultValue: 0 },
                "Name": { type: "string", editable: true, defaultValue: "empty" },
                "Salary": { type: "number", editable: true },
                "Dep": {
                    type: "number",
                    editable: true,
                    validation: {
                        required: true,
                        min: 1
                    }
                },
                "BirthDate": {
                    type: "date",
                    editable: true
                    /*,parse: function (data) {
                    if (window.console && console.log)
                    console.log("parse(%o)", arguments);

                    return data;
                    }*/
                }
            }
        }),
        dataSource = new kendo.data.DataSource({
            type: "json",
            batch: true,
            transport: {
                create: {
                    url: "staff.aspx",
                    type: "POST"
                    , dataType: "json"
                    , contentType: "application/json"
                },
                read: {
                    url: "staff.aspx",
                    type: "GET"
                },
                update: {
                    url: "staff.aspx",
                    type: "PUT"
                    , dataType: "json"
                    , contentType: "application/json"
                },
                destroy: {
                    url: "staff.aspx",
                    type: "DELETE"
                    , dataType: "json"
                    , contentType: "application/json"
                }
                , parameterMap: function (data, operation) {
                    if (window.console && console.log)
                        console.log("parameterMap(%o)", arguments);

                    var ds = dataSource;

                    if (operation == "create" || operation == "update" || operation == "destroy") {
                        var result = [];

                        for (var i = 0; i < data.models.length; i++)
                            result.push(data.models[i]);

                        return kendo.stringify(result);
                    }
                    else
                        return data;
                }
            },
            pageSize: 10,
            serverPaging: true,
            schema: {
                model: Staff,
                data: "staff",
                total: "total"
            }
        });

    $("#grid").kendoGrid({
        dataSource: dataSource,
        groupable: true,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        toolbar: ["create", "save", "cancel"],
        columns: [
            { field: "Id", title: "Id", type: "number", width: 140 },
            { field: "Name", title: "Name", type: "string", width: 190 },
            { field: "Salary", title: "Salary", type: "number" },
            { field: "Dep", title: "Dep", type: "number", width: 110 },
            { field: "BirthDate", title: "BirthDate", type: "date", format: "{0:dd-MM-yyyy}", width: 110 },
            { command: [/*"edit",*/"destroy"] }
        ]
        , editable: true
        //,editable: "inline"
        //,editable: "popup"
    });
});