angular.module('naot')
.directive('sceduleList', function () {
    return {
        restrict: 'E',
        replace: true,
        templateUrl: '/public/templates/scedule.html'
      // template: '<h3>Hello World!!</h3>'
    };
});
