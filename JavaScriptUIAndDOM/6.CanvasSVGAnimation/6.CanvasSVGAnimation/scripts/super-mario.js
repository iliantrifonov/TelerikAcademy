/// <reference path="kinetic-v5.1.0.min.js" />
/// <reference path="raphael-min.js" />
window.onload = function () {
    "use strict";

    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1440,
        height: 960
    });

    var layer = new Kinetic.Layer();

    var imageObj = new Image();

    imageObj.onload = function () {
        var superMario = new Kinetic.Sprite({
            x: 450,
            y: 720,
            image: imageObj,
            animation: 'idle',
            animations: {
                idle: [
                  // x, y, width, height
                  609, 642, 167, 292,
                ],
                move: [
                  // x, y, width, height (4 frames)
                  551, 974, 266, 273,
                  19, 969, 245, 264,
                  852, 659, 231, 261,
                  19, 969, 245, 264,
                ]
            },
            frameRate: 10,
            frameIndex: 0,
            scale: 0.5,
            scaleX: 0.5,
            scaleY: 0.5
        });

        // add the shape to the layer
        layer.add(superMario);

        // add the layer to the stage
        stage.add(layer);

        // start sprite animation
        superMario.start();

        var frameCount = 0;

        superMario.on('frameIndexChange', function (ev) {
            if (superMario.animation() === 'move' && ++frameCount > 4) {
                superMario.animation('idle');
                superMario.scaleX(0.5);
                superMario.scaleY(0.5);
                frameCount = 0;
            }
        });

        function onKeyDown(evt) {
            switch (evt.keyCode) {
                case 37:  // left arrow
                    superMario.setX(superMario.attrs.x -= 10);
                    superMario.attrs.animation = 'move';
                    break;
                case 39:  // right arrow
                    superMario.setX(superMario.attrs.x += 10);
                    superMario.scaleX(-0.5);
                    superMario.scaleY(0.5);
                    superMario.attrs.animation = 'move';
                    break;
            }
        }

        window.addEventListener('keydown', onKeyDown);
    };

    imageObj.src = 'images/MarioHi-Res.png';

    var paper = new Raphael(0, 0, 1440, 960);

    paper.image("images/background.jpg", 0, 0, 1440, 900);
}