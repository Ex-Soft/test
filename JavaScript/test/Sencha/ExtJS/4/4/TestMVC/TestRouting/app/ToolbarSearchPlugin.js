Ext.define("TestRouting.ToolbarSearchPlugin", {
    extend: "Ext.AbstractPlugin",
    alias: "plugin.toolbarSearchPlugin",

    ptype: "toolbarSearchPlugin",

    formPanel: null,
    form: null,
    btnSearch: null,

    searching: false,

    init: function (host) {
        var me = this;

        if (window.console && console.log)
            console.log("ToolbarSearchPlugin.init(%o)", arguments);

        me.cmp.on("viewready", me.onViewReady, me);
    },

    getFormPanel: function () {
        var me = this;

        if (!me.formPanel)
            me.formPanel = me.cmp.down("form");

        return me.formPanel;
    },

    getForm: function () {
        var me = this;

        if (!me.form)
            me.form = me.getFormPanel().getForm();

        return me.form;
    },

    getBtnSearch: function () {
        var me = this;

        if (!me.btnSearch)
            me.btnSearch = me.getFormPanel().down("button");

        return me.btnSearch;
    },

    getValues: function () {
        return this.getForm().getValues();
    },

    setValues: function (values) {
        this.getForm().setValues(values);
    },

    onViewReady: function (cmp) {
        if (window.console && console.log)
            console.log("ToolbarSearchPlugin.onViewReady(%o)", arguments);

        var me = this;

        me.getBtnSearch().on("click", me.onBtnSearchClick, me);
        me.cmp.getStore().on("load", me.onStoreLoad, me);
    },

    onBtnSearchClick: function (btn) {
        if (window.console && console.log)
            console.log("ToolbarSearchPlugin.onBtnSearchClick(%o)", arguments);

        var me = this;

        if (me.searching)
            return;

        me.cmp.fireEvent("searched", me.getValues());
    },

    onStoreLoad: function (store, records, successful, operation, eOpts) {
        if (window.console && console.log)
            console.log("ToolbarSearchPlugin.onStoreLoad(%o)", arguments);

        var me = this;

        if (!me.searching) {
            return;
        }

        me.searching = false;
        me.cmp.getSelectionModel().select(me.cmp.getStore().first());
    },

    search: function (values) {
        var me = this;

        me.setValues(values);
        me.searching = true;
        me.getBtnSearch().getEl().dom.click();
    }
});