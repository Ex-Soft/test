Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("Ext.ux.form.field.Trigger", {
	extend: "Ext.form.field.Trigger",
	alias: "widget.customtrigger",

	trigger1Cls: 'x-form-search-trigger',
	trigger2Cls: 'x-form-clear-trigger',

	valueField: "id",
	displayField: "name",

	getValue: function() {
		if(window.console && console.log)
			console.log("getValue(%o)", arguments);

		return this.callParent(arguments);
	},

	setValue: function(value) {
		if(window.console && console.log)
			console.log("setValue(%o)", arguments);

		this.callParent(arguments);
	},

	applyValue: function() {
		if(window.console && console.log)
			console.log("applyValue(%o)", arguments);

		this.callParent(arguments);
	},

	updateValue: function() {
		if(window.console && console.log)
			console.log("applyValue(%o)", arguments);

		this.callParent(arguments);
	},

	valueToRaw: function(value) {
		var
			rawValue;

		if(Ext.isObject(value))
		{
			this.keyValue = value[this.valueField];
			rawValue = value[this.displayField];
		}
		else
		{
			rawValue = value;
		}

		return this.callParent([rawValue]);
	},

	rawToValue: function(value) {
		var result = {};

		if(Ext.isString(value) && value.length!==0 && this.keyValue)
		{
			result[this.valueField] = this.keyValue;
			result[this.displayField] = value;
		}

		return !Ext.Object.isEmpty(result) ? result : undefined;
	},

	isEqual: function(object1, object2) {
		if(object1 === object2)
			return true;

		if((object1 && !object2) || (!object1 && object2))
			return false;

		return object1[this.valueField] === object2[this.valueField] && object1[this.displayField] === object2[this.displayField];
	},

	onTrigger1Click: function() {
		if(window.console && console.log)
			console.log("onTrigger1Click(%o)", arguments);
	},

	onTrigger2Click: function() {
		var o = {};

		o[this.valueField] = undefined;
		o[this.displayField] = undefined;
		this.setValue(o);
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			text: "getValue()",
			handler: function() {
				var value = searchField.getValue();

				if(window.console && console.log)
					console.log("value = %o", value);
			}
		}, {
			text: "setValue()",
			handler: function() {
				searchField.setValue({id: 1, name: "blah-blah-blah" });
			}
		}, {
			text: "resetOriginalValue()",
			handler: function() {
				searchField.resetOriginalValue();
			}
		}, {
			text: "isDirty()",
			handler: function() {
				var isDirty = searchField.isDirty();

				if(window.console && console.log)
					console.log("isDirty() = %s", isDirty);
			}
		}],
		renderTo: Ext.getBody()
	});

	var searchField = Ext.create("Ext.ux.form.field.Trigger", {
		valueField: "id",
		displayField: "name",
		width: 300,
		renderTo: Ext.getBody()
	});
});