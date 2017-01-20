Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" }
	]
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		r = Ext.create("TestModel", {
			id: 1,
			name: "Record# 1"
		}),
		dirty,
		modified,
		changes,
		isModified;

	dirty = r.dirty;
	modified = r.modified;
	changes = r.getChanges();
	isModified = r.isModified("name");
	if(window.console && console.log)
		console.log("%o dirty=%s modified=%o getChanges()=%o isModified(\"name\")=%s", r, dirty, modified, changes, isModified);

	r.set("name", "Record# 2");
	dirty = r.dirty;
	modified = r.modified;
	changes = r.getChanges();
	isModified = r.isModified("name");
	if(window.console && console.log)
		console.log("%o dirty=%s modified=%o getChanges()=%o isModified(\"name\")=%s", r, dirty, modified, changes, isModified);

	r.set("name", "Record# 1");
	dirty = r.dirty;
	modified = r.modified;
	changes = r.getChanges();
	isModified = r.isModified("name");
	if(window.console && console.log)
		console.log("%o dirty=%s modified=%o getChanges()=%o isModified(\"name\")=%s", r, dirty, modified, changes, isModified);

	r.set("name", "Record# 2");
	dirty = r.dirty;
	modified = r.modified;
	changes = r.getChanges();
	isModified = r.isModified("name");
	if(window.console && console.log)
		console.log("%o dirty=%s modified=%o getChanges()=%o isModified(\"name\")=%s", r, dirty, modified, changes, isModified);

	r.set("name", "Record# 3");
	dirty = r.dirty;
	modified = r.modified;
	changes = r.getChanges();
	isModified = r.isModified("name");
	if(window.console && console.log)
		console.log("%o dirty=%s modified=%o getChanges()=%o isModified(\"name\")=%s", r, dirty, modified, changes, isModified);

	r.set("name", "Record# 1");
	dirty = r.dirty;
	modified = r.modified;
	changes = r.getChanges();
	isModified = r.isModified("name");
	if(window.console && console.log)
		console.log("%o dirty=%s modified=%o getChanges()=%o isModified(\"name\")=%s", r, dirty, modified, changes, isModified);
});

