Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestPanel",{
    extend: "Ext.panel.Panel",
    alias: "widget.testpanel",

    tbar: [{
        text: "addListener",
        handler: function (btn) {
            var panel = btn.up("panel");

            if (panel.isOnWindowResizeAdded)
                return;

            Ext.EventManager.onWindowResize(panel.onWindowResize, panel);
            panel.isOnWindowResizeAdded = true;
        }
    }, {
        text: "removeListener",
        handler: function (btn) {
            var panel = btn.up("panel");

            if (!panel.isOnWindowResizeAdded)
                return;

            Ext.EventManager.removeResizeListener(panel.onWindowResize, panel);
            panel.isOnWindowResizeAdded = false;
        }
    }],
    onWindowResize: function () {
        if (window.console && console.log)
            console.log("panel[\"%s\"].onWindowResize(%o)", this.region, arguments);
    }
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

    if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		viewport = new Ext.Viewport({
			layout: "border",
			items: [{
				region: "west",
				width: 200,
                xtype: "testpanel"
			},{
				region: "center",
				xtype: "testpanel"
			}]
		});
});
