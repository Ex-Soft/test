Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.onReady(function () {
    Ext.QuickTips.init();

    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    var 
		fieldFile = Ext.create("Ext.form.field.File", {
		    name: "document",
		    allowBlank: false,
		    fieldLabel: "File",
		    anchor: "100%"
		}),
		fieldHidden1 = Ext.create("Ext.form.field.Hidden", {
		    name: "hidden1",
		    value: "hidden1"
		}),
		fieldHidden2 = Ext.create("Ext.form.field.Hidden", {
		    name: "hidden2",
		    value: "hidden2"
		}),
		form = Ext.create("Ext.form.Panel", {
		    frame: true,
		    method: "POST",
		    url: "fileupload.aspx?param=param",
		    items: [
				fieldFile,
				fieldHidden1,
				fieldHidden2
			],
		    waitTitle: "Please Wait...",
            waitMsgTarget: true,
		    listeners: {
		        actioncomplete: function (form, action, eOpts) {
		            if (window.console && console.log)
		                console.log("actioncomplete(%o)", arguments);
		        },
		        actionfailed: function (form, action, eOpts) {
		            if (window.console && console.log)
		                console.log("actionfailed(%o)", arguments);
		        }
		    }
		});

    w = Ext.create("Ext.window.Window", {
        autoShow: true,
        title: "Test File",
        border: 0,
        layout: "fit",
        modal: true,
        items: [form],
        buttons: [{
            text: "Watch",
            handler: function (btn, e) {
                var 
					w = btn.up("window");

                if (window.console && console.log)
                    console.log("typeof window.form = \"%s\"", typeof w.form);
            }
        }, {
            text: "Submit",
            handler: function (btn, e) {
                var 
					form = btn.up("window").down("form").getForm();

                if (!form.isValid())
                    return;

                form.submit({
                    params: {
                        param1: "param1",
                        param2: "param2"
                    },
                    waitMsg: "Uploading...",
                    success: function (form, action) {
                        if (window.console && console.log)
                            console.log("success(%o)", arguments);
                    },
                    failure: function (form, action) {
                        if (window.console && console.log)
                            console.log("failure(%o)", arguments);
                    }
                });
            }
        }, {
            text: "Close",
            handler: function (btn, e) {
                var 
					w = btn.up("window");

                w.close();
            }
        }]
    });
});