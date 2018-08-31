Ext.BLANK_IMAGE_URL="../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3.3.1/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		form = new Ext.FormPanel({
			title: "FormPanel Title",
			items: [{
				xtype: "fieldset",
				title: "FieldSet Title",
				checkboxToggle: true,
				defaultType: "textfield",
				items: [{
					fieldLabel: "Field# 1"
				}],
				listeners: {
					render: function (fieldSet) {
						if (window.console && console.log)
							console.log("render(%o)", arguments);

						var checkbox;

						if (!(checkbox = fieldSet.checkbox))
							return;

						checkbox.on("change", function (e, el, eOpt) {
							if (window.console && console.log)
								console.log("change(%o) checked = %o", arguments, el.checked);
						});
					}
				}
			}],
			renderTo: Ext.getBody(),
			onCheckClick: function () {
				if (window.console && console.log)
					console.log("onCheckClick(%o)", arguments);
			}
		}),
		toolBar = new Ext.Toolbar({
			items: [{
				text: "Enable",
				handler: function () {
					form.items.items[0].setDisabled(false);
				}
			}, {
				text: "Disable",
				handler: function () {
					form.items.items[0].setDisabled(true);
				}
			}, {
				text: "Click",
				handler: function () {
					var checkbox = form.items.items[0].checkbox;
					checkbox.dom.click();
				}
			}, {
				text: "Checked",
				handler: function () {
					var checkbox = form.items.items[0].checkbox;
					checkbox.dom.checked = !checkbox.dom.checked;
					checkbox.dom.defaultChecked = checkbox.dom.checked;
				}
			}, {
				text: "setAttribute",
				handler: function () {
					var
						checkbox = form.items.items[0].checkbox,
						checked = checkbox.dom.getAttribute("checked");

					if (checked)
						checkbox.dom.removeAttribute("checked");
					else
						checkbox.dom.setAttribute("checked", "checked");
				}
			}],
			renderTo: Ext.getBody()
		});
});

