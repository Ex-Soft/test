function getSummary(v, record) {
	return record.data.price*record.data.quantity;
}

Ext.define("Order", {
	extend: "Ext.data.Model",
	idProperty: "product_id",
	fields: [
		{ name: "product_id", type: "int" },
		"name",
		{ name: "price", type: "float" },
		{ name: "quantity", type: "float" },
		{ name: "summary", type: "float", convert: getSummary }
	]
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = new Ext.data.ArrayStore({
			model: "Order",
			data: [
				[ 1, "Good# 1", 10, 1 ],
				[ 2, "Good# 2", 20, 2 ],
				[ 3, "Good# 3", 30, 3 ]
			]
		}),
		addToCart = function(pi, n, p, q) {
			var
				rec;

			if(rec=(store.getById(pi)))
			{
				rec.set("quantity",rec.get("quantity")+q);
				rec.set("summary",rec.get("price")*rec.get("quantity"));
			}
			else
				store.add({product_id: pi, name: n, price: p, quantity: q, summary: p*q});
		};

	store.each(function(r) {
		if(window.console && console.log)
			console.log("product_id=%i name=\"%s\" price=%f quantity=%f summary=%f", r.get("product_id"), r.get("name"), r.get("price"), r.get("quantity"), r.get("summary"));
	});

	addToCart(1, "Good# 1", 10, 2);
	addToCart(4, "Good# 4", 40, 4);

	store.each(function(r) {
		if(window.console && console.log)
			console.log("product_id=%i name=\"%s\" price=%f quantity=%f summary=%f", r.get("product_id"), r.get("name"), r.get("price"), r.get("quantity"), r.get("summary"));
	});
});