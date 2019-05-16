var app = angular.module("myApp", []);

if(window.console && console.log)
	console.log("%o", angular.version.full);

app.controller("comboBoxController", ["$scope", "$http", function($scope, $http) {
	if(window.console && console.log)
		console.log("%o", arguments);
	
	this.$onInit = function() {
		if(window.console && console.log)
			console.log("controller: $onInit(%o) $scope.dataUrl = \"%s\"", arguments, $scope.dataUrl);
	};

	this.$doCheck = function() {
		if (window.console && console.log)
			console.log("controller: $doCheck(%o) $scope.dataUrl = \"%o\"", arguments, $scope.dataUrl);
	};

	this.$onChanges = function() {
		if(window.console && console.log)
			console.log("controller: $onChanges(%o) $scope.dataUrl = \"%s\"", arguments, $scope.dataUrl);
	};

	this.$onDestroy = function() {
		if(window.console && console.log)
			console.log("controller: $onDestroy(%o) $scope.dataUrl = \"%s\"", arguments, $scope.dataUrl);
	};
	
	this.$postLink = function() {
		if(window.console && console.log)
			console.log("controller: $postLink(%o) $scope.dataUrl = \"%s\"", arguments, $scope.dataUrl);
		
		if ($scope.dataUrl)
		{
			$http.get($scope.dataUrl).then(
				function(response) {
					if(window.console && console.log)
						console.log("successCallback(%o)", arguments);
					
					$scope.options = response.data;
				},
				function(response) {
					if(window.console && console.log)
						console.log("errorCallback(%o)", arguments);
				});
		}
	};

	this.onChange = function(event, sourceEvent) {
		if (window.console && console.log)
			console.log("controller: onChange(%o, %o)", event, sourceEvent);
	}

	$scope.$on("change", this.onChange);
}])
.directive("comboBox", function() {
	return {
		restrict: "AE",
		scope: {
			dataUrl: "@url"
		},
		controller: "comboBoxController",
		//templateUrl: "ComboBox.html",
		compile: function(tElem, tAttrs) {
			if(window.console && console.log)
				console.log("directive: compile(tElem=%o, tAttrs=%o)", tElem, tAttrs);

			return {
				pre: function(scope, iElem, iAttrs) {
					if(window.console && console.log)
						console.log("directive: pre link (scope=%o, iElem=%o, iAttrs=%o)", scope, iElem, iAttrs);
				},
				post: function(scope, iElem, iAttrs) {
					if(window.console && console.log)
						console.log("directive: post link (scope=%o, iElem=%o, iAttrs=%o)", scope, iElem, iAttrs);
					
					scope.$watch("options", function(newValue, oldValue, scope) {
						if (!newValue || !iElem[0].options)
							return;
						
						for(var i = 0; i < scope.options.length; ++i)
							iElem[0].options.add(new Option(scope.options[i].value, scope.options[i].id, false, false));
					});

					iElem.on("change", function(event) {
						if(window.console && console.log)
							console.log("directive: element.onChange(%o)", event);

						scope.$emit("change", event);
					});
				}
			}
		}
	};
});

// http://tutorials.jenkov.com/angularjs/custom-directives.html#isolating-the-scope-from-the-directive
app.controller("userinfoController", ["$scope", "$http", function($scope, $http) {
	$scope.jakob = { firstName: "Jakob", lastName: "Jenkov" };
	$scope.john = { firstName: "John", lastName: "Doe" };
}])
.directive("userinfo", function() {
	return {
		restrict: "E",
		scope: {
			user: "=user"
		},
		template: "User: {{user.firstName}} {{user.lastName}}"
	};
});

// https://docs.angularjs.org/guide/directive#isolating-the-scope-of-a-directive
app.controller('NaomiController', ['$scope', function($scope) {
	$scope.customer = {
		name: 'Naomi',
		address: '1600 Amphitheatre'
	};
}])
.controller('IgorController', ['$scope', function($scope) {
	$scope.customer = {
		name: 'Igor',
		address: '123 Somewhere'
	};
}])
.directive('myCustomer', function() {
	return {
		restrict: 'E',
		template: 'Name: {{customer.name}} Address: {{customer.address}}'
	};
});
