myApp.factory("monitoringService", function ($http) {
    var service = {};

    var connection = $.hubConnection();
    connection.logging = true;

    var hubProxy = connection.createHubProxy("performanceDataHub");
    
    service.init = function (scope) {
        hubProxy.on("newCpuValue", function (data) {
            scope.$broadcast("newCpuValue", data);
        });
        hubProxy.on("newDiskValue", function (data) {
            scope.$broadcast("newDiskValue", data);
        });

        connection.start().done(function () {
        });
    }

    return service;
});