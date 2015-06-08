app.controller('AdditionalInfoCtrl', function additionalInfoCtrl($scope, $routeParams) {
    'use strict';

    $scope.products = window.data.pictures;

    var item = getItemById($scope.products, $routeParams.id);

    $scope.product = item;

    $scope.isShown = false;
    $scope.learnMoreText = 'Learn More';
    $scope.showLearnMore = function () {
        if ($scope.isShown) {
            $scope.isShown = false;
            $scope.learnMoreText = 'Learn More';
        } else {
            $scope.isShown = true;
            $scope.learnMoreText = 'Hide';
        }
    }
    
    function getItemById(items, id) {
        for (var i = 0; i < items.length; i++) {
            if (items[i].id.toString() === id) {
                return items[i];
            }
        }
    }
});