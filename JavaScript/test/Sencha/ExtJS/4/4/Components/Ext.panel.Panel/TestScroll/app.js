// http://javascript.ru/forum/extjs/27554-ssylki-vnutri-stranicy-ext-tree-panel-ext-panel-panel-2.html#post169887
Ext.onReady(function() {
var text = Ext.String.repeat('<p>текст</p>', 50);
      
var treeStore = Ext.create('Ext.data.TreeStore', {
    root: {
        expanded: true,
        children: [
            { text: "item1", leaf: true },
            { text: "item2", leaf: true },
            { text: "item3", leaf: true }
        ]
    }
});
      
var treePanel = Ext.create('Ext.tree.Panel', {
    title: 'Tree',
    width: 200,
    store: treeStore,
    rootVisible: false,
    region: 'west'
});
      
treePanel.on('itemclick', function (v, rec, itm, idx) {
    var els = Ext.query('h1[name*='+rec.get('text')+']', htmlPanel.dom),
        el = Ext.get(els[0]);
    if( !el ) return false;
    
    htmlPanel.body.scroll('b', el.getY(), true);
});
      
var htmlPanel = Ext.create('Ext.panel.Panel', {
    region: 'center',
    autoScroll: true,
    bodyStyle: 'padding:10px',
    html: '<h1 name="item1">item1</h1>' + text +
          '<h1 name="item2">item2</h1>' + text +
          '<h1 name="item3">item3</h1>' + text
});
           
Ext.create('Ext.container.Viewport', {
    layout  : 'border',
    defaults: {
        split: true
    },
    items: [
        treePanel,
        htmlPanel
    ]          
});
});                    
