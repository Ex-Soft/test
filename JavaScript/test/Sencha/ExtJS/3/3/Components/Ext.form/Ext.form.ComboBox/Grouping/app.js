Ext.BLANK_IMAGE_URL="../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		combobox = new Ext.form.ComboBox({
			store: new Ext.data.ArrayStore({
				autoDestroy: true,
				idIndex: 0,
				fields: [
					{ name: "id", type: "int" },
					"group",
					"name"
				],
				data: [
					[ 1, "Group# 1", "Record# 1.1" ],
					[ 2, "Group# 1", "Record# 1.2" ],
					[ 3, "Group# 1", "Record# 1.3" ],
					[ 4, "Group# 1", "Record# 1.4" ],
					[ 5, "Group# 2", "Record# 2.1" ],
					[ 6, "Group# 2", "Record# 2.2" ],
					[ 7, "Group# 2", "Record# 2.3" ]
				]
			}),
			displayField: "name",
			valueField: "id",
			mode: "local",
			tpl: new Ext.XTemplate(
				"<tpl for=\".\">",
				"<tpl for=\"group\" if=\"this.shouldShowHeader(group)\"><div class=\"group-header\">{[this.showHeader(values, parent, xindex, xcount)]}</div></tpl>",
				"<div class=\"x-combo-list-item\">{name}</div>",
				"</tpl>", {
				shouldShowHeader: function(group) {
					if (window.console && console.log)
						console.log("shouldShowHeader(%o)", arguments);

					return this.currentGroup !== group;
				},
				showHeader: function(values, parent, xindex, xcount) {
					if (window.console && console.log)
						console.log("showHeader(%o)", arguments);

					this.currentGroup = values;
					return values;
				}
			}),
			listClass: "grouped-list",
			renderTo: Ext.getBody()
		});
});
