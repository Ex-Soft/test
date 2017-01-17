Ext.override(Ext.data.Connection, {
    request: Ext.data.Connection.prototype.request.createSequence(function(o) {
        if (!o.failure) {
            o.failure = function(response) {
                var msg = "Unknown server error";
                var resp = Ext.decode(response.responseText);

                if (resp && resp.Message) {
                    msg = resp.Message;
                }

                Ext.Msg.show({
                    title: "Server Error",
                    msg: msg,
                    minWidth: 300,
                    buttons: Ext.Msg.OK,
                    icon: Ext.Msg.ERROR
                });
            }
        }
    })
});