define(function () {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function (section) {
            this._sections.push(section);
            return this;
        };

        Container.prototype.getData = function () {
            var dataSections = []

            for (var i = 0, len = this._sections.length; i < len; i++) {
                dataSections.push(this._sections[i].getData());
            }

            return cloneSections;
        };

        return Container;
    }());
    return Container;
});