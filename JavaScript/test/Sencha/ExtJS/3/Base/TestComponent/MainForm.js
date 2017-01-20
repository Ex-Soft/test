Ext.BLANK_IMAGE_URL="../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		TestComponentDebugWComment1=new Test.ComponentDebugWComment(),
		TestComponentDebugWComment2=new Test.ComponentDebugWComment({ id: "_Test_from_new_Component_", url: "http://google.com/" }),
		TestComponent1=new Test.Component(),
		TestComponent2=new Test.Component({ id: "_Test_from_new_Component_" });

	alert(TestComponentDebugWComment1.id);
	alert(TestComponentDebugWComment2.id);
	alert(TestComponent1.id);
	alert(TestComponent2.id);

	var
		TestStore=new Test.Store(),
		TestWindow=new Test.Window();
});
