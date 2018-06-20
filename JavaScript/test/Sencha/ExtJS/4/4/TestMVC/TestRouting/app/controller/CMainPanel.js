Ext.define("TestRouting.controller.CMainPanel", {
    extend: "Ext.app.Controller",

    refs: [{
        ref: "mainPanel",
        selector: "mainpanel"
    }],

    init: function(app) {
        if (window.console && console.log)
            console.log("CMainPanel.init(%o)", arguments);

        var me = this;

        me.control({
            "mainpanel gridpanel": {
                select: me.onGridRowSelect,
                searched: me.onSearched
            }
        });
    
        app.on("navNodeSelected", this.onNavNodeSelected, this);
        app.on("gridRowChanged", this.onGridRowChanged, this);
    },

    onGridRowSelect: function(grid, record, index, eOpts) {
        if (window.console && console.log)
            console.log("CMainPanel.onGridRowSelected(%o)", arguments);

        this.application.fireEvent("gridRowSelected", record);
    },

    onGridRowChanged: function(token) {
        if (window.console && console.log)
            console.log("CMainPanel.onGridRowChanged(%o)", arguments);

            var mainPanel,
            layout,
            gridPanelIdx;

        if (!(mainPanel = this.getMainPanel()) || !(layout = mainPanel.getLayout()))
            return;

        layout.getActiveItem().fireEvent("gridRowChanged", token);
    },

    onNavNodeSelected: function(category) {
        if (window.console && console.log)
            console.log("CMainPanel.onNavNodeSelected(%o)", arguments);

        var mainPanel,
            layout,
            gridPanelIdx;

        if (!(mainPanel = this.getMainPanel()) || !(layout = mainPanel.getLayout()) || (gridPanelIdx = mainPanel.items.findIndex("category", category)) == -1)
            return;

        layout.setActiveItem(gridPanelIdx);

        layout.getActiveItem().fireEvent("navNodeSelected", category);
    },

    onSearched: function(values) {
        if (window.console && console.log)
            console.log("CMainPanel.onSearched(%o)", arguments);

        this.application.fireEvent("searched", values);
    }
});