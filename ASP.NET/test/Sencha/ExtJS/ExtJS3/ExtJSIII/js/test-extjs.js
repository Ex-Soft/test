Ext.onReady(function() {
	Ext.QuickTips.init();

	var 
		viewport = new Ext.Viewport({
			layout: 'border',
			renderTo: Ext.getBody(),
			items: [{
				region: 'north',
				xtype: 'toolbar',
				id: "NorthToolBar",
				height: 50,
				items: [{
					xtype: "tbspacer"
					}, {
					xtype: "tbbutton",
					text: "Add",
					handler: function(btn) { Add(); }
					}, {
					xtype: "tbspacer"
					}, {
					xtype: "tbspacer"
					}, {
					xtype: "tbbutton",
					text: "Remove",
					handler: function(btn) { Remove(); }
					}, {
					xtype: "tbfill"
				}]
				}, {
				region: 'center',
				xtype: 'panel'
			}]
		});
});

function Add() {
	var 
		cbg = new Ext.form.CheckboxGroup({
			xtype: 'checkboxgroup',
			id: "VictimCheckboxGroup",
			itemCls: 'x-check-group-alt',
			columns: "auto",
			items: [
				{ boxLabel: 'Item 1', name: 'cb1', id: "cb1" },
				{ boxLabel: 'Item 2', name: 'cb2', id: "cb2", checked: true },
				{ boxLabel: 'Item 3', name: 'cb3', id: "cb3" }
			]
		}),
		p = Ext.getCmp("NorthToolBar");

	p.insert(3,cbg);
	p.doLayout();
}

function Remove()
{
    var
        tb,
        cbg;
        
    if(!(tb=Ext.getCmp("NorthToolBar"))
        || !(cbg=Ext.getCmp("VictimCheckboxGroup")))
      return;
    
    tb.remove(cbg);
}