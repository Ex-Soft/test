Ext.define("TestRouting.widget.MainPanel", {
	extend: "Ext.panel.Panel",
	alias: "widget.mainpanel",

    requires: [
		"TestRouting.widget.GridPanel"
    ],
    
	layout: "card",

	items: [{
        xtype: "gridpanel",
        url: "data/grid1data.json",
        layout: "fit"
    }, {
        xtype: "gridpanel",
        url: "data/grid2data.json",
        layout: "fit"
    }],

    tbar: {
        items:[{

        }]
    }
});