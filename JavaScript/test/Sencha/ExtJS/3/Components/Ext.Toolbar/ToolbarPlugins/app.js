Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

ToolbarSearchPlugin = Ext.extend(Object, {
	target: "rightTr",
	position: null,
	text: "Search",
	hideText: true,
	iconCls: null,
	store: null,
	valueField: "id",
	displayField: "value",
	callback: null,

	constructor: function(config) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.constructor(%o)", arguments);

		Ext.apply(this, config);

		return this;
	},

	init: function(cmp) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.init(%o)", arguments);

		if (!cmp.isXType(Ext.Toolbar.xtype) || Ext.isEmpty(this.target))
			return;

		cmp.on("afterrender", this.onAfterRender, this);
		cmp.on("afterlayout", this.inject, this, { single: true });
	},

	onAfterRender: function(toolbar) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.onAfterRender(%o)", arguments);

		var layout;

		if (!(layout = toolbar.getLayout()))
			return;
	},

	inject: function(tb, layout) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.inject(%o)", arguments);

		var me = this;

		me.addButton(tb, layout);
		me.addSearchPanel(tb);
		me.addEventListener(tb);
	},

	addButton: function(tb, layout) {
		var me = this,
			extrasTr = "extrasTr",
			target,
			btn,
			siblingItemIdx,
			td;

		if (!(target = layout[me.target]))
			return;

		btn = new Ext.Button({
			text: me.text,
			iconCls: me.iconCls,
			handler: me.showSearchPanel,
			scope: me
		});

		if (me.hideText) {
			btn.setTooltip(btn.getText());
			btn.setText("");
		}

		if (me.target != extrasTr)
			siblingItemIdx = me.getSiblingItemIdx(tb, target);

		if (!(td = layout.insertCell(btn, target, me.position)))
			return;

		btn.render(td);

		if (me.target != extrasTr)
			tb.items.insert(siblingItemIdx, btn);
	},

	getSiblingItemIdx: function(tb, target) {
		var me = this,
			position = me.position,
			insert,
			id,
			result;

		position = target.childNodes && target.childNodes.length ? (position != null ? me.constrain(position, 0, target.childNodes.length - 1) : target.childNodes.length -1) : 0;
		insert = me.position != null ? (position < me.position ? 1 : 0) : 1;
		id = position < target.childNodes.length ? target.childNodes[position].id : null;
		result = tb.items ? (id != null ? tb.items.findIndexBy(function(item) { return item.container && item.container.id === id; }) + insert : tb.items.length) : 0;

		return result;
	},

	constrain: function(number, min, max) {
		number = parseFloat(number);

		if (!isNaN(min)) {
			number = Math.max(number, min);
		}
		if (!isNaN(max)) {
			number = Math.min(number, max);
		}
		return number;
	},

	addSearchPanel: function(tb) {
		var me = this,
			el = tb.getEl(),
			div = document.createElement("div");

		el.dom.insertBefore(div, el.dom.childNodes[0]);

		me.searchComboBox = new Ext.form.ComboBox({
			store: me.store,
			valueField: me.valueField,
			displayField: me.displayField,
			mode: "local",
			hideTrigger: true,
			listeners: {
				select: me.onSelect,
				blur: me.hideSearchPanel,
				keyup: me.onKeyUp,
				scope: me
			}
		});

		me.searchPanel = new Ext.Panel({
			layout: "fit",
			items: [ me.searchComboBox ],
			applyTo: div,
			hidden: true
		});
	},

	addEventListener: function (tb) {
        var me = this,
            tds = Ext.query(".x-toolbar-left", tb.getEl().dom),
            td;

        if (!Ext.isEmpty(tds)) {
            td = tds[0];

            Ext.get(td).on("click", function (e, target) {
                if (td.id == target.id) {
                    me.showSearchPanel();
                }
            });
        }
	},

	showSearchPanel: function() {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.showSearchPanel(%o)", arguments);

		var me = this;

		me.searchPanel.show();
		me.searchComboBox.focus();
	},

	hideSearchPanel: function() {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.hideSearchPanel(%o)", arguments);

		var me = this;

		me.searchPanel.hide();
	},

	onSelect: function(combo, record, index) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.onSelect(%o)", arguments);

		var me = this;

		me.hideSearchPanel();

		if (!Ext.isFunction(me.callback))
			return;

		me.callback(record);
	},

	onKeyUp: function(combo, e) {
		if (window.console && console.log)
			console.log("ToolbarSearchPlugin.onKeyUp(%o)", arguments);

		if (e.getKey() == e.ESC)
			this.hideSearchPanel();
	}
});
Ext.preg("toolbarsearchplugin", ToolbarSearchPlugin);

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			fields: [ "id", "value"],
			data : [
				[ 1, "Line# 1" ],
				[ 2, "Line# 1" ],
				[ 3, "aaaaaaa" ],
				[ 4, "abbbbbb" ],
				[ 5, "abccccc" ],
				[ 6, "abcdddd" ],
				[ 7, "abcdeee" ],
				[ 8, "abcdeff" ],
				[ 9, "abcdefg" ]
			]
		}),
		callback = function () {
			if (window.console && console.log)
				console.log("callback(%o)", arguments);
		},
		viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				xtype: "toolbar",
				region: "north",
				plugins: [{
					ptype: "toolbarsearchplugin",
					//target: "extrasTr",
					target: "rightTr",
					//target: "leftTr",
					position: 1,
					iconCls: "searchIco",
					store: store,
					valueField: "id",
					displayField: "value",
					callback: callback
				}],
				height: 28,
				items: [{
					text: "getLayout()",
					handler: function(btn, e) {
						var tb,
							layout;

						if (!(tb = btn.findParentByType("toolbar")))
							return;

						layout = tb.getLayout();
					}
				}, {
					text: "Button# 2",
				}, {
					xtype: "tbseparator"
				}, {
					text: "Item# 1.1"
				}, {
					text: "Item# 1.2"
				}, "-", {
					text: "Item# 2.1"
				}, {
					xtype: "tbspacer",
					width: 50
				}, {
					text: "Item# 2.2"
				}, "-", {
					text: "Item# 3.1"
				}, " ", {
					text: "Item# 3.2"
				},
					"-", 
					"->",
					"-",
				{
					text: "Item# 4.1"
				}, {
					text: "Item# 4.2"
				}]
			}, {
				region: "center",
				html: "center"
			}]
		});
});
