app.filter('gameStateFilter', function () {
    return function (item) {
        switch (item) {
            case 0: return "Waiting ForSecond Player";
            case 1: return "Turn X";
            case 2: return "Turn O";
            case 3: return "Won by X";
            case 4: return "Won by O";
            case 5: return "Draw";
        }
    }
});