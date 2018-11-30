// http://excellencenodejsblog.com/angularjs-directive-compile-pre-link-post-link-controller-functions/

var app = angular.module("myApp", []);

if(window.console && console.log)
	console.log("%o", angular.version.full);

app.directive("myDir", function() {
	return {
		restrict: "E",
		controller: function($scope, $element) {
			if(window.console && console.log)
			{
				console.log(": controller");
				console.log($element.html());
			}
		},
		compile: function(tElem, tAttrs) {
			if(window.console && console.log)
			{
				console.log(": compile");
				console.log(tElem.html());
			}

			return {
				pre: function(scope, iElem, iAttrs) {
					if(window.console && console.log)
					{
						console.log(": pre link");
						console.log(iElem.html());
					}
				},
				post: function(scope, iElem, iAttrs) {
					if(window.console && console.log)
					{
						console.log(": post link");
						console.log(iElem.html());
					}
				}
			}
		}
	}
});