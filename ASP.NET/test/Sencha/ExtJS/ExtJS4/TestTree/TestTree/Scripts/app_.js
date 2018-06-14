Ext.define('Catalogue.Model', {
    extend: 'Ext.data.Model',
    fields: ['CatalogueID', 'Code', 'Classificator', 'Name', 'ObjCount']
});

Ext.define('Catalogue.Store', {
    extend: 'Ext.data.TreeStore',
    model: 'Catalogue.Model',
    autoLoad: true,
    nodeParam: "ParentID",
    defaultRootId:1,
    proxy: {
        type: 'ajax',
        url: 'GetChildren', 
        reader: {
            type: 'json',
            idProperty: "CatalogueID"
        }
    }
});

Ext.define('Catalogue.Tree', {
    extend: "Ext.tree.Panel",
    xtype:"mcTree",
    loadMask: true,
    rootVisible:false,
    store: Ext.create("Catalogue.Store"),
    columns: [
        {
            xtype: 'treecolumn',
            text: 'ID',
            width: 70,
            align:'right',
            dataIndex: 'CatalogueID',
        }, {
            text: 'Код',
            width: 100,
            align: 'center',
            dataIndex: 'Code'
        }, {
            text: 'Классификатор',
            width: 100,
            align: 'center',
            dataIndex: 'Classificator'
        }, {
            text: 'Наименование',
            align: 'left',
            flex:1,
            dataIndex: 'Name'
        }, {
            text: 'Кол-во объектов',
            align: 'center',
            dataIndex: 'ObjCount'
        }
    ]
});

Ext.onReady(function () {
    if (window.console && console.clear)
        console.clear();

    if (window.console && console.log)
        console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

    Ext.create("Catalogue.Tree");
});