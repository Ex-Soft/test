Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		onComboBoxChange = function(combo, newValue, oldValue, eOpts) {
			if(window.console && console.log)
				console.log("Ext.form.field.ComboBox.change(%o)", arguments);
		},
		onComboBoxSelect = function(combo, records, eOpts) {
			if(window.console && console.log)
				console.log("Ext.form.field.ComboBox.select(%o)", arguments);
		},
		onSpecialKey = function(field, e, eOpts) {
			if(window.console && console.log)
				console.log("Ext.form.field.Base.specialkey(%o) %s %o", arguments, e.ctrlKey, e.getKey());
		},
		onBeforeQuery = function(queryEvent, eOpts) {
			if(window.console && console.log)
				console.log("Ext.form.field.ComboBox.beforequery(%o)", arguments);

			if(queryEvent.combo.queryMode === "local")
			{
				queryEvent.query = new RegExp(queryEvent.query, "i");
				queryEvent.forceAll = true;
			}
		},
		store = Ext.create("Ext.data.Store", {
			fields: [
				{ name: "id", type: "string" },
				{ name: "name", type: "string" },
				{ name: "smthfield", "type": "string" }
			],
			data: [
				{ id: "ID1", name: "Record# 1", smthfield: "SmthField# 1" },
				{ id: "ID2", name: "Record# 2", smthfield: "SmthField# 2" },
				{ id: "ID3", name: "Record# 3", smthfield: "SmthField# 3" },
				{ id: "ID4", name: "Record# 4", smthfield: "SmthField# 4" },
				{ id: "ID5", name: "aaa", smthfield: "SmthField# 5" },
				{ id: "ID6", name: "aaabbb", smthfield: "SmthField# 6" },
				{ id: "ID7", name: "aaabbbccc", smthfield: "SmthField# 7" }
			]
		}),
		fieldComboBox = Ext.create("Ext.form.field.ComboBox", {
			store: store,
			valueField: "id",
			fieldLabel: "ComboBox",
			displayField: "name",
			queryMode: "local",
			editable: true,
			typeAhead: true,
			forceSelection: true,
			valueNotFoundText: "blah-blah-blah",
			width: 250,
			multiSelect: true,
			listeners: {
				change: onComboBoxChange,
				select: onComboBoxSelect,
				specialkey: onSpecialKey,
				beforequery: onBeforeQuery
			}
		}),
		functionValidator = function() {
			if(window.console && console.log)
				console.log("functionValidator(%o)", arguments);

			return "blah-blah-blah"
		},
		fieldTextBox = Ext.create("Ext.form.field.Text", {
			fieldLabel: "Text"
			//, allowBlank: false
		}),
		f = Ext.create("Ext.form.Panel", {
			frame: true,
			items: [
				fieldTextBox,
			{
				xtype: "datefield",
				fieldLabel: "Date",
				emptyText: "dd.mm.yyyy",
				value: "dd.mm.yyyy"
			},
				fieldComboBox
			],
			dockedItems: [{
				xtype: "toolbar",
				dock: "top",
				items: [{
					text: "setValue()",
					handler: function(btn, e) {
						fieldComboBox.reset();
						fieldComboBox.setValue("ID2");
					},
				}, {
					text: "set validator",
					handler: function(btn, e) {
						fieldTextBox.validator = functionValidator;
					}
				}, {
					text: "reset validator",
					handler: function(btn, e) {
						delete fieldTextBox.validator;
						fieldTextBox.clearInvalid();
					}
				}, {
					text: "markInvalid()",
					handler: function(btn, e) {
						fieldTextBox.markInvalid(["from markInvalid()"]);
					}
				}]
			}, {
				xtype: "toolbar",
				dock: "bottom",
				items: [{
					text: "submit",
					handler: function(btn, e) {
						var
							form = f.getForm();

						if(window.console && console.log)
							console.log("Ext.form.Basic.isValid() = %s, Ext.form.field.ComboBox.getValue() = \"%s\"", form.isValid(), fieldComboBox.getValue());
					}
				}]
			}],
		}),
		w = Ext.create("Ext.window.Window", {
			title: "Test Ext.form.Panel",
			autoScrol: true,
			layout: "fit",
			autoDestroy: true,
			border: 0, // !!!
			buttons: [
				{
					text: "Close",
					handler: function(btn, e) {
						w.close();
					}
				}
			],
			items: [f]
		});

	w.show();
});