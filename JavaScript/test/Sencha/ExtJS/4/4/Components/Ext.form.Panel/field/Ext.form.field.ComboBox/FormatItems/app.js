Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("Ext.data.ArrayStore", {
			fields: [
				{ name: "id", type: "int" },
				{ name: "val", type: "date", dateFormat: "c" }
			],
			proxy: {
				type: "memory",
				reader: {
					type: "array"
				}
			},
			data: [
				[ 1, "2012-04-19T14:55:13.123" ],
				[ 2, "2012-04-19T11:55:13.123Z" ],
				[ 3, "2012-04-20T19:00:00.000" ],
				[ 4, "2012-04-20T19:00:00.000Z" ]
			]
		});

	Ext.create("Ext.form.field.ComboBox", {
		store: store,
		valueField: "id",
		displayField: "val",
		queryMode: "local",
		editable: false,
		renderTo: Ext.getBody()
	});

	Ext.create("Ext.form.field.ComboBox", {
		store: store,
		valueField: "id",
		displayField: "val",
		queryMode: "local",
		editable: false,
		listConfig: {
			tpl: new Ext.XTemplate("<ul><tpl for=\".\"><li role=\"option\" class=\"" + Ext.baseCSSPrefix + "boundlist-item" + "\"><div>{val:date(\"d.m.Y\")}</div></li></tpl></ul>")
		},
		renderTo: Ext.getBody()
	});

	Ext.create("Ext.form.field.ComboBox", {
		store: store,
		valueField: "id",
		displayField: "val",
		queryMode: "local",
		editable: false,
		listConfig: {
			tpl: new Ext.XTemplate("<ul><tpl for=\".\"><li role=\"option\" class=\"" + Ext.baseCSSPrefix + "boundlist-item" + "\"><div>{[this.frmVal(values.val)]}</div></li></tpl></ul>", {
				frmVal: function(val) {
					return Ext.Date.format(val, "d.m.Y");
				}
			})
		},
		renderTo: Ext.getBody()
	});

	Ext.create("Ext.form.field.ComboBox", {
		store: store,
		valueField: "id",
		displayField: "val",
		queryMode: "local",
		editable: false,
		listConfig: {
			tpl: new Ext.XTemplate("<ul><tpl for=\".\"><li role=\"option\" class=\"" + Ext.baseCSSPrefix + "boundlist-item" + "\"><div>{[Ext.Date.format(new Date(values.val.getTime()), \"d.m.Y\")]}</div></li></tpl></ul>")
		},
		renderTo: Ext.getBody()
	});
});