// http://stackoverflow.com/questions/29093229/how-to-call-function-when-angular-watch-cycle-or-digest-cycle-is-completed

var app = angular.module("testBindingApp", []);

app.controller("testBindingController", function($scope) {
	$scope.scopeVar = {};
	$scope.watchVar = false;
	
	Object.defineProperty($scope.scopeVar, "_isDivShow", {
		configurable: true,
		//enumerable: true,
		enumerable: false,
		value: false,
		writable: true
	});

	Object.defineProperty($scope.scopeVar, "isDivShow", {
		enumerable: true,
		get: function() {
			if(window.console && console.log)
				console.log("get()");

			return this._isDivShow
		},
		set: function(value) {
			if(window.console && console.log)
				console.log("set(\"%s\")", value);

			this._isDivShow = value;
		}
	});
	
	$scope.toggle = function() {
		if (window.console && console.log)
			console.log("toggle(%o)", arguments);
		
		$scope.scopeVar.isDivShow = !$scope.scopeVar.isDivShow;
	};
	
	$scope.$watch("watchVar", function(newValue, oldValue, scope){
		if (window.console && console.log)
			console.log("%o -> %o", oldValue, newValue);
	});

	var hasRegistered = false;
	$scope.$watch(function() {
		if (window.console && console.log)
			console.log("$scope.$watch(%o)", arguments);

		if (hasRegistered)
			return;

		hasRegistered = true;

		$scope.$$postDigest(function() {
			hasRegistered = false;
			
			if (window.console && console.log)
				console.log("$scope.$$postDigest(%o)", arguments);
		});
	});
});

function ChangeWatchVar(){
	var scope = angular.element(document.querySelector("div[class=ng-scope]")).scope();

	scope.watchVar = !scope.watchVar;
	
	if (document.getElementById("cbCallApply").checked)
		scope.$apply();
}