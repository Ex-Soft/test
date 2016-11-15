Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.define("Staff", {
    extend: "Ext.data.Model",
    idProperty: "id",
    fields: [
        { name: "id", type: "int" },
        { name: "name" }
    ]
});

Ext.onReady(function () {
    Ext.QuickTips.init();

    var 
        formPanel1 = Ext.create("Ext.form.Panel", {
            title: "Form# 1",
            frame: true,
            url: "Form1.aspx",
            trackResetOnLoad: true,
            items: [{
                xtype: "textfield",
                fieldLabel: "TextField",
                name: "TextField",
            }, {
                xtype: "combobox",
                store: Ext.create("Ext.data.JsonStore", {
                    model: "Staff",
                    proxy: {
                        type: "ajax",
                        url: "Staff.aspx",
                        reader: {
                            type: "json",
                            root: "rows",
                            idProperty: "id",
                            totalProperty: "total",
                            successProperty: "success",
                            messageProperty: "message"
                        }
                    }
                }),
                fieldLabel: "ComboBox (remote)",
                valueField: "id",
                displayField: "name",
                //queryMode: "remote",
                editable: true,
                typeAhead: true,
                forceSelection: true,
                valueNotFoundText: "blah-blah-blah"
            }],
            buttons: [{
                text: "Test",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm(),
                        fields = form.getFields(),
                        values = form.getValues(),
                        fieldValues = form.getFieldValues(),
                        textField = form.findField("TextField"),
                        isFormDirty = form.isDirty(),
                        isTextFieldDirty = textField.isDirty();

                    if (window.console && console.log)
                        console.log("isTextFieldDirty = %s", isTextFieldDirty);
                }
            }, {
                text: "setValue",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm(),
                        textField = form.findField("TextField"),
                        isFormDirty = form.isDirty(),
                        isTextFieldDirty = textField.isDirty(),
                        values = {
                            TextField: "blah-blah-blah"
                        };

                    form.setValues(values);
                    //textField.setValue("blah-blah-blah");
                    //textField.resetOriginalValue();

                    isTextFieldDirty = textField.isDirty();
                    isFormDirty = form.isDirty();

                    if (window.console && console.log)
                        console.log("isTextFieldDirty = %s", isTextFieldDirty);
                }
            }, {
                text: "Reset",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm();

                    form.reset();
                }
            }, {
                text: "Load",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm();

                    form.load({
                        params: {
                            xaction: "load"
                        },
                        success: function (form, action) {
                            if (window.console && console.log)
                                console.log("load.success(%o)", arguments);
                        },
                        failure: function (form, action) {
                            if (window.console && console.log)
                                console.log("load.failure(%o)", arguments);
                        }
                    });
                }
            }, {
                text: "Submit",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm(),
                        fields = form.getFields(),
                        values = form.getValues();

                    if (window.console && console.log) {
                        console.log("isDirty() = %s", form.isDirty());
                    }
                }
            }],
            listeners: {
                actioncomplete: function (form, action, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.form.FormPanel.actioncomplete(%o)", arguments);
                },
                actionfailed: function (form, action, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.form.FormPanel.actionfailed(%o)", arguments);
                }
            }
        }),
        store = Ext.create("Ext.data.Store", {
            model: "Staff",
            proxy: {
                type: "ajax",
                url: "Staff.aspx",
                reader: {
                    type: "json",
                    root: "rows",
                    idProperty: "id",
                    totalProperty: "total",
                    successProperty: "success",
                    messageProperty: "message"
                }
            },
            autoLoad: true
        }),
        grid = Ext.create("Ext.grid.Panel", {
            columnWidth: 0.6,
            store: store,
            columns: [
                { dataIndex: "id", header: "id" },
                { dataIndex: "name", header: "name" }
            ],
            listeners: {
                selectionchange: function (model, records) {
                    if (records[0]) {
                        this.up("form").getForm().loadRecord(records[0]);
                    }
                }
            }
        }),
        formPanel2 = Ext.create("Ext.form.Panel", {
            title: "Form# 2",
            frame: true,
            layout: "column",
            trackResetOnLoad: true,
            items: [
                grid,
            {
                columnWidth: 0.4,
                xtype: "fieldset",
                items: [{
                    xtype: "numberfield",
                    fieldLabel: "id",
                    name: "id",
                    hideTrigger: true,
                    allowDecimals: false
                }, {
                    xtype: "textfield",
                    fieldLabel: "name",
                    name: "name"
                }]
            }],
            buttons: [{
                text: "Test",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm(),
                        fields = form.getFields(),
                        values = form.getValues(),
                        textField = form.findField("name"),
                        isFormDirty = form.isDirty(),
                        isTextFieldDirty = textField.isDirty();

                    if (window.console && console.log)
                        console.log("isTextFieldDirty = %s", isTextFieldDirty);
                }
            }, {
                text: "setValue",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm(),
                        textField = form.findField("name"),
                        isFormDirty = form.isDirty(),
                        isTextFieldDirty = textField.isDirty();

                    textField.setValue("blah-blah-blah");
                    textField.resetOriginalValue();

                    isTextFieldDirty = textField.isDirty();
                    isFormDirty = form.isDirty();

                    if (window.console && console.log)
                        console.log("isTextFieldDirty = %s", isTextFieldDirty);
                }
            }, {
                text: "Reset",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm();

                    form.reset();
                }
            }, {
                text: "updateRecord",
                handler: function (btn, e) {
                    var 
                        formPanel = this.up("form"),
                        form = formPanel.getForm(),
                        rec = form.getRecord();

                    form.updateRecord(rec);
                    rec.commit();
                }
            }],
            listeners: {
                actioncomplete: function (form, action, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.form.FormPanel.actioncomplete(%o)", arguments);
                },
                actionfailed: function (form, action, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.form.FormPanel.actionfailed(%o)", arguments);
                },
                dirtychange: function (form, dirty, eOpts) {
                    if (window.console && console.log)
                        console.log("Ext.form.FormPanel.dirtychange(%o)", arguments);
                }
            }
        });

    Ext.create("Ext.tab.Panel", {
        items: [formPanel1, formPanel2],
        renderTo: Ext.getBody()
    });
});