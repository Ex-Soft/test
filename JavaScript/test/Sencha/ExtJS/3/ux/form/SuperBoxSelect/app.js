Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		cb = new Ext.ux.form.SuperBoxSelect({
			store: {
				xtype: "arraystore",
				fields: ["id", "value"],
				data: [
					[ 1, "value# 1" ]
				]
			},
			valueField: "id",
			displayField: "value"
		}),
		p = new Ext.Panel({
			border: 50,
			items: [ cb ],
			renderTo: Ext.getBody(),
			tbar: {
				items: [{
				}]
			}
		});
});
