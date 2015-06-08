/// <reference path="item.js" />
define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;
    Store = (function () {

        function getItemsSortedByName() {
            var stock = this._stock.slice(0);
            stock = stock.sort(function(first, second) {
                return first._name.localeCompare(second._name);
            });

            return stock;
        }

        function getItemsWithType(array, types) {
            var typesLen = types.length;
            var resultArr = [];

            for (var i = 0, len = array.length; i < len; i++) {

                for (var k = 0; k < typesLen; k++) {
                    if (array[i]._type === types[k]) {
                        resultArr.push(array[i]);
                        break;
                    }
                }
            }

            return resultArr;
        }

        function Store(name) {
            if (!(typeof name === 'string' || name instanceof String)) {
                throw {
                    message: 'The name is not a string'
                }
            } else if (name.length > 30 || name.length < 6) {
                throw {
                    message: 'The name must be between 6 and 30 characters ( inclusive )'
                }
            }

            this._name = name;
            this._stock = [];
        }

        Store.prototype.getName = function getName() {
            return this._name;
        }

        Store.prototype.addItem = function addItem(item) {
            if (!(item instanceof Item)) {
				throw {
					message: 'Trying to add an object that is not an instance of Item'
				};
            }

            this._stock.push(item);

            return this;
        }

        Store.prototype.getAll = function getAll() {
            return getItemsSortedByName.call(this);
        }

        Store.prototype.getSmartPhones = function getSmartPhones() {
            var sorted = getItemsSortedByName.call(this);
            var result = getItemsWithType(sorted, ['smart-phone']);

            return result;
        }

        Store.prototype.getMobiles = function getMobiles() {
            var sorted = getItemsSortedByName.call(this);
            var result = getItemsWithType(sorted, ['smart-phone', 'tablet']);

            return result;
        }

        Store.prototype.getComputers = function getComputers() {
            var sorted = getItemsSortedByName.call(this);
            var result = getItemsWithType(sorted, ['pc', 'notebook']);

            return result;
        }

        Store.prototype.filterItemsByType = function filterItemsByType(type) {
            var sorted = getItemsSortedByName.call(this);
            var result = getItemsWithType(sorted, [type]);

            return result;
        }

        Store.prototype.filterItemsByPrice = function filterItemsByPrice(options) {
            if (options === undefined) {
                options = {};
            }
            var min = options.min || 0;
            var max;
            var collectionBetweenMinAndMax = [];

            if (options.max === 0) {
                max = 0;
            } else {
                max = options.max || Infinity;
            }

            for (var i = 0, len = this._stock.length; i < len; i++) {
                var currentItem = this._stock[i];
                if (currentItem._price >= min && currentItem._price <= max) {
                    collectionBetweenMinAndMax.push(currentItem);
                }
            }

            collectionBetweenMinAndMax = collectionBetweenMinAndMax.slice(0);

            collectionBetweenMinAndMax = collectionBetweenMinAndMax.sort(function (first, second) {
                return first._price - second._price;
            });

            return collectionBetweenMinAndMax;
        }

        Store.prototype.countItemsByType = function countItemsByType() {
            var len = this._stock.length;
            var result = {};

            result['accessory'] = 0;
            result['smart-phone'] = 0;
            result['notebook'] = 0;
            result['pc'] = 0;
            result['tablet'] = 0;

            for (var i = 0; i < len; i++) {
                var currentType = this._stock[i]._type;
                result[currentType] += 1;
            }

            return result;
        }

        Store.prototype.filterItemsByName = function filterItemsByName(partOfName) {
            var sorted = getItemsSortedByName.call(this);
            var result = [];
            partOfName = partOfName.toLowerCase();
            for (var i = 0, len = this._stock.length; i < len; i++) {
                var currentItem = this._stock[i];
                var nameToLower = currentItem._name.toLowerCase()

                if (nameToLower.indexOf(partOfName) > -1) {
                    result.push(currentItem);
                }
            }

            return result;
        }
        
        return Store;
    })();

    return Store;
});