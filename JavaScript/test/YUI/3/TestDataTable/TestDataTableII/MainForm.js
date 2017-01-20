YUI({filter: "debug"}).use(
	"datatable",
	"datasource-get",
	"datasource-jsonschema",
	"datasource-cache",
function (Y) {
	var
		cols = [
			"Title",
			"Phone",
			{ key: "Rating.AverageRating", label: "Rating" }
		],
		myDataSource = new Y.DataSource.Get({
			source: "http://query.yahooapis.com/v1/public/yql?&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys"
			//source: "data.html"
		});

	myDataSource
		.plug(Y.Plugin.DataSourceJSONSchema, {
			schema: {
				resultListLocator: "query.results.Result",
				resultFields: [ "Title", "Phone", "Rating.AverageRating" ]
			}
		})
		.plug(Y.Plugin.DataSourceCache, {
			max: 3
		});

	var
		table = new Y.DataTable.Base({
			columnset: cols,
			summary: "Pizza places near 98089",
			caption: "Table with JSON data from YQL"
		});

	table.plug(Y.Plugin.DataTableDataSource, {
		datasource: myDataSource
	});

	table.render("#DataTable");

	table.datasource.load({
    		request: "&q=select%20*%20from%20local.search%20where%20zip%3D%2794089%27%20and%20query%3D%27pizza%27"
	});

	if(table)
		;

	//table.datasource.load({
	//	request: "&q=select%20*%20from%20local.search%20where%20zip%3D%2794089%27%20and%20query%3D%27chinese%27"
	//});

	var
		btn = Y.one("#btnLoad");

	if(btn)
		btn.on("click", function(e){
			table.datasource.load({
    				request: "&q=select%20*%20from%20local.search%20where%20zip%3D%2794089%27%20and%20query%3D%27pizza%27"
			});
		});
});