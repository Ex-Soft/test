// https://stackoverflow.com/questions/6025814/extjs-4-create-an-iframe-window
 
Ext.define("CustomIFrame", {
	extend: "Ext.Component",
	alias: "widget.CustomIFrame",

	url: null,
	iFrameId: null,

	initComponent: function() {
		Ext.apply(this, {
			autoEl: this.getAutoEl()
		});

		this.callParent(arguments);

		this.addListener("afterrender", function(iFrame, eOpts) {
			if(window.console && console.log)
				console.log("CustomIFrame.afterrender(%o)", arguments);

			iFrame.updateFrameSrc();
		});
	},

	getIFrameId: function () {
		if (!this.iFrameId) {
			this.iFrameId = Ext.id();
		}

		return this.iFrameId;
	},

	getAutoEl : function () {
		var iFrameId = this.getIFrameId();

		return {
			id: iFrameId,
			name: iFrameId,
			security: "restricted",
			allowTransparency: "true",
			src: this.url,
			tag: "iframe",
			origin: window.location.origin
		};
	},

	getChildWindow: function() {
		return this.getEl().dom;
	},

	updateFrameSrc: function(url) {
		this.getChildWindow().src = !Ext.isEmpty(url) ? url : "iframe.html";
	}
});

