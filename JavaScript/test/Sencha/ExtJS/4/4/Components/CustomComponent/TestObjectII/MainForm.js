Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomObject", {
	extend: "Ext.Component",
	alias: "widget.customobject",

	initComponent: function() {
		this.autoEl = {
			tag: "object",
			type: this.type,
			data: this.data
		};

		this.callParent(arguments);
	}
});

Ext.onReady(function() {
	Ext.create("Ext.window.Window", {
		autoShow: true,
		height: 500,
		width: 500,
		layout: "fit",
		items: [{
			xtype: "customobject",
			type: "application/pdf",
			data: "../../../../../../objecttag/testpdf.pdf"
		}],
		buttons: [{
			text: "Watch",
			handler: function(btn, e) {
				var
					c = btn.up("window").down("customobject");

				if(c)
					;
			}
		}]

	});
});
