Ext.define("TestRouting.ToolbarSearchMixin", {
    formPanel: null,
    form: null,
    btnSearch: null,

    onClassMixedIn: function (cls) {
        var me = this;

        if (window.console && console.log)
            console.log("ToolbarSearchMixin.onClassMixedIn(%o)", arguments);

        /*me.on("activate", me.onActivate, me);
        me.on("afterrender", me.onAfterRender, me);
        me.on("show", me.onShow, me);
        me.on("viewready", me.onViewReady, me);*/
    },

    getFormPanel: function () {
        var me = this;

        if (!me.formPanel)
            me.formPanel = me.down("form");

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
    }/*,

    onActivate: function () {
        if (window.console && console.log)
            console.log("ToolbarSearchMixin.onActivate(%o)", arguments);
    },

    onAfterRender: function () {
        if (window.console && console.log)
            console.log("ToolbarSearchMixin.onAfterRender(%o)", arguments);
    },

    onShow: function () {
        if (window.console && console.log)
            console.log("ToolbarSearchMixin.onShow(%o)", arguments);
    },

    onViewReady: function () {
        if (window.console && console.log)
            console.log("ToolbarSearchMixin.onViewReady(%o)", arguments);
    }*/
}, function () {
    if (window.console && console.log)
        console.log("ToolbarSearchMixin.createdFn(%o)", arguments);
});