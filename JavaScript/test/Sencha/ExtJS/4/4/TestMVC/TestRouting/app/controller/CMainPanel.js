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
                gridrowselected: me.onGridRowSelected,
                gridsearch: me.onGridSearch
            }
        });
    
        app.on("navNodeSelected", this.onParentChanged, this);
        app.on("routeparamschanged", this.onRouteParamsChanged, this);
    },

    onGridRowSelected: function(record) {
        if (window.console && console.log)
            console.log("CMainPanel.onGridRowSelected(%o)", arguments);

        this.application.fireEvent("gridrowselected", record);
    },

    onRouteParamsChanged: function(token) {
        if (window.console && console.log)
            console.log("CMainPanel.onRouteParamsChanged(%o)", arguments);

            var mainPanel,
            layout,
            gridPanelIdx;

        if (!(mainPanel = this.getMainPanel()) || !(layout = mainPanel.getLayout()))
            return;

        layout.getActiveItem().fireEvent("routeparamschanged", token);
    },

    onParentChanged: function(category) {
        if (window.console && console.log)
            console.log("CMainPanel.onParentChanged(%o)", arguments);

        var mainPanel,
            layout,
            gridPanelIdx;

        if (!(mainPanel = this.getMainPanel()) || !(layout = mainPanel.getLayout()) || (gridPanelIdx = mainPanel.items.findIndex("category", category)) == -1)
            return;

        layout.setActiveItem(gridPanelIdx);

        layout.getActiveItem().fireEvent("parentchanged", category);
    },

    onGridSearch: function(values) {
        if (window.console && console.log)
            console.log("CMainPanel.onGridSearch(%o)", arguments);

        this.application.fireEvent("gridsearch", values);
    }
});