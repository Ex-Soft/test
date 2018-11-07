Ext.BLANK_IMAGE_URL="../../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	trigger1Class: "x-form-clear-trigger",
	trigger2Class: "x-form-arrow-trigger",

	constructor: function (config) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.constructor(%o)", arguments);

		Test.ComboBox.superclass.constructor.apply(this, arguments);
	},

	initComponent: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.initComponent(%o)", arguments);

		Test.ComboBox.superclass.initComponent.apply(this, arguments);

		this.triggerConfig = {
            tag: "span", cls: "x-form-twin-triggers", cn: [
			{tag: "img", src: Ext.BLANK_IMAGE_URL, alt: "", cls: "x-form-trigger " + this.trigger1Class + " testClass"},
			{tag: "img", src: Ext.BLANK_IMAGE_URL, alt: "", cls: "x-form-trigger " + this.trigger2Class + " testClass"}
        ]};
	},

	getTrigger: function(index){
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.getTrigger(%o)", arguments);

        return Array.isArray(this.triggers) && this.triggers.length > index ? this.triggers[index] : undefined;
	},

    afterRender: function(){
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.afterRender(%o)", arguments);

		Test.ComboBox.superclass.afterRender.apply(this, arguments);

        var triggers = this.triggers,
            i = 0,
            len = triggers.length;
            
        for(; i < len; ++i){
            if(this["hideTrigger" + (i + 1)]){
                triggers[i].hide();
            }
        }    
	},

	initTrigger: function() {
        if (window.console && console.log)
            console.log("Ext.form.ComboBox.initTrigger(%o)", arguments);

		// Test.ComboBox.superclass.initTrigger.apply(this, arguments);

		var ts = this.trigger.select(".x-form-trigger", true),
			triggerField = this;
		
		ts.each(function(t, all, index){
			var triggerIndex = "Trigger" + (index + 1);

			t.hide = function(){
				var w = triggerField.wrap.getWidth();
				this.dom.style.display = "none";
				triggerField.el.setWidth(w - triggerField.trigger.getWidth());
				triggerField["hidden" + triggerIndex] = true;
			};

			t.show = function(){
				var w = triggerField.wrap.getWidth();
				this.dom.style.display = "";
				triggerField.el.setWidth(w - triggerField.trigger.getWidth());
				triggerField["hidden" + triggerIndex] = false;
			};

			this.mon(t, "click", this["on" + triggerIndex + "Click"], this, { preventDefault: true });
			t.addClassOnOver("x-form-trigger-over");
			t.addClassOnClick("x-form-trigger-click");
		}, this);
		this.triggers = ts.elements;
	},

	getTriggerWidth: function(){
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.getTriggerWidth(%o)", arguments);

		var widthBySpanGetWidth = Test.ComboBox.superclass.getTriggerWidth.apply(this, arguments);

        var tw = 0;
        Ext.each(this.triggers, function(t, index){
            var triggerIndex = "Trigger" + (index + 1),
				w = t.getWidth();

            if (w === 0 && !this["hidden" + triggerIndex]){
                tw += this.defaultTriggerWidth;
            } else {
                tw += w;
            }
		}, this);
		
		if (window.console && console.log)
			console.log("widthBySpanGetWidth %s= tw", widthBySpanGetWidth == tw ? "=" : "!");

        return tw;
	},

    onDestroy: function() {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onDestroy(%o)", arguments);

        Ext.destroy(this.triggers);
        Test.ComboBox.superclass.onDestroy.apply(this, arguments);
    },

	onRender: function(container, position) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onRender(%o)", arguments);

    	Test.ComboBox.superclass.onRender.apply(this, arguments);
	},

	onTriggerClick: function(e, target, eOpts) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onTriggerClick(%o)", arguments);

    	Test.ComboBox.superclass.onTriggerClick.apply(this, arguments);
	},

	onTrigger1Click: function(e, target, eOpts) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onTrigger1Click(%o)", arguments);
	},

	onTrigger2Click: function(e, target, eOpts) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.onTrigger2Click(%o)", arguments);

		this.onTriggerClick(e, target, eOpts);
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
		data = [
			[ 1, "Record# 1" ],
			[ 2, "Record# 2" ],
			[ 3, "Record# 3" ],
			[ 4, "Record# 4" ],
			[ 5, "aaaaaaaaa" ],
			[ 6, "abbbbbbbb" ],
			[ 7, "abccccccc" ]
		],
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			data: data
		}),
		combobox = new Test.ComboBox({
			store: store,
			displayField: "name",
			valueField: "id",
			mode: "local",
			maxHeight: 500
		}),
		numberFieldWidth = new Ext.form.NumberField({
			value: 300
		}),
		numberFieldTriggerNo = new Ext.form.NumberField({
			value: 0
		}),
		toolBar = new Ext.Toolbar({
			region: "north",
			height: 25,
			items: [
				combobox,
				"-",
				"Width",
				numberFieldWidth,
				"-",
				"Trigger#",
				numberFieldTriggerNo,
				"->",
				{
					text: "setWidth()",
					handler: function(btn, e){
						combobox.setWidth(numberFieldWidth.getValue());
					}
				}, {
					text: "show()",
					handler: function(btn, e){
						combobox.show();
					}
				}, {
					text: "hide()",
					handler: function(btn, e){
						combobox.hide();
					}
				}, {
					text: "trigger.show()",
					handler: function(btn, e){
						var trigger;

						if (!(trigger = combobox.getTrigger(numberFieldTriggerNo.getValue())))
							return;

						trigger.show();
					}
				}, {
					text: "trigger.hide()",
					handler: function(btn, e){
						var trigger;

						if (!(trigger = combobox.getTrigger(numberFieldTriggerNo.getValue())))
							return;

						trigger.hide();
					}
				}, {
					text: "destroy()",
					handler: function(btn, e){
						combobox.destroy();
					}
				}
			],
			renderTo: Ext.getBody()
		});
});
