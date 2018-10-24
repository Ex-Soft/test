Ext.BLANK_IMAGE_URL="../../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");
Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	onViewClick: function(view, e) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onViewClick(%o)", arguments);

		var target = Ext.fly(e.target);

		if (target.hasClass("group-footer") && (target.hasClass("group1") || target.hasClass("group2")))
			return false;

    	Test.ComboBox.superclass.onViewClick.apply(this, arguments);
	}
});
Ext.reg("testcombo", Test.ComboBox);

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
					"group",
					"name",
					"cls"
				],
				data: [
					[ 1, "Group# 1", "Record# 1.1", "group1" ],
					[ 2, "Group# 1", "Record# 1.2", "group1" ],
					[ 3, "Group# 1", "Record# 1.3", "group1" ],
					[ 4, "Group# 1", "Record# 1.4", "group1" ],
					[ 5, "Group# 2", "Record# 2.1", "group2" ],
					[ 6, "Group# 2", "Record# 2.2", "group2" ],
					[ 7, "Group# 2", "Record# 2.3", "group2" ]
				]
			}),
			displayField: "name",
			valueField: "id",
			mode: "local",
			tpl: new Ext.XTemplate(
				"<tpl for=\".\">",
				"<tpl for=\"group\" if=\"this.shouldShowHeader(group)\"><div class=\"group-header\">{[this.showHeader(values, parent, xindex, xcount)]}</div></tpl>",
				"<div class=\"x-combo-list-item\">{name}</div>",
				//"<tpl if=\"this.shouldShowFooter(values)\"><div class=\"group-footer\">{group}</div></tpl>",
				"<tpl if=\"this.shouldShowFooter(values)\"><div class=\"group-footer {cls}\">{[this.showFooter(values, parent, xindex, xcount)]}</div></tpl>",
				//"<tpl if=\"this.shouldShowFooter(values)\"><div class=\"x-combo-list-item group-footer {cls}\">{[this.showFooter(values, parent, xindex, xcount)]}</div></tpl>",
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
				},
				shouldShowFooter: function(values) {
					if (window.console && console.log)
						console.log("shouldShowFooter(%o)", arguments);

					return values.id == 4 || values.id == 7;
				},
				showFooter: function(values, parent, xindex, xcount) {
					if (window.console && console.log)
						console.log("showFooter(%o)", arguments);

					return "more...";
				}
			}),
			listClass: "grouped-list",
			renderTo: Ext.getBody()
		});
});
