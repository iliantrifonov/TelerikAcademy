app.controller('PlayGameCtrl',
    function additionalInfoCtrl($scope, $location, $routeParams, dataService) {

        dataService.getGameState($routeParams.id)
        .then(function (data) {
            $scope.gameData = data;
        });

        $scope.update = function () {

            dataService.getGameState($routeParams.id)
                .then(function (data) {
                    $scope.gameData = data;
                });
        }

        $scope.play = function (row, col) {

            var toSend = {};
            toSend.Row = row;
            toSend.Col = col;
            toSend.GameId = $routeParams.id;

            dataService.play(toSend);
        }
    });