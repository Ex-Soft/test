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
				{ name: "val", type: "date", dateFormat: "c" },
				"fString"
			],
			proxy: {
				type: "memory",
				reader: {
					type: "array"
				}
			},
			data: [
				[ 1, "2012-04-19T14:55:13.123", "record# 1" ],
				[ 2, "2012-04-19T11:55:13.123Z", "record# 2" ],
				[ 3, "2012-04-20T19:00:00.000", "record# 3" ],
				[ 4, "2012-04-20T19:00:00.000Z", "record# 4" ]
			]
		}),
		PanelCenter=new Ext.Panel({
			region: "center",
			html: "center"
		}),
		tpl=new Ext.XTemplate(
			"<tpl for=\".\"><div>{data.id} - {data.val} -> {[this.frmVal(values.data.val)]} - {data.fString:this.frmString}</div></tpl>",
			{
				frmVal: function(val) {
					return Ext.Date.format(val, "d.m.Y");
				},
				frmString: function(val) {
					return val.toUpperCase();
				}
			}
		),
		viewport=new Ext.Viewport({
			layout: "border",
			border: false,
			renderTo: Ext.getBody(),
			items: [ PanelCenter ]
		});

		tpl.overwrite(PanelCenter.body, store);
});