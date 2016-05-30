angular.module('naot')
.directive('navBar', function () {
    return {
        restrict: 'E',
        replace: true,
        templateUrl: '/public/templates/navbar.html'
      //  template: '<h3>Hello World!!</h3>'
    };
});


