/// <reference path="jquery-2.1.1.min.js" />
/// <reference path="handlebars-v1.3.0.js" />
(function () {
	'use strict';
	var items = [{
		value: 1,
		text: 'Bear'
	}, {
		value: 2,
		text: 'Horse'
	}];

	var sourse = $('#template').html();
	var template = Handlebars.compile(sourse);
	document.body.innerHTML += template({
		option: items
	});
})();