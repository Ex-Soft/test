Ext.ns('App.Store');

App.Store.StaffFields =
[
	{ name: "Id", type: "int" },
	"Name",
	{ name: "Salary", type: "float" },
	{ name: "BirthDate", type: "date", dateFormat: "M$" }
];

App.Store.StaffList = Ext.extend(Ext.data.WsJsonStore, {
    constructor: function() {
        App.Store.StaffList.superclass.constructor.call(this, {
            url: "services/StaffService.asmx/GetStaffList",
            root: "d.Staffs",
            idProperty: "Id",
            totalProperty: "d.Total",
            autoLoad: true,
            fields: App.Store.StaffFields,
            listeners: {
                beforeload: function(s, o) {
                    var start = o.params.start || 0;
                    var limit = o.params.limit || App.Config.GrigPageSize;

                    s.proxy.conn.jsonData = Ext.encode({
                        start: start,
                        limit: limit
                    });

                    return true;
                }
            }
        });
    }
});
