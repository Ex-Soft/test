Ext.define("TestPanel2", {
	extend: "Ext.panel.Panel",
	alias: "widget.testpanel2",

	mixins: {
		testMixin: "TestMixin",
		testMixinSingleton: "TestMixinSingleton"
	},

	initComponent: function() {
		this.doSmth();
		this.callParent(arguments);
	}
});
