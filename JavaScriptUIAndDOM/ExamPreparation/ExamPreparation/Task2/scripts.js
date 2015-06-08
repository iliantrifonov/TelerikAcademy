/// <reference path="jquery.min.js" />
$.fn.tabs = function () {
    var $this = this;

    $this.addClass('tabs-container');
    var $tabContent = $this.find('.tab-item-content');
    $tabContent.hide();

    $this.on('click', '.tab-item-title' , function(ev) {
        var $that = $(this);
        $this.find('.tab-item').removeClass('current');
        $that.parent().addClass('current');
        $tabContent.hide();
        $that.parent().find('.tab-item-content').show();
    });

    $this.find('.tab-item-title').first().trigger('click');
};