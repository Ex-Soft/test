Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("Ext.data.ArrayStore", {
			autoDestroy: true,
			fields: [ "id", "value"],
			data : [
				[ 1, "Line# 1" ],
				[ 2, "Line# 1" ],
				[ 3, "aaaaaaa" ],
				[ 4, "abbbbbb" ],
				[ 5, "abccccc" ],
				[ 6, "abcdddd" ],
				[ 7, "abcdeee" ],
				[ 8, "abcdeff" ],
				[ 9, "abcdefg" ]
			]
		}),
		combobox1 = Ext.create("Ext.form.ComboBox", {
			hideLabel: true,
			store: store,
			valueField: "id",
			displayField: "value",
			typeAhead: true,
			queryMode: "local",
			triggerAction: "all",
			emptyText: "Select...",
			selectOnFocus: true,
			width: 135,
			indent: true,
			forceSelection: true
		}),
		combobox2 = Ext.create("Ext.form.ComboBox", {
			hideLabel: true,
			store: store,
			valueField: "id",
			displayField: "value",
			typeAhead: true,
			queryMode: "local",
			triggerAction: "all",
			emptyText: "Select...",
			selectOnFocus: true,
			width: 135,
			indent: true,
			forceSelection: true
		}),
		combobox3 = Ext.create("Ext.form.ComboBox", {
			hideLabel: true,
			store: store,
			valueField: "id",
			displayField: "value",
			typeAhead: true,
			queryMode: "local",
			triggerAction: "all",
			emptyText: "Select...",
			selectOnFocus: true,
			width: 135,
			indent: true,
			forceSelection: true
		}),
		menu = Ext.create("Ext.menu.Menu", {
			items: [
				combobox2
			]
		}),
		viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				xtype: "toolbar",
				region: "north",
				height: 28,
				items: [{
					xtype: "button",
					text: "Button# 1",
					menu: {
						items: [{
							text: "Item# 1",
						}, {
							text: "Item# 2"
						},
							combobox1
						]
					}
				}, {
					text: "Button# 2",
					menu: menu
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
					combobox3,
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
