Ext.define("DbView.view.main.Main", {
    extend: "Ext.container.Viewport",
    xtype: "app-main",

    requires: [
        "DbView.view.main.MainController",
        "DbView.ux.grid.NavigatePanel",
        "DbView.ux.tab.GridsPanel"
    ],

    controller: "main",

    layout: "border",

    items: [{
        region: "west",
        width: "20%",
        collapsible: true,
        split: true,
        xtype: "navigategrid",
        reference: "navigategrid",
        title: "Tables",
        url: "data/tables",
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
