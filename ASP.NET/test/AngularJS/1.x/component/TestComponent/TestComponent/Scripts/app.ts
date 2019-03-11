namespace TestComponent {
    "use strict";

    class ComboBox {
        static $inject = ["$scope", "$http"];

        private _scope: ng.IScope;
        private _httpService: ng.IHttpService;

        constructor($scope: ng.IScope, $http: ng.IHttpService) {
            if (window.console && console.log)
                console.log("ctor(%o)", arguments);

            this._scope = $scope;
            this._httpService = $http;
        }

        $onInit = function () {
            if (window.console && console.log)
                console.log("$onInit(%o) $scope.dataUrl = \"%o\"", arguments, this._scope);
        }

        $onChanges = function () {
            if (window.console && console.log)
                console.log("$onChanges(%o) $scope.dataUrl = \"%o\"", arguments, this._scope);
        }

        $onDestroy = function () {
            if (window.console && console.log)
                console.log("$onDestroy(%o) $scope.dataUrl = \"%o\"", arguments, this._scope);
        }

        $postLink() {
            let me = this;

            if (window.console && console.log)
                console.log("$postLink(%o) $scope.dataUrl = \"%s\"", arguments, this._scope.dataUrl);

            if (this._scope.dataUrl) {
                this._httpService.get(this._scope.dataUrl).then(
                    function (response) {
                        if (window.console && console.log)
                            console.log("successCallback(%o)", arguments);

                        me._scope.options = response.data;
                    },
                    function (response) {
                        if (window.console && console.log)
                            console.log("errorCallback(%o)", arguments);
                    });
            }
        }
    }

    angular
        .module("TestComponent", [])
        .directive("comboBox", (): ng.IDirective => {
            return {
                restrict: "AE",
                scope: {
                    dataUrl: "@url"
                },
                controller: ComboBox,
                compile: (tElem, tAttrs) => {
                    if (window.console && console.log) {
                        console.log(": compile");
                        console.log(tElem.html());
                    }

                    return {
                        pre: (scope: ng.IScope, iElem: ng.IAugmentedJQuery, iAttrs: ng.IAttributes): void => {
                            if (window.console && console.log) {
                                console.log(": pre link");
                                console.log(iElem.html());
                            }
                        },
                        post: (scope: ng.IScope, iElem: ng.IAugmentedJQuery, iAttrs: ng.IAttributes): void => {
                            if (window.console && console.log) {
                                console.log(": post link");
                                console.log(iElem.html());
                            }

                            const elem = iElem[0] as HTMLSelectElement;

                            scope.$watch("options", (newValue, oldValue, scope): void => {
                                if (!newValue || !elem.options)
                                    return;

                                for (var i = 0; i < scope.options.length; ++i)
                                    elem.options.add(new Option(scope.options[i].value, scope.options[i].id, false, false));
                            });
                        }
                    }
                }
            };
        });
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