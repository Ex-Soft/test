Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomObject", {
	extend: "Ext.Component",
	alias: "widget.customobject",

	autoEl: "object",
	type: "",
	data: "",

	getElConfig: function() {
		var
			config = this.callParent(arguments),
			obj;

		if(this.autoEl == "object")
			obj = config;
		else
			config.cn = [obj = {
				tag: "object",
				id: this.id + "-object"
			}];

		if(this.type)
			obj.type = this.type;

		if(this.data)
			obj.data = this.data;

		return config;
	},

	onRender: function(container, containerIdx) {
		if(window.console && console.log)
			console.log("CustomObject.onRender(%o)", arguments);

		var
			el;

		this.callParent(arguments);

		el = this.el;
		this.objEl = this.autoEl == "object" ? el : el.getById(this.id + "-object");
	},

	onDestroy: function() {
		if(window.console && console.log)
			console.log("CustomObject.onDestroy(%o)", arguments);

		Ext.destroy(this.objEl);
		this.objEl = null;
		this.callParent(arguments);
	},
	
	setSrc: function(src, contentType) {
		if(window.console && console.log)
			console.log("CustomObject.setSrc(%o)", arguments);

		var
			objEl = this.objEl;

		this.type = contentType;
		this.data = src;

		if(objEl)
		{
			objEl.dom.type = contentType;
			objEl.dom.data = src;
		}
	}
});

Ext.define("CustomContainer", {
	extend: "Ext.container.Container",
	alias : "widget.customcontainer",

	layout: "fit",

	initComponent: function() {
		this.currentContentType = "";
		this.setValue(this.src, this.contentType);
		this.callParent(arguments);
	},

	setValue: function(src, contentType) {
		var
			xtype;

		if(!Ext.isDefined(src) || !Ext.isDefined(contentType))
			return;

		if(this.currentContentType != contentType)
		{
			if(this.items && this.items.length > 0)
				this.removeAll();

			switch(this.currentContentType = contentType)
			{
				case "application/pdf":
				{
					xtype = "CustomObject";
					break;
				}
				case "image/jpg":
				{
					xtype = "Ext.Img";
					break;
				}
				default:
				{
					if(window.console && console.log)
						console.log("Unknown content-type: \"%s\"", contentType);
				}
			}

			if(Ext.isString(xtype))
				this.cmp = Ext.create(xtype);

			if(!this.items)
				this.items = [this.cmp];
			else
				this.add(this.cmp)
		}

		this.cmp.setSrc(src, contentType);
	},

	onRender: function(container, containerIdx) {
		if(window.console && console.log)
			console.log("CustomContainer.onRender(%o)", arguments);

		this.callParent(arguments);
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		c = Ext.create("CustomContainer", {
			title: "CustomContainer",
			contentType: "application/pdf",
			src: "../../../../../../objecttag/testpdf1.pdf",
			//contentType: "image/jpg",
			//src: "../../../../../../pix/xpfirewall.jpg"
		});

	Ext.create("Ext.window.Window", {
		autoShow: true,
		title: "Test Custom Container (I)",
		layout: "fit",
		height: 300,
		width: 400,
		items: [c],
		buttons: [{
			text: "Watch",
			handler: function(btn, e) {
				var
					c = btn.up("window").down("customcontainer");

				if(c)
					;
			}
		}, {
			text: "pdf1",
			handler: function(btn, e) {
				c.setValue("../../../../../../../ObjectTag/TestPdf1.pdf", "application/pdf");
			}
		}, {
			text: "pdf2",
			handler: function(btn, e) {
				c.setValue("../../../../../../../ObjectTag/TestPdf2.pdf", "application/pdf");
			}
		}, {
			text: "img1",
			handler: function(btn, e) {
				c.setValue("../../../../../../../pix/xpfirewall.jpg", "image/jpg");
			}
		}, {
			text: "mg2",
			handler: function(btn, e) {
				c.setValue("../../../../../../../pix/podbor.jpg", "image/jpg");
			}
		}]
	});
});
