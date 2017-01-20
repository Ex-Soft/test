Ext.define("AM.controller.Base", {
	extend: "Ext.app.Controller",

	views: [ "Base" ],

	formSelector: "baseview",

	init: function(application) {
		if(window.console && console.log)
			console.log("controller.Base.init(%o)", arguments);

		var
			me = this,
			ref = {
				ref: "viewView",
				selector: Ext.String.format("{0}[formSelector={0}]", me.formSelector)
			},
			control = {
				"baseview button[action=save]": {
					click: me.onSaveClick
				}
			};

		me.refs = [ref];
		me.control(control);
	},

	onSaveClick: function(btn, e) {
		if(window.console && console.log)
			console.log("controller.Base.onSaveClick(%o)", arguments);

		var view = this.getViewView();

		if(view)
			;
	}
});