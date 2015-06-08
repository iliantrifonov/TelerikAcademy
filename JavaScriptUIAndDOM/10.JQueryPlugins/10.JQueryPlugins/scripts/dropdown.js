/// <reference path="jquery-2.1.1.min.js" />
(function ($) {
    $.fn.dropdown = function (selector) {
        var $this = $(this);

        /* IMPORTANT comment the row below for testing */
        $this.hide();

        var $container = $('<div />').addClass('dropdown-list-container'),
            $ul = $('<ul />').addClass('dropdown-list-options'),
            $li;

        var $options = $this.find('option');
        for (var i = 0, len = $options.length; i < len; i++) {
            $li = $('<li />')
                .addClass('dropdown-list-option')
                .attr('data-value', i + 1)
                .on('click', function (ev) {
                    $('.dropdown-list-option').show();
                })
                .on('dblclick', function (ev) {
                    var $that = $(this);
                    $this.val($(ev.target).attr('data-value'));
                    $('.dropdown-list-option').hide();
                    $that.show();
                });

            $li.html($($options[i]).html());
            $ul.append($li.clone(true));
        }

        $ul.children()
            .hide()
            .css({
                'list-style': 'none',
                width: '40px',
                border: '1px solid black',
                padding: '3px 3px',
            });
        $ul.children().first().show();
        $container.append($ul.clone(true));
        $('body').append($container.clone(true));

        return $this;
    }
})(jQuery);