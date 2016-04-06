(function() 
 {
    var app = angular.module('naot', ['ngRoute']);

    app.controller('homeController', function($scope) 
    {
       

    });
    
    app.controller('galleryController', function($scope) 
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
    
 
    var users = [{}];
    
    var images = [
        'images/1.jpg',
        'images/2.jpg',
        'images/3.jpg',
        'images/4.jpg',
        'images/5.jpg',
        'images/6.jpg',
        'images/7.jpg'
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
        
            .when('/gallery',
            {
            templateUrl: 'gallery.html',
            controller: 'galleryController',
            controllerAs:'gallery'
            })
        
            .when('/login', 
            {
            templateUrl: 'login.html',
            controller: 'formController',
            controllerAs: 'form'
            })
        
            .when('/reports', 
            {
            templateUrl: 'reports.html',
            controller: 'reportsController',
            controllerAs: 'reports'
            })
        
            .otherwise(
            {
            redirectTo: '/'
            });
        
    });
    
})();
