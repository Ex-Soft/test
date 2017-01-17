Ext.onReady(function() {
	// Небходима для вывода сообщений об ошибках
	Ext.QuickTips.init();

	Ext.Msg.show({
		title: "Title",
		msg: "Ext.Msg.show()",
		buttons: {
			yes: "YesYes",
			no: "NoNo",
			cancel: "CancelCancel"
		},
		fn: function(btn) {
			switch (btn) {
				case "yes":
					{
						Ext.Msg.prompt("Title", "Ext.Msg.prompt()", function(btn, txt) {
							Ext.Msg.alert(btn, txt.toLowerCase())
						});
						break;
					}
				case "no":
					{
						CreateWindow();
						break;
					}
				case "cancel":
					{
						Ext.Msg.wait("Ext.Msg.wait(3000)", "Ext.Msg.wait()", { duration: 3000, scope: this, fn: function() { Ext.Msg.hide(); } });
						break;
					}
			}
		}
	});

	var genres = new Ext.data.SimpleStore({
		fields: ['id', 'genre'],
		data: [['1', 'Comedy'], ['2', 'Drama'], ['3', 'Action']]
	});

	var 
viewport = new Ext.Viewport({
	id: "movieview",
	layout: 'border',
	renderTo: Ext.getBody(),
	items: [{
		region: 'north',
		xtype: 'toolbar',
		height: 35,
		//autoHeight: true,
		items: [{
			xtype: "tbspacer"
		}, {
			xtype: "tbtext",
			text: "xtype: \"tbtext\""
		}, {
			xtype: "tbbutton",
			text: "Button",
			handler: function(btn) {
				btn.disable();
			}
		}, {
			xtype: "tbbutton",
			text: "Add",
			handler: function(btn) {
				AddCheckBox();
			}
		}, {
			xtype: "tbbutton",
			text: "Send",
			handler: function(btn) {
				SendCheckBox();
			}
		}, {
			xtype: "tbbutton",
			text: "GetJSON",
			handler: function(btn) {
				GetJSON();
			}
		}, {
			xtype: 'tbfill'
		}, {
			xtype: 'tbbutton',
			text: 'Menu Button',
			menu: [{
				text: 'Better'
			}, {
				text: 'Good'
			}, {
				text: 'Best'
}]
			}, {
				xtype: 'tbseparator'
			}, {
				xtype: 'tbsplit',
				text: 'Split Button',
				menu: [{
					text: 'Item One'
				}, {
					text: 'Item Two'
				}, {
					text: 'Item Three'
}]
				}, {
					xtype: "tbfill"
}]
				}, {
					region: 'west',
					/* xtype: 'panel' */
					xtype: 'treepanel',
					id: "__tree",
					split: true,
					width: 200,
					title: "Title west",
					collapsible: true,
					collapseMode: "mini",
					autoScroll: true,
					root: { text: "Autos" },
					loader: new Ext.tree.TreeLoader({ dataUrl: "Data.ashx" }),
					listeners: {
						click: function(n) {
							Ext.Msg.alert(n.ownerTree.getSelectionModel().getSelectedNode());
							if (n.isLeaf())
								Ext.Msg.alert('Navigation Tree Click', 'You clicked: "' + n.attributes.text + '"');
						}
					}
				}, {
					region: 'center',
					xtype: 'tabpanel',
					activeTab: 0,
					items: [{
						title: "TabSheet1",
						id: "TabSheet1",
						items: [{
							xtype: 'textfield',
							fieldLabel: 'Title',
							name: 'title',
							allowBlank: false
						}, {
							xtype: 'textfield',
							fieldLabel: 'Director',
							name: 'director',
							vtype: 'alpha'
						}, {
							xtype: 'datefield',
							fieldLabel: 'Released',
							name: 'released',
							disabledDays: [1, 2, 3, 4, 5]
						},
{
	xtype: 'radio',
	fieldLabel: 'Filmed In',
	name: 'filmed_in',
	boxLabel: 'Color'
}, {
	xtype: 'radio',
	hideLabel: false,
	labelSeparator: '',
	name: 'filmed_in',
	boxLabel: 'Black & White'
},
{
	xtype: 'checkbox',
	fieldLabel: 'Bad Movie',
	name: 'bad_movie'
},
{
	xtype: 'combo',
	name: 'genre',
	fieldLabel: 'Genre',
	mode: 'local',
	store: genres,
	displayField: 'genre',
	width: 120
},
{
	xtype: 'textarea',
	name: 'description',
	hideLabel: true,
	labelSeparator: '',
	height: 100,
	anchor: '100%'
},
{
	xtype: 'htmleditor',
	name: 'description',
	hideLabel: true,
	labelSeparator: '',
	height: 100,
	anchor: '100%'
}
						]
					}, {
						title: "TabSheet2",
						layout: "accordion",
						items: [{
							title: "Title1",
							html: "Title1"
						}, {
							title: "Title2",
							html: "Title2"
						}, {
							title: "Title3",
							html: "Title3"
}]
						}, {
							title: "TabSheet3",
							layout: "border",
							border: false,
							items: [{
								region: "north",
								xtype: 'panel',
								height: 100,
								split: true,
								html: "Nested North",
								id: "nn"
							}, {
								region: "center",
								html: "Nested Center",
								id: "nc"
}]
}]
							}, {
								region: 'east',
								xtype: 'panel',
								split: true,
								width: 200,
								html: 'East',
								id: "moreinfo"
							}, {
								region: 'south',
								xtype: 'panel',
								html: 'South',
								split: true,
								collapsible: true
}]
							});
	/*                    
	var 
	Tree = Ext.tree;

	var 
	tree = new Tree.TreePanel({
	renderTo: "moreinfo",
	useArrows: true,
	autoScroll: true,
	animate: true,
	enableDD: true,
	containerScroll: true,
	border: false,
	// auto create TreeLoader
	dataUrl: "Data.ashx",

	root: {
	nodeType: 'async',
	text: "Autos",
	draggable: false,
	id: "TreeInEastPanel"
	}
	});


	//tree.render();
	//tree.getRootNode().expand(); */
});

/*
function CreateWindow() {
    var w = new Ext.Window({
    layout: 'form',
        height: 150, width: 200,
        title: 'A Window',
        //html: '<h1>Oh</h1><p>HI THERE EVERYONE</p>'
        items: [
       { xtype: 'textfield', fieldLabel: 'First Name' },
       new Ext.form.TextField({ fieldLabel: 'Surname' })
    ]
    });
    w.show();
}
*/

function CreateWindow() {
	var 
		tree = new Ext.tree.TreePanel({
  			useArrows: true,
  			autoScroll: true,
  			animate: true,
  			enableDD: true,
  			containerScroll: true,
  			border: false,
  			dataUrl: "Data.ashx",
  			root: {
  				nodeType: 'async',
  				text: "Autos",
  				draggable: false,
  				id: "TreeInWindow"
  			},
  			listeners: {
  				click: function(n) {
  					if (n.isLeaf())
  						storeXml.load();
  				}
  			}
		  });

	var
		store=new Ext.data.JsonStore({
			url: "TestGridDataJson.aspx",
			root: 'movies',
			idProperty: 'id',
			totalProperty: 'count',
			fields: ['id', 'title', 'release_year', 'rating']
		});

	var 
		grid = new Ext.grid.GridPanel({
			title: 'Movies (by JSON)',
			store: store,
			columns: [
                { header: "ID", width: 30, dataIndex: 'id', sortable: true, hidden: true },
                { id: 'title-col', header: "Title", width: 180, dataIndex: 'title', sortable: true },
                { header: "Rating", width: 75, dataIndex: 'rating', sortable: true },
                { header: "Year", width: 75, dataIndex: 'release_year', sortable: true, align: 'center' }
            ],
			autoExpandColumn: 'title-col',
			width: 600,
			height: 200,
			loadMask: true,
			columnLines: true,
			bbar: new Ext.PagingToolbar({
				pageSize: 5,
				store: store,
				displayInfo: true,
				displayMsg: 'Displaying movies {0} - {1} of {2}',
				emptyMsg: "No movies found"
			})
		});
		
	var 
		storeXml = new Ext.data.XmlStore({
			url: "TestGridDataXml.aspx",
			record: 'movie',
			idPath: 'id',
			fields: ['id', 'title', 'year', 'rating']
		});

	var 
		gridXml = new Ext.grid.GridPanel({
			title: 'Movies (by XML)',
			store: storeXml,
			columns: [
                { header: "ID", width: 30, dataIndex: 'id', sortable: true, hidden: true },
                { id: 'title-col', header: "Title", width: 180, dataIndex: 'title', sortable: true },
                { header: "Rating", width: 75, dataIndex: 'rating', sortable: true },
                { header: "Year", width: 75, dataIndex: 'year', sortable: true, align: 'center' }
            ],
			autoExpandColumn: 'title-col',
			width: 600,
			height: 200,
			loadMask: true
		});
		
var storeJSONWithGrooping = new Ext.data.GroupingStore({
  url: "TestGridDataJsonII.aspx",
  sortInfo: {
     field: 'genre',
     direction: "ASC"
  },
  groupField: 'genre',
  reader: new Ext.data.JsonReader({
    root:'movies',
    id:'id'
  }, ["id","title","rating","release_year","genre"])
});		

var gridJSONWithGrooping = new Ext.grid.GridPanel({
  title: 'Movies (by JSON)',
  height:200,
  width:600,
  store: storeJSONWithGrooping,
	columns: [
                { header: "ID", width: 30, dataIndex: 'id', sortable: true, hidden: true },
                { header: "genre", width: 75, dataIndex: 'genre', sortable: true },
                { id: 'title-col', header: "Title", width: 180, dataIndex: 'title', sortable: true },
                { header: "Rating", width: 75, dataIndex: 'rating', sortable: true },
                { header: "Year", width: 75, dataIndex: 'release_year', sortable: true, align: 'center' }
            ],
			autoExpandColumn: 'title-col',
			view: new Ext.grid.GroupingView({
				forceFit: true,
				groupTextTpl: '{text} ({[values.rs.length]} {[values.rs.length > 1 ? "Items" : "Item"]})'
			}),
			iconCls: 'icon-grid',
			fbar: ['->', {
				text: 'Clear Grouping',
				iconCls: 'icon-clear-group',
				handler: function() {
				storeJSONWithGrooping.clearGrouping();
				}
}]
});

	var
		w = new Ext.Window({
			/* layout: "fit", */
			layout: "border",
			height: 800,
			width: 1050,
			title: "title",
			items: /* tree */ [{
				region: "north",
				xtype: "panel",
				height: 250,
				items: gridJSONWithGrooping
				}, {
				region: "west",
				xtype: "panel",
				items: grid,
				width: 600
				}, {
				region: "center",
				xtype: "panel",
				items: tree
				}, {
				region: "east",
				xtype: "treepanel",
				width: 200,
				root: { text: "Autos" },
				loader: new Ext.tree.TreeLoader({ dataUrl: "Data.ashx" }),
				listeners: {
					click: function(n) {
						if(n.isLeaf())
						{ store.load({ params: { start: 0, limit: 5} }), storeJSONWithGrooping.load() };
						}
					}
				}, {
				region: "south",
				xtype: "panel",
				height: 250,
				items: gridXml
			}]
		});

	w.show();
}

function AddCheckBox() {
	var 
		c = new Ext.form.Checkbox({boxLabel: "Single"});

	var
		cbg = new Ext.form.CheckboxGroup({
	id: 'myGroup',
	xtype: 'checkboxgroup',
	fieldLabel: 'Single Column',
	itemCls: 'x-check-group-alt',
	// Put all controls in a single column with width 100%
	columns: "auto",
	items: [
        { boxLabel: 'Item 1', name: 'cb1', id: "cb1" },
        { boxLabel: 'Item 2', name: 'cb2', id: "cb2", checked: true },
        { boxLabel: 'Item 3', name: 'cb3', id: "cb3" }
    ]
	});
		
	var
		ts=Ext.getCmp("TabSheet1");

	ts.add(c);
	ts.add(cbg);
	ts.doLayout();
}

function SendCheckBox() {
	var
		cbg,
		cb;

	if (!(cbg = Ext.getCmp("myGroup")))
		return;

	for (var i = 0; i < cbg.items.length; ++i) {
		cb = cbg.items.items[i];
		alert("\"" + cb.id + "\"=" + cb.checked);
	}
}

function GetJSON() {
	var myJsonReader = new Ext.data.JsonReader({
		idProperty: 'ContragentId',
		root: 'rows',
		totalProperty: 'results',
		//Ext.data.DataReader.messageProperty: "msg",
		fields: [
			{name: 'Name'},
			{name: 'Job'}
		]
	});

	var myJsonStore = new Ext.data.JsonStore({
		url: "TestJsonReader.aspx",
		reader: myJsonReader,
		idProperty: 'ContragentId',
		root: "rows",
		fields: ["ContragentId","Name","Job"],
		listeners: {
			load: { fn: function(store, records, options) { ShowJsonStore(store, records, options) }}
		}
	});

	myJsonStore.load(/*{ callback: function(records, o, s) { CheckLoadCallBack(records, o, s) } }*/);
}

function ShowJsonStore(store, records, options) {
	if (records && records.length > 0) {
		var
			Msg;

		var 
			cbg = new Ext.form.CheckboxGroup({
			id: 'myGroup',
			xtype: 'checkboxgroup',
			fieldLabel: 'Single Column',
			itemCls: 'x-check-group-alt',
			columns: "auto",
			items: []
		});

		var
			c;

		/*
		http://www.extjs.com/forum/showthread.php?t=83825 ???
		http://www.extjs.com/forum/showthread.php?t=48702
		
		for (var i=0; i<records.length; i++) {
		thisItem = new Array();
		thisItem["boxLabel"] = records[i].get("boxLabel");
		thisItem["name"] = records[i].get("name");
		dataArray.push(thisItem);
		}

		
		data = [];
		Ext.each(records, function(rec)
		{
		data.push({boxLabel: rec.get('boxLabel'), name: rec.get('name'));
		}
		);
		*/
					
		/*for (var i = 0; i < records.length; ++i) {
			//c = new Ext.form.Checkbox({ boxLabel: records[i].data.Name, id: "CB" + records[i].data.ContragentId, name: "CB" + records[i].data.ContragentId, inGroup: true });
			//c = new Ext.form.Checkbox({ boxLabel: records[i].get("Name"), id: "CB" + records[i].get("ContragentId"), name: "CB" + records[i].get("ContragentId"), inGroup: true });
			c = { boxLabel: records[i].get("Name"), id: "CB" + records[i].get("ContragentId"), name: "CB" + records[i].get("ContragentId"), inGroup: true };
			cbg.items.push(c);
		}*/

		Ext.each(records, function(rec)
		{
			cbg.items.push({ boxLabel: rec.get("Name"), id: "CB" + rec.get("ContragentId"), name: "CB" + rec.get("ContragentId"), inGroup: true });
		}
		);
		
		var 
			ts = Ext.getCmp("TabSheet1");

		ts.add(cbg);
		ts.doLayout();
	}
}

function CheckLoadCallBack(records, o, s) {
	if (records)
		if (o)
			if (s)
				alert("CheckLoadCallBack(records, o, s)");
}