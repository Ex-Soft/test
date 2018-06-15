Ext.define("TestRouting.controller.CMainPanel", {
    extend: "Ext.app.Controller",

    refs: [{
        ref: "mainPanel",
        selector: "mainpanel"
    }],

    init: function(app) {
        if (window.console && console.log)
            console.log("CMainPanel.init(%o)", arguments);

        this.control({
            "mainpanel gridpanel": {
                select: this.onGridRowSelect
            }
        });
    
        app.on("navNodeSelected", this.onNavNodeSelected, this);
    },

    onGridRowSelect: function(grid, record, index, eOpts) {
        if (window.console && console.log)
            console.log("CMainPanel.onGridRowSelected(%o)", arguments);

        this.application.fireEvent("gridRowSelected", record.getId());
    },

    onNavNodeSelected: function(folderId) {
        if (window.console && console.log)
            console.log("CMainPanel.onNavNodeSelected(%o)", arguments);

        var layout;

        if (isNaN(folderId) || !(layout = this.getMainPanel().getLayout()) || --folderId >= layout.layoutCount)
            return;

        layout.setActiveItem(folderId);
    }
});