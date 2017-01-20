// http://www.sencha.com/forum/showthread.php?95486-Cursor-Position-in-TextField&p=451800&viewfull=1#post451800

Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.override(Ext.form.field.TextArea, {
		insertAtCursor: function(value) {
			if(window.console && console.log)
				console.log("Ext.form.field.TextArea.insertAtCursor(%o)", arguments);

			var
				el = this.inputEl.dom,
				sel,
				pos;

			if(typeof document.selection !== "undefined")
			{
				el.focus();
				sel = document.selection.createRange();
				sel.text = value;
			}
			else
			{
				pos = el.selectionStart;
				el.value = el.value.substring(0, pos) + value + el.value.substring(pos);
			}
		}
	});

	var
		textArea = Ext.create("Ext.form.field.TextArea", {
			renderTo: Ext.getBody()
		});

	textArea.insertAtCursor("value");
});
