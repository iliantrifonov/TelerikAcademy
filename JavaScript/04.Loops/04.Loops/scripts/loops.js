(function () {
    console.log("1.Write a script that prints all the numbers from 1 to N");

    var printOneToN = function printOneToN(intNumber) {
        if (intNumber) {
            for (var i = 1; i < intNumber + 1; i++) {
                console.log(i);
            }
        }
    };

    console.log("N = 5");
    printOneToN(5);
    console.log(" ");
    console.log("2.Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time");

    var printOneToNDivisibleBy3And7 = function printOneToNDivisibleBy3And7(intNumber) {
        if (intNumber) {
            for (var i = 1; i < intNumber + 1; i++) {
                if (i % 3 === 0 && i % 7 === 0) {
                    console.log(i);
                }
            }
        }
    };

    console.log("N = 100");

    printOneToNDivisibleBy3And7(100);
    console.log(" ");

    console.log("3.Write a script that finds the max and min number from a sequence of numbers");

    var findMax = function findMax(intArray) {
        if (intArray && intArray.length > 0) {
            var max = intArray[0];
            for (var i = 1, len = intArray.length; i < len; i++) {
                if (max < intArray[i]) {
                    max = intArray[i];
                }
            }
            return max;
        }
    };

    var findMin = function findMin(intArray) {
        if (intArray && intArray.length > 0) {
            var min = intArray[0];
            for (var i = 1, len = intArray.length; i < len; i++) {
                if (min > intArray[i]) {
                    min = intArray[i];
                }
            }
            return min;
        }
    };

    var arrOfNums = [1, 4, 6, 2, 4, -1, -9, 10];
    console.log("For sequence [1,4,6,2,4,-1,-9,10]");
    console.log("Min value is: " + findMin(arrOfNums));
    console.log("Max value is: " + findMax(arrOfNums));
    console.log(" ");

    console.log("4.Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects ");

    var findLexicographicallySmallestProperty = function findLexicographicallySmallestProperty(obj) {
        if (obj) {
            var i = 0,
                smallestProperty;
            for (var prop in obj) {
                if (i === 0) {
                    smallestProperty = prop.toString();
                } else {
                    if (smallestProperty > prop.toString()) {
                        smallestProperty = prop.toString();
                    }
                }
                i++;
            }

            return smallestProperty;
        }
    };

    var findLexicographicallyLargestProperty = function findLexicographicallyLargestProperty(obj) {
        if (obj) {
            var i = 0,
                largestProperty;
            for (var prop in obj) {
                if (i === 0) {
                    largestProperty = prop.toString();
                } else {
                    if (largestProperty < prop.toString()) {
                        largestProperty = prop.toString();
                    }
                }
                i++;
            }

            return largestProperty;
        }
    };

    console.log("For document the lexicographically smallest and largest properties are: " + findLexicographicallySmallestProperty(document) + " and " + findLexicographicallyLargestProperty(document));
    console.log("For window the lexicographically smallest and largest properties are: " + findLexicographicallySmallestProperty(window) + " and " + findLexicographicallyLargestProperty(window));
    console.log("For navigator the lexicographically smallest and largest properties are: " + findLexicographicallySmallestProperty(navigator) + " and " + findLexicographicallyLargestProperty(navigator));
})();