Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	var
		p = Ext.create("TestPanel", {
			renderTo: Ext.getBody()
		}),
		dp = Ext.create("DerivedTestPanel", {
			renderTo: Ext.getBody()
		});

	p.foo1(100);
	p.foo2(100);
	dp.foo1(1000);
	dp.foo2(1000);
});
