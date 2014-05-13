myApp.controller("monitoringController", function ($scope, $timeout, monitoringService) {
    monitoringService.init($scope);

    $scope.diskSeries = [
     	{ category: "Free", percentage: 50 },
        { category: "Used", percentage: 50 }
    ];

    $scope.xFunction = function () {
        return function (d) {
            return d.category;
        };
    }
    $scope.yFunction = function () {
        return function (d) {
            return d.percentage;
        };
    }

    $scope.$on("newCpuValue", function (evt, data) {
        $scope.$apply($scope.cpuData = data.value);
    });

    $scope.$on("newDiskValue", function (evt, data) {
        $scope.$apply(function () {
            var newValue = [
                { category: "Free", percentage: data.value },
                { category: "Used", percentage: 100 - data.value }
            ];
            $scope.diskSeries = newValue;
        });
    });
});