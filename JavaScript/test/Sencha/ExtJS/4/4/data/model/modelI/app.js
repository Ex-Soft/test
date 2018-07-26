Ext.require([
	"Ext.data.*"
]);

Ext.define("TestModel1", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" },
		{ name: "fdate", type: "date", dateFormat: "c" }
	],
	proxy: {
		type: "memory",
		reader: {
			type: "json"
		}
	}
});

Ext.define("TestModel2", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" },
		{ name: "fdate", type: "date", dateFormat: "c" }
	],
	proxy: {
		type: "memory",
		reader: {
			type: "array"
		}
	}
});

Ext.define("TestModel3", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" },
		{ name: "fdate", type: "date", dateFormat: "c" }
	]
});

Ext.define("TestModel4", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "fauto", type: "auto" },
		{ name: "fstring", type: "string" },
		{ name: "fint", type: "int" },
		{ name: "ffloat", type: "float" },
		{ name: "fboolean", type: "boolean" },
		{ name: "fdate", type: "date", dateFormat: "c" }
	]
});

Ext.define("TestModel5", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "fauto", type: "auto" },
		{ name: "fstring", type: "string" },
		{ name: "fint", type: "int" },
		{ name: "ffloat", type: "float" },
		{ name: "fboolean", type: "boolean" },
		{ name: "fdate", type: "date", dateFormat: "c", convert: function(v) {
			var
				result;

			if(window.console && console.log)
				console.log("fdate.convert(%o)", arguments);

			return Ext.isDate(v) ? v : (!isNaN(result=Date.parse(v)) ? new Date(result) : null);
		} }
	]
});

Ext.onReady(function() {
	var
		r = Ext.create("TestModel1", {
			id: 1,
			name: "Record# 1",
			fdate: new Date(2012,8,25,9,13,13,13)
		}),
		m,
		data,
		fields,
		field,
		value,
		i,
		len;

	if(window.console && console.log)
		console.log("%o", r);

	r = Ext.create(TestModel1, {
			id: 2,
			name: "Record# 2",
			fdate: "2012-09-25T09:13:13.13+03:00"
		});

	data = [];
	fields = r.fields.items;
	len=fields.length;
	for(i=0; i<len; ++i)
	{
		value = r.get((field = fields[i]).name);

		if(field.type.type === "date")
			value = Ext.isDate(value) ? Ext.Date.format(value, field.dateFormat) : null;

		data.push(value);
	}

	field = r.fields.get("name");
	if(window.console && console.log)
		console.log("%o", field);

	field = r.fields.get("_name_");
	if(window.console && console.log)
		console.log("%o", field);

	if(window.console && console.log)
		console.log("%o", r);

	r = Ext.create("TestModel2",
		[ 3, "Record# 3", new Date(2012,8,25,9,13,13,13) ]
	);

	if(window.console && console.log)
		console.log("%o", r);

	r = Ext.create("TestModel3",
		[ 4, "Record# 4", "2012-09-25T09:13:13.13+03:00" ]
	);

	if(window.console && console.log)
		console.log("%o", r);

	r = Ext.create("TestModel4");

	if(window.console && console.log)
		console.log("%o", r);

	data = [];
	fields = r.fields.items;
	len=fields.length;
	for(i=0; i<len; ++i)
	{
		value = r.get((field = fields[i]).name);

		if(field.type.type === "date")
			value = Ext.isDate(value) ? Ext.Date.format(value, field.dateFormat) : null;

		data.push(value);
	}

	m=r.get("id");
	m=r.get("fauto");
	m=r.get("fstring");
	m=r.get("fint");
	m=r.get("ffloat");
	m=r.get("fboolean");
	m=r.get("fdate");

	r = Ext.create("TestModel4", {
		id: 999,
		fauto: null,
		fstring: null,
		fint: null,
		ffloat: null,
		fboolean: null,
		fdate: null
	});

	if(window.console && console.log)
		console.log("%o", r);

	m=r.get("id");
	m=r.get("fauto");
	m=r.get("fstring");
	m=r.get("fint");
	m=r.get("ffloat");
	m=r.get("fboolean");
	m=r.get("fdate");

	r = Ext.create("TestModel4", {
		id: 999,
		fauto: "",
		fstring: "",
		fint: "",
		ffloat: "",
		fboolean: "",
		fdate: ""
	});

	if(window.console && console.log)
		console.log("%o", r);

	m=r.get("id");
	m=r.get("fauto");
	m=r.get("fstring");
	m=r.get("fint");
	m=r.get("ffloat");
	m=r.get("fboolean");
	m=r.get("fdate");
	
	if(window.console && console.log)
		console.log("%o", Ext.ModelManager.getModel("TestModel1"));

	m=Ext.ModelManager.getModel("TestModel11");
	if(window.console && console.log)
		console.log("%s", typeof m);

	r = Ext.create("TestModel5");
	r.set("fdate", new Date());
	r.set("fdate", "2012-11-08T09:13:13.13+03:00");
	m = r.get("fdate");
});

