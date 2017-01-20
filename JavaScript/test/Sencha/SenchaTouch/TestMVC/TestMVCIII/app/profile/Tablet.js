Ext.define("TestMVCIII.profile.Tablet", {
	extend: "TestMVCIII.profile.Base",

	config: {
		controllers: [ "Main" ],
		views: [ "Main" ]
	},

	isActive: function() {
		return Ext.os.is.Tablet || Ext.os.is.Desktop;
	},

	launch: function() {
		Ext.create("TestMVCIII.view.tablet.Main");

		this.callParent();
	}
});