/* http://blog.extjs.eu/know-how/factory-functions-in-ext-extensions/ */
/* http://blog.extjs.eu/know-how/writing-a-big-application-in-ext/ */
/* http://blog.extjs.eu/know-how/writing-a-big-application-in-ext-part-2/ */
/* http://blog.extjs.eu/know-how/writing-a-big-application-in-ext-part-3/ */

Ext.BLANK_IMAGE_URL = "./ext/resources/images/default/s.gif";
Ext.ns("App");

Ext.onReady(function() {
	Ext.QuickTips.init();

	App.Layout = new App.Components.Layout();
});
