Ext.define("DbView.view.main.Main", {
    extend: "Ext.container.Viewport",
    xtype: "app-main",

    requires: [
        "DbView.view.main.MainController",
        "DbView.ux.classic.grid.AutoReconfigurePanel",
        "DbView.ux.classic.tab.GridsPanel"
    ],

    controller: "main",

    layout: "border",

    items: [{
        region: "west",
        width: "20%",
        collapsible: true,
        split: true,
        xtype: "autoreconfiguregrid",
        reference: "navigationgrid",
        title: "Tables",
        url: "api/navigation",
        listeners: {
            rowclick: "onTableRowClick"
        }
    }, {
        region: "center",
        xtype: "gridstabpanel",
        reference: "gridstabpanel",
        tabPosition: "bottom"
    }]
});
