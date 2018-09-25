Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		panel1 = new Ext.Panel({
			items: [{
				xtype: "textfield"
			}],
			padding: 10,
			renderTo: Ext.getBody()
		}),
		panel2 = new Ext.Panel({
			items: [{
				xtype: "textfield"
			}],
			padding: "0 0 0 30", // top right bottom left
			renderTo: Ext.getBody()
		});
});
