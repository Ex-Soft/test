Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.window.Window", {
		title: "title",
		height: 200,
		width: 200,
		//html: "blah-blah-blah",
		html: "blah-blah-blah<br/><br/>blah-blah-blah",
		dockedItems: [{
			xtype: "toolbar",
			dock: "bottom",
			items: [{
				text: "Select",
				handler: function(btn, e) {
					var
						w,
						range,
						s;

					if(!(w=btn.up("window")))
						return;

					if(document.selection)
					{
						document.selection.empty();

						range=document.body.createTextRange();
						range.moveToElementText(w.body.dom);
						range.select();
					}
					else if(window.getSelection
						&& (s = window.getSelection())
						&& (range = document.createRange()))
					{
						if(s.rangeCount>0)
							s.removeAllRanges();

						//range.selectNode(w.body.dom.firstChild);
						range.setStart(w.body.dom.childNodes[0], 0);
						range.setEnd(w.body.dom.childNodes[3], w.body.dom.childNodes[3].length);
						s.addRange(range);
					}
				}
			}]
		}],
		autoShow: true,
		renderTo: Ext.getBody()
	});
});