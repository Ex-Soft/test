Ext.define("TestMixin", {
	constructor: function(config) {
		if (window.lonsole && console.log)
			console.log("TestMixin.ctor(%o)", arguments);

		this.callParent([config]);

		return this;
	}
});
