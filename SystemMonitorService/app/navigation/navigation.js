myApp.controller("navbarController", function ($scope, $location) {

});

myApp.directive("ttNavbar", function () {
    return {
        restrict: "EA",
        templateUrl: "navigation/nav.html",
        controller: "navbarController"
    };
});