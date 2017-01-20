Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("Country", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
		"id"
	]
});

Ext.define("Countries", {
    extend: "Ext.data.Store",
    alias: "store.countries",
    model: "Country",
    autoLoad: true,
    proxy: {
        type: "ajax",
        url: "Country.xml",
        reader: {
            type: "xml",
            record: "row",
            idProperty: "id",
            totalProperty: "total",
            successProperty: "success",
            messageProperty: "message"
        }
    }
});

Ext.define("CountriesComboBox" ,{
	extend: "Ext.form.field.ComboBox",
	alias : "widget.countriescombobox",

	initComponent: function() {
		Ext.apply(this, {
			store: Ext.create("Countries"),
			valueField: "id",
			displayField: "id",
			grow: true,
			listConfig: {
				getInnerTpl: function() {
					return "<div<tpl if=\"id==&quot;ru&quot;\"> class=\"red\"</tpl>>{id}</div>";
				}
			},
			value: "en",
			queryMode: "local",
			editable: false
		});
		
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
		p = Ext.create("Ext.panel.Panel", {
			renderTo: Ext.getBody(),
			items: [
				{ xtype: "countriescombobox" }
			]
		});
});