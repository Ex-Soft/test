// https://www.codementor.io/angularjs/tutorial/how-angular-directive-scope-work

var app = angular.module("myApp", []);

if(window.console && console.log)
	console.log("%o", angular.version.full);

app.directive("expandableSection1", function() {
	return function($scope, $element) {
		$element.find("article").hide();

		$element.find("h2").click(function() {
			$element.find("article").toggle();
		});
	};
});

app.directive("expandableSection2", function() {
	return {
		restrict: "E",
		template: "<section><h2>{{title}}</h2><article>{{body}}</article>",
		replace: true,
		scope: true, //scope: false means the scope is not inherited
		link: function($scope, $element, attrs) {
			if(window.console && console.log)
				console.log("%o", arguments);

			$scope.title = attrs.sectionTitle;
			$scope.body = attrs.sectionBody;

			$element.find("article").hide();

			$element.find("h2").click(function() {
				$element.find("article").toggle();
			});
		}
	};
});

app.directive("expandableSection3", function() {
	return {
		restrict: "E",
		template: "<section><h2>{{title}}</h2><article>{{body}}</article>",
		replace: true,
		scope: {
			title: "@sectionTitle",
			body: "@sectionBody"
		},
		link: function($scope, $element, attrs) {
			if(window.console && console.log)
				console.log("%o", arguments);

			$element.find("article").hide();

			$element.find("h2").click(function() {
				$element.find("article").toggle();
			});
		}
	};
});

app.controller("MyController", function($scope) {
	var myCtrl = this;

	myCtrl.myTitle = "Section Title (via method# 4) @";
	myCtrl.myBody = "Body";
	
	myCtrl.getTitle = function() {
		return "Section Title (via method# 4) =";
	};
	
	myCtrl.getBody = function() {
		return "Body";
	};
	
	myCtrl.someFunction = function(magicArgument) {
		if(window.console && console.log)
			console.log("%o", arguments);
	};
	
	this.$postLink = function() {
		if(window.console && console.log)
			console.log("%o", arguments);
	};
});

app.directive("expandableSection4", function() {
	return {
		restrict: "E",
		template: "<section><h2>{{title}}</h2><article>{{body}}</article>",
		replace: true,
		scope: {
			title: "@sectionTitle", // section-title="{{myCtrl.myTitle}}"
			body: "@sectionBody" // section-body="{{myCtrl.myBody}}"
		},
		link: function($scope, $element) {
			if(window.console && console.log)
				console.log("%o", arguments);

			$element.find("article").hide();

			$element.find("h2").click(function() {
				$element.find("article").toggle();
			});
		}
	};
});

app.directive("expandableSection5", function() {
	return {
		restrict: "E",
		template: "<section><h2>{{title}}</h2><article>{{body}}</article>",
		replace: true,
		scope: {
			title: "=sectionTitle", // section-title="myCtrl.getTitle()"
			body: "=sectionBody", // section-body="myCtrl.getBody()"
			expr: "&someExpression"
		},
		link: function($scope, $element) {
			if(window.console && console.log)
				console.log("%o", arguments);

			$scope.expr({magicArgument: 42});
			
			$element.find("article").hide();

			$element.find("h2").click(function() {
				$element.find("article").toggle();
			});
		}
	};
});

$(function() {
	$("[expandable-sectionJQuery] article").hide();

	$("[expandable-sectionJQuery] h2").click(function() {
		$(this).parent().find("article").toggle();
	});
});

// https://www.codementor.io/angularjs/tutorial/6-angularjs-tips-scope-directives-localization-postdigest-controllers
// Tip #6: Angular Controllers vs Link Functions

app.controller("ExpandableSectionCtrl", function($parse, $scope, $element, $attrs) {
	var expr = $parse($attrs.someExpression)
	expr($scope.$parent, {magicArgument: 84});

	$element.find("article").hide();
	
	$element.find("h2").click(function() {
		$element.find("article").toggle();
	});
});

app.directive("expandableSection6", function() {
	return {
		restrict: "E",
		template: "<section><h2>{{title}}</h2><article>{{body}}</article>",
		replace: true,
		scope: {
			title: "=sectionTitle",
			body: "=sectionBody"
		},
		controller: "ExpandableSectionCtrl"
	};
});
