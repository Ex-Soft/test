Ext.define("TestRouting.widget.MainPanel", {
	extend: "Ext.panel.Panel",
	alias: "widget.mainpanel",

    requires: [
		"TestRouting.widget.GridPanel"
    ],
    
	layout: "card",

	items: [{
        xtype: "gridpanel",
        category: "1",
        url: "data/grid1data.json",
        layout: "fit"
    }, {
        xtype: "gridpanel",
        category: "2",
        url: "data/grid2data.json",
        layout: "fit"
    }, {
        xtype: "gridpanel",
        category: "3",
        url: "data/grid3data.json",
        layout: "fit"
    }, {
        xtype: "gridpanel",
        category: "4",
        url: "data/grid4data.json",
        layout: "fit"
    }]
});