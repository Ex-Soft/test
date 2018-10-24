Ext.BLANK_IMAGE_URL="../../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	constructor: function (config) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.constructor(%o)", arguments);

		config = config || {};

		config.enableKeyEvents = true; // enable "keydown"
		config.autoSelect = false; // require a manual selection from the dropdown list to set the components value
		
		Test.ComboBox.superclass.constructor.apply(this, arguments);
	},

	initComponent: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.initComponent(%o)", arguments);

        Test.ComboBox.superclass.initComponent.apply(this, arguments);

        this.on({
            keydown: this.eventListenerOnKeyDown,
            keyup: this.eventListenerOnKeyUp,
            keypress: this.eventListenerOnKeyPress,
			specialkey: this.eventListenerOnSpecialKey,
			blur: this.eventListenerOnBlur,
            scope: this
        });
    },

    initList: function() {
        if (window.console && console.log)
            console.log("Ext.form.ComboBox.initList(%o)", arguments);

        Test.ComboBox.superclass.initList.apply(this, arguments);
    },

	initEvents: function() {
        if (window.console && console.log)
            console.log("Ext.form.ComboBox.initEvents(%o)", arguments);

		Test.ComboBox.superclass.initEvents.apply(this, arguments);
    },

	initTrigger: function() {
        if (window.console && console.log)
            console.log("Ext.form.ComboBox.initTrigger(%o)", arguments);

		Test.ComboBox.superclass.initTrigger.apply(this, arguments);
	},

	onTriggerClick: function(e, target, eOpts) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onTriggerClick(%o)", arguments);

    	Test.ComboBox.superclass.onTriggerClick.apply(this, arguments);
    },

    onViewClick: function(doFocus) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onViewClick(%o)", arguments);

    	Test.ComboBox.superclass.onViewClick.apply(this, arguments);
	},

	select: function(index, scrollIntoView) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.select(%o)", arguments);

		Test.ComboBox.superclass.select.apply(this, arguments);
	},

	selectNext: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.selectNext(%o)", arguments);

		Test.ComboBox.superclass.selectNext.apply(this, arguments);
	},

	selectPrev: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.selectPrev(%o)", arguments);

		Test.ComboBox.superclass.selectPrev.apply(this, arguments);
	},

	initQuery: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.initQuery(%o)", arguments);

		Test.ComboBox.superclass.initQuery.apply(this, arguments);
	},

	checkTab: function(me, e) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.checkTab(%o)", arguments);

		Test.ComboBox.superclass.checkTab.apply(this, arguments);
	},

	doQuery: function(q, forceAll) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.doQuery(%o)", arguments);

		Test.ComboBox.superclass.doQuery.apply(this, arguments);
	},

	onLoad: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onLoad(%o)", arguments);

		Test.ComboBox.superclass.onLoad.apply(this, arguments);
	},

    onSelect: function(record, index) {
		if (window.console && console.log)
            console.log("Ext.form.ComboBox.onSelect(%o)", arguments);
            
        var
            callerArguments,
            e,
            type,
            keyCode;

        for (var caller = this.onSelect.caller; caller; caller = caller.caller) {
            callerArguments = caller.arguments;

            if (!Ext.isEmpty(callerArguments) && (callerArguments[0] instanceof Ext.EventObjectImpl)) {
                e = callerArguments[0];
                type = e ? e.type : null;
                keyCode = e && Ext.isFunction(e.getKey) ? e.getKey() : null;

                if (window.console && console.log)
                    console.log("type: \"%s\", keyCode: %o", type, keyCode);
            }
        }

    	Test.ComboBox.superclass.onSelect.apply(this, arguments);
    },

    onKeyDown: function(e, target, eOpts) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onKeyDown(%o)", arguments);

    	Test.ComboBox.superclass.onKeyDown.apply(this, arguments);
    },

    onKeyUp: function(e, target, eOpts) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onKeyUp(%o)", arguments);

    	Test.ComboBox.superclass.onKeyUp.apply(this, arguments);
	},

    triggerBlur: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.triggerBlur(%o)", arguments);

    	Test.ComboBox.superclass.triggerBlur.apply(this, arguments);
	},

    onBlur: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onBlur(%o)", arguments);

    	Test.ComboBox.superclass.onBlur.apply(this, arguments);
    },

    eventListenerOnKeyDown: function(combo, e) {
		if (window.console && console.log)
			console.log("eventListenerOnKeyDown(%o)", arguments);
    },

    eventListenerOnKeyUp: function(combo, e) {
		if (window.console && console.log)
			console.log("eventListenerOnKeyUp(%o) selectedIndex=%i", arguments, combo.selectedIndex);
    },

    eventListenerOnKeyPress: function(combo, e) {
		if (window.console && console.log)
			console.log("eventListenerOnKeyPress(%o)", arguments);
    },

    eventListenerOnSpecialKey: function(combo, e) {
		if (window.console && console.log)
			console.log("eventListenerOnSpecialKey(%o)", arguments);
	},

	eventListenerOnBlur: function(combo, e) {
		if (window.console && console.log)
			console.log("eventListenerOnBlur(%o)", arguments);
    }
});
Ext.reg("testcombo", Test.ComboBox);

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		beforeselect = function(combo, record, index) {
			if (window.console && console.log)
				console.log("beforeselect(%o) store.data.length=%i", arguments, combo.store.data.length);
		},
		select = function(combo, record, index) {
			if (window.console && console.log)
				console.log("select(%o) store.data.length=%i", arguments, combo.store.data.length);
		},
		data = [
			[ 1, "Record# 1" ],
			[ 2, "Record# 2" ],
			[ 3, "Record# 3" ],
			[ 4, "Record# 4" ],
			[ 5, "aaaaaaaaa" ],
			[ 6, "abbbbbbbb" ],
			[ 7, "abccccccc" ]
		],
		store1 = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			data: data
		}),
		store2 = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			data: data
		}),
		store3 = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			data: data
		}),
		combobox1 = new Test.ComboBox({
			store: store1,
			displayField: "name",
			valueField: "id",
			mode: "local",
			maxHeight: 500
		}),
		combobox2 = new Test.ComboBox({
			store: store2,
			displayField: "name",
			valueField: "id",
			mode: "local",
			maxHeight: 500
		}),
		toolBar = new Ext.Toolbar({
			region: "north",
			height: 25,
			items: [
				combobox1,
				combobox2,
				"->",
				{
					text: "blur()",
					handler: function(btn, e){
						combobox1.blur();
					}
				}, {
					text: "triggerBlur()",
					handler: function(btn, e){
						combobox1.triggerBlur();
					}
				}
			],
			listeners: {
				afterlayout: function(tb, layout) {
					var td;

					if (Ext.isEmpty(td = tb.getEl().query(".x-toolbar-left")))
						return;

					Ext.get(td = td[0]).on("click", function(e, target, opt){
						if (td.id == target.id) {
							if (window.console && console.log)
								console.log(".x-toolbar-left.click(%o)", arguments);
						}
					});
				}
			}
		}),
		colModel = new Ext.grid.ColumnModel({
			columns: [
				{ dataIndex: "id", header: "Id" },
				{ dataIndex: "name", header: "name" }
			]
		}),
		grid = new Ext.grid.GridPanel({
			region: "center",
			store: store3,
			colModel: colModel,
			listeners: {
				columnresize: function (columnIndex, newSize) {
					if (window.console && console.log)
						console.log("Ext.grid.GridPanel.columnresize(%o)", arguments);

					combobox1.setWidth(newSize);
				}
			}
		}),
		viewport = new Ext.Viewport({
			layout: "border",
			items: [
				toolBar,
				grid
			]
		});

	combobox1.on({
		beforeselect: beforeselect,
		select: select
	});
});
