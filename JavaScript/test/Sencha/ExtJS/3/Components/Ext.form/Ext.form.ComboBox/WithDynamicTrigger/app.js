Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	triggerClass: "x-form-clear-trigger",

	initComponent: function() {
		var me = this;

		if (window.console && console.log)
			console.log("initComponent(%o)", arguments);

		Test.ComboBox.superclass.initComponent.apply(me, arguments);

		me.on("keyup", me.processWithTrigger, me);
	},

	initTrigger: function() {
		var me = this;

		Test.ComboBox.superclass.initTrigger.apply(me, arguments);
	},

	onTriggerClick: function(e, target, eOpts) {
		var me = this,
			el;

		if (window.console && console.log)
			console.log("onTriggerClick(%o)", arguments);

		if (!target || !(el = Ext.fly(target)) || !el.hasClass(me.triggerClass)) {
			if (window.console && console.log)
				console.log("superclass.onTriggerClick(%o)", arguments);

			Test.ComboBox.superclass.onTriggerClick.apply(me, arguments);
			return;
		}

		me.setRawValue();
		me.collapse();
	},

	processWithTrigger: function() {
		var me = this;

		if (Ext.isEmpty(me.getRawValue())) {
			if (me.trigger.isVisible())
				me.trigger.hide();
		} else {
			if (!me.trigger.isVisible())
			me.trigger.show();
		}
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
		onSelect = function(combo, record, index) {
			if(window.console && console.log)
				console.log("onSelect(%o)", arguments);
		},
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [ "id", "value"],
			data : [
				[ 1, "Env1" ],
				[ 2, "Env2" ],
				[ 3, "Env3" ],
				[ 4, "Group1" ],
				[ 5, "Group2" ],
				[ 6, "Group3" ],
				[ 7, "Region1" ],
				[ 8, "Region2" ],
				[ 9, "Region3" ]
			]
		}),
		combobox1 = new Test.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true,
			width: 300
		})
		panel = new Ext.Panel({
			layout: {
				type: "hbox"
			},
			items: [
				combobox1
			],
			tbar: {
				items: [{
					text: "show()",
					handler: function (btn, e) {
						var panel = btn.findParentByType("panel"),
							comboBox = panel ? panel.findByType("testcombo") : null;

						if (Ext.isEmpty(comboBox)
							|| !(comboBox = comboBox[0]).trigger
							|| comboBox.trigger.isVisible())
							return;
						
						comboBox.trigger.show();
					}
				}, {
					text: "hide()",
					handler: function (btn, e) {
						var panel = btn.findParentByType("panel"),
							comboBox = panel ? panel.findByType("testcombo") : null;

						if (Ext.isEmpty(comboBox)
							|| !(comboBox = comboBox[0]).trigger
							|| !comboBox.trigger.isVisible())
							return;
						
						comboBox.trigger.hide();
					}
				}]
			},
			renderTo: Ext.getBody()
		});

	combobox1.on("select", onSelect);
});
