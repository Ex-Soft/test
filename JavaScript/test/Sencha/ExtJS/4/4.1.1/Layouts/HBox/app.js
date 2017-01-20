Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.panel.Panel", {
		width: 500,
		height: 100,
		title: "HBoxLayout Panel",
		layout: {
			type: "hbox",
			align: "stretch"
		},
		items: [{
			xtype: "panel",
			title: "Inner Panel One",
			flex: 2,
			html: "Inner Panel One"
		},{
			xtype: "panel",
			title: "Inner Panel Two",
			flex: 1
		},{
			xtype: "panel",
			title: "Inner Panel Three",
			flex: 1
		}],
		renderTo: Ext.get("Panel1")
	});

	var
		p = Ext.create("Ext.form.Panel", {
			title: "Panel",
			border: 0,
			layout: {
				type: "hbox",
				align: "stretch"
			},
			items: [{
				flex: 1,
				xtype: "textfield",
				fieldLabel: "core",
				value: Ext.versions.core.version,
				anchor: "100%",
				labelAlign: "right"
			}, {
				flex: 2,
				xtype: "textfield",
				fieldLabel: "extjs",
				value: Ext.versions.extjs.version,
				anchor: "100%",
				labelAlign: "right"
			}]
		});

	Ext.create("Ext.window.Window", {
		autoShow: true,
		layout: "fit",
		items: [p]
	});
});