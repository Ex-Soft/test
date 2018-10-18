Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		viewport = new Ext.Viewport({
			layout: "border",
			items: [{
				region: "west",
				width: 200,
                xtype: "panel",
                tbar: [{
                    text: "addListener",
                    handler: function (btn) {
                        var panel = btn.ownerCt.ownerCt;

                        if (panel.isOnWindowResizeAdded)
                            return;

                        Ext.EventManager.onWindowResize(panel.onWindowResize, panel);
                        panel.isOnWindowResizeAdded = true;
                    }
                }, {
                    text: "removeListener",
                    handler: function (btn) {
                        var panel = btn.ownerCt.ownerCt;

                        if (!panel.isOnWindowResizeAdded)
                            return;

                        Ext.EventManager.removeResizeListener(panel.onWindowResize, panel);
                        panel.isOnWindowResizeAdded = false;
                    }
                }],
                onWindowResize: function () {
                    if (window.console && console.log)
                        console.log("panel[\"west\"].onWindowResize(%o)", arguments);
                }
			},{
				region: "center",
				xtype: "panel",
                tbar: [{
                    text: "addListener",
                    handler: function (btn) {
                        var panel = btn.ownerCt.ownerCt;

                        if (panel.isOnWindowResizeAdded)
                            return;

                        Ext.EventManager.onWindowResize(panel.onWindowResize, panel);
                        panel.isOnWindowResizeAdded = true;
                    }
                }, {
                    text: "removeListener",
                    handler: function (btn) {
                        var panel = btn.ownerCt.ownerCt;

                        if (!panel.isOnWindowResizeAdded)
                            return;

                        Ext.EventManager.removeResizeListener(panel.onWindowResize, panel);
                        panel.isOnWindowResizeAdded = false;
                    }
                }],
                onWindowResize: function () {
                    if (window.console && console.log)
                        console.log("panel[\"center\"].onWindowResize(%o)", arguments);
                }
			}]
		});
});
