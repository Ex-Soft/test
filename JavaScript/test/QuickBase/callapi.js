(function(win) {
	if(window.console && console.log)
	{
		console.log(document.location.search);
		console.log("%s", $.fn.jquery);
	}

	if (!win.QBU)
		win.QBU = {
			getQuickBaseClient: function(baseUrl) {
				if (!window.QuickBaseClient)
					return $.getScript(baseUrl + "js/QuickBaseClient.js");
				else
				{
					var dfd = $.Deferred();
					dfd.resolve(null, "success", null);
					return dfd.promise();
				}
			},
			doQueryViaClient: function(data, statusText, jqXHR) {
				if (statusText !== "success")
					return;

				var
					client = new QuickBaseClient("https://igornozhenko.quickbase.com");
					
				client.Authenticate("inozhenko@yahoo.com", "Vbvjghj[jlzobq74");
				
				var
					data = client.GetRecordInfo("bktmrw9ve", "1"),
					fieldName = "FText",
					field = $("field name:contains(\"" + fieldName + "\")", data).parent(),
					fieldId = parseInt($("fid", field).text(), 10),
					fieldType = $("type", field).text(),
					fieldValue = $("value", field).text();

				if (window.console && console.log)
					console.log("{fid: %i, name: \"%s\", type: \"%s\", value: \"%s\"}", fieldId, fieldName, fieldType, fieldValue);
			},
			doQuery: function(rid, url) {
				if(window.console && console.log){
					console.log("doQuery(%o)", arguments);
					console.log(document.location.search);
				}
				
				var baseUrl = /.*(?=db)/.exec(url)[0];
				
				$.when(QBU.getQuickBaseClient(baseUrl))
					.then(QBU.doQueryViaClient)
					.fail(function(jqXHR, statusText, error) {
						if(window.console && console.log)
							console.log("fail(%o)", arguments);
					});
				
				/*url+="?act=API_DoQuery&query={3.EX." + rid + "}";

				$.get(url)
					.done(function(xml, status, jqXHR){
						if(window.console && console.log)
							console.log("%o", arguments);
	
						if(status === "success"){
							var
								errcode = $("errcode", xml).text(),
								fText = $("ftext", xml).text();

							if(window.console && console.log)
								console.log("errcode= %i { FText: \"%s\" }", errcode, fText);
						}
						else{
							if(window.console && console.log)
								console.log("%s", status);
						}
					})
					.fail(function(data){
						if(window.console && console.log)
							console.log("%o", arguments);
					})
					.always(function(data){
						if(window.console && console.log)
							console.log("%o", arguments);
					});

				$.ajax({
					url: "https://mock-api.greenlancer.com",
					type: "POST",
					dataType: "json",
					data: JSON.stringify({ "method": "authUser",  "params": {"email": "example@greenlancer.com", "password": "reallyStrongPassword12345"} }),
					xhrFields: { withCredentials: true },
					headers: { "Access-Control-Allow-Origin": "*" }
					, contentType: "application/json; charset=utf-8"
					, crossDomain: true
				}).then(
					function() {
						if (window.console && console.log)
							console.log("done(%o)", arguments);
					},
					function() {
						if (window.console && console.log)
							console.log("fail(%o)", arguments);
					},
					function() {
						if (window.console && console.log)
							console.log("progress(%o)", arguments);
					}
				);*/
			}
		};
})(window);