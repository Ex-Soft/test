Ext.define("DbView.ux.data.AutoReconfigureJsonStore", {
    extend: "Ext.data.JsonStore",
    alias : "store.autoreconfigurejson",

    autoLoad: true,

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

        if (!Ext.isEmpty(me.needMetadataExtraParamName))
            me.on("beforeload", me.patchExtraParams, me);

        return me;
    },

    patchExtraParams: function (store, operation, eOpts) {
        var me = this,
            configured = !Ext.isEmpty(store.getFields()),
            extraparams = store.getProxy().getExtraParams();

        if (Ext.isEmpty(me.needMetadataExtraParamName))
            return;

        if (configured) {
            delete extraparams[me.needMetadataExtraParamName];
            me.un("beforeload", me.patchExtraParams, me);
        }
        else
            extraparams[me.needMetadataExtraParamName] = true;
    }
});