namespace HaveIBeenPwned {
    "use strict";

    class App { }
}

/*
var app = angular.module("myApp", []);

if (window.console && console.log)
    console.log("%o", angular.version.full);

app.controller("comboBoxController", ["$scope", "$http", function ($scope, $http) {
    if (window.console && console.log)
        console.log("%o", arguments);

    this.$onInit = function () {
        if (window.console && console.log)
            console.log("$onInit(%o) $scope.dataUrl = \"%s\"", arguments, $scope.dataUrl);
    };

    this.$onChanges = function () {
        if (window.console && console.log)
            console.log("$onChanges(%o) $scope.dataUrl = \"%s\"", arguments, $scope.dataUrl);
    };
    this.$onDestroy = function () {
        if (window.console && console.log)
            console.log("$onDestroy(%o) $scope.dataUrl = \"%s\"", arguments, $scope.dataUrl);
    };

    this.$postLink = function () {
        if (window.console && console.log)
            console.log("$postLink(%o) $scope.dataUrl = \"%s\"", arguments, $scope.dataUrl);

        if ($scope.dataUrl) {
            $http.get($scope.dataUrl).then(
                function (response) {
                    if (window.console && console.log)
                        console.log("successCallback(%o)", arguments);

                    $scope.options = response.data;
                },
                function (response) {
                    if (window.console && console.log)
                        console.log("errorCallback(%o)", arguments);
                });
        }
    };
}]);

app.directive("comboBox", function () {
    return {
        restrict: "AE",
        scope: {
            dataUrl: "@url"
        },
        //templateUrl: "ComboBox.html",
        compile: function (tElem, tAttrs) {
            if (window.console && console.log) {
                console.log(": compile");
                console.log(tElem.html());
            }

            return {
                pre: function (scope, iElem, iAttrs) {
                    if (window.console && console.log) {
                        console.log(": pre link");
                        console.log(iElem.html());
                    }
                },
                post: function (scope, iElem, iAttrs) {
                    if (window.console && console.log) {
                        console.log(": post link");
                        console.log(iElem.html());
                    }

                    scope.$watch("options", function (newValue, oldValue, scope) {
                        if (!newValue || !iElem[0].options)
                            return;

                        for (var i = 0; i < scope.options.length; ++i)
                            iElem[0].options.add(new Option(scope.options[i].value, scope.options[i].id, false, false));
                    });
                }
            }
        },
        controller: "comboBoxController"
    };
});
*/