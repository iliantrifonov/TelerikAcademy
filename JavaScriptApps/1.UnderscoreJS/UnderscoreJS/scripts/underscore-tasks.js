/// <reference path="underscore.js" />
(function () {
    "use strict";

    var studentArray = [
        { firstName: 'Pesho', lastName: 'Ivanov', age: 20, marksAverage: 5 },
        { firstName: 'Ivan', lastName: 'Ivanov', age: 18, marksAverage: 3 },
        { firstName: 'Ali', lastName: 'Ivanov', age: 17, marksAverage: 5.3 },
        { firstName: 'Bali', lastName: 'Ali', age: 24, marksAverage: 4 },
        { firstName: 'Sivcho', lastName: 'Ivov', age: 25, marksAverage: 5.8 },
        { firstName: 'Ahoy', lastName: 'Morqk', age: 25, marksAverage: 6 },
        { firstName: 'Ahoy', lastName: 'Mao', age: 23, marksAverage: 3 },
    ];

    console.log('Students array:');
    console.dir(studentArray);
    console.log(' ');

    //Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name. Use Underscore.js

    function getFirstNameBeforeLast(students) {
        return _.chain(students)
                    .filter(function (a) {
                        return a.lastName > a.firstName;
                    })
                    .value();
    }

    console.log('1.Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name. Use Underscore.js');

    var filteredStudents = getFirstNameBeforeLast(studentArray);
    _.chain(filteredStudents)
        .map(function (st) {
            return {
                fullName: st.firstName + ' ' + st.lastName,
            }
        })
        .sortBy(function (a) {
            return -1 * a.fullName;
        })
        .each(function (st) {
            console.log(st.fullName);
        });

    console.log(' ');

    //Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js
    
    function getFirstAndLastNameBetweenAge(students, bottomAge, topAge) {
        return _.chain(students)
            .filter(function (st) {
                return (st.age >= bottomAge) && (st.age <= topAge);
            })
            .map(function (st) {
                return {
                    firstName: st.firstName,
                    lastName: st.lastName,
                }
            })
            .value();
    }

    console.log('2.Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js');

    var studentsWithOnlyFirstAndLastNameBetween18And24 = getFirstAndLastNameBetweenAge(studentArray, 18, 24);
    _.chain(studentsWithOnlyFirstAndLastNameBetween18And24).each(function (st) {
        console.log(st);
    });

    console.log(' ');

    //Write a function that by a given array of students finds the student with highest marks
    
    function getStudentWithHighestMarks(students) {
        return _.chain(students)
                    .sortBy(function (st) {
                        return st.marksAverage;
                    })
                    .last()
                    .value();
    }

    console.log('3.Write a function that by a given array of students finds the student with highest marks');

    console.log(getStudentWithHighestMarks(studentArray));

    console.log(' ');

    //Write a function that by a given array of animals, groups them by species and sorts them by number of legs
    
    var animalArray = [
        { type: 'Rhino', species: 'Mammal', legs: 4 },
        { type: 'Lion', species: 'Mammal', legs: 4 },
        { type: 'Bear', species: 'Mammal', legs: 4 },
        { type: 'Human', species: 'Mammal', legs: 2 },
        { type: 'Something with 6 legs', species: 'Mammal', legs: 6 },
        { type: 'Butterfly?', species: 'Bug', legs: 6 },
        { type: 'Stonojka', species: 'Bug', legs: 100 },
    ];

    function groupBySpeciesSortByLegs(animals) {
        return _.chain(animals)
            .sortBy(function (an) {
                return an.legs;
            })
            .groupBy(function (an) {
                return an.species;
            })
            .value();
    }

    console.log('4.Write a function that by a given array of animals, groups them by species and sorts them by number of legs');

    console.log(groupBySpeciesSortByLegs(animalArray));

    console.log(' ');

    console.log('5.By a given array of animals, find the total number of legs ');

    var totalLegs = 0;
    _.each(animalArray, function (an) {
        totalLegs += an.legs;
    });

    console.log(totalLegs);

    console.log(' ');

    var collectionOfBooks = [
        { name: 'Book1', author: 'Author 0' },
        { name: 'Book1', author: 'Author 1' },
        { name: 'Book2', author: 'Author 2' },
        { name: 'Book3', author: 'Author 2' },
        { name: 'Book4', author: 'Author 1' },
        { name: 'Book5', author: 'Author 1' },
    ];

    console.log('Book collection');
    console.dir(collectionOfBooks);

    console.log(' ');

    console.log('6.By a given collection of books, find the most popular author (the author with the highest number of books)');
    var mostPopularAuthor = _.chain(collectionOfBooks)
                                .countBy(function (book) {
                                    return book.author;
                                })
                                .pairs()
                                .sortBy(_.last)
                                .last()
                                .value();

    console.dir(mostPopularAuthor);

    console.log(' ');

    //By an array of people find the most common first and last name. Use underscore.

    function mostCommonName(people) {
        return { firstName:
            _.max(_.groupBy(people, function (person) {
                return person.firstName;
            }), function (peopleByName) {
                return peopleByName.length;
            })[0].firstName,

            lastName:
            _.max(_.groupBy(people, function (person) {
                return person.lastName;
            }), function (peopleByName) {
                return peopleByName.length;
            })[0].lastName
        };
    }

    console.log('7.By an array of people find the most common first and last name. Use underscore.');

    console.log(mostCommonName(studentArray));
})();