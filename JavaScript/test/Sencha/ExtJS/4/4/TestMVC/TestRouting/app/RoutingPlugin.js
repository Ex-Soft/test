Ext.define("TestRouting.RoutingPlugin", {
    extend: "Ext.AbstractPlugin",
    alias: "plugin.routingplugin",

    ptype: "routingplugin",

    formPanel: null,
    form: null,
    btnSearch: null,

    searching: false,

    init: function (cmp) {
        if (window.console && console.log)
            console.log("RoutingPlugin.init(%o)", arguments);

        var
            me = this,
            store,
            btnSearch;

        me.setCmp(cmp);

        cmp.addEvents({
            "parentchanged": true,
            "gridrowselected": true,
            "routeparamschanged": true,
            "gridsearch": true
        });

        cmp.on({
            parentchanged: { fn: me.onParentChanged, scope: me },
            select: { fn: me.onGridRowSelected, scope: me },
            routeparamschanged: { fn: me.onRouteParamsChanged, scope: me },
        });

        if (store = cmp.getStore()) {
            store.on("load", me.onStoreLoad, me);
        }

        if (btnSearch = me.getBtnSearch()) {
            btnSearch.on("click", me.onBtnSearchClick, me);
        }
    },

    getFormPanel: function () {
        var me = this;

        if (!me.formPanel)
            me.formPanel = me.getCmp().down("form");

        return me.formPanel;
    },

    getForm: function () {
        var
            me = this,
            formPanel;

        if (!me.form)
            me.form = (formPanel = me.getFormPanel()) ? formPanel.getForm() : null;

        return me.form;
    },

    getBtnSearch: function () {
        var
            me = this,
            formPanel;

        if (!me.btnSearch)
            me.btnSearch = (formPanel = me.getFormPanel()) ? formPanel.down("button") : null;

        return me.btnSearch;
    },

    getValues: function () {
        var form;

        return (form = this.getForm()) ? form.getValues() : null;
    },

    setValues: function (values) {
        var form;

        if (form = this.getForm())
            form.setValues(values);
    },

    onParentChanged: function (category) {
        if (window.console && console.log)
            console.log("RoutingPlugin.onParentChanged(%o)", arguments);

        var me = this,
            store = me.getCmp().getStore();

        if (Ext.isEmpty(me.getCmp().getUrl())) {
            return;
        }

        if (!store.getTotalCount()) {
            store.load({
                scope: me,
                callback: me.onStoreFirstLoad
            });
        } else {
            me.onStoreFirstLoad();
        }
    },

    onStoreFirstLoad: function () {
        this.onRouteParamsChanged(TestRouting.Router.parseToken(TestRouting.Router.getToken()));
    },

    onGridRowSelected: function (rowModel, record, index, eOpts) {
        if (window.console && console.log)
            console.log("RoutingPlugin.onGridRowSelected(%o)", arguments);

        var me = this;

        if (me.disabled)
            return;

        me.getCmp().fireEvent("gridrowselected", record);
    },

    onRouteParamsChanged: function (token) {
        if (window.console && console.log)
            console.log("RoutingPlugin.onRouteParamsChanged(%o)", arguments);

        var
            me = this,
            params = token.params || {};

        if (me.disabled)
            return;

        if (Ext.isEmpty(params.id))
            params.id = "";

        me.search(params);
    },

    onBtnSearchClick: function (btn) {
        if (window.console && console.log)
            console.log("RoutingPlugin.onBtnSearchClick(%o)", arguments);

        var me = this;

        if (me.disabled || me.searching)
            return;

        me.getCmp().fireEvent("gridsearch", me.getValues());
    },

    onStoreLoad: function (store, records, successful, operation, eOpts) {
        if (window.console && console.log)
            console.log("RoutingPlugin.onStoreLoad(%o)", arguments);

        var
            me = this,
            cmp = me.getCmp();

        if (me.disabled || !me.searching) {
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
        btnSearch.handler(btnSearch);
    }
});
