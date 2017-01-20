Ext.onReady(function() {
	var
		div = document.createElement("div"),
		lbl = new Ext.form.Label({ text: "йцукен" });

	lbl.render(div);

	document.body.appendChild(div);
});