/// <reference path="jquery-2.1.1.min.js" />
(function () {
	'use strict';

	// using the native .before and .after functions

	var $target = $('#target'),
		$elementToInsertBefore = $('<div />'),
		$elementToInsertAfter = $('<div />');

	$elementToInsertBefore.addClass('before');
	$elementToInsertAfter.addClass('after');

	$target.before($elementToInsertBefore);
	$target.after($elementToInsertAfter);
})();