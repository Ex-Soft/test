Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBoxWithMultiFilter = Ext.extend(Ext.form.ComboBox, {
	groupRe: /([^:]+)(:?)(.*)/,
	groupField: "",

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

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			fields: [ "id", "group", "value"],
			data : [
				[ 1, "", "Line# 1" ],
				[ 2, "", "Line# 1" ],
				[ 3, "g1", "aaaaaaa" ],
				[ 4, "g1", "abbbbbb" ],
				[ 5, "g1", "abccccc" ],
				[ 6, "g2", "abcdddd" ],
				[ 7, "g2", "abcdeee" ],
				[ 8, "g2", "abcdeff" ],
				[ 9, "g3", "abcdefg" ]
			]
		}),
		combobox1 = new Test.ComboBoxWithMultiFilter({
			store: store,
			valueField: "id",
			displayField: "value",
			groupField: "group",
			mode: "local"
		})
		panel = new Ext.Panel({
			layout: {
				type: "hbox"
			},
			items: [
				combobox1
			],
			renderTo: Ext.getBody()
		});
});
