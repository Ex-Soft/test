Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		store1 = new Ext.data.ArrayStore({
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				"value"
			],
			data: [
				[ 1, "value# 1" ],
				[ 2, "value# 2" ],
				[ 3, "value# 3" ],
				[ 4, "value# 4" ],
				[ 5, "value# 5" ]
			]
		}),
		store2 = new Ext.data.ArrayStore({
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				"value"
			],
			data: [
				[ 1, "value# 1" ],
				[ 2, "value# 2" ],
				[ 3, "value# 3" ],
				[ 4, "value# 4" ],
				[ 5, "value# 5" ]
			]
		}),
		cb1 = new Ext.ux.form.SuperBoxSelect({
			mode: "local",
			store: store1,
			valueField: "id",
			displayField: "value"
		}),
		cb2 = new Ext.ux.form.SuperBoxSelect({
			mode: "local",
			store: store2,
			valueField: "id",
			displayField: "value"
		}),
		p = new Ext.Panel({
			layout: "column",
			items: [ cb1, cb2 ],
			renderTo: Ext.getBody(),
			tbar: {
				items: [{
					text: "get ComboBox",
					handler: function (btn, e) {
						if (window.console && console.log)
							console.log("%o %o", cb1, cb2);
					}
				}, {
					text: "getValue",
					handler: function (btn, e) {
						if (window.console && console.log)
							console.log("%o %o", cb1.getValue(), cb2.getValue());
					}
				}, {
					text: "setValue",
					handler: function (btn, e) {
						cb1.setValue("1,2");
						cb2.setValue([ 3, 4, 5 ]);
					}
				}]
			}
		});
});
