Ext.define('SAMPLE.model.Country', {
	extend: 'Ext.data.Model',
	idProperty: "id",
	fields: [
		{ name: 'id', type: "int" },
		'name'
	]
});