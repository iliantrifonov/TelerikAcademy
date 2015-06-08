define(['todo-list/item'], function() {
    'use strict';
    var Section;
    Section = (function() {
        function Section(title) {
            this._title = title;
            this._items = [];
        }
	
        Section.prototype.add = function(item) {
            this._items.push(item);
            return this;
        };

        Section.prototype.getData = function () {

            var dataItems = [];

            for (var i = 0, len = this._items.length; i < len; i++) {
                dataItems.push(this._items[i].getData());
            }

            return {
                title: this._title,
                items: dataItems
            }
        };

        return Section;
    }());
    return Section;
})