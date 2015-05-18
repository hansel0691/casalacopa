
angular.module('main.controllers', ['main.controllers.location', 'main.controllers.book']);

var app = angular.module('main', ['main.controllers', 'main.directives', 'ngRoute']);

app.config([
    '$routeProvider', function($routeProvider) {
        $routeProvider.
            when('/home', {
                templateUrl: 'partialroute/home',
            }).
            when('/about', {
                templateUrl: 'partialroute/aboutUs',
            }).
            when('/location', {
                templateUrl: 'partialroute/location',
                controller: 'locationCtr'
            }).
            when('/rooms', {
                templateUrl: 'partialroute/rooms',
            }).
            when('/terrace', {
                templateUrl: 'partialroute/terrace',
            }).
            when('/todo', {
                templateUrl: 'partialroute/toDo',
            })
            .otherwise({ redirectTo: '/home' });
    }
]);
