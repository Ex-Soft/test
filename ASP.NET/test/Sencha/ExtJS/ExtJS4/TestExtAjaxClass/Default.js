Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.onReady(function () {
    var 
        cbIsAsync = Ext.create("Ext.form.field.Checkbox", {
            fieldLabel: "async",
            checked: true,
            renderTo: Ext.getBody()
        }),
        nfSleep = Ext.create("Ext.form.field.Number", {
            fieldLabel: "Sleep (msec)",
            allowDecimals: false,
            hideTrigger: true,
            minValue: 0,
            value: 5000,
            renderTo: Ext.getBody()
        }),
        cbMethod = Ext.create("Ext.form.field.ComboBox", {
            store: Ext.create("Ext.data.ArrayStore", {
                fields: [ "name" ],
                data: [
                    ["DELETE"],
                    ["GET"],
                    ["POST"],
                    ["PUT"]
                ]
            }),
            fieldLabel: "method",
            displayField: "name",
            valueField: "name",
            queryMode: "local",
            editable: false,
            value: "POST",
            renderTo: Ext.getBody()
        }),
        doExtAjaxRequest = function () {
            var 
                name4request = "Ext.Ajax.request",
                name4response = "response",
                isAsync = cbIsAsync.getValue(),
                sleep = nfSleep.getValue();

            if (window.console) {
                if (console.log)
                    console.log("Ext.Ajax.request() started...");
                if (console.time) {
                    console.time(name4request);
                    console.time(name4response);
                }
            }

            Ext.Ajax.request({
                url: "SmthHandler.aspx?getparam1=getparam1&getparam2=getparam2",
                method: cbMethod.getValue(),
                headers: { MyHeader: "MyHeaderValue" },
                urlParams: "getparam3=getparam3",
                params: { params: " params ", async: isAsync, sleep: sleep },
                //jsonData: { jsonData: "json Data" },
                jsonData: "ПрЫвЭт!!!",
                //disableCaching: false,
                async: isAsync,
                success: function (response, opts) {
                    if (window.console) {
                        if (console.log)
                            console.log("Ext.Ajax.request().success()");
                        if (console.timeEnd)
                            console.timeEnd(name4response);
                    }
                },
                failure: function (response, opts) {
                    if (window.console) {
                        if (console.log)
                            console.log("Ext.Ajax.request().failure()");
                        if (console.timeEnd)
                            console.timeEnd(name4response);
                    }
                }
            });

            if (window.console) {
                if (console.log)
                    console.log("Ext.Ajax.request() finished");
                if (console.timeEnd)
                    console.timeEnd(name4request);
            }
        },
        btnExtAjaxRequest = Ext.create("Ext.button.Button", {
            text: "Ext.Ajax.request()",
            renderTo: Ext.getBody(),
            handler: doExtAjaxRequest
        });

    Ext.Ajax.disableCaching = false;
    Ext.Ajax.extraParams = { extraParams: " extraParams " };
});