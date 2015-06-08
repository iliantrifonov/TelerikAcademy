var snakeGame = snakeGame || {};
snakeGame.gameObjects = function () {
    'use strict';

    var Snake = function (elementSize, startX, startY) {

        var elements = [],
            direction = 'R',
            isAlive = true,
            newElement,
            lastElement,
            i,
            changeDirection,
            keyPressedHandler

        (function () {
            elements.push({ x: startX + elementSize * 2, y: startY });
            elements.push({ x: startX + elementSize, y: startY });
            elements.push({ x: startX + 0, y: startY });
            elements.push({ x: startX - elementSize, y: startY });
        }());

        changeDirection = function (newDirection) {
            if (newDirection === 'U') {

                if (direction !== 'D') {
                    direction = 'U';
                }
            }
            else if (newDirection === 'D') {
                if (direction !== 'U') {
                    direction = 'D';
                }
            }
            else if (newDirection === 'R') {
                if (direction !== 'L') {
                    direction = 'R';
                }
            }
            else if (newDirection === 'L') {
                if (direction !== 'R') {
                    direction = 'L';
                }
            }
        }

        keyPressedHandler = function (e) {
            switch (e.keyCode) {
                case 65: //a
                case 37: changeDirection('L'); break; 

                case 87: //w
                case 38: changeDirection('U'); break; 

                case 68: //d
                case 39: changeDirection('R'); break; 

                case 83: //s
                case 40: changeDirection('D'); break; 
            }

            e.preventDefault();
        }

        var getElements = function () {
            return elements;
        }

        var getElementSize = function () {
            return elementSize;
        }

        var getIsAlive = function () {
            return isAlive
        }

        var kill = function () {
            isAlive = false;
        }

        var grow = function () {
            elements.push(lastElement);
        }

        var move = function () {
            switch (direction) {
                case 'R': newElement = { x: elements[0].x + elementSize, y: elements[0].y }; break;
                case 'L': newElement = { x: elements[0].x - elementSize, y: elements[0].y }; break;
                case 'U': newElement = { x: elements[0].x, y: elements[0].y - elementSize }; break;
                case 'D': newElement = { x: elements[0].x, y: elements[0].y + elementSize }; break;
            }

            lastElement = elements.pop();
            elements.unshift(newElement);

            for (i = 1; i < elements.length; i += 1) {
                if (elements[i].x === newElement.x && elements[i].y === newElement.y) {
                    isAlive = false;
                    return;
                }
            }
        }

        var getHeadElement = function () {
            return elements[0];
        }

        return {
            getElements: getElements,
            getElementSize: getElementSize,
            grow: grow,
            getIsAlive: getIsAlive,
            kill: kill,
            move: move,
            getHeadElement: getHeadElement,
            keyPressedHandler: keyPressedHandler
        }
    }

    var Apple = function (appleSize, maxX, maxY) {
        var x = 0,
            y = 0,
            getCoordinates,
            getAppleSize,
            refresh;

        getCoordinates = function () {
            return {
                x: x,
                y: y,
            }
        }

        getAppleSize = function () {
            return appleSize;
        }

        refresh = function () {
            x = getNumberCloseToPixel(getRandomNumberInRange(0, maxX), appleSize);
            y = getNumberCloseToPixel(getRandomNumberInRange(0, maxY), appleSize);
        }

        return {
            getCoordinates: getCoordinates,
            getAppleSize: getAppleSize,
            refresh: refresh
        }
    }

    var Obsticles = function (obsticleSize, maxX, maxY, ammount) {
        var obsticles = [],
            getObsticles,
            getObsticleSize;

        (function () {
            var i,
                j,
                newX,
                newY,
                loop;

            function generateObsticle(_x, _y) {
                obsticles.push({ x: _x, y: _y });
            }

            for (i = 0; i < maxX; i += obsticleSize) {
                obsticles.push({ x: i, y: 0 });
                obsticles.push({ x: i, y: maxY - obsticleSize });
            }
            for (i = 0; i < maxY; i += obsticleSize) {
                obsticles.push({ x: 0, y: i });
                obsticles.push({ x: maxX - obsticleSize, y: i });
            }

            for (i = 0; i < ammount; i += 1) {
                newX = getNumberCloseToPixel(getRandomNumberInRange(0, maxX), obsticleSize);
                newY = getNumberCloseToPixel(getRandomNumberInRange(0, maxY), obsticleSize);

                while (newY == maxY / 2) {
                    newX = getNumberCloseToPixel(getRandomNumberInRange(0, maxX), obsticleSize);
                    newY = getNumberCloseToPixel(getRandomNumberInRange(0, maxY), obsticleSize);
                }

                loop = true;

                while (loop) {
                    loop = false;

                    for (j = 0; j < obsticles.length; j += 1) {
                        if (isInRangeOfObject(newX, newY, obsticles[j].x, obsticles[j].y, obsticleSize)) {
                            newX = getNumberCloseToPixel(getRandomNumberInRange(0, maxX), obsticleSize);
                            newY = getNumberCloseToPixel(getRandomNumberInRange(0, maxY), obsticleSize);

                            loop = true;
                            break;
                        }
                    }
                }

                obsticles.push({ x: newX, y: newY });
            }
        }());

        getObsticles = function () {
            return obsticles;
        }

        getObsticleSize = function () {
            return obsticleSize;
        }

        return {
            getObsticles: getObsticles,
            getObsticleSize: getObsticleSize
        }
    }

    var isInRangeOfObject = function (sourceX, sourceY, targetX, targetY, radius) {
        return ((sourceX === targetX - radius || sourceX === targetX || sourceX === targetX + radius) &&
                (sourceY === targetY - radius || sourceY === targetY || sourceY === targetY + radius));
    }

    var getRandomNumberInRange = function (min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    var getNumberCloseToPixel = function (num, pixelSize) {
        return num - num % pixelSize;
    }

    return {
        Snake: Snake,
        Apple: Apple,
        Obsticles: Obsticles
    }
}();