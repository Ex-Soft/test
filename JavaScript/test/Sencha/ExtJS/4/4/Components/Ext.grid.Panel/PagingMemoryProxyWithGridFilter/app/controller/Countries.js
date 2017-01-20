Ext.define('SAMPLE.controller.Countries', {
	extend : 'Ext.app.Controller',

	stores : ['Countries'],
	models : ['Country'],
	views  : ['CountryList'],
	refs: [{
		ref: 'myGrid',
		selector: 'grid'
	}], 

	init : function() {
		this.control({
			'viewport > panel' : {
				render : this.onPanelRendered
			},
			'countrylist #gridTrigger' : {
				keyup : this.onTriggerKeyUp,
				triggerClear : this.onTriggerClear
			}
		});
	},

	onPanelRendered : function() {
		console.log('The panel was rendered');
		this.getCountriesStore().setProxy({
			type: 'pagingmemory',
			data: myTempData,
			reader: {
				type: 'json',
				totalProperty: 'total',
				root: 'countries',
				successProperty: 'success'
			}
		});

		this.getCountriesStore().load();
	},

	onTriggerKeyUp : function(t) {
		console.log('You typed something!');

		var thisRegEx = new RegExp(t.getValue(), "i");
		var grid = this.getMyGrid();
		records = [];
		Ext.each(myData.countries, function(record) {
			for (var i = 0; i < grid.columns.length; i++) {
				// Do not search the fields that are passed in as omit columns
				if (grid.omitColumns) {
					if (grid.omitColumns.indexOf(grid.columns[i].dataIndex) === -1) {
						if (thisRegEx.test(record[grid.columns[i].dataIndex])) {
							if (!grid.filterHidden && grid.columns[i].isHidden()) {
								continue;
							} else {
								records.push(record);
								break;
							};
						};
					};
				} else {
					if (thisRegEx.test(record[grid.columns[i].dataIndex])) {
						if (!grid.filterHidden && grid.columns[i].isHidden()) {
							continue;
						} else {
							records.push(record);
							break;
						};
					};
				};
			} 
		});

		myTempData.countries = records;
		myTempData.totalCount = records.length;
		this.getCountriesStore().load();
	},

	onTriggerClear : function() {
		console.log('Trigger got reset!');
		myTempData.countries = myData.countries;
		myTempData.totalCount = myData.totalCount;
		this.getCountriesStore().load();
	}
});