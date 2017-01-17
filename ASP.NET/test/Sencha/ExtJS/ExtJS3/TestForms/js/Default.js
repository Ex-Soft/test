Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function () {
	Ext.QuickTips.init();

	var 
		ComboBoxStore1 = new Ext.data.Store({
			reader: new Ext.data.JsonReader({
				fields: ["ID", "VAL"],
				root: "rows"
			}),
			proxy: new Ext.data.HttpProxy({
				url: "DataSourceHandler.aspx"
			})
		}),
		ComboBoxStore2 = new Ext.data.Store({
			reader: new Ext.data.JsonReader({
				fields: ["ID", "VAL"],
				root: "rows"
			}),
			proxy: new Ext.data.HttpProxy({
				url: "DataSourceHandler.aspx"
			})
		}),
		ComboBoxStore3 = new Ext.data.Store({
			reader: new Ext.data.JsonReader({
				fields: ["ID", "VAL"],
				root: "rows"
			}),
			proxy: new Ext.data.HttpProxy({
				url: "DataSource2Handler.aspx"
			}),
			autoLoad: true,
			listeners: {
				load: function (s, r, o) {
					if (Ext.isGecko && window.console)
						console.log("ComboBoxStore3.load: records.length=%i", r.length);
				}
			}
		}),
		ComboBoxStore4 = new Ext.data.Store({
			reader: new Ext.data.JsonReader({
				fields: ["ID", "VAL"],
				root: "rows"
			}),
			proxy: new Ext.data.HttpProxy({
				url: "DataSource2Handler.aspx"
			}),
			autoLoad: true,
			listeners: {
				load: function (s, r, o) {
					if (Ext.isGecko && window.console)
						console.log("ComboBoxStore4.load: records.length=%i", r.length);
				}
			}
		}),
		DateTimeField = new Ext.ux.form.DateTime({
			fieldLabel: "Date & Time",
			name: "DateTimeField",
			hiddenFormat: "c", //"d.m.Y H:i:s",
			dateFormat: "d.m.Y",
			timeFormat: "H:i",
			timeConfig: {
				minValue: "09:00",
				maxValue: "18:00",
				increment: 5
			},
			otherToNow: false,
			emptyToNow: false
		}),
		HiddenField1 = new Ext.form.Hidden({
			name: "HiddenField1",
			value: -1
		}),
		TestForm = new Ext.FormPanel({
			url: "SaveFormHandler.aspx",
			renderTo: document.body,
			autoHeight: true,
			//autoWidth: true,
			width: 450,
			frame: true,
			title: "TestForm",
			items: [
				HiddenField1,
			{
				xtype: "numberfield",
				id: "NumberField",
				name: "NumberField",
				fieldLabel: "NumberField",
				allowDecimals: false,
				minValue: 0,
				maxValue: 999999,
				anchor: "100%"
			}, {
				xtype: "textfield",
				fieldLabel: "TextField",
				name: "TextField",
				allowBlank: false,
				vtype: "alpha",
				emptyText: "emptyText",
				listeners: {
					specialkey: function (f, e) {
						if (e.getKey() == e.ENTER) {
							TestForm.getForm().submit();
						}
					}
				}
			}, {
				xtype: "datefield",
				fieldLabel: "DateField",
				name: "DateField",
				allowBlank: false,
				format: "d.m.Y",
				editable: false
			}, {
				xtype: "timefield",
				fieldLabel: "TimeField",
				name: "TimeField",
				allowBlank: false,
				format: "H:i",
				minValue: "09:00",
				maxValue: "18:00",
				increment: 5
			},
				DateTimeField,
			{
				xtype: "radio",
				fieldLabel: "Radio",
				id: "Radio1",
				name: "Radio",
				inputValue: "Radio1",
				boxLabel: "Radio# 1"
			}, {
				xtype: "radio",
				hideLabel: false,
				labelSeparator: "",
				id: "Radio2",
				name: "Radio",
				inputValue: "Radio2",
				boxLabel: "Radio# 2"
			}, {
				xtype: "checkbox",
				fieldLabel: "CheckBox",
				id: "CheckBox",
				name: "CheckBox"
			}, {
				xtype: "combo",
				id: "ComboBox1",
				name: "ComboBox1",
				hiddenName: "ComboBox1HN",
				fieldLabel: "ComboBox1",
				store: ComboBoxStore1,
				valueField: "ID",
				displayField: "VAL",
				width: 240,
				emptyText: "Select a make...",
				loadingText: "Searching...",
				//forceSelection: true,
				//triggerAction: "all",
				//typeAhead: true,
				listeners: {
					select: function (f, r, i) {
						if (i == 0) {
							Ext.Msg.prompt("New Value", "Value", Ext.emptyFn);
						}
					},
					change: function (f, newValue, oldValue) {
						Ext.Msg.alert("OnChange", "\"" + oldValue + "\" -> \"" + newValue + "\"");
					}
				}
			}, {
				xtype: "combo",
				id: "ComboBox2",
				name: "ComboBox2",
				hiddenName: "ComboBox2HN",
				fieldLabel: "ComboBox2",
				store: ComboBoxStore2,
				valueField: "ID",
				displayField: "VAL",
				width: 240,
				emptyText: "Select a make...",
				loadingText: "Searching...",
				//forceSelection: true,
				//triggerAction: "all",
				//typeAhead: true,
				listeners: {
					select: function (f, r, i) {
						if (i == 0) {
							Ext.Msg.prompt("New Value", "Value", Ext.emptyFn);
						}
					},
					change: function (f, newValue, oldValue) {
						Ext.Msg.alert("OnChange", "\"" + oldValue + "\" -> \"" + newValue + "\"");
					}
				}
			}, {
				xtype: "combo",
				id: "ComboBox3",
				name: "ComboBox3",
				hiddenName: "ComboBox3HN",
				fieldLabel: "ComboBox3",
				store: ComboBoxStore3,
				valueField: "ID",
				displayField: "VAL",
				width: 240,
				emptyText: "Select a make...",
				loadingText: "Searching...",
				editable: false,
				mode: "local",
				forceSelection: true,
				triggerAction: "all",
				//typeAhead: true,
				//lazyInit: false,
				listeners: {
					select: function (f, r, i) {
						if (i == 0) {
							Ext.Msg.prompt("New Value", "Value", Ext.emptyFn);
						}
					},
					change: function (f, newValue, oldValue) {
						Ext.Msg.alert("OnChange", "\"" + oldValue + "\" -> \"" + newValue + "\"");
					}
				}
			}, {
				xtype: "combo",
				id: "ComboBox4",
				name: "ComboBox4",
				hiddenName: "ComboBox4HN",
				fieldLabel: "ComboBox4",
				store: ComboBoxStore4,
				valueField: "ID",
				displayField: "VAL",
				width: 240,
				emptyText: "Select a make...",
				loadingText: "Searching...",
				editable: false,
				mode: "local",
				forceSelection: true,
				triggerAction: "all",
				//typeAhead: true,
				listeners: {
					select: function (f, r, i) {
						if (i == 0) {
							Ext.Msg.prompt("New Value", "Value", Ext.emptyFn);
						}
					},
					change: function (f, newValue, oldValue) {
						Ext.Msg.alert("OnChange", "\"" + oldValue + "\" -> \"" + newValue + "\"");
					}
				}
			}, {
				xtype: "textarea",
				name: "TextArea",
				hideLabel: true,
				labelSeparator: "",
				height: 100,
				anchor: "100%"
			}, {
				xtype: "htmleditor",
				name: "HtmlEditor",
				hideLabel: true,
				labelSeparator: "",
				height: 100,
				anchor: "100%"
			}],
			buttons: [{
				text: "Save",
				handler: function () {
					TestForm.getForm().submit({
						success: function (f, a) {
							if (Ext.isGecko && window.console)
								console.log("submit().success");
						},
						failure: function (f, a) {
							if (Ext.isGecko && window.console)
								console.log("submit().failure");

							if (a.failureType === Ext.form.Action.CONNECT_FAILURE) {
								Ext.Msg.alert('Failure', 'Server reported: ' + a.response.status + ' ' + a.response.statusText);
							}

							if (a.failureType === Ext.form.Action.SERVER_INVALID) {
								Ext.Msg.alert('Warning', a.result.errormsg);
							}
						}
					});
				}
			}, {
				text: "Reset",
				handler: function () {
					TestForm.getForm().reset();
				}
			}, {
				text: "Load",
				handler: function () {
					TestForm.getForm().load({
						url: "LoadFormHandler.aspx",
						params: {
							id: 1
						},
						success: function (f, a) {
							if (Ext.isGecko && window.console)
								console.log("load().success");
						},
						failure: function (form, action) {
							if (Ext.isGecko && window.console)
								console.log("load().failure");
						}
					});
				}
			}, {
				text: "Check",
				handler: CheckCtrl
			}, {
				text: "DateTime",
				handler: function () {
					var 
						Ctrl,
						dt,
						tm,
						d;

					if (Ctrl = TestForm.getForm().findField("DateField")) {
						dt = Ctrl.getValue();

						if (Ext.isGecko && window.console)
							console.log("typeof() = %s, instanceof Date = %s, isDate() = %s", typeof (dt), dt instanceof Date, Ext.isDate(dt));
					}

					if (Ctrl = TestForm.getForm().findField("TimeField")) {
						tm = Ctrl.getValue();

						if (Ext.isGecko && window.console)
							console.log("typeof() = %s, instanceof Date = %s, isDate() = %s", typeof (tm), tm instanceof Date, Ext.isDate(tm));

						if (tm.length != 0) {
							d = Date.parseDate(tm, "H:i");

							if (Ext.isGecko && window.console)
								console.log("%s: typeof() = %s, instanceof Date = %s, isDate() = %s", d, typeof (d), d instanceof Date, Ext.isDate(d));
						}
					}

					if (Ext.isDate(dt) && Ext.isDate(d)) {
						dt.setHours(d.getHours());
						dt.setMinutes(d.getMinutes());

						if (Ext.isGecko && window.console)
							console.log("%s", dt);
					}

					dt = DateTimeField.getValue();
					if (Ext.isGecko && window.console)
						console.log("\"%s\" typeof() = %s, instanceof Date = %s, isDate() = %s", dt, typeof (dt), dt instanceof Date, Ext.isDate(dt));
				}
			}],
			listeners: {
				actioncomplete: function (form, action) {
					if (Ext.isGecko && window.console)
						console.log("Ext.form.FormPanel.listeners.actioncomplete");
				},
				actionfailed: function (form, action) {
					if (Ext.isGecko && window.console)
						console.log("Ext.form.FormPanel.listeners.actionfailed");
				}
			}
		});

	//TestForm.getForm().findField("DateField").setValue("01.01.2010");
});

function CheckCtrl()
{
	var
		Ctrl,
		CtrlName;

	if(Ctrl=document.getElementById(CtrlName="Radio1"))
		alert(CtrlName);
	if(Ctrl=document.getElementById(CtrlName="Radio2"))
		alert(CtrlName);
	if(Ctrl=document.getElementById(CtrlName="CheckBox"))
		alert(CtrlName);
		
	if(Ctrl=Ext.getCmp(CtrlName="Radio1"))
		alert(CtrlName);
	if(Ctrl=Ext.getCmp(CtrlName="Radio2"))
		alert(CtrlName);
	if(Ctrl=Ext.getCmp(CtrlName="CheckBox"))
		alert(CtrlName);

	if (Ctrl = Ext.getCmp(CtrlName = "ComboBox1")) {
		Ctrl = Ctrl.getValue();
		alert("\"" + Ctrl + "\"");
		alert("typeof()=\"" + typeof (Ctrl) + "\"");
	}

	if(Ctrl=Ext.getCmp(CtrlName="ComboBox3"))
		alert(CtrlName);

	if(Ctrl=Ext.getCmp(CtrlName="NumberField"))
	{
		Ctrl=Ctrl.getValue();
		alert("Ctrl"+(Ctrl==null ? "=" : "!")+"=null");
		alert("typeof()=\""+typeof(Ctrl)+"\"");
		alert("string.length="+Ctrl.length);
	}
}