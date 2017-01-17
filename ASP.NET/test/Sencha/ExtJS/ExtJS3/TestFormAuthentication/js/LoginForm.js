Ext.onReady(function () {
    Ext.BLANK_IMAGE_URL = "../ext3.4.1/resources/images/default/s.gif";

	Ext.QuickTips.init();

	var
		login = new Ext.FormPanel({
			labelWidth: 80,
			url: "LoginFormHandler.aspx",
			frame: true,
			title: "Please Login",
			defaultType: "textfield",
			monitorValid: true,
			items: [{
				fieldLabel: "Username",
				name: "loginUsername",
				allowBlank: false
			},{
				fieldLabel: "Password",
				name: "loginPassword",
				inputType: "password",
				allowBlank: false
			}],
			buttons: [{
				text: "Login",
				formBind: true,
				handler: function(){
					login.getForm().submit({
						method: "POST",
						waitTitle: "Connecting",
						waitMsg: "Sending data...",
						success: function(){
							Ext.Msg.alert("Status", "Login Successful!", function(btn, text){
								if (btn == "ok")
									window.location.href = "Default.aspx";
							});
						},
						failure: function(form, action){
							if(action.failureType == "server")
							{
								var
									obj = Ext.util.JSON.decode(action.response.responseText);

								Ext.Msg.alert("Login Failed!", obj.errors.reason);
							}
							else
							{
								Ext.Msg.alert("Warning!", "Authentication server is unreachable : " + action.response.responseText);
							}
							login.getForm().reset();
						}
					});
				}
			}]
		}),
		win = new Ext.Window({
			layout: "fit",
			width: 300,
			height: 150,
			closable: false,
			resizable: false,
			plain: true,
			border: false,
			items: [login]
		});

	win.show();
});