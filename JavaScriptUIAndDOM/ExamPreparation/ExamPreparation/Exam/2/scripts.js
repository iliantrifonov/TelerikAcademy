/// <reference path="jquery.min.js" />
$.fn.gallery = function (collumns) {
    var col = collumns || 4,
        $this = this,
        lastImageDataInfo = $this.find('.image-container').last().find('img').attr('data-info');
    lastImageDataInfo = parseInt(lastImageDataInfo);
    $this.addClass('gallery');

    for (var i = 1; i < lastImageDataInfo; i++) {
        if (i % (col) === 0) {
            if (true) {
                
                $this.find(getSelectorString(i + 1)).parent().addClass('clearfix');
            }
            else {
                 $this.find(getSelectorString(i)).parent().addClass('clearfix');
            }
        }
    }

    //var imgWidth = $this.find('img')[0].width;
    //$this.css({
    //    width: (imgWidth * col) + ((col * 2) * 5),
    //});

    $this.find('.selected').hide();

    $this.on('click', '.image-container', clickImage);
    $this.on('click', '.current-image', clickSelected);
    $this.on('click', '.previous-image', clickPrevImage);
    $this.on('click', '.next-image', clickNextImage);
    
    function clickSelected() {
        var selectedDiv = $this.find('.selected');
        if (selectedDiv.hasClass('shown')) {
            selectedDiv.hide();
            selectedDiv.removeClass('shown');
            $this.on('click', '.image-container', clickImage);
            $this.find('.gallery-list').removeClass('blurred');
        }
    }

    function clickNextImage() {
        var $that = $(this).find('img'),
            $container = $this.find('.selected'),
            clickedDataInfo = parseInt($that.attr('data-info')),
            current = clickedDataInfo,
            next = clickedDataInfo + 1,
            prev = clickedDataInfo - 1;

        if (next > lastImageDataInfo) {
            next = 1;
        }

        if (prev < 1) {
            prev = lastImageDataInfo;
        }

        $container.find('.current-image img').attr('src', $this.find(getSelectorString(current)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(current)).attr('data-info'));

        $container.find('.previous-image img').attr('src', $this.find(getSelectorString(prev)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(prev)).attr('data-info'));

        $container.find('.next-image img').attr('src', $this.find(getSelectorString(next)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(next)).attr('data-info'));
    }

    function clickPrevImage() {
        var $that = $(this).find('img'),
            $container = $this.find('.selected'),
            clickedDataInfo = parseInt($that.attr('data-info')),
            current = clickedDataInfo,
            next = clickedDataInfo + 1,
            prev = clickedDataInfo - 1;
        if (prev < 1) {
            prev = lastImageDataInfo;
        }

        if (next < 1) {
            next = lastImageDataInfo;
        }

        if (next > lastImageDataInfo) {
            next = 1;
        }

        $container.find('.current-image img').attr('src', $this.find(getSelectorString(current)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(current)).attr('data-info'));

        $container.find('.previous-image img').attr('src', $this.find(getSelectorString(prev)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(prev)).attr('data-info'));

        $container.find('.next-image img').attr('src', $this.find(getSelectorString(next)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(next)).attr('data-info'));
        
    }

    function getSelectorString(dataInfo){
        return 'img[data-info=' + dataInfo + ']';
    }

    function clickImage() {
        
        $this.find('.gallery-list').addClass('blurred');
        $this.off('click', '.image-container');
        var $that = $(this),
            $container = $this.find('.selected'),
            current = parseInt($that.find('img').attr('data-info')),
            prev = current - 1,
            next = current + 1;
        if (next > lastImageDataInfo) {
            next = 1;
        }

        if (prev < 1) {
            prev = lastImageDataInfo;
        }

        if (next < 1) {
            next = lastImageDataInfo;
        }

        $container.find('.current-image img').attr('src', $this.find(getSelectorString(current)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(current)).attr('data-info'));

        $container.find('.previous-image img').attr('src', $this.find(getSelectorString(prev)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(prev)).attr('data-info'));

        $container.find('.next-image img').attr('src', $this.find(getSelectorString(next)).attr('src'))
        .attr('data-info', $this.find(getSelectorString(next)).attr('data-info'));

        $container.show()
            .addClass('shown');
    }
};