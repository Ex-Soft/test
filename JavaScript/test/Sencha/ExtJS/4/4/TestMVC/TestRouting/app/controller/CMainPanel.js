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

    onNavNodeSelected: function(categoryId) {
        if (window.console && console.log)
            console.log("CMainPanel.onNavNodeSelected(%o)", arguments);

        var mainPanel,
            layout,
            gridPanelIdx;

        if (!(mainPanel = this.getMainPanel()) || !(layout = mainPanel.getLayout()) || (gridPanelIdx = mainPanel.items.findIndex("category", categoryId)) == -1)
            return;

        layout.setActiveItem(gridPanelIdx);

        layout.getActiveItem().fireEvent("navNodeSelected", categoryId);
    }
});