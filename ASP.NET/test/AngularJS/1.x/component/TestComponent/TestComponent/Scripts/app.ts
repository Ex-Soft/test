namespace TestComponent {
    "use strict";

    export interface IMyScope extends ng.IScope {
        dataUrl: string;
        options: Array<any>;
    }

    export class ComboBox implements angular.IController {
        static $inject = ["$scope", "$http"];

        constructor(private $scope: IMyScope, private $http: ng.IHttpService) {
            if (window.console && console.log)
                console.log("controller: ctor(%o)", arguments);
        }

        $onInit() {
            if (window.console && console.log)
                console.log("controller: $onInit(%o) $scope.dataUrl = \"%o\"", arguments, this.$scope);
        }

        $onChanges(onChangesObj: ng.IOnChangesObject) {
            if (window.console && console.log)
                console.log("controller: $onChanges(%o) $scope.dataUrl = \"%o\"", arguments, this.$scope);
        }

        $onDestroy() {
            if (window.console && console.log)
                console.log("controller: $onDestroy(%o) $scope.dataUrl = \"%o\"", arguments, this.$scope);
        }

        $postLink() {
            let me = this;

            if (window.console && console.log)
                console.log("controller: $postLink(%o) $scope.dataUrl = \"%s\"", arguments, this.$scope.dataUrl);

            if (this.$scope.dataUrl) {
                this.$http.get(this.$scope.dataUrl).then(
                    function (response) {
                        if (window.console && console.log)
                            console.log("successCallback(%o)", arguments);

                        me.$scope.options = response.data as Array<any>;
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
                        console.log("directive: compile");
                        console.log(tElem.html());
                    }

                    return {
                        pre: (scope: IMyScope, iElem: ng.IAugmentedJQuery, iAttrs: ng.IAttributes): void => {
                            if (window.console && console.log) {
                                console.log("directive: pre link");
                                console.log(iElem.html());
                            }
                        },
                        post: (scope: IMyScope, iElem: ng.IAugmentedJQuery, iAttrs: ng.IAttributes): void => {
                            if (window.console && console.log) {
                                console.log("directive: post link");
                                console.log(iElem.html());
                            }

                            const elem = iElem[0] as HTMLSelectElement;

                            scope.$watch("options", (newValue, oldValue, scope): void => {
                                if (!newValue || !elem.options)
                                    return;

                                for (let i = 0; i < scope.options.length; ++i)
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