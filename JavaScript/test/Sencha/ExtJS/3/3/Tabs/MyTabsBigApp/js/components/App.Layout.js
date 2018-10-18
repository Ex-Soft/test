Ext.ns("App.Components");
Ext.ns("App.Layout");

App.Components.NorthPanel = Ext.extend(Ext.Panel, {
    constructor: function(c) {
        var d = {
            region: "north",
            height: 25,
            html: "NorthPanel",
            border: false
        };

        App.Components.NorthPanel.superclass.constructor.call(this, Ext.apply(d, c));
    }
});

App.Components.CenterPanel = Ext.extend(Ext.Panel, {
	initComponent: function(){
		var
			config = {
				region: "center",
				layout: "border",
				border: false,
				items: [new App.Components.MainPanel()]
			};

		Ext.apply(this, Ext.apply(this.initialConfig, config));
		App.Components.CenterPanel.superclass.initComponent.apply(this, arguments);
	}
});

App.Components.Layout = Ext.extend(Ext.Viewport, {
	initComponent: function(){
		var
			header = new App.Components.NorthPanel(),
			center = new App.Components.CenterPanel(),
			config = {
				region: "center",
				layout: "border",
				border: false,
				Header: header,
				Center: center,
				items: [header, center]
			};

		Ext.apply(this, Ext.apply(this.initialConfig, config));
		App.Components.Layout.superclass.initComponent.apply(this, arguments);
	}
});
