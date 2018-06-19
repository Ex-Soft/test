Ext.define("TestPanel1", {
	extend: "Ext.panel.Panel",
	alias: "widget.testpanel1",

	mixins: {
		testMixin: "TestMixin",
		testMixinSingleton: "TestMixinSingleton"
	},

	initComponent: function() {
		this.doSmth();
		this.callParent(arguments);
	}
});
