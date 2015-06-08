'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies', 'angularUtils.directives.dirPagination']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/main', {
                templateUrl: 'views/partials/mainItemsPage.html',
                controller: 'MainItemsPageCtrl'
            })
            .when('/products/:id', {
                templateUrl: 'views/partials/additionalInfo.html',
                controller: 'AdditionalInfoCtrl'
            })
            .when('/add', {
                templateUrl: 'views/partials/addItem.html',
                controller: 'AddItemCtrl'
            })
            .otherwise({ redirectTo: '/main' });
    }])
    .config(["$httpProvider",
    function ($httpProvider) {
        //$httpProvider.defaults.withCredentials = true;
        //$httpProvider.defaults.headers.common["X-Requested-With"] = "XMLHttpRequest";
        $httpProvider.interceptors.push('authInterceptorService');
}
    ])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:23610');