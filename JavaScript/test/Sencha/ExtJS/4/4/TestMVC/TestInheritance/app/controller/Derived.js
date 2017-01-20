Ext.define("AM.controller.Derived", {
	extend: "AM.controller.Base",

	views: [ "Derived" ],

	formSelector: "derivedview",

	init: function(application) {
		if(window.console && console.log)
			console.log("controller.Derived.init(%o)", arguments);

		this.callParent(arguments);
	},

	onSaveClick: function(btn, e) {
		if(window.console && console.log)
			console.log("controller.Derived.onSaveClick(%o)", arguments);

		var view = this.getViewView();

		if(view)
			;
	}
});