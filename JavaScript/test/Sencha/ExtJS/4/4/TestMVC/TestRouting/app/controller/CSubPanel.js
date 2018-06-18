Ext.define("TestRouting.controller.CSubPanel", {
    extend: "Ext.app.Controller",

    refs: [{
        ref: "subPanel",
        selector: "viewport > gridpanel"
    }],

    init: function(app) {
        if (window.console && console.log)
            console.log("CSubPanel.init(%o)", arguments);

        this.control({
            "viewport gridpanel": {
                select: this.onSubGridRowSelect
            }
        });
    
        app.on("navNodeSelected", this.onNavNodeSelected, this);
        app.on("gridRowSelected", this.onGridRowSelected, this);
    },

    onSubGridRowSelect: function(grid, record, index, eOpts) {
        if (window.console && console.log)
            console.log("CSubPanel.onGridRowSelect(%o)", arguments);
    },

    onNavNodeSelected: function(folderId) {
        if (window.console && console.log)
            console.log("CSubPanel.onNavNodeSelected(%o)", arguments);
    },

    onGridRowSelected: function(id) {
        if (window.console && console.log)
            console.log("CSubPanel.onGridRowSelected(%o)", arguments);

        var store;
        
        if (!(store = this.getSubPanel().getStore()))
            return;

        store.getProxy().url = `data/grid${id}data`;
        store.load();
    }
});