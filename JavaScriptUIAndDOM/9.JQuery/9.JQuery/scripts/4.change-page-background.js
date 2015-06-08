/// <reference path="jquery-2.1.1.min.js" />
(function () {
    'use strict';
    $('#background-changer').on('change', function () {
        $('body').css('background-color', this.value);
    });
})();