(function () {
    console.log("1.Write a function that returns the last digit of given integer as an English word.");
    function getLastDigitAsString(intNumber) {
        var number = parseInt(intNumber, 10),
            digit;

        if (number) {
            number = number.toString();
            digit = number[number.length - 1];
            switch (digit) {
                case "0": return "zero";
                case "1": return "one";
                case "2": return "two";
                case "3": return "three";
                case "4": return "four";
                case "5": return "five";
                case "6": return "six";
                case "7": return "seven";
                case "8": return "eight";
                case "9": return "nine";
                default: return "Incorrect value of number";
            }
        }
    }

    var number = 53214;
    console.log("For the number " + number + " the result is " + getLastDigitAsString(number));
    console.log(" ");

    console.log("2.Write a function that reverses the digits of given decimal number.");
    //this will make a complete reversal ( with the decimal sign also moving)
    function reverseNumber(number) {
        var result = "";
        number = parseFloat(number);
        if (number) {
            number = number.toString();
            for (var i = number.length - 1; i >= 0; i--) {
                result += number[i];
            }

            result = parseFloat(result);
            return result;
        }
    }

    number = 532141;
    console.log("For the number " + number + " the result is " + reverseNumber(number));
    console.log(" ");

    console.log("3.Write a function that finds all the occurrences of word in a text");


    function wordOccurencesInText(text, word, isCaseSensitive) {
        var regex;
        if (isCaseSensitive === true) {
            regex = new RegExp('\\b' + word + '\\b', "g");
        } else {
            regex = new RegExp('\\b' + word + '\\b', "gi");
        }
        return text.match(regex).length;
    }

    var str = "text ttext tttext Text";
    console.log("For the text: " + str + " with case insensitive for 'text' word, the answer is: " + wordOccurencesInText(str, "text") + " and with case sensitive is : " + wordOccurencesInText(str, "text", true));
    console.log(" ");

    console.log("4.Write a function to count the number of divs on the web page");

    function numberOfDivs() {
        var count = document.getElementsByTagName("div").length;
        return count;
    }

    console.log("For this document, the amount of divs are: " + numberOfDivs());
    console.log(" ");

    console.log("5.Write a function that counts how many times given number appears in given array. Write a test function to check if the function is working correctly.");

    function timesInArray(intNumber, arr) {
        if (!isNaN(intNumber && arr.length > 0)) {
            var count = 0;

            for (var i = 0, len = arr.length; i < len; i++) {
                if (arr[i] === intNumber) {
                    count++;
                }
            }

            return count;
        }
    }

    function isTimesInArrayTest() {
        function testPositives() {
            var arr = [4, 2, 2, 5, 2, 1, 6, 1123, 2, 10, 10, 22],
                testNum = 2,
                expectedResult = 4;
            if (timesInArray(testNum, arr) === expectedResult) {
                return true;
            } else {
                return false;
            }
        }

        function testNegatives() {
            var arr = [-5, -5, -12, -33, -1, -5],
                testNum = -5,
                expectedResult = 3;
            if (timesInArray(testNum, arr) === expectedResult) {
                return true;
            } else {
                return false;
            }
        }

        function testIfFirstElementIsTheOnly() {
            var arr = [-5, 2, -12, -33, -1, 8, 232],
                testNum = -5,
                expectedResult = 1;
            if (timesInArray(testNum, arr) === expectedResult) {
                return true;
            } else {
                return false;
            }
        }

        function testIfLastElementIsTheOnly() {
            var arr = [-5, 2, -12, -33, -1, 8, 232],
                testNum = 232,
                expectedResult = 1;
            if (timesInArray(testNum, arr) === expectedResult) {
                return true;
            } else {
                return false;
            }
        }

        function testWithZero() {
            var arr = [-5, 2, -12, -33, -1, 8, 232],
                testNum = 2232,
                expectedResult = 0;
            if (timesInArray(testNum, arr) === expectedResult) {
                return true;
            } else {
                return false;
            }
        }

        if (testIfFirstElementIsTheOnly() && testIfLastElementIsTheOnly() && testNegatives() && testPositives() && testWithZero()) {
            return true;
        } else {
            return false;
        }
    }

    console.log("Running tests, if the function works correctly, tests will return true : " + isTimesInArrayTest());
    console.log(" ");

    console.log("6.Write a function that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).");

    function isBiggerThanNeighbours(arr, position) {
        if ((arr.length > 2) && !isNaN(position) && (position > -1)) {
            position = parseInt(position, 10);

            if ((position !== 0) && (position !== arr.length - 1)) {
                if ((arr[position] > arr[position - 1]) && (arr[position] > arr[position + 1])) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
    }

    var arr = [2, 3, 8, 1, 5];

    console.log("Checking for array : " + arr + " for position 1: " + isBiggerThanNeighbours(arr, 1) + ", and for position 2: " + isBiggerThanNeighbours(arr, 2) + ", and for position 0: " + isBiggerThanNeighbours(arr, 0) + ", and for last position: " + isBiggerThanNeighbours(arr, 4) + ". And for an empty array:" + isBiggerThanNeighbours([], 0));
    console.log(" ");

    console.log("7.Write a function that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.");

    function findIndexOfFirstElementGreaterThanNeighbors(arr) {
        if (arr.length > 0) {
            for (var i = 1, len = arr.length; i < len - 1; i++) {
                if (isBiggerThanNeighbours(arr, i)) {
                    return i;
                }
            }

            return -1;
        }
    }

    arr = [2, 3, 8, 1, 52, 2];
    console.log("Checking for array : " + arr + " the position of the element is: " + findIndexOfFirstElementGreaterThanNeighbors(arr));
})();