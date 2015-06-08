'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies', 'angularUtils.directives.dirPagination']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/scores', {
                templateUrl: 'views/partials/scores.html',
                controller: 'ScoresCtrl'
            })
            .when('/main-menu', {
                templateUrl: 'views/partials/mainMenuOfGame.html',
                controller: 'MainMenuCtrl'
            })
            .when('/game/:id', {
                templateUrl: 'views/partials/playGame.html',
                controller: 'PlayGameCtrl'
            })
            .otherwise({ redirectTo: '/scores' });
    }])
    .config(["$httpProvider",
    function ($httpProvider) {
        //$httpProvider.defaults.withCredentials = true;
        //$httpProvider.defaults.headers.common["X-Requested-With"] = "XMLHttpRequest";
        $httpProvider.interceptors.push('authInterceptorService');
}
    ])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:33257');