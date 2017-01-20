Ext.onReady(function() {
	var
		UserInfo={
			Name: "Name",
			Login: "Login",
		},
		PanelCenter=new Ext.Panel({
			region: "center",
			html: "center"
		}),
		tpl=new Ext.XTemplate(
			"<span>{Name}</span>",
			"<span>{Login}</span>"
		),
		viewport=new Ext.Viewport({
			layout: "border",
			border: false,
			renderTo: Ext.getBody(),
			items: [ PanelCenter ]
		});

		tpl.overwrite(PanelCenter.body, UserInfo);
});