function ShowForm(cbGenerateStatusCode, tfStatusCode, cbWriteToResponse)
{
	var
		f = new Ext.form.FormPanel({
			region: "center",
			url: "FormHandler.aspx",
			frame: true,
			items: [{
				xtype: "textfield",
				name: "TextField",
				fieldLabel: "TextField",
				allowBlank: true
			}],
			buttons: [{
				text: "load",
				handler: function(btn, e){
					f.getForm().load({
						params: {
							type: "load",
							GenerateStatusCode: cbGenerateStatusCode.getValue(),
							StatusCode: tfStatusCode.getValue(),
							WriteToResponse: cbWriteToResponse.getValue()
						},
						waitMsg: "loading..."
					});
				}
			}, {
				text: "submit",
				handler: function(btn, e){
					f.getForm().submit({
						params: {
							type: "submit",
							GenerateStatusCode: cbGenerateStatusCode.getValue(),
							StatusCode: tfStatusCode.getValue(),
							WriteToResponse: cbWriteToResponse.getValue()
						},
						waitMsg: "submitting..."
					});
				}
			}, {
				text: "reset",
				handler: function(btn, e){
					f.getForm().reset();
				}
			}],
			listeners: {
				actioncomplete: function(form, action){
					if(window.console)
						console.log("Ext.form.FormPanel.listeners.actioncomplete: action.response.status=%i action.response.statusText=\"%s\"",action.response.status,action.response.statusText);
				},
				actionfailed: function(form, action){
					if(window.console)
						console.log("Ext.form.FormPanel.listeners.actionfailed: action.response.status=%i action.response.statusText=\"%s\"",action.response.status,action.response.statusText);
				}
			}
		}),
		w = new Ext.Window({
			layout: "border",
			title: "Form",
			height: 300,
			width: 300,
			items: [f]
		});

	w.show();
}
