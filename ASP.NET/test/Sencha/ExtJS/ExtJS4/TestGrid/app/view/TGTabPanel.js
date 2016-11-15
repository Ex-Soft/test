Ext.define("TG.view.TGTabPanel", {
    extend: "Ext.tab.Panel",
    alias: "widget.tgtabpanel",
    items: [
        {
            //title: "Tab# 1"
            xtype: "stafflist"
        }, {
            title: "Tab# 2"
            //xtype: "stafflist"
        }
    ]
});