Ext.BLANK_IMAGE_URL="../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	tpl: new Ext.XTemplate(
		"<tpl for=\".\">",
		"<div class=\"x-combo-list-item\"><input type=\"checkbox\"/>{name}</div>",
		"</tpl>"
	),

	initList: function() {
		Test.ComboBox.superclass.initList.apply(this, arguments);

		this.view.on({
			beforeclick: this.viewBeforeClick,
			scope: this.view
		});
	},

	viewBeforeClick: function(view, index, item, e) {
		if (window.console && console.log)
			console.log("beforeclick(%o)", arguments);

		if (e.target.nodeName === "INPUT")
			return false;
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		combobox = new Test.ComboBox({
			store: new Ext.data.ArrayStore({
				autoDestroy: true,
				idIndex: 0,
				fields: [
					{ name: "id", type: "int" },
					"name"
				],
				data: [
					[ 1, "Record# 1" ],
					[ 2, "Record# 2" ],
					[ 3, "Record# 3" ],
					[ 4, "Record# 4" ],
					[ 5, "Record# 5" ]
				]
			}),
			displayField: "name",
			valueField: "id",
			mode: "local",
			listeners: {
				select: function(combo, record, index) {
					if (window.console && console.log)
						console.log("select(%o)", arguments);
				}
			},
			renderTo: Ext.getBody()
		});
});
