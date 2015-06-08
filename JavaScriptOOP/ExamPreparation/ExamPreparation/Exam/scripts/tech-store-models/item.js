define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(type, name, price) {
           
            var isValidType = (type === 'accessory' || type === 'smart-phone' || type === 'notebook' || type === 'pc' || type === 'tablet');
            if (!(typeof type === 'string' || type instanceof String)) {
                throw {
                    message: 'The type is not a string'
                }
            } else if (!isValidType) {
                throw {
                    message: "Types can only be 'accessory', 'smart-phone', 'notebook', 'pc' or 'tablet'"
                }
            }

            if (!(typeof name === 'string' || name instanceof String)) {
                throw {
                    message: 'The name is not a string'
                }
            } else if (name.length > 40 || name.length < 6) {
                throw {
                    message: 'The name must be between 6 and 40 characters ( inclusive )'
                }
            }

            if (isNaN(price)) {
                throw {
                    message: 'The price must be a number'
                }
            } else if (price < 0) {
                throw {
                    message: 'Price cannot be a negative number'
                }
            }

            this._type = type;
            this._name = name;
            this._price = price;
        }

        Item.prototype.getType = function getType() {
            return this._type;
        }

        Item.prototype.getName = function getName() {
            return this._name;
        }

        Item.prototype.getPrice = function getPrice() {
            return this._price;
        }

        return Item;
    })();

    return Item;
});