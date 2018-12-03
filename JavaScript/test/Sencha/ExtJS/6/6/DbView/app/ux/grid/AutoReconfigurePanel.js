Ext.define("DbView.ux.grid.AutoReconfigurePanel", {
    extend: "Ext.grid.Panel",
    alias: ["widget.autoreconfiguregridpanel", "widget.autoreconfiguregrid"],
    
    requires: [
        "DbView.ux.data.AutoReconfigureJsonStore"
    ],

    config: {
        url: undefined
    },

    constructor: function (config) {
        this.columns = [];

        config = Ext.apply({
            store: {
                type: "autoreconfigurejson"
            }
        }, config);

        this.callParent([config]);

        return this;
    },

    initComponent: function () {
        var url;

        if (this.store && Ext.isEmpty(this.store.url) && !Ext.isEmpty(url = this.getUrl()))
            this.store.url = url + ".json";

        this.callParent();
       
        this.getStore().on("metachange", this.doReconfigure, this);
    },

    doReconfigure: function (store, meta) {
        this.reconfigure(store, meta.columns);
    }
});