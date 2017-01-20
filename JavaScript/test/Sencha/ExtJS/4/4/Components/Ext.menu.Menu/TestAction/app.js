Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("ButtonWOText",{
	extend: "Ext.button.Button",
	alias: "widget.buttonwotext",

	initComponent: function() {
		this.callParent(arguments);
		this.setTooltip(this.getText());
		this.setText("");
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		actions = [],
		duplicate;

	actions["action1"] = new Ext.Action({
		text: "TestAction1",
		iconCls: "iconTools",
		handler: doAction,
		customProperty: "blah-blah-blah"
	});

	duplicate = Ext.copyTo({}, actions["action1"].initialConfig, "iconCls,handler");

	actions["action2"] = new Ext.Action({
		text: "TestAction2",
		handler: doAction
	});

	actions["action31"] = new Ext.Action({
		text: "TestAction31",
		iconCls: "iconTools",
		handler: doAction
	});
	actions["action32"] = new Ext.Action({
		text: "TestAction32",
		iconCls: "iconTools",
		handler: doAction
	});
	actions["action3"] = new Ext.Action({
		text: "TestAction3",
		iconCls: "iconTools",
		iconAlign: "top",
		arrowAlign: "bottom",
		menu: [
			actions["action31"],
			actions["action32"]
		]
	});

	Ext.create("Ext.toolbar.Toolbar", {
		items: [
			new ButtonWOText(actions["action1"]),
			duplicate,
		{
			text: "Menu# 1",
			menu: [
				actions["action1"],
				actions["action2"],
				actions["action3"]
			]
		},
			new ButtonWOText(actions["action3"]),
			new Ext.Action({
				text: "Ext.Action.text",
				iconCls: "iconTools",
				handler: doAction
			}),
		{
			text: "DoIt!",
			handler: function() {
				var
					tb = this.up("toolbar"),
					b,
					a;

				if(!tb)
					return;

				b = tb.items.items[0];

				if(!b)
					return;

				a = b.baseAction;
				a.setDisabled(!a.isDisabled());

				b = tb.items.items[3];
				a = b.baseAction;
				a.setDisabled(!a.isDisabled());
			}
		}, {
			text: "setDisabled()",
			handler: function() {
				actions["action1"].setDisabled(!actions["action1"].isDisabled());
				actions["action3"].setDisabled(!actions["action3"].isDisabled());
			}
		}],
		renderTo: Ext.getBody()
	});
});

function doAction(menuItem, e) {
	if(window.console && console.log)
		console.log("doAction(%o)", arguments);
}