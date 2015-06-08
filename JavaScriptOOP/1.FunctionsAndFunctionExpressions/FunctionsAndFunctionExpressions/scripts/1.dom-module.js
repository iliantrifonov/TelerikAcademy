var domManipulateModule = function domManipulate() {
    'use strict';
    var BUFFER_SIZE = 100;
    var bufferSelectorArray = [];

    function appendChild(domElement, selector) {
        var targetElements = document.querySelectorAll(selector);

        for (var i = 0; i < targetElements.length; i++) {

            targetElements[i].appendChild(domElement);
        }
    }

    function removeChild(parentSelector, elementToRemoveSelector) {
        var parents = document.querySelectorAll(parentSelector);

        for (var i = 0; i < parents.length; i++) {

            var elementToRemove = parents[i].querySelector(elementToRemoveSelector);

            parents[i].removeChild(elementToRemove);
        }
    }

    function addHandler(selector, eventName, func) {
        var elements = document.querySelectorAll(selector);

        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(eventName, func);
        }
    }

    function appendToBuffer(containerSelector, domElement) {
        if (bufferSelectorArray[containerSelector]) {

            if (bufferSelectorArray[containerSelector].length >= BUFFER_SIZE) {

                var parents = document.querySelectorAll(containerSelector);

                console.log(bufferSelectorArray[containerSelector]);
                for (var i = 0; i < parents.length; i++) {
                    var selectedParent = parents[i];
                    var frag = document.createDocumentFragment();
                    for (var j = 0, len = bufferSelectorArray[containerSelector].length; j < len; j++) {
                        var elementToAppend = bufferSelectorArray[containerSelector][j];
                        frag.appendChild(elementToAppend.cloneNode(true));
                    }
                    selectedParent.appendChild(frag.cloneNode(true));

                    bufferSelectorArray[containerSelector] = [];
                }
            } else {

                bufferSelectorArray[containerSelector].push(domElement.cloneNode(true));
            }
        } else {
            bufferSelectorArray[containerSelector] = [];
            bufferSelectorArray[containerSelector].push(domElement.cloneNode(true));
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
    }
};