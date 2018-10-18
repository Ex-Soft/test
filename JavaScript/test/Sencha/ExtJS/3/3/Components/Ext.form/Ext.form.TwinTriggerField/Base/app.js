Ext.BLANK_IMAGE_URL="../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.CustomTwinTriggerField = Ext.extend(Ext.form.TwinTriggerField, {
	trigger1Class: "x-form-first-trigger",
	trigger2Class: "x-form-second-trigger",
	trigger3Class: "x-form-third-trigger",
	trigger4Class: "x-form-fourth-trigger",
	trigger5Class: "x-form-clear-trigger",
	trigger6Class: "x-form-search-trigger",

	initComponent: function() {
		Test.CustomTwinTriggerField.superclass.initComponent.apply(this, arguments);

		this.triggerConfig.cn.splice.apply(this.triggerConfig.cn, [this.triggerConfig.cn.length, 0].concat([
			{tag: "img", src: Ext.BLANK_IMAGE_URL, alt: "", cls: "x-form-trigger " + this.trigger3Class},
			{tag: "img", src: Ext.BLANK_IMAGE_URL, alt: "", cls: "x-form-trigger " + this.trigger4Class},
			{tag: "img", src: Ext.BLANK_IMAGE_URL, alt: "", cls: "x-form-trigger " + this.trigger5Class},
			{tag: "img", src: Ext.BLANK_IMAGE_URL, alt: "", cls: "x-form-trigger " + this.trigger6Class}
		]));

		this.on({
			specialkey: function(f, e) {
				if(window.console && console.log)
					console.log("CustomTriggerField.specialkey(%o)", arguments);

				if (e.getKey() == e.ENTER) {
					if(window.console && console.log)
						console.log("CustomTriggerField.specialkey(%o) ENTER", arguments);
				}
			},
			scope: this
		});
	},

	onTriggerClick: function(e, target, eOpts) {
		Test.CustomTwinTriggerField.superclass.onTriggerClick.apply(this, arguments);

		if(window.console && console.log)
			console.log("CustomTriggerField.onTriggerClick(%o)", arguments);
	},

	onTrigger1Click: function(e, target, eOpts) {
		Test.CustomTwinTriggerField.superclass.onTrigger1Click.apply(this, arguments);

		if(window.console && console.log)
			console.log("CustomTriggerField.onTrigger1Click(%o)", arguments);

		//this.onTriggerClick();
		this.triggers[1].hide();
	},

	onTrigger2Click: function(e, target, eOpts) {
		Test.CustomTwinTriggerField.superclass.onTrigger2Click.apply(this, arguments);

		if(window.console && console.log)
			console.log("CustomTriggerField.onTrigger2Click(%o)", arguments);
	},

	onTrigger3Click: function(e, target, eOpts) {
		if(window.console && console.log)
			console.log("CustomTriggerField.onTrigger3Click(%o)", arguments);

		this.triggers[1].show();
	},

	onTrigger4Click: function(e, target, eOpts) {
		if(window.console && console.log)
			console.log("CustomTriggerField.onTrigger4Click(%o)", arguments);
	},

	onTrigger5Click: function(e, target, eOpts) {
		if(window.console && console.log)
			console.log("CustomTriggerField.onTrigger5Click(%o)", arguments);
	},

	onTrigger6Click: function(e, target, eOpts) {
		if(window.console && console.log)
			console.log("CustomTriggerField.onTrigger6Click(%o)", arguments);
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		triggerField = new Test.CustomTwinTriggerField({
			//hideTrigger: true, // (all)
			//hideTrigger5: true,
			renderTo: Ext.getBody()
		});
});
