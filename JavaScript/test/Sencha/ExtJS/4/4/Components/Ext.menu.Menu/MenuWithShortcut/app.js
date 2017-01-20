// http://www.sencha.com/forum/showthread.php?154304-Menu-items-with-right-aligned-keyboard-shortcut-descriptions
// http://jsfiddle.net/clint_harris/Syhj2/
Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("MyMenuItem", {
	extend: "Ext.menu.Item",
	renderTpl: [
/*
		'<tpl if="plain">',
			'{text}',
		'</tpl>',
		'<tpl if="!plain">',
			'<a id="{id}-itemEl" class="' + Ext.baseCSSPrefix + 'menu-item-link mymenuitem-link" href="{href}" <tpl if="hrefTarget">target="{hrefTarget}"</tpl> hidefocus="true" unselectable="on">',
				'<img id="{id}-iconEl" src="{icon}" class="' + Ext.baseCSSPrefix + 'menu-item-icon {iconCls}" />',
				'<span id="{id}-textEl" class="' + Ext.baseCSSPrefix + 'menu-item-text mymenuitem-text">{text}</span>',
				'<span class="' + Ext.baseCSSPrefix + 'menu-item-text mymenuitem-cmdTxt" <tpl if="menu">style="margin-right: 17px;"</tpl> >{cmdTxt}</span>',
				'<tpl if="menu">',
					'<img id="{id}-arrowEl" src="{blank}" class="' + Ext.baseCSSPrefix + 'menu-item-arrow" />',
				'</tpl>',
			'</a>',
		'</tpl>'
*/

		"<tpl if=\"plain\">",
			"{text}",
		"</tpl>",
		"<tpl if=\"!plain\">",
			"<a id=\"{id}-itemEl\" class=\"" + Ext.baseCSSPrefix + "menu-item-link mymenuitem-link\" href=\"{href}\" <tpl if=\"hrefTarget\">target=\"{hrefTarget}\"</tpl> hidefocus=\"true\" unselectable=\"on\">",
				"<img id=\"{id}-iconEl\" src=\"{icon}\" class=\"" + Ext.baseCSSPrefix + "menu-item-icon {iconCls}\" />",
				"<span id=\"{id}-textEl\" class=\"" + Ext.baseCSSPrefix + "menu-item-text mymenuitem-text\">{text}</span>",
				"<span class=\"" + Ext.baseCSSPrefix + "menu-item-text mymenuitem-cmdTxt\" <tpl if=\"menu\">style=\"margin-right: 17px;\"</tpl> >{cmdTxt}</span>",
				"<tpl if=\"menu\">",
					"<img id=\"{id}-arrowEl\" src=\"{blank}\" class=\"" + Ext.baseCSSPrefix + "menu-item-arrow\" />",
				"</tpl>",
			"</a>",
		"</tpl>"

	],
	onRender: function(ct, pos) {
		// Intercept the call to onRender so we can add the
		// keyboard shortcut text to the render data which
		// will be used by the template
		var me = this;
		me.renderData = me.renderData || {};
		me.renderData.cmdTxt = me.cmdTxt;
		me.callParent(arguments);
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		handleOption1 = function() {
			if(window.console && console.log)
				console.log("You executed Option 1");
		},
		handleOption2 = function() {
			if(window.console && console.log)
				console.log("You executed Option 2");
		},
		toolbar = Ext.create("Ext.toolbar.Toolbar", {
			items: [
				{
					xtype: "button",
					text: "File",
					menu: {
						xtype: "menu",
						showSeparator: false,
						items: [
							Ext.create("MyMenuItem", {
								text: "Option 1",
								cmdTxt: "Ctrl+1",
								handler: handleOption1
							}),
							Ext.create("MyMenuItem", {
								text: "Option 2",
								cmdTxt: "Ctrl+2",
								handler: handleOption2
							})
						]
					}
				}
			]
		});

	Ext.create("Ext.panel.Panel", {
		renderTo: Ext.getBody(),
		tbar: toolbar,
		html: "blah"
	});

	// Create a KeyMap
	var
		map = new Ext.util.KeyMap(Ext.getDoc(), {
			key: Ext.EventObject.ONE,
			ctrl: true,
			handler: handleOption1
		});

	// Create a KeyMap
	var
		map = new Ext.util.KeyMap(Ext.getDoc(), {
			key: Ext.EventObject.TWO,
			ctrl: true,
			handler: handleOption2
		});
});
