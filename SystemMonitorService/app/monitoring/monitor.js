myApp.controller("monitoringController", function ($scope, $timeout, monitoringService) {
    monitoringService.init($scope);

    $scope.diskSeries = [
     	{ key: "Free", y: 50 },
        { key: "Used", y: 50 }
    ];

    $scope.xFunction = function () {
        return function (d) {
            return d.key;
        };
    }
    $scope.yFunction = function () {
        return function (d) {
            return d.y;
        };
    }

    $scope.$on("newCpuValue", function (evt, data) {
        $scope.$apply($scope.cpuData = data.value);
    });

    $scope.$on("newDiskValue", function (evt, data) {
        $scope.$apply(function () {
            var newValue = [
                { key: "Free", y: data.value },
                { key: "Used", y: 100 - data.value }
            ];
            $scope.diskSeries = newValue;
        });
    });
});