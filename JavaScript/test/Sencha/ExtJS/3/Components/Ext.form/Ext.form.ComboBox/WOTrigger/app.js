Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBoxWOTrigger = Ext.extend(Ext.form.ComboBox, {
	constructor: function(config) {
		if (window.console && console.log)
			console.log("ComboBoxWOTrigger.constructor(%o)", arguments);

		Test.ComboBoxWOTrigger.superclass.constructor.call(this, config);

		return this;
	},

	initComponent: function () {
		if (window.console && console.log)
			console.log("ComboBoxWOTrigger.initComponent(%o)", arguments);

		Test.ComboBoxWOTrigger.superclass.initComponent.apply(this, arguments);

		this.on({
			render: function(cmp) {
				if (window.console && console.log)
					console.log("ComboBoxWOTrigger.render(%o)", arguments);

				this.getEl().on("click", this.onClick.createDelegate(this, arguments));
			}
		});
	},

	onRender: function (ct, position) {
		if (window.console && console.log)
			console.log("ComboBoxWOTrigger.onRender(%o)", arguments);

		Test.ComboBoxWOTrigger.superclass.onRender.call(this, ct, position);
	},

	initEvents: function () {
		if (window.console && console.log)
			console.log("ComboBoxWOTrigger.initEvents(%o)", arguments);

		Test.ComboBoxWOTrigger.superclass.initEvents.apply(this, arguments);
	},

	onClick: function(cmp) {
		if (window.console && console.log)
			console.log("ComboBoxWOTrigger.onClick(%o)", arguments);

		this.onTriggerClick();
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		f = function(combobox) {
			if (window.console && console.log)
				console.log("f(%o)", arguments);

			combobox.onTriggerClick();
		},
		ff = function(e, el, eOpt) {
			if (window.console && console.log)
				console.log("ff(%o)", arguments);

			this.onTriggerClick();
		},
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			fields: [ "id", "value"],
			data : [
				[ 1, "Line# 1" ],
				[ 2, "Line# 1" ],
				[ 3, "aaaaaaa" ],
				[ 4, "abbbbbb" ],
				[ 5, "abccccc" ],
				[ 6, "abcdddd" ],
				[ 7, "abcdeee" ],
				[ 8, "abcdeff" ],
				[ 9, "abcdefg" ]
			]
		}),
		combobox1 = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true,
			triggerAction: "all",
			listeners: {
				render: function(cmp) {
					if (window.console && console.log)
						console.log("ComboBox.render(%o)", arguments);

					var el;

					if (!(el = cmp.getEl()))
						return;

					el.on("click", f.createDelegate(cmp, arguments));
				}
			}
		}),
		combobox2 = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true,
			triggerAction: "all",
			listeners: {
				render: function(cmp) {
					if (window.console && console.log)
						console.log("ComboBox.render(%o)", arguments);

					var el;

					if (!(el = cmp.getEl()))
						return;

					el.on("click", ff, cmp);
				}
			}
		}),
		combobox3 = new Test.ComboBoxWOTrigger({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true,
			triggerAction: "all"
		}),
		panel = new Ext.Panel({
			layout: {
				type: "hbox"
			},
			items: [
				combobox1,
				combobox2,
				combobox3
			],
			renderTo: Ext.getBody()
		});
});
