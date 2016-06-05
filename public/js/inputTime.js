angular.module('naot')
.directive('inputTime', function () {
    return {
        restrict: 'E',
        replace: true,
       templateUrl: '/public/templates/inputTime.html'
      // template: '<h3>Hello World!!</h3>'
    };
});
