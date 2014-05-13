myApp.directive('smoothieChart', function () {
    return {
        restrict: "E",
        replace: true,
        transclude: true,
        template: "<canvas>Your browser does not support the HTML 5 canvas element.</canvas>",
        link: function (scope, elem, attrs) {
            doResize();

            $(window).resize(function () {
                doResize();
            });

            var values = new TimeSeries();
            var chart = new SmoothieChart({ grid: { verticalSections: 4, sharpLines: true }, maxValue: 100, minValue: 0 });
            chart.addTimeSeries(values, { strokeStyle: 'rgba(0, 255, 0, 1)', fillStyle: 'rgba(0, 255, 0, 0.2)', lineWidth: 4 });
            chart.streamTo(elem[0], 1000);

            scope.$watch(attrs.data, function (data) {
                values.append(new Date().getTime(), parseFloat(data));
            });

            function doResize() {
                var parent = elem.parent()[0];
                elem.attr('width', parent.clientWidth - 25);
            }
        }
    };
});
