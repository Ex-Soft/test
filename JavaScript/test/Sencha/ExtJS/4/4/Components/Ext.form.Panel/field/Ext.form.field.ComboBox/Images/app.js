//http://www.sencha.com/learn/legacy/Tutorial:Extending_Ext2_Class
// http://xo66ut.ru/archives/275#more-275
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
    },
    listeners: {
        beforeload: function(store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeload (Countries)");
        },
        beforeprefetch: function(store, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.beforeprefetch (Countries)");
        },
        load: function (store, records, successful, operation) {
            if (window.console && console.log)
                console.log("Store.load: successful=%s (Countries)", successful);
        },
        update: function (store, record, operation, eOpts) {
            if (window.console && console.log)
                console.log("Store.update (Countries)");
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
				//getInnerTpl: function() { return "<div><img src=\"images/flags/{id}.png\" align=\"left\">&nbsp;&nbsp;{id}</div>"; }
				//itemTpl: Ext.create("Ext.XTemplate", "<div><img src=\"images/flags/{id}.png\" align=\"left\">&nbsp;&nbsp;{id}</div>")
				tpl: Ext.create("Ext.XTemplate", "<ul><tpl for=\".\"><li role=\"option\" class=\"" + Ext.baseCSSPrefix + "boundlist-item" + "\"><div><img src=\"images/flags/{id}.png\" align=\"left\">&nbsp;&nbsp;{id}</div></li></tpl></ul>")
			},
			//tpl: Ext.create("Ext.XTemplate", "<ul><tpl for=\".\"><li role=\"option\" class=\"" + Ext.baseCSSPrefix + "boundlist-item" + "\"><div><img src=\"images/flags/{id}.png\" align=\"left\">&nbsp;&nbsp;{id}</div></li></tpl></ul>"),
			value: "en",
			queryMode: "local",
			editable: false
		});
		
		this.callParent(arguments);
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		p = Ext.create("Ext.panel.Panel", {
			renderTo: Ext.getBody(),
			items: [
				{ xtype: "countriescombobox" }
			]
		});
});