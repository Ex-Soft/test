Ext.define('MAIN', {
	extend: 'Ext.data.Model',
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" }
	],
	proxy: {
		type: "memory",
		reader: {
			type: "json",
			root: "rows"
		}
	},
	associations: [{
		type: 'hasMany',
		model: 'App',
		name: 'application',
		associationKey: "app"
	},{
		type: 'hasMany',
		model: 'Form',
		name: 'form'
	}]
});

Ext.define('App', {
	extend: 'Ext.data.Model',
	fields: [
		{name: 'id', type: 'int'},
		{name: 'name', type: 'string'}
	],
	belongsTo: 'MAIN'
});

Ext.define('Form', {
	extend: 'Ext.data.Model',
	fields: [
		{name: 'id', type: 'int'},
		{name: 'name', type: 'string'}
	],
	belongsTo: 'MAIN'
});

Ext.define('ARM.store.MAIN', {
	extend: 'Ext.data.Store',
	model: 'MAIN'
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("ARM.store.MAIN");
		data = {
			success : true,
			total: 1,
			rows: [{
				id: 1,
				name: "Main# 1",
				app: [
					{ id: 1, name: "App# 1" },
					{ id: 2, name: "App# 2" },
					{ id: 3, name: "App# 3" }
				],
				form: [
					{ id: 1, name: "Form# 1" },
					{ id: 2, name: "Form# 2" },
					{ id: 3, name: "Form# 3" }
				]
			}]
		};

	store.loadRawData(data, false);

	store.each(function(r) {
		if(window.console && console.log)
			console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));

		r.application().each(function(r) {
			if(window.console && console.log)
				console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
		});
		r.form().each(function(r) {
			if(window.console && console.log)
				console.log("id=%i name=\"%s\"", r.get("id"), r.get("name"));
		});
	});
});