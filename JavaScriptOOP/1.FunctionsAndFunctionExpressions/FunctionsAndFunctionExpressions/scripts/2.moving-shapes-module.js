var movingShapesModule = function movingShapesModule() {
    'use strict';

	function add(shape) {
		var currDiv = document.createElement('div');
		currDiv.innerHTML += 'Div';

		currDiv.style.width = getRandomNumber(20, 50) + 'px';
		currDiv.style.height = getRandomNumber(20, 50) + 'px';
		currDiv.style.backgroundColor = getRandomColor();
		currDiv.style.color = getRandomColor();
		currDiv.style.border = 2 + 'px' + ' solid ' + getRandomColor();
		currDiv.style.borderRadius = getRandomNumber(0, 100) + 'px';
		currDiv.style.position = 'absolute';

		var root = document.getElementById('root');
		root.appendChild(currDiv);

		if (shape === 'ellipse') {
			var CENTER_X = 200;
			var CENTER_Y = 200;
			var RADIUS = 80;
			var OFFSET_X = 90;
			var OFFSET_Y = 0;

			var angle = 0;

			var functionTimer = setInterval(function moveDivs() {
				angle++;
				if (angle === 360) {
					angle = 0;
				}

				var left = CENTER_X + Math.cos((2 * 3.14 / 180) * (angle)) * (RADIUS + OFFSET_X);
				var right = CENTER_Y + Math.sin((2 * 3.14 / 180) * (angle)) * (RADIUS + OFFSET_Y);

				currDiv.style.left = left + 'px';
				currDiv.style.top = right + 'px';
			}, 20);
		} else if (shape === 'rect') {
		    var WIDTH = 150;
		    var HEIGHT = 350;
		    var START_X = 600;
		    var START_Y = 200;
		    var centerX = START_X;
		    var centerY = START_Y;
			var direction = 0;

			var functionTimer = setInterval(function moveDivs() {
				if (direction > 3) {
					direction = 0;
				}

				switch (direction) {
					case 0: centerX += 1;
						if (centerX > START_X + WIDTH) {
							direction++;
						}
						break;
					case 1: centerY += 1;
						if (centerY > START_Y + HEIGHT) {
							direction++;
						}
						break;
					case 2: centerX -= 1;
						if (centerX < START_X) {
							direction++;
						}
						break;
					case 3: centerY -= 1;
						if (centerY < START_Y) {
							direction++;
						}
						break;
				}

				currDiv.style.left = centerX + 'px';
				currDiv.style.top = centerY + 'px';
			}, 10);
		}

	}

	function getRandomNumber(min, max) {
		return Math.floor(Math.random() * (max - min + 1)) + min;
	}


	function getRandomColor() {
		var red = Math.floor(Math.random() * 256);
		var green = Math.floor(Math.random() * 256);
		var blue = Math.floor(Math.random() * 256);

		return 'rgb(' + red + ',' + green + ',' + blue + ')';
	}

	return {
		add: add
	}
};