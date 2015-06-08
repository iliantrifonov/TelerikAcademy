/// <reference path="jquery-2.1.1.min.js" />
(function () {
	"use strict";
    var $container = $('#slider-control'),
        /* IMPORTANT the reason the buttons here taken from the html and not made here, is so the user can use any tag and shape he likes, and it will still work */
        $prevBtn = $container.find('#slider-control-previous'),
		$nextBtn = $container.find('#slider-control-next'),
        $contentContainer = $container.find('#slider-control-slide-content'),
        $slides = $contentContainer.find('.slider-control-slide');
	styleSlides($slides);
	$slides.hide();
	if ($contentContainer.find('.current').length === 0) {
	    $slides.first().addClass('current');
	}
	$contentContainer.find('.current').show();
	$container.css('position', 'relative');

	$prevBtn.css({
	    'position': 'absolute',
	    'top': ($container.height() / 2).toString() + 'px',
	    'left': '0px',
	    'width': '10%'
	});

	$nextBtn.css({
	    'position': 'absolute',
	    'top': ($container.height() / 2).toString() + 'px',
	    'right': '0px',
	    'width': '10%'
	});

	$prevBtn.on('click', function() {
	    var $curSlide = $contentContainer.find('.current');
	    if ($curSlide.prev().length !== 0) {
	        $curSlide.removeClass('current');
	        $curSlide.prev().addClass('current');
	        $slides.hide();
	        $contentContainer.find('.current').show();
	    }
	});

	$nextBtn.on('click', function () {
	    var $curSlide = $contentContainer.find('.current');
	    if ($curSlide.next().length !== 0) {
	        $curSlide.removeClass('current');
	        $curSlide.next().addClass('current');
	        $slides.hide();
	        $contentContainer.find('.current').show();
	    }
	});

	window.setInterval(function () {
	    $nextBtn.click();
	}, 5000);

	function styleSlides($slides) {
	    $slides.children().css({
	        'position': 'relative',
	        'left': '10%',
	        'width': '80%',
	    });
	}
})();