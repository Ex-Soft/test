Ext.define("UnitTestingI.Application", {
	name: "UnitTestingI",

	extend: "Ext.app.Application",

	views: [],

	controllers: [ "MainMenu" ],

	stores: [],

	init: function(application) {
		this.callParent(arguments);
	}
});
