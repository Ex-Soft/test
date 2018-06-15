Ext.define("TestRouting.controller.CNavPanel", {
    extend: "Ext.app.Controller",
    
    stores: ["NavStore"],

    models: ["NavModel"],

    init: function(app) {
        if (window.console && console.log)
            console.log("CNavPanel.init(%o)", arguments);

        this.control({
            "navpanel": {
                select: this.onSelect
            }
        });
    },

    onSelect: function (panel, record, index, eOpts) {
        if (window.console && console.log)
            console.log("onSelect(%o)", arguments);

        if (!record.getData().leaf)
            this.application.fireEvent("navNodeSelected", record.getId());
    }
});