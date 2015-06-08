app.controller('AddItemCtrl', function additionalInfoCtrl($scope, $location) {
    $scope.redirect = function () {
        $location.path('/main');
    }

    $scope.addPicture = function () {
        window.data.pictures.push($scope.picture);
        // if success..
        $location.path('/main');
    }

    $scope.validUser = true;
});