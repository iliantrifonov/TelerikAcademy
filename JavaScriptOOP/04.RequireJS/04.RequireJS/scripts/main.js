/// <reference path="libs/jquery-2.1.1.min.js" />
/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="require.js" />

(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-2.1.1.min",
            "handlebars": "libs/handlebars-v1.3.0",
            "controls": "controls"
        }
    });

    require(["jquery", "controls"], function ($, controls) {

        var container = $("#container");
        var people = [
            { id: 1, name: "Doncho Minkov", age: 25, avatarUrl: "images/1.jpg" },
            { id: 2, name: "Georgi Georgiev", age: 23, avatarUrl: "images/2.jpg" },
            { id: 2, name: "Niki ", age: 19, avatarUrl: "images/3.jpg" }
        ];

        var comboBox = new controls.ComboBox(people);
        var template = $("#person-template").html();
        var comboBoxDiv = comboBox.render(template);
        console.dir(comboBoxDiv);
        container.append(comboBoxDiv);

    });
})();