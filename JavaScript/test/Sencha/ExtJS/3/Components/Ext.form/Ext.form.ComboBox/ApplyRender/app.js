Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	initComponent: function() {
		var me = this;

		if (window.console && console.log)
			console.log("initComponent(%o)", arguments);

		Test.ComboBox.superclass.initComponent.apply(me, arguments);
	}
});
Ext.reg("testcombo", Test.ComboBox);

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		store1 = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [ "id", "value"],
			data : [
				[ 1, "Rec# 1" ],
				[ 2, "Rec# 2" ],
				[ 3, "Rec# 3" ]
			]
		}),
		store2 = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [ "id", "value"],
			data : [
				[ 1, "Rec# 1" ],
				[ 2, "Rec# 2" ],
				[ 3, "Rec# 3" ]
			]
		}),
		store3 = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [ "id", "value"],
			data : [
				[ 1, "Rec# 1" ],
				[ 2, "Rec# 2" ],
				[ 3, "Rec# 3" ]
			]
		}),
		combobox1 = new Test.ComboBox({
			store: store1,
			valueField: "id",
			displayField: "value",
			mode: "local",
			applyTo: Ext.get("input4apply1")
		}),
		combobox2 = new Test.ComboBox({
			store: store2,
			valueField: "id",
			displayField: "value",
			mode: "local",
			applyTo: Ext.get("input4apply2")
		}),
		combobox3 = new Test.ComboBox({
			store: store3,
			valueField: "id",
			displayField: "value",
			mode: "local",
			renderTo: Ext.get("div4render")
		}),
		panel = new Ext.Panel({
			layout: {
				type: "hbox"
			},
			tbar: {
				items: [{
					text: "show()",
					handler: function (btn, e) {
						var panel = btn.findParentByType("panel"),
							comboBox = panel ? panel.findByType("testcombo") : null;

						if (Ext.isEmpty(comboBox))
							return;
					}
				}]
			},
			renderTo: Ext.getBody()
		});
});
