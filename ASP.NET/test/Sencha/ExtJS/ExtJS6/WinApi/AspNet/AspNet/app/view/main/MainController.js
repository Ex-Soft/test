Ext.define('AspNetApp.view.main.MainController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.main',

    onDatePickerSelect: function (picker, date, eOpts) {
        if (window.console && console.log)
            console.log("MainController.onDatePickerSelect(%o)", arguments);

        this.setStoreDate(picker.getValue())
    },

    onDatePickerAfterRender: function(picker, eOpts) {
        if (window.console && console.log)
            console.log("MainController.onDatePickerAfterRender(%o), picker.getValue() = %o", arguments, picker.getValue());

        this.setStoreDate(picker.getValue());
    },

    setStoreDate: function(date) {
        var
            store;

        if (store = Ext.data.StoreManager.lookup('AspNetApp.store.Task'))
            store.setDate(date);
    }
});
