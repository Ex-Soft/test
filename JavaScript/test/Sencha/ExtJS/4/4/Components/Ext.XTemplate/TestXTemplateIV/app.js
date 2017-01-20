Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		data = {
			name: "Don Griffin",
			title: "Senior Technomage",
			company: "Sencha Inc.",
			drinks: ["Coffee", "Water", "More Coffee"],
			kids: [
				{ name: "Aubrey", age: 17 },
				{ name: "Joshua", age: 13 },
				{ name: "Cale", age: 10 },
				{ name: "Nikol", age: 5 },
				{ name: "Solomon", age: 0 }
			]
		},
		tpl;

	tpl = new Ext.XTemplate(
		"<div>Kids: ",
			"<tpl for=\".\">",
				"<p>{#}. {name}</p>",
			"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div1"), data.kids);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<p>Title: {title}</p>",
		"<p>Company: {company}</p>",
		"<div>Kids: ",
			"<tpl for=\"kids\">",
				"<p>{name}</p>",
			"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div2"), data);

	tpl = new Ext.XTemplate(
		"<p>{name}\'s favorite beverages:</p>",
		"<tpl for=\"drinks\">",
			"<div> - {.}</div>",
		"</tpl>"
	);
	tpl.overwrite(Ext.get("div3"), data);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<tpl if=\"age &gt; 1\">",
				"<p>{name}</p>",
				"<p>Dad: {parent.name}</p>",
			"</tpl>",
		"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div4"), data);

	tpl = new Ext.XTemplate(
		"<dl>",
			"<tpl foreach=\".\">",
				"<dt>{$}</dt>", // the special **`{$}`** variable contains the property name
				"<dd>{.}</dd>", // within the loop, the **`{.}`** variable is set to the property value
			"</tpl>",
		"</dl>"
	);
	//tpl.overwrite(Ext.get("div5"), data); // Available since: Ext 4.1.2

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<tpl if=\"age &gt; 1\">",
				"<p>{name}</p>",
			"</tpl>",
		"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div6"), data);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<div>{name} is a ",
			"<tpl if=\"age &gt;= 13\">",
		            "<p>teenager</p>",
			"<tpl elseif=\"age &gt;= 2\">",
				"<p>kid</p>",
			"<tpl else>",
				"<p>baby</p>",
			"</tpl>",
			"</div>",
		"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div7"), data);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<div>{name} is a ",
			"<tpl switch=\"name\">",
				"<tpl case=\"Aubrey\" case=\"Nikol\">",
					"<p>girl</p>",
				"<tpl default>",
					"<p>boy</p>",
			"</tpl>",
			"</div>",
		"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div8"), data);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<div>{name} is a ",
				"<tpl if=\"name==&quot;Aubrey&quot; || name==&quot;Nikol&quot;\">",
					"<p>girl</p>",
				"<tpl else>",
					"<p>boy</p>",
				"</tpl>",
			"</div>",
		"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div9"), data);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<tpl if=\"age &gt; 1\">",
				"<p>{#}: {name}</p>",
				"<p>In 5 Years: {age+5}</p>",
				"<p>Dad: {parent.name}</p>",
			"</tpl>",
		"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div10"), data);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<p>Company: {[values.company.toUpperCase() + \", \" + values.title]}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<div class=\"{[xindex % 2 === 0 ? \"even\" : \"odd\"]}\">",
				"{name}",
			"</div>",
		"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div11"), data);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<p>Company: {[values.company.toUpperCase() + \", \" + values.title]}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<div>",
				"{% if (xindex % 2 === 0) continue; %}",
					"{name}",
				"{% if (xindex > 100) break; %}",
			"</div>",
		"</tpl>",
		"</div>"
	);
	tpl.overwrite(Ext.get("div12"), data);

	tpl = new Ext.XTemplate(
		"<p>Name: {name}</p>",
		"<div>Kids: ",
		"<tpl for=\"kids\">",
			"<tpl if=\"this.isGirl(name)\">",
				"<p>Girl: {name} - {age}</p>",
			"<tpl else>",
				"<p>Boy: {name} - {age}</p>",
			"</tpl>",
			"<tpl if=\"this.isBaby(age)\">",
				"<p>{name} is a baby!</p>",
			"</tpl>",
		"</tpl>",
		"</div>",
		{
			disableFormats: true,
			isGirl: function(name) {
				return name == "Aubrey" || name == "Nikol";
			},
			isBaby: function(age) {
				return age < 1;
			}
		}
	);
	tpl.overwrite(Ext.get("div13"), data);

	data = {
		name: "Child"
	};
	data.parentRef = { name: "Parent" };
	data.parentRef.parentRef = { name: "Grandparent" };
	tpl = new Ext.XTemplate(
		"<tpl if=\"parentRef\">",
			"{[this.recursive(values)]} &gt; ",
		"</tpl>",
		"{name}",
		{
			recursive: function(values) {
				return this.apply(values.parentRef);
			}
		}
	);
	tpl.overwrite(Ext.get("div14"), data);
});