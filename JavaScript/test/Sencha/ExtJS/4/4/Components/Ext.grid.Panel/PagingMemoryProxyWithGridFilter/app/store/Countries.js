var myData = {
	success: true,
	total: 5,
	countries: [
		{ "name": "Ukraine", "id": 380 },
		{ "name": "Russia", "id": 7 },
		{ "name": "USA", "id": 1 },
		{ "name": "Portugal", "id": 351 },
		{ "name": "Gibraltar", "id": 350 }
	]
};

var myTempData = myData;

Ext.define('SAMPLE.store.Countries', {
	extend: 'Ext.data.Store',
	model: 'SAMPLE.model.Country',
	pageSize: 2,
	listeners: {
		beforeload: function(store, operation, options){
			console.log("My Store data is loading!");
		}
	}
});