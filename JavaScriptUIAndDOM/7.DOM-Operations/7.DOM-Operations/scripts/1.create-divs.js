(function () {
	'use strict';

	generateDivs(getRandomInt(1, 10));

	function generateDivs(numberOfDivs) {
		for (var i = 0; i < numberOfDivs; i++) {
			document.body.appendChild(createRandomDiv());
		}
	}

	function createRandomDiv() {
		var result = document.createElement('div'),
		  style = result.style;

		style.width = getRandomInt(20, 100) + 'px';
		style.height = getRandomInt(20, 100) + 'px';

		style.backgroundColor = getRandomColor();

		style.color = getRandomColor();
		style.textAlign = 'center';

		style.position = 'absolute';
		style.top = getRandomInt(0, 75) + '%';
		style.left = getRandomInt(0, 75) + '%';

		style.borderRadius = getRandomInt(0, 50) + '%';
		style.borderColor = getRandomColor();
		style.borderWidth = getRandomInt(1, 20) + 'px';
		style.borderStyle = 'solid';

		result.appendChild(createStrong('div'));

		return result;
	}

	function getRandomColor() {
		return 'rgba(' + [
			getRandomInt(0, 255),
			getRandomInt(0, 255),
			getRandomInt(0, 255),
			getRandomInt(1, 10) / 10
		].join(', ') + ')';
	}

	function createStrong(text) {
		var result = document.createElement('strong');

		result.appendChild(document.createTextNode(text));

		return result;
	}

	//using a function from mozilla MDN
	//https://developer.mozilla.org/en-US/docs/JavaScript/Reference/Global_Objects/Math/random
	function getRandomInt(min, max) {
		return Math.floor(Math.random() * (max - min + 1)) + min;
	}
})();