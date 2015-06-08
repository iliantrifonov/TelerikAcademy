app.controller('MainItemsPageCtrl', function mainItemsPageCtrl($scope, dataService) {
    'use strict';

    $scope.products = window.data.pictures;
});