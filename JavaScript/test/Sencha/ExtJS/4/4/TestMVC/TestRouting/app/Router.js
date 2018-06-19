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

        me.application.on("navPanelRendered", me.onNavPanelRendered, me);
        me.application.on("navNodeSelected", me.onNavNodeSelected, me);
        me.application.on("gridRowSelected", me.onGridRowSelected, me);

        me.ready = true;
    },

    onNavPanelRendered: function () {
        var me = this;

        me.onChange(me.history.getToken());
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

        me.application.fireEvent("navNodeChanged", me.parseToken(token));
    },

    onNavNodeSelected: function(nodeId) {
        if (window.console && console.log)
            console.log("Router.onNavNodeSelected(%o)", arguments);

        var
            me = this,
            curToken = me.parseToken(me.history.getToken());

        if (curToken.nodeId == nodeId) {
            return;
        }

        me.selfProcessing = true;
        me.history.add(this.tag + nodeId);
    },

    onGridRowSelected: function(rowId) {
        if (window.console && console.log)
            console.log("Router.onGridRowSelected(%o)", arguments);

        var
            me = this,
            curToken = me.parseToken(me.history.getToken());

        if (curToken.rowId == rowId) {
            return;
        }

        me.selfProcessing = true;
        me.history.add(me.tag + curToken.nodeId + me.paramsDelimiter + rowId);
    },

    parseToken: function(token) {
        var
            match = this.parseRegexp.exec(token),
            success = !Ext.isEmpty(match) && match.length > 2,
            nodeIdExists = success && !Ext.isEmpty(match[1]),
            rowIdExists = success && !Ext.isEmpty(match[2]);

        return { nodeId: nodeIdExists ? match[1] : null, rowId: rowIdExists ? match[2] : null};
    }
});