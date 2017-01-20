Ext.define("TestPanel", {
	extend: "Ext.panel.Panel",
	alias: "widget.testpanel",

	statics: {
		defaultCustomName: "customName",
		orderIdAttributeName: "orderId",
		menuIdAttributeName: "menuId",
		actionIdAttributeName: "actionId",

		hasEqualProperties: function(objl, objr) {
			var
				result = false;

			if(!objl || !objr)
				return result;

			for(var p in objr)
			{
				if(!(result = objl[p]==objr[p]))
					break;
			}

			return result;
		}
	},

	initComponent: function() {
		this.items = this.items || [];

		this.actions = [];

		this.dockedItems = [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				text: "TopTestPanelButton1"
			}, {
				text: "TopTestPanelMenu1",
				menuId: "TopTestPanelMenu1",
				menu: [{
					text: "TopTestPanelMenu1Button1"
				}, {
					text: "TopTestPanelMenu1Menu1",
					menuId: "TopTestPanelMenu1Menu1",
					menu: [{
						text: "TopTestPanelMenu1Menu1Button1"
					}]
				}, {
					text: "TopTestPanelMenu1Button2"
				}, {
					text: "TopTestPanelMenu1Menu2",
					menuId: "TopTestPanelMenu1Menu2",
					menu: [{
						text: "TopTestPanelMenu1Menu2Button1"
					}]
				}, {
					text: "TopTestPanelMenu1Button3"
				}]
			}, {
				text: "TopTestPanelButton2"
			}, {
				text: "TopTestPanelMenu2",
				menuId: "TopTestPanelMenu2",
				menu: [{
					text: "TopTestPanelMenu2Button1"
				}, {
					text: "TopTestPanelMenu2Menu1",
					menuId: "TopTestPanelMenu2Menu1",
					menu: [{
						text: "TopTestPanelMenu2Menu1Button1"
					}]
				}, {
					text: "TopTestPanelMenu2Button2"
				}, {
					text: "TopTestPanelMenu2Menu2",
					menuId: "TopTestPanelMenu2Menu2",
					menu: [{
						text: "TopTestPanelMenu2Menu2Button1"
					}]
				}, {
					text: "TopTestPanelMenu2Button3"
				}]
			}, {
				text: "Test",
				scope: this,
				handler: function(btn, e) {
					var
						tbs,
						m;

					if(!(tbs = this.getDockedItemsByFilter({ xtype: "toolbar", dock: "top" })))
						return;

					for(var i=0, len=tbs.length; i<len; ++i)
					{
						m = this.getMenu(tbs[i], "TopTestPanelMenu1Menu2");
						if(window.console && console.log)
							console.log("%o", m);
					}
				}
			}]
		},{
			xtype: "toolbar",
			dock: "bottom",
			items: [{
				text: "BottomTestPanelButton1"
			}]
		}, {
			xtype: "toolbar",
			dock: "bottom",
			ui: "footer",
			items: [{
				text: "BottomFooterTestPanelButton1"
			}]
		}, {
			xtype: "toolbar",
			dock: "left",
			items: [{
				text: "LeftTestPanelButton1"
			}]
		}, {
			xtype: "toolbar",
			dock: "right",
			items: [{
				text: "RightTestPanelButton1"
			}]
		}];

		this.customNameMap = [];

		if(typeof this.dfm==="string")
			this.dfm = Ext.decode(this.dfm);

		if(typeof this.functions==="string")
			this.functions = Ext.decode(this.functions);

		Ext.apply(this, this.functions);

		if(this.dfm && this.dfm.items)
			this.items = this.items.concat(this.dfm.items);

		this.createActions();
		this.mergeDockedItems();

		this.callParent(arguments);

		if(typeof this.initCustomComponent==="function")
			this.addListener("afterrender", this.initCustomComponent, this);
	},

	getCustomCmp: function(customName, customAttributeName) {
		var
			cmp;

		if(this.customNameMap[customName])
			return this.customNameMap[customName];

		customAttributeName = customAttributeName || TestPanel.defaultCustomName;

		if(cmp = this.findCmpByCustomName(this.items, customName, customAttributeName))
			this.customNameMap[customName] = cmp;

		return cmp;
	},

	findCmpByCustomName: function(items, customName, customAttributeName) {
		var
			item,
			foundedItem;

		for(var i=0, len=items.items.length; i<len; ++i)
		{
			item = items.items[i];

			if(item[customAttributeName] === customName)
				foundedItem = item;
			else if(item.isContainer || item.isPanel)
				foundedItem = this.findCmpByCustomName(item.items, customName, customAttributeName);

			if(foundedItem)
				break;
		}

		return foundedItem;
	},

	getDockedItemsByFilter: function(obj) {
		var
			result = [],
			items;

		if(!this.dockedItems)
			return result;

		items = Ext.isArray(this.dockedItems) ? this.dockedItems : this.dockedItems.items;

		for(var i=0, len=items.length; i<len; ++i)
			if(TestPanel.hasEqualProperties(items[i], obj))
				result.push(items[i]);

		return result;
	},

	mergeDockedItems: function() {
		var
			di,
			item,
			filter,
			m;

		if(!this.dfm || !this.dfm.dockedItems)
			return;

		for(var i=0, len=this.dfm.dockedItems.length; i<len; ++i)
		{
			filter = {
				xtype: this.dfm.dockedItems[i].xtype,
				dock: this.dfm.dockedItems[i].dock
			};

			if(this.dfm.dockedItems[i].ui)
				filter.ui = this.dfm.dockedItems[i].ui;

			if((di=this.getDockedItemsByFilter(filter)).length > 0)
				for(var ii=0, lenlen=di.length; ii<lenlen; ++ii)
					for(var iii=0, lenlenlen=this.dfm.dockedItems[i].items.length; iii<lenlenlen; ++iii)
					{
						if((item=this.dfm.dockedItems[i].items[iii]).menu)
						{
							this.prepareMenu(item.menu);

							if(item[TestPanel.menuIdAttributeName])
							{
								if(m = this.getMenu(di[ii].items, item[TestPanel.menuIdAttributeName]))
								{
									if(item.text)
										m.text = item.text;

									for(var iiii=0, lenlenlenlen=item.menu.length; iiii<lenlenlenlen; ++iiii)
										m.menu.splice(item.menu[iiii][TestPanel.orderIdAttributeName]<m.menu.length ? item.menu[iiii][TestPanel.orderIdAttributeName] : m.menu.length, 0, item.menu[iiii]);
								}
								else
									di[ii].items.push(item);
							}
							else
								di[ii].items.push(item);
						}
						else
							di[ii].items.splice(item[TestPanel.orderIdAttributeName]<di[ii].items.length ? item[TestPanel.orderIdAttributeName] : di[ii].items.length, 0, item[TestPanel.actionIdAttributeName] && this.actions[item[TestPanel.actionIdAttributeName]] ? this.actions[item[TestPanel.actionIdAttributeName]] : item);
					}
		}
	},

	prepareMenu: function(m) {
		var
			orderId;

		for(var i=0, len=m.length; i<len; ++i)
		{
			orderId = m[i][TestPanel.orderIdAttributeName];
			if(m[i][TestPanel.actionIdAttributeName] && this.actions[m[i][TestPanel.actionIdAttributeName]])
			{
				m[i] = this.actions[m[i][TestPanel.actionIdAttributeName]];
				if(orderId != undefined)
					m[i][TestPanel.orderIdAttributeName] = orderId;
			}

			if(m[i].menu)
				this.prepareMenu(m[i].menu);
		}
	},

	getMenu: function(items, menuId, menuIdAttributeName) {
		var
			m = undefined,
			items = Ext.isArray(items) ? items : (items.menu ? (Ext.isArray(items.menu) ? items.menu : items.menu.items.items) : items.items.items),
			item;

		menuIdAttributeName = menuIdAttributeName || TestPanel.menuIdAttributeName;

		for(var i=0, len=items.length; i<len; ++i)
		{
			item = items[i];

			if(!item.menu)
				continue;

			if(item[menuIdAttributeName] == menuId)
			{
				m = item;
				break;
			}

			if(m = this.getMenu(item, menuId, menuIdAttributeName))
				break;
		}

		return m;
	},

	createActions: function() {
		var
			action,
			item;

		if(!this.dfm || !this.dfm.actions)
			return;

		for(var i=0, len=this.dfm.actions.length; i<len; ++i)
		{
			action = new Ext.Action({});
			if((item=this.dfm.actions[i]).iconCls)
				action.setIconCls(item.iconCls);
			if(item.text)
				action.setText(item.text);
			if(item.handler
				&& this[item.handler])
				action.setHandler(this[item.handler], this);
			this.actions[item.id] = action;
		}
	}
});

Ext.onReady(function() {
	var
		loadDfm = function() {
			Ext.Ajax.request({
				url: "dfm.html",
				success: function(response, opts) {
					loadJs(response.responseText);
				}
			});
		},
		loadJs = function(dfm) {
			Ext.Ajax.request({
				url: "js.js",
				success: function(response, opts) {
					Ext.create("TestPanel", {
						dfm: dfm,
						functions: "{" + response.responseText + "}",
						width: 1024,
						renderTo: Ext.getBody()
					});
				}
			});
		};

	Ext.create("Ext.button.Button", {
		text: "DoIt!",
		handler: loadDfm,
		renderTo: Ext.getBody()
	});
});
