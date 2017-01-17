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
		viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [ dv ]
		});

	store.load();
});