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

            $scope.$on("change", this.onChange);
        }

        $onInit() {
            if (window.console && console.log)
                console.log("controller: $onInit(%o) $scope.dataUrl = \"%o\"", arguments, this.$scope.dataUrl);
        }

        $doCheck() {
            if (window.console && console.log)
                console.log("controller: $doCheck(%o) $scope.dataUrl = \"%o\"", arguments, this.$scope.dataUrl);
        }

        $onChanges(onChangesObj: ng.IOnChangesObject) {
            if (window.console && console.log)
                console.log("controller: $onChanges(%o) $scope.dataUrl = \"%o\"", onChangesObj, this.$scope.dataUrl);
        }

        $onDestroy() {
            if (window.console && console.log)
                console.log("controller: $onDestroy(%o) $scope.dataUrl = \"%o\"", arguments, this.$scope.dataUrl);
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

        onChange(event, sourceEvent): void {
            if (window.console && console.log)
                console.log("controller: onChange(%o, %o)", event, sourceEvent);
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
                    if (window.console && console.log)
                        console.log("directive: compile(tElem=%o, tAttrs=%o)", tElem, tAttrs);

                    return {
                        pre: (scope: IMyScope, iElem: ng.IAugmentedJQuery, iAttrs: ng.IAttributes): void => {
                            if (window.console && console.log)
                                console.log("directive: pre link (scope=%o, iElem=%o, iAttrs=%o)", scope, iElem, iAttrs);
                        },
                        post: (scope: IMyScope, iElem: ng.IAugmentedJQuery, iAttrs: ng.IAttributes): void => {
                            if (window.console && console.log)
                                console.log("directive: post link (scope=%o, iElem=%o, iAttrs=%o)", scope, iElem, iAttrs);

                            const elem = iElem[0] as HTMLSelectElement;

                            scope.$watch("options", (newValue, oldValue, scope): void => {
                                if (!newValue || !elem.options)
                                    return;

                                for (let i = 0; i < scope.options.length; ++i)
                                    elem.options.add(new Option(scope.options[i].value, scope.options[i].id, false, false));
                            });

                            iElem.on("change", event => {
                                if (window.console && console.log)
                                    console.log("directive: element.onChange(%o)", event);

                                scope.$emit("change", event);
                            });
                        }
                    }
                }
            };
        });
}
