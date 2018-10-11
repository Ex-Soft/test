Ext.BLANK_IMAGE_URL = "../../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	autoSelect: false,

	groupRe: /([^:]+)(:?)(.*)/,
	groupField: "",

	onSelect: function(record, index) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.oSelect(%o)", arguments);

		Test.ComboBox.superclass.onSelect.apply(this, arguments);
		
		if (record.get("group") == "tag")
			this.doQuery(this.lastRawValue = record.get("value"));
	},

    select: function(index, scrollIntoView) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.select(%o)", arguments);

		var oldRecord = this.selectedIndex != -1 ? this.store.getAt(this.selectedIndex) : null,
			newRecord = this.store.getAt(index);

		if ((!oldRecord || oldRecord.get("group") != "tag") && newRecord.get("group") == "tag")
			this.lastRawValue = this.getRawValue();

		if ((!oldRecord || oldRecord.get("group") == "tag") && newRecord.get("group") != "tag")
			this.setRawValue(this.lastRawValue);

		if (newRecord.get("group") == "tag")
			this.setRawValue(newRecord.get("value"));

    	Test.ComboBox.superclass.select.apply(this, arguments);
	},

    selectNext: function(index, scrollIntoView) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.selectNext(%o)", arguments);

    	Test.ComboBox.superclass.selectNext.apply(this, arguments);
	},

    selectPrev: function(index, scrollIntoView) {
		if (window.console && console.log)
			console.log("Ext.form.ComboBox.selectPrev(%o)", arguments);

    	Test.ComboBox.superclass.selectPrev.apply(this, arguments);
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
        }, filters;
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
						if(filters = this.getFilters(q)){
							this.store.filter(filters);
						}else{
							this.store.filter(this.displayField, q, true);
						}
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
	},

	getFilters: function(q){
		var me = this,
			match = q.match(me.groupRe),
			result = null;

		if (!Ext.isEmpty(me.groupField) && !Ext.isEmpty(match) && match.length > 3 && match[2] == ":") {
			result = [{ property: me.groupField, value: match[1], anyMatch: true, caseSensitive: false, exactMatch: false }];
			
			if (!Ext.isEmpty(match[3]))
				result.push({ property: me.displayField, value: match[3], anyMatch: true, caseSensitive: false, exactMatch: false });
		}

		return result;			
	}
});
Ext.reg("testcombo", Test.ComboBox);

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			fields: [
				{ name: "id", type: "string" },
                { name: "group", type: "string" },
                { name: "groupPriority", type: "int" },
                { name: "groupName", type: "string" },
                { name: "value", type: "string" }
			],
			data : [
				[ -7, "tag", 0, "", "envowner:" ],
				[ -6, "tag", 0, "", "region:" ],
				[ -5, "tag", 0, "", "envgroup:" ],
				[ -4, "tag", 0, "", "ip:" ],
				[ -3, "tag", 0, "", "node:" ],
				[ -2, "tag", 0, "", "nodegroup:" ],
				[ -1, "tag", 0, "", "env:" ],
				[ 1, "env", 1, "Environment", "Env# 1" ],
				[ 2, "env", 1, "Environment", "Env# 2" ],
				[ 3, "env", 1, "Environment", "Env# 3" ],
				[ 4, "env", 1, "Environment", "Env# 4" ],
				[ 5, "nodegroup", 2, "Node Group", "Node Group# 1" ],
				[ 6, "nodegroup", 2, "Node Group", "Node Group# 2" ],
				[ 7, "nodegroup", 2, "Node Group", "Node Group# 3" ],
				[ 8, "nodegroup", 2, "Node Group", "Node Group# 4" ],
				[ 9, "node", 3, "Node", "Node# 1" ],
				[ 10, "node", 3, "Node", "Node# 2" ],
				[ 11, "node", 3, "Node", "Node# 3" ],
				[ 12, "node", 3, "Node", "Node# 4" ],
				[ 13, "ip", 4, "IP", "IP# 1" ],
				[ 14, "ip", 4, "IP", "IP# 2" ],
				[ 15, "ip", 4, "IP", "IP# 3" ],
				[ 16, "ip", 4, "IP", "IP# 4" ],
				[ 17, "envgroup", 5, "Groups", "Group# 1" ],
				[ 18, "envgroup", 5, "Groups", "Group# 2" ],
				[ 19, "region", 6, "Regions", "Region# 1" ],
				[ 20, "region", 6, "Regions", "Region# 2" ],
				[ 21, "envowner", 7, "Owners", "Owner# 1" ],
				[ 22, "envowner", 7, "Owners", "Owner# 2" ]
			],
			hasMultiSort: true,
			multiSortInfo: {
				sorters: [
					{ field: "groupPriority", direction: "ASC" },
					{ field: "value", direction: "ASC" }
				]
			}
		}),
		combobox1 = new Test.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			groupField: "group",
			mode: "local",
			hideTrigger: true
		})
		panel = new Ext.Panel({
			layout: {
				type: "hbox"
			},
			items: [
				combobox1
			],
			listeners: {
				afterrender: function(panel) {
					combobox1.focus();
				}
			},
			renderTo: Ext.getBody()
		});
});
