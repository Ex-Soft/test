Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.require([
	"IndexedDBManager"
]);

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		textFieldId = Ext.create("Ext.form.field.Text", {
			value: "admin:id1"
		}),
		textFieldValue = Ext.create("Ext.form.field.Text", {
			value: "{ \"prop1\": \"prop1\" }",
			width: 300
		}),
		checkboxFieldAuto = Ext.create("Ext.form.field.Checkbox");

	Ext.create("Ext.toolbar.Toolbar", {
		items: [
			"id: ",
			textFieldId,
			"value: ",
			textFieldValue,
			"auto",
			checkboxFieldAuto,
		{
			text: "add()",
			handler: function(btn, e) {
				var
					id,
					value,
					result,
					o;

				if((id=Ext.String.trim(textFieldId.getValue())).length===0
					|| (value=Ext.String.trim(textFieldValue.getValue())).length===0)
					return;

				if(!checkboxFieldAuto.getValue())
				{
					if(value.match(/^{.*?}$/))
						value = Ext.JSON.decode(value, true);

					if(!value)
						return;

					IndexedDBManager.add(id, value);
				}
				else
				{
					if(isNaN(id = parseInt(id, 10))
						|| isNaN(value = parseInt(value, 10)))
						return;

					result = [];
					for(var i=0; i<id; ++i)
					{
						o = {};
						for(var j=0; j<value; ++j)
							o["prop"+j] = "prop"+j;
						result.push(o);
					}

					IndexedDBManager.add("admin:test"+id, result);
				}
			}
		}, {
			text: "put()",
			handler: function(btn, e) {
				var
					id,
					value;

				if((id=Ext.String.trim(textFieldId.getValue())).length===0
					|| (value=Ext.String.trim(textFieldValue.getValue())).length===0)
					return;

				if(value.match(/^{.*?}$/))
					value = Ext.JSON.decode(value, true);

				if(!value)
					return;

				IndexedDBManager.put(id, value, function() {
					if(window.console && console.log)
						console.log("main.put.callback(%o)", arguments);
				}, this);
			}
		}, {
			text: "get()",
			handler: function(btn, e) {
				var
					id;

				if((id=Ext.String.trim(textFieldId.getValue())).length===0)
					return;

				IndexedDBManager.get(id, function(value) {
					textFieldValue.setValue(typeof value!=="undefined" ? Ext.JSON.encode(value) : typeof value);
				}, this);
			}
		}, {
			text: "delete()",
			handler: function(btn, e) {
				var
					id;

				if((id=Ext.String.trim(textFieldId.getValue())).length===0)
					return;

				IndexedDBManager.delete(id, function(value) {
					textFieldValue.setValue(typeof value!=="undefined" ? Ext.JSON.encode(value) : typeof value);
				}, this);
			}
		}, {
			text: "clearUserData()",
			handler: function(btn, e) {
				var
					id;

				if((id=Ext.String.trim(textFieldId.getValue())).length===0)
					return;

				IndexedDBManager.clearUserData(id.indexOf(":")!==-1 ? IndexedDBManager.getUser(id) : id, function(value) {
					textFieldValue.setValue(typeof value!=="undefined" ? Ext.JSON.encode(value) : typeof value);
				}, this);
			}
		}, {
			text: "clear()",
			handler: function(btn, e) {
				IndexedDBManager.clear(function(value) {
					textFieldValue.setValue(typeof value!=="undefined" ? Ext.JSON.encode(value) : typeof value);
				}, this);
			}
		}, {
			text: "deleteDatabase()",
			handler: function(btn, e) {
				IndexedDBManager.deleteDb();
			}
		}],
		renderTo: Ext.getBody()
	});
});