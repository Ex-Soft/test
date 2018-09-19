Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("ToolbarSearchPlugin", {
	extend: "Ext.AbstractPlugin",
	alias: "plugin.toolbarsearchplugin",

	type: "toolbarsearchplugin",

	constructor: function (config) {
		if(window.console && console.log)
			console.log("ToolbarSearchPlugin.constructor(%o)", arguments);

		var me = this;

		me.callParent([config]);

		return me;
	},

	init: function (cmp) {
		if(window.console && console.log)
			console.log("ToolbarSearchPlugin.init(%o)", arguments);

		var	me = this,
			layout;

		if (!(layout = cmp.getLayout()))
			return;

		if(window.console && console.log)
			console.log("layout.extrasTr=%o", layout.extrasTr);
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				xtype: "toolbar",
				region: "north",
				plugins: [ "toolbarsearchplugin" ],
				height: 28,
				items: [{
					text: "Button# 1"
				}, {
					text: "Button# 2",
				}, {
					xtype: "tbseparator"
				}, {
					text: "Item# 1.1"
				}, {
					text: "Item# 1.2"
				}, "-", {
					text: "Item# 2.1"
				}, {
					xtype: "tbspacer",
					width: 50
				}, {
					text: "Item# 2.2"
				}, "-", {
					text: "Item# 3.1"
				}, " ", {
					text: "Item# 3.2"
				},
					"-", 
					"->",
					"-",
				{
					text: "Item# 4.1"
				}, {
					text: "Item# 4.1"
				}]
			}, {
				region: "center",
				html: "center"
			}]
		});
});
