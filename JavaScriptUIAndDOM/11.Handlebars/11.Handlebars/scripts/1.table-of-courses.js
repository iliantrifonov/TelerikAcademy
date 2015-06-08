/// <reference path="handlebars-v1.3.0.js" />
(function () {
    'use strict';
    var courseOne = {
        id: 1,
        title: "Course intro",
        dateOne: "Wed 18:00, 28 May 2014",
        dateTwo: "Tue 14:00, 29 May 2014",
    };

    var courseTwo = {
        id: 2,
        title: "DOM",
        dateOne: "Wed 18:00, 28 May 2014",
        dateTwo: "Tue 14:00, 29 May 2014",
    };

    var courseThree = {
        id: 3,
        title: "HTML5 Canvas",
        dateOne: "Thu 18:00, 04 Jun 2014",
        dateTwo: "Fri 14:00, 30 May 2014",
    };

    var courses = [courseOne, courseTwo, courseThree];
    Handlebars.registerHelper('courses', function () {
        return courses;
    })
    var source = $("#table-of-courses-template").html();
    var template = Handlebars.compile(source);
    var html = template({
        courses: courses
    });

    document.body.innerHTML += html;
})();