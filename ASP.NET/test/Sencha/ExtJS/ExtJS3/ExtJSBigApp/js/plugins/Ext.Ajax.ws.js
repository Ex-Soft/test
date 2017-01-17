Ext.Ajax.ws = function(c) {
    Ext.Ajax.request({
        method: "POST",
        url: c.url,
        jsonData: c.data,
        headers: { "Content-Type": "application/json;charset=utf-8" },
        success: function(resp) {
            var json = Ext.decode(resp.responseText);
            c.success(json.d || json);
        }
    });
}
