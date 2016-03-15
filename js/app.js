
(function(){
	
	var app = angular.module('myApp',[]);
	app.controller('MyController', function(){
		this.myVar = tempVar;
		});
	
	var tempVar = {
		name : 'tirgul',
		count : 1,
		update : false
	};
		
	
})();