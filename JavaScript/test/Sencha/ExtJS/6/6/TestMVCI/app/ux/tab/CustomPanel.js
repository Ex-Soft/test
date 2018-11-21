Ext.define("TestMVCI.ux.tab.CustomPanel", {
    extend: "Ext.tab.Panel",
    alias : "widget.customtabpanel",

    constructor: function(config) {
		if(window.console && console.log)
			console.log("TestMVCI.ux.tab.CustomPanel.constructor(%o)", arguments);

        this.callParent([config]);
        
        return this;
    },

    initComponent: function() {
        if(window.console && console.log)
			console.log("TestMVCI.ux.tab.CustomPanel.initComponent(%o)", arguments);

		this.callParent(arguments);
    }
});