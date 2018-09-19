Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

ButtonWOText = Ext.extend(Ext.Button,{
	initComponent: function() {
		ButtonWOText.superclass.initComponent.call(this);
		this.setTooltip(this.getText());
		this.setText("");
	}
});
Ext.reg("buttonwotext", ButtonWOText);

ToolbarSearchPlugin = Ext.extend(Object, {
	target: "extrasTr",
	position: 0,
	text: "Search",
	iconCls: "searchIco",

	constructor: function(config) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.constructor(%o)", arguments);

		Ext.apply(this, config);

		return this;
	},

	init: function(cmp) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.init(%o)", arguments);

		if (cmp.getXType() != Ext.Toolbar.xtype || Ext.isEmpty(this.target))
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
			btn,
			beforeTd,
			beforeItemIdx;

		if (!(layout = toolbar.getLayout())
			|| !layout[this.target]
			|| !(btn = new ButtonWOText({ text: this.text, iconCls: this.iconCls }))
			|| !layout[this.target]
			|| !layout[this.target].childNodes
			|| !(beforeTd = layout[this.target].childNodes[this.position])
			|| (beforeItemIdx = toolbar.items.indexOfKey(beforeTd.childNodes[0].id)) === -1
			|| !(td = layout.insertCell(btn, layout[this.target], this.position)))
			return;

		btn.render(td);
		toolbar.items.insert(beforeItemIdx, btn);
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
				plugins: [{
					ptype: "toolbarsearchplugin",
					//target: "extrasTr",
					target: "rightTr",
					position: 1,
					cls: "searchIco"
				}],
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
