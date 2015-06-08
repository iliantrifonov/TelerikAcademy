/// <reference path="shapes-module.js" />
(function () {
    var shapes = shapesModule();

    var rectangle = new shapes.Rect('canvas', 50, 250, 100, 120);
    var circle = new shapes.Circle('canvas', 100, 100, 80);
    var line = new shapes.Line('canvas', 200, 100, 300, 400);
})();