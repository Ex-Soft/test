Ext.data.WsJsonStore = Ext.extend(Ext.data.JsonStore, {
    constructor: function(c) {
        var d = {
            root: "d",
            proxy: new Ext.data.WsProxy({
                url: c.url
            })
        }
        Ext.data.WsJsonStore.superclass.constructor.call(this, Ext.apply(d, c));
    }
});
