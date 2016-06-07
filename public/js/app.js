(function() 
 {
    var app = angular.module('naot', ['ngRoute']);

    app.controller('homeController', function($scope) 
    { 
    });
    
    app.controller('managerController', function($scope) 
    {
        this.images = images;

    });
    
    app.controller('formController', function($scope) 
    {
        this.user = "";
        this.submitForm = function(data)
        {
            users.push(this.user);
            this.user = {};
        }
    });
    
    app.controller('reportsController', function($scope) 
    {
        

    });
    
    
$(document).ready(function(){
      $('.parallax').parallax();
    });
    
 
    var users = [{}];
    
    var images = [
        '/public/images/1.jpg',
        '/public/images/2.jpg',
        '/public/images/3.jpg',
        '/public/images/4.jpg',
        '/public/images/5.jpg',
        '/public/images/6.jpg',
        '/public/images/7.jpg'
    ];
    
    
    
    app.config(function ($routeProvider) 
    {
        $routeProvider
            
            .when('/home', 
            {
            templateUrl: 'home.html',
            controller: 'homeController',
            controllerAs: 'home'
            })
        
            .when('/manager',
            {
            templateUrl: 'manager.html',
            controller: 'managerController',
            controllerAs:'manager'
            })
        
        
            .when('/student', 
            {
            templateUrl: 'student.html',
            controller: 'reportsController',
            controllerAs: 'reports'
            })
        
            .otherwise(
            {
            redirectTo: '/'
            });
        
    });
    
})();
