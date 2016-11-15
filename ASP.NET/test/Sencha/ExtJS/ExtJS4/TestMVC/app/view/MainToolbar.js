Ext.define("AM.view.MainToolbar" ,{
	extend: "Ext.toolbar.Toolbar",
	alias : "widget.maintoolbar",
	requires: ["AM.view.CountriesComboBox"],

	initComponent: function() {
		Ext.apply(this, {
			items: [
				"->",
				{
					xtype: "countriescombobox"
				}
			]
		});

		this.callParent(arguments);		
	}
});