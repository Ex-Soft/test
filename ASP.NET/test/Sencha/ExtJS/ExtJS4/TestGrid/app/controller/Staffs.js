Ext.define("TG.controller.Staffs", {
    extend: "Ext.app.Controller",

    stores: ["Staffs", "Countries"],

    models: ["Staff", "Country"],

    views: ["staff.List"],

    init: function () {
        if (window.console && console.log)
            console.log("TG.controller.Staff.init(%o)", arguments);

        this.control({
            "tgtabpanel > stafflist": {
                //itemclick: this.showId,
                render: this.onRendered
            }
        });
    },

    onRendered: function () {
        if (window.console && console.log)
            console.log("TG.controller.Tabs.onRendered(%o)", arguments);
    },

    showId: function (view, record, item, index, e, eOpts) {
        alert(item.viewRecordId);
    }
});