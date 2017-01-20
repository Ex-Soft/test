Ext.onReady(function() {
	Ext.create("Ext.panel.Panel", {
		height: 300,
		width: 300,
		//autoLoad: {		},
		loader: {
			autoLoad: false,
			url: "content.html",
			listeners: {
				beforeload: function(loader, options, eOpts) {
					if(window.console && console.log)
						console.log("Ext.ComponentLoader.beforeload(%o)", arguments);

					loader.target.getLoadMask().show();
				},
				exception: function(loader, response, options, eOpts) {
					if(window.console && console.log)
						console.log("Ext.ComponentLoader.exception(%o)", arguments);
				},
				load: function(loader, response, options, eOpts) {
					if(window.console && console.log)
						console.log("Ext.ComponentLoader.load(%o)", arguments);

					loader.target.getLoadMask().hide();
				}
			}
		},
		listeners: {
			afterrender: function(panel, eOpts) {
				panel.getLoader().load();
			}
		},
		renderTo: Ext.getBody(),

		getLoadMask: function() {
			if(!this.lm)
				this.lm = new Ext.LoadMask(this.getEl());

			return this.lm;
		}
	});
});