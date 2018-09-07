Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		animator = Ext.create("Ext.fx.Animator", {
			target: "ball",
			duration: 5000,
			keyframes: {
				0: {
					y: 50,
					opacity: 1,
					backgroundColor: "FF0000"
				},
				20: {
					y: 300,
					x: 30,
					opacity: 0.5
				},
				40: {
					y: 175,
					x: 130,
					backgroundColor: "0000FF"
				},
				60: {
					y: 80,
					opacity: 0.3
				},
				80: {
					width: 200,
					y: 200
				},
				100: {
					y: 300,
					opacity: 1,
					backgroundColor: "00FF00"
				}
			},
			listeners: {
				afteranimate: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("Ext.fx.Animator.afteranimate(%o)", arguments);
				},
				beforeanimate: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("Ext.fx.Animator.beforeanimate(%o)", arguments);
				},
				keyframe: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("Ext.fx.Animator.keyframe(%o)", arguments);
				}
			}
		});
});
