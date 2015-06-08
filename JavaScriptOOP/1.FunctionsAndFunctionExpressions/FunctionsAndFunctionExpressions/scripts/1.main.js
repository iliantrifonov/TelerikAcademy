/// <reference path="dom-module.js" />
(function () {
    // for task 1 : Create a module for working with DOM. The module should have the following functionality

    var domModule = domManipulateModule();
    var div = document.createElement("div");
    div.innerHTML += 'Added div';
    //appends div to #wrapper
    domModule.appendChild(div, "#root"); 
    //removes li:first-child from ul
    domModule.removeChild("ul","li:first-child"); 
    //add handler to each a element with class button
    domModule.addHandler("a.button", 'click', function () {
        alert("Clicked")
    });

    var navItem = document.createElement('li');
    navItem.innerHTML += 'Added nav item';
    for (var i = 0; i <= 100; i++) {

        domModule.appendToBuffer("#container", div.cloneNode(true));
        domModule.appendToBuffer("#main-nav ul", navItem);
    }

})();