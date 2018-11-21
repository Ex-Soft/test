Ext.define("UniView.view.main.MainController", {
    extend: "Ext.app.ViewController",

    alias: "controller.main",

    onTableRowClick: function(gridView, record, element, rowIndex, e, eOpts) {
        var gridsPanel;

        if (!record || !(gridsPanel = this.lookupReference("gridstabpanel")))
            return;

        gridsPanel.fireEvent("addtable", { name: record.get("name"), description: record.get("description") });
    }
});
