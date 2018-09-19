Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

ToolbarSearchPlugin = Ext.extend(Object, {
	init: function(cmp) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.init(%o)", arguments);

		if (cmp.getXType() != Ext.Toolbar.xtype)
			return;

		cmp.on("afterrender", this.onAfterRender, this);
		cmp.on("afterlayout", this.onAfterLayout, this, { single: true });
	},

	onAfterRender: function(toolbar) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.onAfterRender(%o)", arguments);

		var layout;

		if (!(layout = toolbar.getLayout()))
			return;
	},

	onAfterLayout: function(toolbar, layout) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.onAfterLayout(%o)", arguments);

		var layout,
			td,
			btn;

		if (!(layout = toolbar.getLayout())
			|| !(btn = new Ext.Button({ text: "btn" }))
			|| !(td = layout.insertCell(btn, layout.extrasTr, 100)))
			return;

		btn.render(td);
	}
});

Ext.preg("toolbarsearchplugin", ToolbarSearchPlugin);

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

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
					text: "getLayout()",
					handler: function(btn, e) {
						var tb,
							layout;

						if (!(tb = btn.findParentByType("toolbar")))
							return;

						layout = tb.getLayout();
					}
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
