Ext.define('AM.view.Viewport', {
    extend: 'Ext.container.Viewport',
    layout: 'fit',
    requires: ["AM.view.MainToolbar"],
    items: [
                {
                    tbar: { xtype: "maintoolbar" },
                    xtype: 'userlist'
                }
            ]
});