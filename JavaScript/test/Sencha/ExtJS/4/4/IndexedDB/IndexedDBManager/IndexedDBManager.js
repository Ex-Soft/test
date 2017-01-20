Ext.define("IndexedDBManager", {
	singleton: true,

	isSupported: false,
	indexedDB: window.indexedDB || window.webkitIndexedDB || window.mozIndexedDB || window.msIndexedDB,
	db: undefined,
	dbVersion: 1,
	dbName: "TestIndexDBManagerDatabase",
	tableName: "TestTable",
	indexName: "user",
	indexKeyPath: "user",

	constructor: function(config) {
		if(!this.indexedDB)
			return this;

		isSupported = true;

		if(window.webkitIndexedDB)
		{
			if(!window.IDBRequest)
				window.IDBRequest = window.webkitIDBRequest;

			if(!window.IDBTransaction)
				window.IDBTransaction = window.webkitIDBTransaction;

			if(!window.IDBDatabase)
				window.IDBDatabase = window.webkitIDBDatabase;

			if(!window.IDBKeyRange)
				window.IDBKeyRange = window.webkitIDBKeyRange;
		}

		this.openDb();

		return this;
	},

	openDb: function() {
		if(window.console && console.log)
			console.log("openDb()");

		var
			me = this,
			request = me.indexedDB.open(me.dbName, me.dbVersion);

		request.onsuccess = function(event) {
			if(window.console && console.log)
				console.log("open.onsuccess()");

			me.setDb(event.target.result);
		};

		request.onupgradeneeded = function(event) {
			if(window.console && console.log)
				console.log("open.onupgradeneeded()");

			me.setDb(event.target.result);
			me.createObjectStore();
		};

		request.onblocked = me.onblocked;
		request.onerror = me.onerror;
	},

	setDb: function(db) {
		if(!this.db)
		{
			this.db = db;

			this.db.onversionchange = this.onversionchange;
			this.db.onerror = this.onerror;
			this.db.onabort = this.onabort;
		}
	},

	createObjectStore: function() {
		if(window.console && console.log)
			console.log("createObjectStore()");

		var
			request;

		try
		{
			request = this.db.createObjectStore(this.tableName, { autoIncrement: false });
			request.createIndex(this.indexName, this.indexKeyPath, { unique: false });
		}
		catch(e)
		{
			if(window.console && console.error)
				console.error("%s: \"%s\"", e.name, e.message);
		}
	},

	closeDb: function() {
		if(this.db)
		{
			this.db.close();
			this.db = undefined;
		}
	},

	deleteDb: function() {
		var
			request;

		if(this.db)
			this.closeDb();

		request = this.indexedDB.deleteDatabase(this.dbName);
		request.onsuccess = function(event) {
			if(window.console && console.log)
				console.log("deleteDb.onsuccess()");
		};

		request.onerror = this.onerror;
		request.onblocked = this.onblocked;
	},

	doOperation: function(operation) {
		var
			me = this,
			transaction = me.db.transaction([me.tableName], operation.transactionMode),
			table,
			request;

		transaction.oncomplete = me.oncomplete;
		transaction.onabort = me.onabort;
		transaction.onerror = me.onerror;

		try
		{
			table = transaction.objectStore(me.tableName);

			switch(operation.operation)
			{
				case "add":
				case "put":
				{
					request = table[operation.operation](operation.value, operation.id);
					break;
				}
				case "get":
				case "delete":
				{
					request = table[operation.operation](operation.id);
					break;
				}
				case "clear":
				{
					request = table[operation.operation]();
					break;
				}
			}

			request.onsuccess = function(event) {
				var
					result = event.target.result;

				if(window.console && console.log)
					console.log("%s.onsuccess(%o) typeof result = \"%s\"", operation.operation, event, typeof result);

				if(operation.callback)
				{
					if(operation.scope)
					{
						if(operation.operation === "get")
							operation.callback.call(operation.scope, result);
						else
							operation.callback.call(operation.scope);
					}
					else
					{
						if(operation.operation === "get")
							operation.callback(result);
						else
							operation.callback();
					}
				}
			};

			request.onerror = me.onerror;
		}
		catch(e)
		{
			if(window.console && console.error)
				console.error("%s: \"%s\"", e.name, e.message);
		}
	},

	getUser: function(id) {
		var
			result;

		return (result=id.match(/^(.*?):(?:.*?)$/)) && result.length>1 ? result[1] : undefined;
	},

	add: function(id, value, callback, scope) {
		value[this.indexKeyPath] = this.getUser(id);

		this.doOperation({
			operation: "add",
			transactionMode: "readwrite",
			id: id,
			value: value,
			callback: callback,
			scope: scope
		});
	},

	put: function(id, value, callback, scope) {
		value[this.indexKeyPath] = this.getUser(id);

		this.doOperation({
			operation: "put",
			transactionMode: "readwrite",
			id: id,
			value: value,
			callback: function() {
				if(window.console && console.log)
					console.log("put.callback(%o)", arguments);

				if(callback)
				{
					if(scope)
						callback.call(scope);
					else
						callback();
				}
			},
			scope: this
		});
	},

	"get": function(id, callback, scope) {
		this.doOperation({
			operation: "get",
			transactionMode: "readonly",
			id: id,
			callback: callback,
			scope: scope
		});
	},

	"delete": function(id, callback, scope) {
		this.doOperation({
			operation: "delete",
			transactionMode: "readwrite",
			id: id,
			callback: callback,
			scope: scope
		});
	},

	clearUserData: function(user, callback, scope) {
		var
			transaction = this.db.transaction([this.tableName], "readwrite"),
			table = transaction.objectStore(this.tableName),
			index = table.index(this.indexName),
			cursor;

		transaction.oncomplete = this.oncomplete;
		transaction.onabort = this.onabort;
		transaction.onerror = this.onerror;

		if(window.console && console.log)
			console.log("typeof transaction=\"%s\", typeof table=\"%s\", typeof index=\"%s\"", typeof transaction, typeof table, typeof index);

		index.openCursor(user).onsuccess = function(event) {
			cursor = event.target.result;

			if (cursor) {
				if(window.console && console.log)
					console.log("cursor: { primaryKey: \"%s\" value: %o }", cursor.primaryKey, cursor.value);

				cursor["delete"]();
				cursor["continue"]();
			}
			else
			{
				if(window.console && console.log)
					console.log("cursor: No more entries!");

				if(callback)
				{
					if(scope)
						callback.call(scope);
					else
						callback();
				}
			}
		};
	},

	clear: function(callback, scope) {
		this.doOperation({
			operation: "clear",
			transactionMode: "readwrite",
			callback: callback,
			scope: scope
		});
	},

	onabort: function(event) {
		var
			me;

		if(this instanceof IDBTransaction)
			me = "IDBTransaction";
		else if(this instanceof IDBDatabase)
			me = "IDBDatabase";

	if(window.console && console.log)
			console.log("onabort(%o) this=\"%s\"", event, me);
	},

	onblocked: function(event) {
		if(window.console && console.log)
			console.log("onblocked(%o)", arguments);
	},

	onerror: function(event) {
		var
			me;

		if(this instanceof IDBRequest)
			me = "IDBRequest";
		else if(this instanceof IDBTransaction)
			me = "IDBTransaction";
		else if(this instanceof IDBDatabase)
			me = "IDBDatabase";

		if(window.console && console.log)
			console.log("onerror(%o) this=\"%s\"", event, me);
	},

	onversionchange: function(event) {
		if(window.console && console.log)
			console.log("onversionchange(%o)", arguments);
	},

	oncomplete: function(event) {
		if(window.console && console.log)
			console.log("oncomplete(%o)", arguments);
	}
});