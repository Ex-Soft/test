Ext.BLANK_IMAGE_URL="../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		cb = new Ext.form.ComboBox({
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
					[ 4, "Record# 4" ]
				]
			}),
			displayField: "name",
			valueField: "id",
			mode: "local",
			tpl: new Ext.XTemplate("<tpl for=\".\"><div class=\"x-combo-list-item{[this.getIconClass(values)]}\">{name}</div></tpl>", {
				getIconClass: function(values) {
					if (window.console && console.log)
						console.log("getIconClass(%o)", arguments);

					var result = "";

					switch(values.id)
					{
						case 1: result = "spade"; break;
						case 2: result = "club"; break;
						case 3: result = "diamond"; break;
						case 4: result = "heart"; break;
					}

					return !Ext.isEmpty(result) ? " " + result : result;
				}
			}),
			listWidth: 100,
			title: "title",
			renderTo: Ext.getBody()
		});
});
