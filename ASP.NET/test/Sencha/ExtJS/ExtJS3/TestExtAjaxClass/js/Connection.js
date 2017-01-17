Ext.override(Ext.data.Connection, {
    request: Ext.data.Connection.prototype.request.createSequence(function(o) {
        if (!o.failure) {
            o.failure = function(response) {
				if(window.console)
					console.log("Ext.data.Connection.failure: response.status=%i response.statusText=\"%s\"",response.status,response.statusText);
            }
        }
    })
});