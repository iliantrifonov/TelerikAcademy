(function () {
    console.log("1.Write functions for working with shapes in standard Planar coordinate system. Points are represented by coordinates P(X, Y). Lines are represented by two points, marking their beginning and ending( L(P1(X1,Y1), P2(X2,Y2)) ). Calculate the distance between two points. Check if three segment lines can form a triangle");

    function Point(intX, intY) {
        intX = parseInt(intX, 10);
        intY = parseInt(intY, 10);
        if (intX && intY) {
            return {
                x: intX,
                y: intY
            };
        }
    }

    function Line(pointOne, pointTwo) {
        if (!isNaN(pointOne.x) && !isNaN(pointOne.y) && !isNaN(pointTwo.x) && !isNaN(pointTwo.y)) {
            return {
                x1: pointOne.x,
                y1: pointOne.y,
                x2: pointTwo.x,
                y2: pointTwo.y
            };
        }
    }

    function distanceBetweenTwoPoints(point1, point2) {
        var xs = 0;
        var ys = 0;

        xs = point2.x - point1.x;
        xs = xs * xs;

        ys = point2.y - point1.y;
        ys = ys * ys;

        return Math.sqrt(xs + ys);
    }

    function canFormTriangle(lineOne, lineTwo, lineThree) {
        return ((lineOne + lineTwo > lineThree) && (lineTwo + lineThree > lineOne) && (lineThree + lineOne > lineTwo));
    }

    var point = Point(5, 2);
    var pointTwo = Point(5, 5);

    console.log("Distance between two points " + JSON.stringify(point) + " and " + JSON.stringify(pointTwo) + " is: " + distanceBetweenTwoPoints(point, pointTwo));

    console.log("Check if three lines can form a triangle: " + canFormTriangle(Line(Point(5, 2), Point(5, 3)), Line(Point(10, 2), Point(15, -2)), Line(Point(5, 18), Point(-1, 3))));
    console.log(" ");

    console.log("2.Write a function that removes all elements with a given value. Attach it to the array type");

    Array.prototype.remove = function (elementToRemove) {
        for (var index in this) {
            if (this[index] === elementToRemove) {
                this.splice(index, 1);
            }
        }
    };

    var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];

    console.log("For the array: " + arr + " we use the remove method, and the result is: ");
    arr.remove(1);
    console.log(arr);
    console.log(" ");

    console.log("3.Write a function that makes a deep copy of an object. The function should work for both primitive and reference types");

    function deepClone(obj) {
        if (obj === null || typeof (obj) !== 'object') {
            return obj;
        }
        return JSON.parse(JSON.stringify(obj));
    }

    var num = deepClone(5);
    console.log("Cloning a number : " + num);

    var obj = deepClone(pointTwo);
    console.log("Clonning an object: ");
    console.log(obj);
    console.log(" ");

    console.log("4.Write a function that checks if a given object contains a given property");

    function hasProperty(obj, prop) {
        if (obj.hasOwnProperty(prop.toString())) {
            return true;
        } else {
            for (var p in obj) {
                if (p === prop.toString()) {
                    return true;
                }
            }
        }
        return false;
    }

    console.log("Check if the Point 'class' has 'x' property: " + hasProperty(pointTwo, 'x'));
    console.log(" ");

    console.log("5.Write a function that finds the youngest person in a given array of persons and prints his/hers full name");

    function printSmallestAgeInLog(people) {
        if (people.length > 0 && people[0].firstname && people[0].lastname && people[0].age) {
            var minAge = people[0].age,
                minAgeIndex = 0;

            for (var i = 0, len = people.length; i < len; i++) {
                if (people[i].age < minAge) {
                    minAge = people[i].age;
                    minAgeIndex = i;
                }
            }

            console.log(people[minAgeIndex]);
        }
    }

    var people = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Bat ti', lastname: 'Gosho', age: 26 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 }, ];

    console.log("Testing with array of people, the youngest:");
    printSmallestAgeInLog(people);
    console.log(" ");

    console.log("6.Write a function that groups an array of persons by age, first or last name. The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups");
    function group(people, property) {
        if (people.length > 0 && people[0][property]) {
            var resultCollection = [];
            for (var i = 0, len = people.length; i < len; i++) {
                resultCollection[people[i][property]] = deepClone(people[i]);
            }

            return resultCollection;
        }
    }

    console.log("Group by age: ");
    var groupedByAge = group(people, 'age');
    console.log("The check who has age of 32: " + JSON.stringify(groupedByAge[32]));

    console.log("Group by firstname: ");
    var groupedByFirstName = group(people, 'firstname');
    console.log("The check who has firstname Bay: " + JSON.stringify(groupedByFirstName["Bay"]));
})();