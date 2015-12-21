'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'HomeController'
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'LoginController'
            })
            .when('/user-details', {
                templateUrl: 'views/partials/userInfo.html',
                controller: 'LoginController'
            })
            .when('/create-game', {
                templateUrl: 'views/partials/create-game.html',
                controller: 'CreateController'
            })
            .when('/join-game', {
                templateUrl: 'views/partials/join-game.html',
                controller: 'CreateController'
            })
            .otherwise({ redirectTo: '/' });
    }])
    .value('baseHeader', "")
    .value('toastr', toastr)
    .constant('baseUrl', 'http://localhost:33257');