Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
    Ext.QuickTips.init();

    var
        store = new Ext.data.JsonStore({
			url: "Data.aspx",
			root: "rows",
			idProperty: "Id",
			successProperty: "success",
			totalProperty: "count",
			fields: [
				{ name: "Id", type: "int" },
				"Name",
				{ name: "Salary", type: "float" },
				{ name: "Dep", type: "int" },
				{ name: "BirthDate", type: "date", dateFormat: "c" }
			]
		}),
		tpl = new Ext.XTemplate(
			"<tpl for=\".\">",
				"<div>",
					"<span>{[values.BirthDate ? values.BirthDate.format(\"d.m.Y\") : \"\"]}</span> <span>{Name}</span><br/><span>{[fm.ellipsis(values.Name.replace(/<.*?>/ig,\"\"),9)]}</span> <a href=\"http://google.com/#q={Name}\" target=\"_blank\">More >>></a></div>",
			"</tpl>",
			"<div class=\"x-clear\"></div>"
		),
		dv = new Ext.DataView({
			region: "center",
			store: store,
			tpl: tpl,
			autoHeight: true,
			multiSelect: true,
			overClass: "x-view-over",
			itemSelector: "div.thumb-wrap",
			emptyText: "No images to display"
		}),
		tp = new Ext.TabPanel({
			//activeTab: 0,
			items: [
			],
			buttons: [{
				text: "Get cookie",
				handler: function() {
					var
						c,
						cv,
						pos,
						separator="&",
						signature="Value1=";

					if(c=Ext.util.Cookies.get("AjaxRequestHandler"))
					{
						cv=Ext.urlDecode(c);

						if(c.indexOf(separator)!=-1)
						{
							cv=c.split(separator);
							for(var i=0; i<cv.length; ++i)
								if((pos=cv[i].indexOf(signature))!=-1)
								{
									c=cv[i].substring(pos+signature.length);
									break;
								}
						}
						c=Date.parseDate(c, "c");
						Ext.Msg.alert("Ext.Ajax.request", c);
					}
				}
			}, {
				text: "Set cookie",
				handler: function() {
					var
						c,
						cv,
						CookieName;
						
					cv = (c=Ext.util.Cookies.get(CookieName="AjaxRequestHandler")) ? Ext.urlDecode(c) : {};
					cv.Value1=1;
					cv.Value2=2;
					cv.Value33=33;
					//cv.Value2=new Date();
					c=Ext.urlEncode(cv);
					//Ext.util.Cookies.set("AjaxRequestHandler",c);
					document.cookie=CookieName+"="+Ext.urlEncode(cv)+";expires="+new Date().add(Date.YEAR,1).toGMTString();
				}
			}, {
				text: "Clear cookie",
				handler: function() {
					Ext.util.Cookies.clear("AjaxRequestHandler");
				}
			}, {
				text: "Ext.Ajax.request",
				handler: function() {
					Ext.Ajax.request({
						url: "AjaxRequest.aspx",
						method: "POST",
						success: function(result, request) {
							Ext.Msg.alert("Ext.Ajax.request", "success");
						},
						failure: function(result, request) {
							Ext.Msg.alert("Ext.Ajax.request", "failure");
						}
					});
				}
			}]
		}),
		viewport = new Ext.Viewport({
			layout: "fit",
			items: [ tp ]
		});

	store.load();
});