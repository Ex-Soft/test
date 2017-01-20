Ext.define("TestForm", {
	extend: "Ext.form.Panel",
	alias: "widget.testform",

	requires: ["TestText"],

	initComponent: function() {
		if(window.console && console.log)
			console.log("TestForm.initComponent(%o)", arguments);

		this.frame = true;

		this.testText = Ext.create("TestText",{
			value: "blah-blah-blah"
			, anchor: "100%"
		});

		this.dockedItems = [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				text: "Button"
			}]
		}];

		this.items = [this.testText];

		this.addListener("afterlayout", this.afterLayout, this);
		this.callParent(arguments);
	},

	render: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestForm.render(%o)", arguments);

		this.callParent(arguments);
	},

	onRender: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestForm.onRender(%o)", arguments);

		this.callParent(arguments);
	},

	afterRender: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestForm.afterRender(%o)", arguments);

		//this.testText.focus(true);
		this.callParent(arguments);
		//this.testText.focus(true);
	},

	afterComponentLayout: function(width, height, isSetSize, layoutOwner /* callingContainer */) {
		if(window.console && console.log)
			console.log("TestForm.afterComponentLayout(%o)", arguments);

		this.callParent(arguments);
		//this.testText.focus(true);
	},

	afterLayout: function(form, layout, eOpts) {
		if(window.console && console.log)
			console.log("TestForm.afterlayout(%o)", arguments);

		//this.testText.focus(true);
	}
});