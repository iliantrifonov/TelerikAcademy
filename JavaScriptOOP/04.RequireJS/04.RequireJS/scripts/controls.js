/// <reference path="libs/jquery-2.1.1.min.js" />
/// <reference path="require.js" />
/// <reference path="libs/handlebars-v1.3.0.js" />
(define(["jquery", "handlebars"], function ($) {

    var ComboBox = (function (people) {
        this._people = people;
        return this;
    });

    ComboBox.prototype.render = function (template) {
        var $div = $('<div />');
        var $outterShell = $('<div />');
        $outterShell.addClass('shell');
        $div.addClass('item');
        $div.addClass('hidden');

        $outterShell.on('click', function () {
            $outterShell.find('.item').toggleClass('hidden');
        });

        $outterShell.on('click', '.item', function () {
            $outterShell.find('.item').removeClass('selected');
            $(this).addClass('selected');
            $outterShell.toggleClass('hidden');
        });

        for (var i = 0, len = this._people.length; i < len; i++) {

            var compiled = Handlebars.compile(template);
            var $clone = $div.clone(true);
            $clone.html(compiled({
                name: this._people[i].name,
                age: this._people[i].age,
                avatarUrl: this._people[i].avatarUrl
            }));

            var className = 'option' + i;
            $clone.addClass(className);
            $outterShell.append($clone);
        }

        $outterShell.find('.option0').addClass('selected');

        return $outterShell;
    };

    return {
        ComboBox: ComboBox
    };
}));