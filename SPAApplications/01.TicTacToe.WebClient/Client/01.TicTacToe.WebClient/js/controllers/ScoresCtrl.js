app.controller('ScoresCtrl',
    function additionalInfoCtrl($scope, dataService) {
        $scope.scores = dataService.getScores();
});