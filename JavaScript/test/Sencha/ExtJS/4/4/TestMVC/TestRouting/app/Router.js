Ext.define("TestRouting.Router", {
    requires: [
        "Ext.util.History"
    ],

    singleton: true,

    tag: "!/",
    paramsDelimiter: "?",
    parseRegexp: /!\/([^?]*)(?:\??)(.*)/,

    selfProcessing: false,

    init: function (application) {
        var me = this;

        if (me.ready) {
            return me;
        }

        me.history = Ext.util.History;
        me.application = application;

        me.history.init();
        me.history.on("change", me.onChange, me);

        me.application.on("navPanelReady", me.onNavPanelReady, me);
        me.application.on("navNodeSelected", me.onNavNodeSelected, me);
        me.application.on("gridrowselected", me.onGridRowSelected, me);
        me.application.on("gridsearch", me.onGridSearch, me);

        me.ready = true;
    },

    getToken: function () {
        return this.history.getToken();
    },

    onNavPanelReady: function () {
        var me = this;

        me.onChange(me.getToken());
    },

    onChange: function (token) {
        if (window.console && console.log)
            console.log("Router.onChange(\"%s\") %o", token, arguments);

        var
            me = this,
            newToken;

        if (me.selfProcessing) {
            me.selfProcessing = false;
            return;
        }

        me.application.fireEvent("routechanged", me.parseToken(token));
    },

    onNavNodeSelected: function(category) {
        if (window.console && console.log)
            console.log("Router.onNavNodeSelected(%o)", arguments);

        var
            me = this,
            curToken = me.parseToken(me.history.getToken());

        if (curToken.category == category) {
            return;
        }

        me.selfProcessing = true;
        me.history.add(this.tag + category);
    },

    onGridRowSelected: function(record) {
        if (window.console && console.log)
            console.log("Router.onGridRowSelected(%o)", arguments);

        var
            me = this,
            curToken = me.parseToken(me.history.getToken()),
            idProperty  = record.idField.name,
            id = record.getId(),
            params = curToken.params || {};

        if (params[idProperty]  == id) {
            return;
        }

        me.selfProcessing = true;
        params[idProperty] = id;
        me.history.add(me.tag + curToken.category + me.paramsDelimiter + Ext.Object.toQueryString(params));
    },

    onGridSearch: function(values) {
        if (window.console && console.log)
            console.log("Router.onGridSearch(%o)", arguments);

        var
            me = this,
            curToken = me.parseToken(me.history.getToken());

        me.selfProcessing = true;
        me.history.add(me.tag + curToken.category + me.paramsDelimiter + Ext.Object.toQueryString(values));
    },

    parseToken: function(token) {
        var
            match = this.parseRegexp.exec(token),
            success = !Ext.isEmpty(match) && match.length > 2,
            categoryExists = success && !Ext.isEmpty(match[1]),
            paramsExists = success && !Ext.isEmpty(match[2]);

        return { category: categoryExists ? match[1] : null, params: paramsExists ? Ext.Object.fromQueryString(match[2]) : null };
    }
});