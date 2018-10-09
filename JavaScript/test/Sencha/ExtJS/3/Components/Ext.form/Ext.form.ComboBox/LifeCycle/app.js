Ext.BLANK_IMAGE_URL="../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	initComponent: function() {
		if (window.console && console.log)
			console.log("initComponent(%o)", arguments);

        Test.ComboBox.superclass.initComponent.apply(this, arguments);

        if (window.console && console.log)
            console.log("enableKeyEvents: %o", this.enableKeyEvents);

        this.on({
            keydown: this.on_KeyDown,
            keyup: this.on_KeyUp,
            keypress: this.on_KeyPress,
            specialkey: this.on_SpecialKey,
            scope: this
        });
    },

	initEvents: function() {
        if (window.console && console.log)
            console.log("initEvents(%o)", arguments);

		Test.ComboBox.superclass.initEvents.apply(this, arguments);
    },

	initTrigger: function() {
        if (window.console && console.log)
            console.log("initTrigger(%o)", arguments);

		Test.ComboBox.superclass.initTrigger.apply(this, arguments);
	},

	onTriggerClick: function(e, target, eOpts) {
		if (window.console && console.log)
			console.log("onTriggerClick(%o)", arguments);

    	Test.ComboBox.superclass.onTriggerClick.apply(this, arguments);
    },

    onViewClick: function(doFocus) {
		if (window.console && console.log)
			console.log("onViewClick(%o)", arguments);

    	Test.ComboBox.superclass.onViewClick.apply(this, arguments);
    },

    onSelect: function(record, index) {
		if (window.console && console.log)
            console.log("onSelect(%o)", arguments);
            
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
                    console.log("type: \"%s\", keyCode: %i", type, keyCode);
            }
        }

    	Test.ComboBox.superclass.onSelect.apply(this, arguments);
    },

    onKeyDown: function(record, index) {
		if (window.console && console.log)
			console.log("onKeyDown(%o)", arguments);

    	Test.ComboBox.superclass.onKeyDown.apply(this, arguments);
    },

    onKeyUp: function(record, index) {
		if (window.console && console.log)
			console.log("onKeyUp(%o)", arguments);

    	Test.ComboBox.superclass.onKeyUp.apply(this, arguments);
    },

    on_KeyDown: function(record, index) {
		if (window.console && console.log)
			console.log("on_KeyDown(%o)", arguments);
    },

    on_KeyUp: function(record, index) {
		if (window.console && console.log)
			console.log("on_KeyUp(%o)", arguments);
    },

    on_KeyPress: function(record, index) {
		if (window.console && console.log)
			console.log("on_KeyPress(%o)", arguments);
    },

    on_SpecialKey: function(record, index) {
		if (window.console && console.log)
			console.log("on_SpecialKey(%o)", arguments);
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
		combobox = new Test.ComboBox({
			store: new Ext.data.ArrayStore({
				autoDestroy: true,
				idIndex: 0,
				fields: [
					{ name: "id", type: "int" },
					"name"
				],
				data: [
					[ 1, "Record# 1" ],
					[ 2, "Record# 2" ],
					[ 3, "Record# 3" ],
					[ 4, "Record# 4" ]
				]
			}),
			displayField: "name",
			valueField: "id",
            mode: "local",
            enableKeyEvents: true,
			renderTo: Ext.getBody()
		});
});
