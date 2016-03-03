'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'HomeCtrl'
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'RegisterController'
            })
            .when('/userInfo', {
                templateUrl: 'views/partials/userInfo.html',
                controller: 'UserInfoCtrl'
            })
            .when('/unauthorized', {
                templateUrl: 'views/partials/unauthorized.html'
            })
            .when('/trips', {
                templateUrl: 'views/partials/trips-details.html',
                controller: 'TripsCtrl'
            })
            .when('/create-new-trip', {
                templateUrl: 'views/partials/create-new-trip.html',
                controller: 'CreateNewTripCtrl'
            })
            .when('/join-trip', {
                templateUrl: 'views/partials/join-trip.html',
                controller: 'JoinTripCtrl'
            })
            .when('/drivers', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'DriversCtrl'
            })
            .when('/drivers/:id', {
                templateUrl: 'views/partials/drivers-details.html',
                controller: 'DriverByIdCtrl'
            })
            .when('/trips/:id', {
                templateUrl: 'views/partials/detailed-trip.html',
                controller: 'TripByIdCtrl'
            })
            .otherwise({ redirectTo: '/' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:1337');