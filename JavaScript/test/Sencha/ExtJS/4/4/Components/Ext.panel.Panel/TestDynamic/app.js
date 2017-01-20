Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

/*
Ext.define("App.view.custom.TestPanelX", {
	extend: "Ext.panel.Panel",
	alias: "widget.testpanelx",
	requires: [
		"CLabel"
	],

	initComponent: function() {
		if(window.console && console.log)
			console.log("TestPanelX.initComponent(%o)", arguments);

		Ext.apply(this, {
			items: [{
				xtype: "clabel",
				text: "clabel"
			}]
		});

		this.callParent(arguments);
	}
});
*/

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		//formDefStr = "Ext.define(\"App.view.custom.TestPanel\", { extend: \"Ext.panel.Panel\", alias: \"widget.testpanel\", initComponent: function() { if(window.console && console.log) console.log(\"TestPanel.initComponent(%o)\", arguments); Ext.apply(this, { items: [{ xtype: \"label\", text: \"label\" }] }); this.callParent(arguments); } })",
		formDefStr = "Ext.define(\"App.view.custom.TestPanel\", { extend: \"Ext.panel.Panel\", alias: \"widget.testpanel\", requires: [\"CLabel\"], initComponent: function() { if(window.console && console.log) console.log(\"TestPanel.initComponent(%o)\", arguments); Ext.apply(this, { items: [{ xtype: \"clabel\", text: \"clabel\" }] }); this.callParent(arguments); } }, function() { if(window.console && console.log) console.log(\"TestPanel.createdFn(%o) Ext.ClassManager.getNameByAlias(\\\"%s\\\") = \\\"%s\\\" \", arguments, \"widget.clabel\", Ext.ClassManager.getNameByAlias(\"widget.clabel\")); })",
		className = /(Ext.define\s*?\(\s*?")([A-Za-z\d.]+?)(?=")/.exec(formDefStr)[2],
		aliasName = /(alias\s*?:\s*?")([A-Za-z\d.]+?)(?=")/.exec(formDefStr)[2],
		requiresStr = /(requires\s*?:\s*?\[)(.+?)(?=])/.exec(formDefStr)[2],
		requires = eval("[" + requiresStr + "]"),
		isDef = isDefined(className),
		formDef = eval(formDefStr),
		form,
		aliasName2 = "widget.clabel";

	isDef = isDefined(className);

	if(window.console && console.log)
		console.log("Ext.ClassManager.getNameByAlias(\"%s\") = \"%s\", typeof formDef = \"%s\", typeof form = \"%s\"", aliasName, Ext.ClassManager.getNameByAlias(aliasName), typeof formDef, typeof form);

	if(window.console && console.log)
		console.log("Ext.ClassManager.getNameByAlias(\"%s\") = \"%s\"", aliasName2, Ext.ClassManager.getNameByAlias(aliasName2));

/*	form = Ext.create(formDef, {
		renderTo: Ext.getBody()
	});*/

	if(window.console && console.log)
		console.log("Ext.ClassManager.getNameByAlias(\"%s\") = \"%s\", typeof formDef = \"%s\", typeof form = \"%s\"", aliasName, Ext.ClassManager.getNameByAlias(aliasName), typeof formDef, typeof form);
});

function isDefined(className) {
	var
		classNameParts = className.split("."),
		checkedName = "",
		t;

	for(var i=0, len=classNameParts.length; i<len; ++i)
	{
		if(checkedName.length > 0)
			checkedName += ".";

		checkedName += classNameParts[i];

		if((t = eval("typeof " + checkedName)) === "undefined")
			return false;
	}

	return true;
}