Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	name: "Sencha",
	
	launch: function() {
		if(window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		var
			red = {
				style: "background-color: #B22222; color: white;",
				title: "Red",
				html: "Red",
				listeners: {
					initialize: function(element,eOpts) {
						if(window.console && console.log)
							console.log("initialize(%o)", arguments);
					},
					painted: function(element,eOpts) {
						if(window.console && console.log)
							console.log("painted(%o)", arguments);
					},
					renderedchange: function(element, item, rendered, eOpts) {
						if(window.console && console.log)
							console.log("renderedchange(%o)", arguments);
					},
					show: function(element, eOpts) {
						if(window.console && console.log)
							console.log("show(%o)", arguments);
					}
				}
			},
			amber = {
				style: "background-color: #FFBF00; color: white;",
				title: "Amber",
				html: "Amber",
				listeners: {
					initialize: function(element,eOpts) {
						if(window.console && console.log)
							console.log("initialize(%o)", arguments);
					},
					painted: function(element,eOpts) {
						if(window.console && console.log)
							console.log("painted(%o)", arguments);
					},
					renderedchange: function(element, item, rendered, eOpts) {
						if(window.console && console.log)
							console.log("renderedchange(%o)", arguments);
					},
					show: function(element, eOpts) {
						if(window.console && console.log)
							console.log("show(%o)", arguments);
					}
				}
			},
			green = {
				style: "background-color: #3B7E00; color: white;",
				title: "Green",
				html: "Green",
				listeners: {
					initialize: function(element,eOpts) {
						if(window.console && console.log)
							console.log("initialize(%o)", arguments);
					},
					painted: function(element,eOpts) {
						if(window.console && console.log)
							console.log("painted(%o)", arguments);
					},
					renderedchange: function(element, item, rendered, eOpts) {
						if(window.console && console.log)
							console.log("renderedchange(%o)", arguments);
					},
					show: function(element, eOpts) {
						if(window.console && console.log)
							console.log("show(%o)", arguments);
					}
				}
			};
		
		Sencha.container = Ext.create("Ext.Container", {
			fullscreen: true,
			layout: {
				type: "card"
				//,animation: "cover",
				//,animation: "cube"
				//,animation: "fade"
				//,animation: "flip"
				//,animation: "pop"
				//,animation: "reveal"
				//,animation: "scroll"
				//,animation: "slide"
			},
			items: [ red, amber, green, 
			{
				xtype: "toolbar",
				docked: "top",
				items: [{
					text: "0",
					handler: function(btn) {
						Sencha.container.setActiveItem(parseInt(btn.getText(), 10));
					}
				}, {
					text: "1",
					handler: function(btn) {
						Sencha.container.setActiveItem(parseInt(btn.getText(), 10));
					}
				}, {
					text: "2",
					handler: function(btn) {
						Sencha.container.setActiveItem(parseInt(btn.getText(), 10));
					}
				}]
			}]
		});
	}
});