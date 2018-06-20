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
                viewready: me.onViewReady
            }
        });

        app.on("navNodeChanged", me.onNodeChanged, me);
    },

    onViewReady: function () {
        this.application.fireEvent("navPanelReady");
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

        if (!(newTreeNode = rootNode.findChild("category", token.category, true))) {
            return;
        }

        if (!selModel.isSelected(newTreeNode)) {
            navPanel.expandPath(me.getPath(newTreeNode));
            selModel.select(newTreeNode);
        } else {
            me.application.fireEvent("gridRowChanged", token);
        }
    },

    getPath: function (node) {
        var path = "";

        for (var parentNode = node; parentNode; parentNode = parentNode.parentNode) {
            path = "/" + parentNode.getId().toString() + path;
        }

        return path;
    }
});