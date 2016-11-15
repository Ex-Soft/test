Ext.define("AM.view.CountriesComboBox" ,{
	extend: "Ext.form.field.ComboBox",
	alias : "widget.countriescombobox",

	initComponent: function() {
		Ext.apply(this, {
			store: "Countries",
			valueField: "id",
			displayField: "id",
			grow: true,
			listConfig: {
				getInnerTpl: function() { return "<div><img src=\"images/flags/{id}.png\" align=\"left\">&nbsp;&nbsp;{id}</div>"; }
			},
			value: "en",
			queryMode: "local",
			editable: false,
			width: 40
		});
		
		this.callParent(arguments);
	}
});