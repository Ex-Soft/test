Ext.define("AM.controller.Countries", {
    extend: "Ext.app.Controller",
    
    stores: ["Countries"],

    models: ["Country"],

    views: ["CountriesComboBox"],

    refs: [
        {
            ref: "countriescombobox",
            selector: "countriescombobox"
        }
    ],

    init: function() {
    	if(window.console && console.log)
    		console.log("AM.controller.Countries.init(%o)", arguments);
        /*
    	var
    		s = this.getStore("Countries");

    	if(s)
    		s.load();

    	this.control({
            "countriescombobox": {
                select: this.countriesComboBoxSelect
            }
        });*/
    },

    countriesComboBoxSelect: function(combo, records, eOpts) {
    	if(window.console && console.log)
    		console.log("countriesComboBoxSelect(%o)", arguments);

    	var
    		cb=this.getCountriescombobox();

    	if(combo==cb)
    	;
    }
});