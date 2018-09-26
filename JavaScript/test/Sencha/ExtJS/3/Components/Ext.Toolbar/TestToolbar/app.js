Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			fields: [ "id", "value"],
			data : [
				[ 1, "Line# 1" ],
				[ 2, "Line# 1" ],
				[ 3, "aaaaaaa" ],
				[ 4, "abbbbbb" ],
				[ 5, "abccccc" ],
				[ 6, "abcdddd" ],
				[ 7, "abcdeee" ],
				[ 8, "abcdeff" ],
				[ 9, "abcdefg" ]
			]
		}),
		combobox1 = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			typeAhead: true,
			mode: "local",
			forceSelection: true,
			triggerAction: "all",
			emptyText: "Select...",
			selectOnFocus: true,
			width: 135,
			getListParent: function() {
				return this.el.up(".x-menu");
			},
			iconCls: "no-icon"
		}),
		combobox2 = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			typeAhead: true,
			mode: "local",
			forceSelection: true,
			triggerAction: "all",
			emptyText: "Select...",
			selectOnFocus: true,
			width: 135,
			getListParent: function() {
				return this.el.up(".x-menu");
			},
			iconCls: "no-icon"
		}),
		combobox3 = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			typeAhead: true,
			mode: "local",
			forceSelection: true,
			triggerAction: "all",
			emptyText: "Select...",
			selectOnFocus: true,
			width: 135,
			getListParent: function() {
				return this.el.up(".x-menu");
			},
			iconCls: "no-icon"
		}),
		menu = new Ext.menu.Menu({
			items: [
				combobox2
			]
		}),
		viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				xtype: "toolbar",
				region: "north",
				height: 28,
				items: [{
					xtype: "button",
					text: "Button# 1",
					menu: {
						items: [{
							text: "Item# 1",
						}, {
							text: "Item# 2"
						},
							combobox1
						]
					}
				}, {
					text: "Button# 2",
					menu: menu
				}, {
					xtype: "tbseparator"
				}, {
					text: "Item# 1.1"
				}, {
					text: "Item# 1.2"
				}, "-", {
					text: "Item# 2.1"
				}, {
					xtype: "tbspacer",
					width: 50
				}, {
					text: "Item# 2.2"
				}, "-", {
					text: "Item# 3.1",
					handler: function(btn, e) {
						if (window.console && console.log)
							console.log("btn.click(%o)", arguments);
					}
				}, " ", {
					text: "Item# 3.2",
					handler: function(btn, e) {
						if (window.console && console.log)
							console.log("btn.click(%o)", arguments);
					}
				},
					"-", 
					combobox3,
					"->",
					"-",
				{
					text: "Item# 4.1",
					handler: function(btn, e) {
						if (window.console && console.log)
							console.log("btn.click(%o)", arguments);
					}
				}, {
					text: "Item# 4.2",
					handler: function(btn, e) {
						if (window.console && console.log)
							console.log("btn.click(%o)", arguments);
					}
				}],
				listeners: {
					click: function () {
						if (window.console && console.log)
							console.log("toolbar.click(%o)", arguments);
					}
				}
			}, {
				region: "center",
				html: "center"
			}]
		}),
		toolbar = viewport.findByType("toolbar"),
		td = toolbar && toolbar.length ? toolbar[0].getEl().query(".x-toolbar-left") : null,
		//td = toolbar && toolbar.length ? Ext.query(".x-toolbar-left", toolbar[0].getEl().dom) : null,
		table = toolbar && toolbar.length ? toolbar[0].getEl().query(".x-toolbar-ct") : null;
		//table = toolbar && toolbar.length ? Ext.query(".x-toolbar-ct", toolbar[0].getEl().dom) : null;

	if (table && table.length) {
		table = Ext.get(table[0]);

		//table.hide(); // visibility: hidden
		//table.show();
		//table.setDisplayed(false); // display: none
		//table.setDisplayed(true);
	}

	if (td && td.length) {
		td = td[0];

		Ext.get(td).on("click", function (e, target, eOpts) {
			if (window.console && console.log)
				console.log("%s.click(%o, %o)", td.id == target.id ? "td" : target.tagName, e, target);
		})
	}
});
