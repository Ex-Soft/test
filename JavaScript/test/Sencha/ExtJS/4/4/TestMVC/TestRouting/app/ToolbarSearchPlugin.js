Ext.define("TestRouting.ToolbarSearchPlugin", {
    extend: "Ext.AbstractPlugin",
    alias: "plugin.toolbarSearchPlugin",

    ptype: "toolbarSearchPlugin",

    formPanel: null,
    form: null,
    btnSearch: null,

    searching: false,

    init: function (cmp) {
        var me = this;

        me.setCmp(cmp);

        if (window.console && console.log)
            console.log("ToolbarSearchPlugin.init(%o)", arguments);

        me.getCmp().on("viewready", me.onViewReady, me);
    },

    getFormPanel: function () {
        var me = this;

        if (!me.formPanel)
            me.formPanel = me.getCmp().down("form");

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

        me.getCmp().fireEvent("searched", me.getValues());
    },

    onStoreLoad: function (store, records, successful, operation, eOpts) {
        if (window.console && console.log)
            console.log("ToolbarSearchPlugin.onStoreLoad(%o)", arguments);

        var
            me = this,
            cmp;

        if (!me.searching || !(cmp = me.getCmp())) {
            return;
        }

        me.searching = false;
        cmp.getSelectionModel().select(cmp.getStore().first());
    },

    search: function (values) {
        var
            me = this,
            btnSearch;

        if (!(btnSearch = me.getBtnSearch())) {
            return;
        }

        me.setValues(values);
        me.searching = true;
        btnSearch.fireEvent("click", btnSearch);
    }
});