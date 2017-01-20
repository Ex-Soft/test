Ext.onReady(function() {
	var
		allNames = new Ext.util.MixedCollection();

	allNames.addAll([
		{id: 1, name: 'Ed',    age: 25},
		{id: 2, name: 'Jamie', age: 37},
		{id: 3, name: 'Abe',   age: 32},
		{id: 4, name: 'Aaron', age: 26},
		{id: 5, name: 'David', age: 32}
	]),
	ageFilter = new Ext.util.Filter({
		property: 'age',
		value   : 32
	}),
	longNameFilter = new Ext.util.Filter({
		filterFn: function(item) {
			return item.name.length > 4;
		}
	}),
	longNames = allNames.filter(longNameFilter),
	youngFolk = allNames.filter(ageFilter);
});
