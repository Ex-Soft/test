Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("ModelSelectFieldItem", {
    extend: "Ext.data.Model",

    config: {
        idProperty: "Id",
        fields: [
			{ name: "Id", type: "int" },
			{ name: "Value", type: "string" }
		]
    }
});

Ext.define("ModelDataItem", {
    extend: "Ext.data.Model",

    config: {
        idProperty: "Id",
        fields: [
			{ name: "Id", type: "int" },
			{ name: "TestSelectFieldId", type: "int" }
		]
    }
});

Ext.application({
	launch: function() {
		if (window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		var
            form = Ext.Viewport.add({
                xtype: "formpanel",
                //trackResetOnLoad: true,
                items: [{
                    xtype: "selectfield",
                    name: "TestSelectFieldId",
                    label: "Select",
                    valueField: "Id",
                    displayField: "Value",
                    store: {
                        autoLoad: false,
                        model: "ModelSelectFieldItem",
                        proxy: {
                            type: "ajax",
                            url: "SelectField.json",
                            reader: {
                                type: "json",
                                rootProperty: "data"
                            }
                        }
                    }
                }]
            }),
            s = form.getFields("TestSelectFieldId");

	    s.getStore().load({
	        callback: function (records, operation, success) {
	            var
	                sel = s,
                    record = Ext.create("ModelDataItem", { Id: 1, TestSelectFieldId: 3 }),
                    store = sel.getStore(),
                    index = store.find("Id", 3, null, null, null, true),
                    originalValue = store.getAt(index),
                    originalValueId = originalValue.get("Id"),
                    originalValueValue = originalValue.get("Value"),
                    component = sel.getComponent(),
                    isDirty,
                    value;

			//form.setRecord(record);
			sel._value = sel.record = originalValue;
			sel.originalValue =  originalValueId;
			component.updateValue(originalValueValue);
			component._value = component.originalValue = originalValueValue;
			isDirty = sel.isDirty();
			value = sel.getValue();

	            if (window.console && console.log)
	                console.log("%s", isDirty);
	        },
            scope: this
	    });
	}
});