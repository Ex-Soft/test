Ext.define("Custom.ux.data.reader.CustomReader", {
    extend: "Ext.data.reader.Array",
    alias: "reader.customreader",

    readRecords: function (data) {
        if (window.console && console.log)
            console.log("customreader.readRecords(%o)", arguments);

        return this.callParent([data]);
    }
});