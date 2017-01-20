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
		fieldCheckbox = Ext.create("Ext.form.field.Checkbox", {
			name: "fieldCheckbox",
			fieldLabel: "Checkbox",
			uncheckedValue: "xyj"
		}),
		form = Ext.create("Ext.form.Panel", {
			frame: true,
			method: "POST",
			url: "Test.aspx?param=param",
			items: [
				fieldCheckbox
			]
		});

	Ext.create("Ext.window.Window", {
		autoShow: true,
		autoDestroy: true,
		title: "Test isDirty",
		border: 0,
		layout: "fit",
		modal: true,
		height: 300,
		width: 300,
		items: [form],
		buttons: [{
			text: "Watch",
			handler: function(btn, e) {
				var
					w = btn.up("window");

				if(window.console && console.log)
					console.log("typeof window.form = \"%s\"", typeof w.form);
			}
		}, {
			text: "Submit",
			handler: function(btn, e) {
				var
					form = btn.up("window").down("form").getForm(),
					fields,
					isDirty,
					values,
					fieldValues;

				if(!form.isValid())
					return;

				fields = form.getFields();
				isDirty = form.isDirty();
				values = form.getValues();
				fieldValues = form.getFieldValues();
				isDirty = fieldCheckbox.isDirty();

				//form.submit();

				if(this)
					;
			}
		}, {
			text: "Close",
			handler: function(btn, e) {
				var
					w = btn.up("window");

				w.close();
			}
		}]
	});
});