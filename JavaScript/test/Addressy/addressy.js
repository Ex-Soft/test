function showClear() {
	document.getElementById("clearButton").style.display = "block";
}

function clearSearch() {
	var input = document.getElementById("searchBox");
	input.value = "";
	document.getElementById("clearButton").style.display = "none";	
}

function showError(message) {
	var error = document.getElementById("errorMessage");
	error.innerText = message;
	error.style.display = "block";
	
	setTimeout(function(){
		error.style.display = "none";
	}, 10000)
}

function enterSearch(e) {
	if (e.keyCode == 13){
		findAddress();	
	}
}

function findAddress(SecondFind) {
  var Text = document.getElementById("searchBox").value;
	
	if (Text === "") {
		showError("Please enter an address");
		return;
	}
	
	var Container = "";			
			
	if (SecondFind !== undefined){
		 Container = SecondFind;
	} 
	
var Key = "",
    IsMiddleware = false,
    Origin = "",
    Countries = "UA",
    Limit = "1000",
    Language = "en",  
	url = 'https://api.addressy.com/Capture/Interactive/Find/v1.10/json3.ws';

var params = '';
    params += "&Key=" + encodeURIComponent(Key);
    params += "&Text=" + encodeURIComponent(Text);
    params += "&IsMiddleware=" + encodeURIComponent(IsMiddleware);
    params += "&Container=" + encodeURIComponent(Container);
    params += "&Origin=" + encodeURIComponent(Origin);
    params += "&Countries=" + encodeURIComponent(Countries);
    params += "&Limit=" + encodeURIComponent(Limit);
	params += "&Language=" + encodeURIComponent(Language);

var http = new XMLHttpRequest();
http.open('POST', url, true);
http.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
http.onreadystatechange = function() {
  if (http.readyState == 4 && http.status == 200) {
      var response = JSON.parse(http.responseText);
      if (response.Items.length == 1 && typeof(response.Items[0].Error) != "undefined") {
         showError(response.Items[0].Description);
      }
      else {
        if (response.Items.length == 0)
            showError("Sorry, there were no results");

        else {
					var resultBox = document.getElementById("result");
					
					if (resultBox.childNodes.length > 0) {
						var selectBox = document.getElementById("mySelect");
						selectBox.parentNode.removeChild(selectBox)
					}
							
          var resultArea = document.getElementById("result");
          var list = document.createElement("select");
              list.id = "selectList";
              list.setAttribute("id", "mySelect");
              resultArea.appendChild(list);
					
					var defaultOption = document.createElement("option");
					 defaultOption.text = "Select Address";
					defaultOption.setAttribute("value", "");
					defaultOption.setAttribute("selected", "selected");
					list.appendChild(defaultOption);

          for (var i = 0; i < response.Items.length; i++){  	
            var option = document.createElement("option"); 
            option.setAttribute("value", response.Items[i].Id)
            option.text = response.Items[i].Text + " " + response.Items[i].Description;
						option.setAttribute("class", response.Items[i].Type)
																												
            list.appendChild(option);
          }
					selectAddress(Key);				          
        }
    }
  }
}
	http.send(params);
};  

function selectAddress(Key){
		var resultList = document.getElementById("result");
	
		if (resultList.childNodes.length > 0) {		
				var elem = document.getElementById("mySelect");
					
				//IE fix
							elem.onchange = function (e) {
								
								var target = e.target[e.target.selectedIndex];
								
								if (target.text === "Select Address") {
									return;
								}		

								if (target.className === "Address"){
									retrieveAddress(Key, target.value);
								}
								
								else {
								  findAddress(target.value)
								}							
						};				
					}
};

function retrieveAddress(Key, Id){
	var Field1Format = "";
	var url = 'https://api.addressy.com/Capture/Interactive/Retrieve/v1.00/json3.ws';
	var params = '';
			params += "&Key=" + encodeURIComponent(Key);
			params += "&Id=" + encodeURIComponent(Id);
			params += "&Field1Format=" + encodeURIComponent(Field1Format);
   
var http = new XMLHttpRequest();
http.open('POST', url, true);
http.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
http.onreadystatechange = function() {
  if (http.readyState == 4 && http.status == 200) {
      var response = JSON.parse(http.responseText);

      if (response.Items.length == 1 && typeof(response.Items[0].Error) != "undefined") {
        showError(response.Items[0].Description);
      }
      else {
        if (response.Items.length == 0)
            showError("Sorry, there were no results");
        else {           
					var res = response.Items[0];
					var resBox = document.getElementById("output");
					resBox.innerText = res.Label;			
				  document.getElementById("output").style.display = "block";
					document.getElementById("seperator").style.display = "block";
       }
    }
  }
}
	http.send(params); 
}