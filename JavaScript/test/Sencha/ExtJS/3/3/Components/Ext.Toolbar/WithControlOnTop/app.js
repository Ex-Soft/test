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
		combobox = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			width: 135,
			getListParent: function() {
				return this.el.up(".x-menu");
			},
			hidden: true
		}),
		viewport = new Ext.Viewport({
			layout: "border",
			items: [{
				xtype: "toolbar",
				region: "north",
				height: 28,
				items: [{
					text: "Button# 1"
				}, {
					text: "Button# 2"
				}, {
					text: "Button# 3"
				}, {
					text: "Button# 4"
				},
					"->",
				{
					text: "Search",
					iconCls: "searchIco",
					handler: function(btn, e) {
						if (window.console && console.log)
							console.log("btn.click(%o)", arguments);

						var toolbar,
							el,
							table;

						if (!(toolbar = btn.findParentByType("toolbar"))
							|| !(el = toolbar.getEl())
							|| !(table = el.query(".x-toolbar-ct"))
							|| !table.length)
							return;

						combobox.render(el, 0);
						combobox.wrap.addClass("search");
					}
				}]
			}, {
				region: "center",
				html: "center"
			}],
			renderTo: Ext.getBody()
		});
});
