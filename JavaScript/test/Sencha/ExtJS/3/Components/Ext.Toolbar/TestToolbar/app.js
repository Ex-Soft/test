Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		combobox = new Ext.form.ComboBox({
			store: new Ext.data.ArrayStore({
				autoDestroy: true,
				fields: [ "id", "value"],
				data : [
					[ 1, "Line# 1" ],
					[ 2, "Line# 1" ]
				]
			}),
			valueField: "id",
			displayField: "value",
			typeAhead: true,
			mode: "local",
			forceSelection: true,
			triggerAction: "all",
			emptyText: "Select...",
			selectOnFocus: true,
			width: 135,
			getListParent: function() {
				return this.el.up(".x-menu");
			},
			iconCls: "no-icon"
		}),
		menu = new Ext.menu.Menu({
			items: [
				combobox
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
							combobox
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
					combobox,
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
