Ext.define("TestRouting.controller.CNavPanel", {
    extend: "Ext.app.Controller",
    
    stores: ["NavStore"],

    models: ["NavModel"],

    refs: [{
        ref: "navPanel",
        selector: "navpanel"
    }],

    init: function(app) {
        if (window.console && console.log)
            console.log("CNavPanel.init(%o)", arguments);

        var me = this;

        me.control({
            "navpanel": {
                select: me.onSelect,
                afterrender: me.onRender
            }
        });

        app.on("navNodeChanged", me.onNodeChanged, me);
    },

    onRender: function () {
        this.application.fireEvent("navPanelRendered");
    },

    onSelect: function (panel, record, index, eOpts) {
        if (window.console && console.log)
            console.log("CNavPanel.onSelect(%o)", arguments);

        var category;
        if (!Ext.isEmpty(category = record.get("category")))
            this.application.fireEvent("navNodeSelected", record.get("category"));
    },

    onNodeChanged: function (token) {
        if (window.console && console.log)
            console.log("CNavPanel.onNodeChanged(%o)", arguments);

        var me = this,
            navPanel,
            store,
            rootNode,
            selModel,
            newTreeNode;

        if (!(navPanel = me.getNavPanel()) || !(store = navPanel.getStore()) || !(rootNode = store.getRootNode())) {
            return;
        }

        selModel = navPanel.getSelectionModel();

        if (!(newTreeNode = rootNode.findChild("category", token.nodeId, true))) {
            return;
        }

        navPanel.expandPath(me.getPath(newTreeNode));
        selModel.select(newTreeNode);
    },

    getPath: function (node) {
        var path = "";

        for (var parentNode = node; parentNode; parentNode = parentNode.parentNode) {
            path = "/" + parentNode.getId().toString() + path;
        }

        return path;
    }
});