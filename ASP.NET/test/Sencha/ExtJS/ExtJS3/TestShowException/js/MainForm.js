Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
    Ext.QuickTips.init();

	Ext.Ajax.on("requestexception", function(conn, response, options) {
		if(Ext.isGecko && window.console)
			console.log("Ext.Ajax.requestexception: arguments.length=%i", arguments.length);

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

			if(resp && resp.message)
				msg = resp.message;
		}
		else if(response.isTimeout)
			msg="Time out: "+response.statusText;

		Ext.Msg.show({
			title: "Error",
			msg: msg,
			minWidth: 300,
			buttons: Ext.Msg.OK,
			icon: Ext.Msg.ERROR
		});
	});

	var
		tb=new Ext.Toolbar({
			items: [{
				xtype: "button",
				text: "Get Exception",
				handler: function(btn, e){
					Ext.Ajax.request({
						url: "ExceptionSource.aspx",
						method: "POST",
						success: function(response, opts){
							if(Ext.isGecko && window.console)
								console.log("Ext.Ajax.request.success: arguments.length=%i", arguments.length);
						},
						failure: function(response, opts){
							if(Ext.isGecko && window.console)
								console.log("Ext.Ajax.request.failure: arguments.length=%i", arguments.length);
						},
						callback: function(options, success, response){
							if(Ext.isGecko && window.console)
								console.log("Ext.Ajax.request.callback: arguments.length=%i", arguments.length);
						}						
					});
				}
			},
				"->"
			]
		}),
		viewport=new Ext.Viewport({
			layout: "fit",
			items: [tb]
		});
});
