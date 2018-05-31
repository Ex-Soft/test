Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomObject", {
	extend: "Ext.Component",
	alias: "widget.customobject",

	menu: Ext.create("Ext.menu.Menu", {
		items: [{
			text: "blah-blah-blah"
		}]
	}),

	layout: "fit",

	constructor: function(config) {
		config = config || {};

		if(config.expanded)
		{
			this.autoEl = {
				tag: "object",
				type: "application/pdf" //"application/x-m3-desktop-service"
			};

			if(config.data)
				this.autoEl.data = config.data;
		}
		else
		{
			this.autoEl = {
				tag: "a",
				href: config.data,
				html: config.document || "download"
			};

			if(config.height)
				delete config.height;

			if(config.width)
				delete config.width;
		};

		this.callParent([config]);

		return this;
	},

	initComponent: function() {
		this.callParent(arguments);

		this.addListener("contextmenu", function() {
			if(window.console && console.log)
				console.log("contextmenu(%o)", arguments);
		});
	},

	onRender: function(parentNode, containerIdx) {
		if(window.console && console.log)
			console.log("onRender(%o)", arguments);

		this.callParent(arguments);
	}
});

Ext.onReady(function() {
	var
		o = Ext.create("CustomObject", {
			height: 700,
			width: 700,
			expanded: false,
			documentName: "test.pdf",
			data: "../../../../../../../ObjectTag/TestPdf1.pdf"
		}),
		p = Ext.create("Ext.panel.Panel", {
			items: [
				//o,
			{
				xtype: "customobject",
				height: 700,
				width: 700,
				expanded: true,
				documentName: "test.pdf",
				data: "../../../../../../../ObjectTag/TestPdf1.pdf"
			}],
			dockedItems: [{
				xtype: "toolbar",
				dock: "top",
				items: [{
					text: "status",
					handler: function(btn, e) {
						var
							p = btn.up("panel"),
							o = p.down("customobject");

						if(o)
							o.el.dom.data = null;
					}
				}]
			}],
			renderTo: Ext.getBody()
		});
});
