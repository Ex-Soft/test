Ext.BLANK_IMAGE_URL = "../ext/resources/images/default/s.gif";

Ext.onReady(function() {
    Ext.QuickTips.init();

	var
		cbGenerateStatusCode=new Ext.form.Checkbox({
			boxLabel: "Generate StatusCode"
		}),
		tfStatusCode=new Ext.form.NumberField({
			allowDecimals: false,
			allowBlank: true
		}),
		cbWriteToResponse=new Ext.form.Checkbox({
			boxLabel: "Write to response"
		}),
		tb=new Ext.Toolbar({
			items: [{
				xtype: "button",
				text: "Form# 1",
				handler: function(btn, e){
					ShowForm(cbGenerateStatusCode, tfStatusCode, cbWriteToResponse);
				}
			},
				" ",
			{
				xtype: "button",
				text: "Form# 2",
				handler: function(btn, e){
					ShowForm(cbGenerateStatusCode, tfStatusCode, cbWriteToResponse);
				}
			},
				" ",
			{
				xtype: "button",
				text: "Grid# 1",
				handler: function(btn, e){
					ShowGrid(cbGenerateStatusCode, tfStatusCode, cbWriteToResponse);
				}
			},
				" ",
			{
				xtype: "button",
				text: "Grid# 2",
				handler: function(btn, e){
					ShowGrid(cbGenerateStatusCode, tfStatusCode, cbWriteToResponse);
				}
			},
				"->",
				cbGenerateStatusCode,
				" ",
				tfStatusCode,
				" ",
				cbWriteToResponse
			]
		}),
		viewport=new Ext.Viewport({
			layout: "fit",
			items: [tb]
		});

	Ext.Ajax.on("requestcomplete", function(conn, response, options){
		if(Ext.isGecko && window.console)
			console.log("Ext.Ajax.requestcomplete: response.status=%i response.statusText=\"%s\"",response.status,response.statusText);
	});

	Ext.Ajax.on("requestexception", function(conn, response, options){
		if(Ext.isGecko && window.console)
			console.log("Ext.Ajax.onrequestexception: response.status=%i response.statusText=\"%s\"",response.status,response.statusText);
	});
});
