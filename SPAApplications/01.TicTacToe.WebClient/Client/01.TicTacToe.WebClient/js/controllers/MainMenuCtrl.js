app.controller('MainMenuCtrl',
    function additionalInfoCtrl($scope, dataService, $location) {

        $scope.create = function () {
            dataService.createGame()
                .then(function (data) {
                    $location.path('/game/' + data.substring(1, data.length - 1));
                });
        }

        $scope.join = function () {
            dataService.joinGame()
                .then(function (data) {
                    $location.path('/game/' + data.substring(1, data.length - 1));
                });
        };

        $scope.rejoin = function () {
            $location.path('/game/' + $scope.gameId);
        }
    });