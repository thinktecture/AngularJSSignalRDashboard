var myApp = angular.module("myApp", ["ngRoute", "nvd3ChartDirectives"]);

myApp.config(function ($routeProvider) {
    $routeProvider
        .when("/", { templateUrl: "app/monitoring/monitor.html", controller: "monitoringController" })
        .otherwise({ redirectTo: "/" });
});

myApp.run(function () {
    FastClick.attach(document.body);
});
