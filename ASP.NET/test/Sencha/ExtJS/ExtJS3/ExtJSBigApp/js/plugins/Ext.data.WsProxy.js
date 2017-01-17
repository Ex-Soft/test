Ext.data.WsProxy = Ext.extend(Ext.data.HttpProxy, {
    constructor: function(c) {
        var d = {
            method: "POST",
            headers: { "Content-Type": "application/json;charset=utf-8" }
        }
        Ext.data.WsProxy.superclass.constructor.call(this, Ext.apply(d, c));
    }
});