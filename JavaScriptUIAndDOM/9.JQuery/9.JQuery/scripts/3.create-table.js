/// <reference path="jquery-2.1.1.min.js" />
(function () {
    'use strict';

    var $table = $('<table />');
    
    var $thead = $('<thead />'),
        $trow = $('<tr />'),
        $firstName = $('<th />'),
        $lastName = $('<th />'),
        $grade = $('<th />');

    $firstName.html('First Name');
    $lastName.html('Last Name');
    $grade.html('Grade');

    $trow.append($firstName);
    $trow.append($lastName);
    $trow.append($grade);

    $thead.append($trow);
    $table.append($thead);

    var students = createArrOfStudents(10);

    var $tbody = $('<tbody />');
    for (var i = 0, len = students.length; i < len; i++) {
        $trow = $('<tr />');
        $firstName = $('<td />');
        $lastName = $('<td />');
        $grade = $('<td />');

        $firstName.html(students[i].firstName);
        $lastName.html(students[i].lastName);
        $grade.html(students[i].grade);

        $trow.append($firstName);
        $trow.append($lastName);
        $trow.append($grade);

        $tbody.append($trow);
    }

    $table.append($tbody);

    $('#container').append($table);

    function createArrOfStudents(number) {
        var arr = [];

        for (var i = 0; i < number; i++) {
            arr.push({
                firstName: 'FirstName' + (i + 1),
                lastName: 'LastName' + (i + 1),
                grade: i
            });
        }

        return arr;
    }
})();