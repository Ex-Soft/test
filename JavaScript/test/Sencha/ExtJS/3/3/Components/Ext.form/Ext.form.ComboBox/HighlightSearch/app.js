Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBoxWithHighlightSearch = Ext.extend(Ext.form.ComboBox, {
	initComponent: function() {
		Test.ComboBoxWithHighlightSearch.superclass.initComponent.call(this);

		this.tpl = new Ext.XTemplate("<tpl for=\".\"><div class=\"x-combo-list-item\">{[this.highlightSearch(values."+ this.displayField +")]}</div></tpl>", {
			highlightSearch: function(value) {
				if (window.console && console.log)
					console.log("highlightSearch(%o)", arguments);
	
				return !Ext.isEmpty(this.lastQuery) ? value.replace(new RegExp(this.lastQuery, "ig"), "<span class=\"searching\">$&</span>") : value;
			}
		});
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
                this.tpl.lastQuery = this.lastQuery = q;
                if(this.mode == 'local'){
                    this.selectedIndex = -1;
                    if(forceAll){
                        this.store.clearFilter();
                    }else{
                        this.store.filter(this.displayField, q, true);
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
		combobox1 = new Test.ComboBoxWithHighlightSearch({
			store: store,
			valueField: "id",
			displayField: "value",
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
