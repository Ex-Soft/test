YUI({filter: "debug"}).use(
	"datatable",
	function (Y) {
		var
			calculate = function (o) {
				var
					cost = o.record.getValue("cost"),
					price = o.record.getValue("price");

				return !isNaN(cost) && !isNaN(price) ? "$" + (price - cost).toFixed(2) : "<em>FREE!!!</em>";
			},
			cols1 = ["id","name","price"],
			cols2 = [
				{ key: "id", label: "ID" },
				{ key: "name", label: "Name" },
				{ key: "price", label: "Price", emptyCellValue: "<em>FREE!!!</em>", formatter: "\${value}" },
				{ key: "profit", formatter: calculate }
			],
			cols3 = [
				{
					key: "id",
					label: "Mfr Part ID",
					abbr: "ID"
				},
				{
					key: "name",
					label: "Mfr Part Name",
					abbr: "Name"
				},
				{
					key: "price",
					label: "Wholesale Price",
					abbr: "Price"
				}
			],
			nestedCols = [
				{
					label: "Train Schedule",
					children: [ // Use children to define nested relationships
						{ key: "track" },
						{
							label: "Route",
							children: [
								{ key: "from" },
								{ key: "to" }
							]
						}
					]
				}
			],
			data1 = [
				{id:"ga-3475", name:"gadget", price:"$6.99", cost:"$5.99"},
				{id:"sp-9980", name:"sprocket", price:"$3.75", cost:"$3.25"},
				{id:"wi-0650", name:"widget", price:"$4.25", cost:"$3.75"}
			],
			data2 = [
				{id:"ga-3475", name:"gadget", price:6.99, cost:5.99},
				{id:"sp-9980", name:"sprocket", price:3.75, cost:3.25},
				{id:"wi-0650", name:"widget", /*price:4.25,*/ cost:3.75}
			],
			nestedData = [
				{ track: "1", from: "Paris", to: "Amsterdam" },
				{ track: "2", from: "Paris", to: "London" },
				{ track: "3", from: "Paris", to: "Zurich" }
			],
			table1 = new Y.DataTable.Base({
				columnset: cols1,
				recordset: data1
			}).render("#DataTable1"),
			table2 = new Y.DataTable.Base({
				columnset: cols2,
				recordset: data2
			}).render("#DataTable2"),
			table3 = new Y.DataTable.Base({
				columnset: cols3,
				recordset: data1
			}).render("#DataTable3"),
			nestedTable = new Y.DataTable.Base({
				columnset: nestedCols,
				recordset: nestedData,
				summary: "Train schedule",
				caption: "Table with nested column headers"
			}).render("#DataTableNested");
});