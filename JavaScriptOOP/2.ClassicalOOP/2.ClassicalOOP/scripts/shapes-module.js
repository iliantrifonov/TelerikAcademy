/// <reference path="canvas-vsdoc.js" />
var shapesModule = function shapesModule() {
    function Rect(canvasId, x, y, width, height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this._selector = canvasId;

        this.draw();
    }

    Rect.prototype.draw = function draw() {
        var canvas = Canvas.vsGet(document.getElementById(this._selector));
        var ctx = canvas.getContext('2d');

        ctx.beginPath();
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
    }

    function Circle(canvasId, x, y, radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
        this._selector = canvasId;

        this.draw();
    }

    Circle.prototype.draw = function draw() {
        var canvas = Canvas.vsGet(document.getElementById(this._selector));
        var ctx = canvas.getContext('2d');

        ctx.beginPath();
        ctx.arc(this.x, this.y, this.radius, 0, 2 * Math.PI);
        ctx.stroke();
    };

    function Line(canvasId, x1, y1, x2, y2) {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this._selector = canvasId;

        this.draw();
    }

    Line.prototype.draw = function draw() {
        var canvas = Canvas.vsGet(document.getElementById(this._selector));
        var ctx = canvas.getContext('2d');

        ctx.beginPath();
        ctx.moveTo(this.x1, this.y1);
        ctx.lineTo(this.x2, this.y2);
        ctx.stroke();
    };

    return {
        Line: Line,
        Circle: Circle,
        Rect: Rect
    }
};