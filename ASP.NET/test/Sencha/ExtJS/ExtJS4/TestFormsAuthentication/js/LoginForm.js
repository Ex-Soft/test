Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    Ext.Ajax.on("requestexception", function (connection, response, options, eOpts) {
        var 
            resp;

        if (response.status == 403 || response.status == 302) {
            alert(response.status);
            //M3.core.M3App.fireEvent("loginNeed", options);
            return;
        }

        if (response.responseText) {
            try {
                resp = Ext.JSON.decode(response.responseText);
            }
            catch (err) {
                msg = { errMsg: Ext.String.format("{0}: {1} \"{2}\" ({3})", err.name, M3.core.M3Locale.getLocaleString("nevozmozhnoDecodirovat"), response.responseText, err.message) };
            }

            if (resp)
                msg = { errCode: resp.errCode, errMsg: resp.errMsg };
        }
        else if (response.timedout)
            msg = { errMsg: M3.core.M3Locale.getLocaleString("serverVremennoNedostupen") };

        Ext.create("M3.view.ErrorWindow", msg);
    });

    var 
        textFieldLogin = Ext.create("Ext.form.field.Text", {
            allowBlank: false,
            blankText: "Required field",
            fieldLabel: "Login",
            anchor: "100%",
            value: "login"
        }),
        textFieldPassword = Ext.create("Ext.form.field.Text", {
            allowBlank: false,
            blankText: "Required field",
            inputType: "password",
            fieldLabel: "Password",
            anchor: "100%"
        }),
        form = Ext.create("Ext.form.Panel", {
            baseCls: "x-plain",
            labelWidth: 80,
            bodyStyle: "padding: 5px;",
            items: [
                textFieldLogin,
                textFieldPassword
            ]
        }),
        loginWindow = Ext.create("Ext.window.Window", {
            title: "Login",
            autoShow: true,
            layout: "anchor",
            width: 300,
            height: 180,
            plain: true,
            modal: true,
            closable: false,
            resizable: false,
            items: [form],
            buttons: [{
                text: "Login",
                handler: function (btn, e, eOpts) {
                    Ext.Ajax.request({
                        url: "LoginFormHandler.aspx",
                        method: "POST",
                        params:
                        {
                            login: textFieldLogin.getValue(),
                            password: textFieldPassword.getValue()
                        }
                    });
                }
            }]
        });
});