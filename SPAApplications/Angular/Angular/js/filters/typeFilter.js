app.filter('typeFilter', function () {
    return function (item) {
        switch (item){
            case 0: return "Flower";
            case 1: return "Grass";
        }
    }
})