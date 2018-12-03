Ext.define("DbView.ux.core.data.AutoReconfigureJsonStore", {
    extend: "Ext.data.JsonStore",
    alias : "store.autoreconfigurejson",

    autoLoad: true,
    remoteSort: true,
    remoteFilter: true,

    needMetadataExtraParamName: "needMetadata",

    constructor: function (config) {
        var me = this;

        config = Ext.apply({
            proxy: {
                type: "ajax",
                reader: "json",
                writer: "json"
            }
        }, config);

        if (!Ext.isEmpty(config.url))
            config.proxy.url = config.url;

        me.callParent([config]);

        if (!Ext.isEmpty(me.needMetadataExtraParamName)) {
            me.on("beforeload", me.patchExtraParams, me);
            me.on("metachange", me.onMetadataChange, me);
        }

        return me;
    },

    onMetadataChange: function (store, meta) {
        store.configured = true;
        delete store.getProxy().getExtraParams()[store.needMetadataExtraParamName];
        store.un("beforeload", store.patchExtraParams, store);
        store.un("metachange", store.onMetadataChange, store);
    },

    patchExtraParams: function (store, operation, eOpts) {
        var me = this,
            extraparams = store.getProxy().getExtraParams();

        if (Ext.isEmpty(me.needMetadataExtraParamName))
            return;

        if (me.configured) {
            delete extraparams[me.needMetadataExtraParamName];
            me.un("beforeload", me.patchExtraParams, me);
            me.un("metachange", me.onMetadataChange, me);
        }
        else
            extraparams[me.needMetadataExtraParamName] = true;
    }
});
