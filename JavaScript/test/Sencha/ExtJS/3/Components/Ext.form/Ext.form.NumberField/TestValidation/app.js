Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("App");

App.CustomNumberField = Ext.extend(Ext.form.NumberField, {
	validate: function () {
		if (window.console && console.log)
			console.log("CustomNumberField.validate(%o)", arguments);

		return App.CustomNumberField.superclass.validate.apply(this, arguments);
	},

	isValid: function () {
		if (window.console && console.log)
			console.log("CustomNumberField.isValid(%o)", arguments);

		return App.CustomNumberField.superclass.isValid.apply(this, arguments);
	},

	validateValue: function () {
		if (window.console && console.log)
			console.log("CustomNumberField.validateValue(%o)", arguments);

		return App.CustomNumberField.superclass.validateValue.apply(this, arguments);
	},

	getErrors: function () {
		if (window.console && console.log)
			console.log("CustomNumberField.getErrors(%o)", arguments);

		return App.CustomNumberField.superclass.getErrors.apply(this, arguments);
	}
});

Ext.reg("customnumberfield", App.CustomNumberField);

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		p = new Ext.Panel({
			items: [{
				xtype: "form",
				items: [{
					xtype: "customnumberfield",
					minValue: 10,
					maxValue: 20,
					validator: function(value) {
						if(window.console && console.log)
							console.log("CustomNumberField.validator(%o)", arguments);

						return true;
					}
				}]
			}],
			tbar: [{
				text: "isValid",
				handler: function (btn) {
					var panel,
						formPanels,
						form,
						numberFields,
						numberField;

					if (!(panel = btn.findParentByType("panel"))
						|| Ext.isEmpty(formPanels = panel.findByType("form"))
						|| !(form = formPanels[0].getForm())
						|| Ext.isEmpty(numberFields = formPanels[0].findByType("customnumberfield")))
						return;

					numberField = numberFields[0];

					if(window.console && console.log)
						console.log("NumberField.isValid()");
					numberField.isValid(); // isValid() -> validateValue() -> getErrors() -> validator()

					if(window.console && console.log)
						console.log("Form.isValid()");
					form.isValid(); // form.isValid() -> field.validate()-> field.validateValue() -> field.getErrors() -> field.validator()
				}
			}],
			renderTo: Ext.getBody()
		});
});
