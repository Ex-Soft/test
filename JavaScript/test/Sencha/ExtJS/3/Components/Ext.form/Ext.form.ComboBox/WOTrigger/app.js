Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBoxWOTriggerV1 = Ext.extend(Ext.form.ComboBox, {
	initComponent: function () {
		if (window.console && console.log)
			console.log("ComboBoxWOTriggerV1.initComponent(%o)", arguments);

		Test.ComboBoxWOTriggerV1.superclass.initComponent.apply(this, arguments);

		this.on({
			render: function(cmp) {
				if (window.console && console.log)
					console.log("ComboBoxWOTriggerV1.render(%o)", arguments);

				this.getEl().on("click", Ext.createDelegate(this.onClick, this, arguments));
			}
		});
	},

	onClick: function(cmp) {
		if (window.console && console.log)
			console.log("ComboBoxWOTriggerV1.onClick(%o)", arguments);

		if (this.isExpanded())
			return;

		this.onTriggerClick();
	},

    /**
     * Execute a query to filter the dropdown list.  Fires the {@link #beforequery} event prior to performing the
     * query allowing the query action to be canceled if needed.
     * @param {String} query The SQL query to execute
     * @param {Boolean} forceAll <tt>true</tt> to force the query to execute even if there are currently fewer
     * characters in the field than the minimum specified by the <tt>{@link #minChars}</tt> config option.  It
     * also clears any filter previously saved in the current store (defaults to <tt>false</tt>)
     */
    doQuery : function(q, forceAll){
        q = Ext.isEmpty(q) ? '' : q;
        var qe = {
            query: q,
            forceAll: forceAll,
            combo: this,
            cancel:false
        };
        if(this.fireEvent('beforequery', qe)===false || qe.cancel){
            return false;
        }
        q = qe.query;
        forceAll = qe.forceAll;
        if(forceAll === true || (q.length >= this.minChars)){
            if(this.lastQuery !== q){
                this.lastQuery = q;
                if(this.mode == 'local'){
                    this.selectedIndex = -1;
                    if(forceAll){
                        this.store.clearFilter();
                    }else{
                        this.store.filter(this.displayField, new RegExp(Ext.escapeRe(q), "i"), true);
                    }
                    this.onLoad();
                }else{
                    this.store.baseParams[this.queryParam] = q;
                    this.store.load({
                        params: this.getParams(q)
                    });
                    this.expand();
                }
            }else{
                this.selectedIndex = -1;
                this.onLoad();
            }
        }
    }
});

Test.ComboBoxWOTriggerV2 = Ext.extend(Ext.form.ComboBox, {
	onRender: function (ct, position) {
		if (window.console && console.log)
			console.log("ComboBoxWOTriggerV2.onRender(%o)", arguments);

		Test.ComboBoxWOTriggerV2.superclass.onRender.call(this, ct, position);

		this.getEl().on("click", Ext.createDelegate(this.onClick, this, arguments));
	},

	onClick: function(cmp) {
		if (window.console && console.log)
			console.log("ComboBoxWOTriggerV2.onClick(%o)", arguments);

		if (this.isExpanded())
			return;

		this.onTriggerClick();
	},

    /**
     * Execute a query to filter the dropdown list.  Fires the {@link #beforequery} event prior to performing the
     * query allowing the query action to be canceled if needed.
     * @param {String} query The SQL query to execute
     * @param {Boolean} forceAll <tt>true</tt> to force the query to execute even if there are currently fewer
     * characters in the field than the minimum specified by the <tt>{@link #minChars}</tt> config option.  It
     * also clears any filter previously saved in the current store (defaults to <tt>false</tt>)
     */
    doQuery : function(q, forceAll){
        q = Ext.isEmpty(q) ? '' : q;
        var qe = {
            query: q,
            forceAll: forceAll,
            combo: this,
            cancel:false
        };
        if(this.fireEvent('beforequery', qe)===false || qe.cancel){
            return false;
        }
        q = qe.query;
        forceAll = qe.forceAll;
        if(forceAll === true || (q.length >= this.minChars)){
            if(this.lastQuery !== q){
                this.lastQuery = q;
                if(this.mode == 'local'){
                    this.selectedIndex = -1;
                    if(forceAll){
                        this.store.clearFilter();
                    }else{
                        this.store.filter(this.displayField, new RegExp(Ext.escapeRe(q), "i"), true);
                    }
                    this.onLoad();
                }else{
                    this.store.baseParams[this.queryParam] = q;
                    this.store.load({
                        params: this.getParams(q)
                    });
                    this.expand();
                }
            }else{
                this.selectedIndex = -1;
                this.onLoad();
            }
        }
    }
});

Test.ComboBoxWOTriggerV3 = Ext.extend(Ext.form.ComboBox, {
	initEvents: function() {
		if (window.console && console.log)
			console.log("ComboBoxWOTriggerV3.initEvents(%o)", arguments);

		Test.ComboBoxWOTriggerV3.superclass.initEvents.call(this);

		this.getEl().on("click", Ext.createDelegate(this.onClick, this));
	},

	onClick: function(e, el, eOpts) {
		if (window.console && console.log)
			console.log("ComboBoxWOTriggerV3.onClick(%o)", arguments);

		if (this.isExpanded())
			return;

		this.onTriggerClick();
	},

    /**
     * Execute a query to filter the dropdown list.  Fires the {@link #beforequery} event prior to performing the
     * query allowing the query action to be canceled if needed.
     * @param {String} query The SQL query to execute
     * @param {Boolean} forceAll <tt>true</tt> to force the query to execute even if there are currently fewer
     * characters in the field than the minimum specified by the <tt>{@link #minChars}</tt> config option.  It
     * also clears any filter previously saved in the current store (defaults to <tt>false</tt>)
     */
    doQuery : function(q, forceAll){
        q = Ext.isEmpty(q) ? '' : q;
        var qe = {
            query: q,
            forceAll: forceAll,
            combo: this,
            cancel:false
        };
        if(this.fireEvent('beforequery', qe)===false || qe.cancel){
            return false;
        }
        q = qe.query;
        forceAll = qe.forceAll;
        if(forceAll === true || (q.length >= this.minChars)){
            if(this.lastQuery !== q){
                this.lastQuery = q;
                if(this.mode == 'local'){
                    this.selectedIndex = -1;
                    if(forceAll){
                        this.store.clearFilter();
                    }else{
                        this.store.filter(this.displayField, new RegExp(Ext.escapeRe(q), "i"), true);
                    }
                    this.onLoad();
                }else{
                    this.store.baseParams[this.queryParam] = q;
                    this.store.load({
                        params: this.getParams(q)
                    });
                    this.expand();
                }
            }else{
                this.selectedIndex = -1;
                this.onLoad();
            }
        }
    }
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		f = function(combobox) {
			if (window.console && console.log)
				console.log("f(%o)", arguments);

			if (combobox.isExpanded())
				return;

			combobox.onTriggerClick();
		},
		ff = function(e, el, eOpt) {
			if (window.console && console.log)
				console.log("ff(%o)", arguments);

			var cmp;

			if (Ext.isEmpty(el.id) || !(cmp = Ext.getCmp(el.id)) || cmp.isExpanded())
				return;

			/*this*/cmp.onTriggerClick();
		},
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
		combobox1 = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true,
			listeners: {
				render: function(cmp) {
					if (window.console && console.log)
						console.log("ComboBox.render(%o)", arguments);

					var el;

					if (!(el = cmp.getEl()))
						return;

					el.on("click", Ext.createDelegate(f, cmp, arguments));
				}
			}
		}),
		combobox2 = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true,
			listeners: {
				render: function(cmp) {
					if (window.console && console.log)
						console.log("ComboBox.render(%o)", arguments);

					var el;

					if (!(el = cmp.getEl()))
						return;

					el.on("click", ff, cmp);
				}
			}
		}),
		combobox3 = new Test.ComboBoxWOTriggerV1({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true
		}),
		combobox4 = new Test.ComboBoxWOTriggerV2({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true
		}),
		combobox5 = new Test.ComboBoxWOTriggerV3({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			hideTrigger: true
		}),
		panel = new Ext.Panel({
			layout: {
				type: "hbox"
			},
			items: [
				combobox1,
				combobox2,
				combobox3,
				combobox4,
				combobox5
			],
			renderTo: Ext.getBody()
		});
});
