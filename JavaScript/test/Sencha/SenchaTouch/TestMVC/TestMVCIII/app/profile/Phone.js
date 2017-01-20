Ext.define("TestMVCIII.profile.Phone", {
	extend: "TestMVCIII.profile.Base",

	config: {
		controllers: [ "Main" ],
		views: [ "Main" ]
	},

	isActive: function() {
		return Ext.os.is.Phone; // || Ext.os.is.Desktop;
	},

	launch: function() {
		Ext.create("TestMVCIII.view.phone.Main");

		this.callParent();
	}
});
