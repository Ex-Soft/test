Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
    Ext.QuickTips.init();

    Ext.Ajax.on("requestcomplete", function(conn, response, options){
		var
			msg = "Unknown server error",
			resp;

		if(response.responseText)
		{
			try
			{
				resp = Ext.decode(response.responseText);
			}
			catch(err)
			{
				msg=err.name+": Can't decode \""+response.responseText+"\" ("+err.message+")";
			}

			if(resp)
			{
				if(resp.success)
					return;

				if(!resp.IsAuthenticated)
				{
					msg = resp.IsInvalidUserOrPasswd && resp.message ? resp.message : "";
					LoginForm();
				}
				else if (resp.message)
					msg = resp.message;
			}
		}
		else if(response.isTimeout)
			msg="Time out: "+response.statusText;

		if(msg.length!=0)
			Ext.Msg.show({
				title: "Server Error",
				msg: msg,
				minWidth: 300,
				buttons: Ext.Msg.OK,
				icon: Ext.Msg.ERROR
			});
    });

	Ext.Ajax.on("requestexception", function(conn, response, options){
		if(Ext.isGecko && window.console)
			console.log("Ext.Ajax.onrequestexception: response.status=%i response.statusText=\"%s\"",response.status,response.statusText);
	});

	Ext.Ajax.request({
		url: "SmthHandler.aspx",
		method: "POST",
		success: function(result, request) {
			if(request)
				;
		}
	});

	/*
	var
		tb=new Ext.Toolbar({
			items: [{
				xtype: "button",
				text: "Form# 1",
				handler: function(btn, e){
					ShowForm1();
				}
			},
				"->"
			]
		}),
		viewport=new Ext.Viewport({
			layout: "fit",
			items: [tb]
		});
	*/
});
