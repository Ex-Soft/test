"use strict";

function onLoad()
{
	var
		arr = [];

	for(var i = 0; i < 3; ++i)
		arr[i] = function() {
			if(window.console && console.log)
				console.log(i);
		}

	arr[0]();
	arr[1]();
	arr[2]();
	
	for(var i = 0; i < 3; ++i)
		(function(i) {
			arr[i] = function() {
				if(window.console && console.log)
					console.log(i);
			}
		})(i);

	arr[0]();
	arr[1]();
	arr[2]();

	for(let i = 0; i < 3; ++i)
		arr[i] = function() {
			if(window.console && console.log)
				console.log(i);
		}

	arr[0]();
	arr[1]();
	arr[2]();
}

