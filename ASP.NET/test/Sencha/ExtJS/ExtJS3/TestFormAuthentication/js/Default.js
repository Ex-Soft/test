Ext.onReady(function () {
    Ext.BLANK_IMAGE_URL = "../ext3.4.1/resources/images/default/s.gif";

	Ext.QuickTips.init();

	var
		f = new Ext.form.FormPanel({
			url: "DefaultFormHandler.aspx",
			renderTo: Ext.getBody(),
			frame: true,
			items: [{
				xtype: "checkbox",
				id: "CheckBoxGenerateStatusCode",
				name: "CheckBoxGenerateStatusCode",
				fieldLabel: "Generate StatusCode"
			}, {
				xtype: "textfield",
				id: "TextFieldStatusCode",
				name: "TextFieldStatusCode",
				fieldLabel: "StatusCode",
				allowBlank: true
			}, {
				xtype: "checkbox",
				id: "CheckBoxWriteToResponse",
				name: "CheckBoxWriteToResponse",
				fieldLabel: "Write to response"
			}],
			buttons: [{
				text: "submit",
				handler: function(btn, e){
					f.getForm().submit({
						success: function(form, action){
							if(Ext.isGecko && ("console" in window))
								console.log("Ext.form.FormPanel.getForm().submit().success");
						},
						failure: function(form, action){
							if(Ext.isGecko && ("console" in window))
								console.log("Ext.form.FormPanel.getForm().submit().failure");

							switch(action.failureType)
							{
								case Ext.form.Action.CLIENT_INVALID:
								{
									Ext.Msg.alert("Failure", "Form fields may not be submitted with invalid values");
									break;
								}
								case Ext.form.Action.CONNECT_FAILURE:
								{
									if(Ext.isGecko && ("console" in window))
									{
										console.log("action.failureType==Ext.form.Action.CONNECT_FAILURE");
										console.log("Failure: Ajax communication failed");
										console.log("action.response.status=%i",action.response.status);
										console.log("action.response.statusText=%s",action.response.statusText);
									}
									break;
								}
								case Ext.form.Action.SERVER_INVALID:
								{
									Ext.Msg.alert("Failure", action.result.msg);
									break;
								}
							}
						}
					});
				}
			}, {
				text: "reset",
				handler: function(btn, e){
					f.getForm.reset();
				}
			}],
			listeners: {
				actioncomplete: function(form, action){
					if(Ext.isGecko && ("console" in window))
						console.log("Ext.form.FormPanel.listeners.actioncomplete");
				},
				actionfailed: function(form, action){
					if(Ext.isGecko && ("console" in window))
					{
						console.log("Ext.form.FormPanel.listeners.actioncomplete");
						console.log("action.failureType==%s",action.failureType);
						console.log("action.response.status=%i",action.response.status);
						console.log("action.response.statusText=%s",action.response.statusText);
					}
				}
			}
		});
});