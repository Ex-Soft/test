Ext.onReady(function() {
	Ext.QuickTips.init();

	var 
		viewport = new Ext.Viewport({
			id: "movieview",
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
					handler: function(btn) {
						Add();
						}
					}, {
					xtype: "tbspacer"
					}, {
					xtype: "checkboxgroup",
					id: "CheckboxGroup1",
					fieldLabel: 'Single Column',
					hidden: true,
					items: [{}]
					}, {
					xtype: "tbspacer"
				}]
				}, {
				region: 'center',
				xtype: 'panel',
				items: []
			}]
		});
});

function Add() {
	//AddButton();
	//AddCB();
	//AddCBG();
	AddCBGS();
	//AddButton();
}

function AddButton() {
	var 
		b = new Ext.Button({text: "Dynamic Button"}),
		p = Ext.getCmp("NorthToolBar");

	p.add(b);
	p.doLayout();
}

function AddCB() {
	var 
		cb = new Ext.form.Checkbox({boxLabel: "Dynamic Checkbox"}),
		p = Ext.getCmp("NorthToolBar");

	p.add(cb);
	p.doLayout();
}

function AddCBG() {
	var 
		cbg = new Ext.form.CheckboxGroup({
			xtype: 'checkboxgroup',
			fieldLabel: 'Single Column',
			itemCls: 'x-check-group-alt',
			columns: "auto",
			items: [
				{ boxLabel: 'Item 1', name: 'cb1', id: "cb1" },
				{ boxLabel: 'Item 2', name: 'cb2', id: "cb2", checked: true },
				{ boxLabel: 'Item 3', name: 'cb3', id: "cb3" }
			]
		}),
		p = Ext.getCmp("NorthToolBar");

	p.add(cbg);
	p.doLayout();
}

function AddCBGS() {
	var
		cbg;

	if (!(cbg = Ext.getCmp("CheckboxGroup1")))
	{
		alert("!");
	}

	cbg.items = [{ boxLabel: 'Item 1', name: 'cb1', id: "cb1" },
				{ boxLabel: 'Item 2', name: 'cb2', id: "cb2", checked: true },
				{ boxLabel: 'Item 3', name: 'cb3', id: "cb3" }];
			
	if (!cbg.isVisible())
		//cbg.show();
		cbg.setVisible(true);

	p = Ext.getCmp("NorthToolBar");
	p.doLayout();
}