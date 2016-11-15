$(document).ready(function() {
    $(".testKendoComboBox").kendoComboBox({
        dataValueField: "id",
        dataTextField: "name",
        dataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    url: "staffs"
                }
            }
        })
    });
});