(function () {
    console.log("1.Write a script that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.");

    var intArray = [];

    for (var i = 0; i < 20; i++) {
        intArray[i] = i * 5;
        console.log("[" + i + "]" + " => " + intArray[i]);
    }

    console.log(" ");

    console.log("2.Write a script that compares two char arrays lexicographically (letter by letter).");

    var isCharArrayEqual = function isCharArrayEqual(charArr, secondCharArr) {
        if (charArr.length > 0 && secondCharArr.length > 0) {
            var len = charArr.length;
            if (charArr.length !== secondCharArr.length) {
                return false;
            }

            for (var i = 0; i < len; i++) {
                if (charArr[i] !== secondCharArr[i]) {
                    return false;
                }
            }

            return true;
        }
    };

    var charArray = ["a", "b", "c", "d"];
    var otherCharArray = ["a", "b", "c", "d"];
    console.log("Comparing arrays that contain 'a' 'b' 'c' 'd' the result is: " + isCharArrayEqual(charArray, otherCharArray));

    otherCharArray = ["a", "b", "c", "z"];
    console.log("Comparing arrays that contain 'a' 'b' 'c' 'd', and 'a' 'b' 'c' 'z' the result is: " + isCharArrayEqual(charArray, otherCharArray));

    otherCharArray = ["a", "b", "c"];
    console.log("Comparing arrays that contain 'a' 'b' 'c' 'd', and 'a' 'b' 'c' the result is: " + isCharArrayEqual(charArray, otherCharArray));
    console.log(" ");

    console.log("3.Write a script that finds the maximal sequence of equal elements in an array.");

    var returnMaxSequenceOfElementsInArray = function returnMaxSequenceOfElementsInArray(collection) {
        var element,
            maxElement,
            elemCounter = 1,
            maxElementCounter = 0,
            resultArray = [];

        if (collection.length > 0) {
            element = collection[0];

            for (var i = 1, len = collection.length; i < len; i++) {
                if (collection[i] === element) {
                    elemCounter++;
                } else {
                    if (elemCounter > maxElementCounter) {
                        maxElementCounter = elemCounter;
                        maxElement = element;
                    }
                    element = collection[i];
                    elemCounter = 1;
                }
            }

            for (var i = 0; i < maxElementCounter; i++) {
                resultArray[i] = maxElement;
            }

            return resultArray;
        }
    };

    var arr = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];

    console.log("For the array : " + arr + " the max sequence of elements is: " + returnMaxSequenceOfElementsInArray(arr));
    console.log(" ");

    console.log("4.Write a script that finds the maximal increasing sequence in an array");

    var returnMaxIncreasingSequenceOfElementsInArray = function returnMaxIncreasingSequenceOfElementsInArray(collection) {
        var element,
            elemCounter = 1,
            maxElementCounter = 0,
            resultArray = [],
            maxResultArray = [];

        if (collection.length > 0) {
            element = collection[0];
            resultArray[0] = collection[0];
            for (var i = 1, len = collection.length; i < len; i++) {
                if (collection[i] > element) {
                    elemCounter++;
                    element = collection[i];
                    resultArray[elemCounter - 1] = collection[i];
                } else {
                    if (elemCounter > maxElementCounter) {
                        maxElementCounter = elemCounter;
                        maxResultArray = resultArray;
                    }
                    element = collection[i];
                    elemCounter = 1;
                    resultArray = [];
                    resultArray[0] = collection[i];
                }
            }

            return maxResultArray;
        }
    };

    arr = [3, 2, 3, 4, 2, 2, 4];

    console.log("For the array : " + arr + " the max increasing sequence of elements is: " + returnMaxIncreasingSequenceOfElementsInArray(arr));
    console.log(" ");

    console.log("5.Sorting an array means to arrange its elements in increasing order. Write a script to sort an array. Use the \"selection sort\" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position,etc.");

    // there is no need to use a second array.. so I'm not going to
    var selectionSort = function selectionSort(collection) {
        if (collection.length > 1) {
            var swapHelper,
                currentMin,
                indexOfMin;

            for (var i = 0, len = collection.length; i < len; i++) {
                currentMin = collection[i];
                indexOfMin = i;
                for (var k = i; k < len; k++) {
                    if (collection[k] < currentMin) {
                        currentMin = collection[k];
                        indexOfMin = k;
                    }
                }
                if (indexOfMin != i) {
                    swapHelper = collection[i];
                    collection[i] = collection[indexOfMin];
                    collection[indexOfMin] = swapHelper;
                }
            }
        }
    };
    arr = [-5, 110, -1993, 222, 1, 4324, 333];
    console.log("For the array : " + arr + " after sorting is: ");
    selectionSort(arr);
    console.log(arr);
    console.log(" ");

    console.log("6.Write a program that finds the most frequent number in an array.");
    var mostFrequentNumberInArrayAndTimesMet = function mostFrequentNumberInArray(collection) {
        if (collection.length > 1) {
            var number,
                timesCounter,
                maxTimesCounter = 0;

            for (var i = 1, len = collection.length; i < len; i++) {
                timesCounter = 1;

                for (var k = i; k < len; k++) {
                    if (collection[i] === collection[k]) {
                        timesCounter++;
                    }
                }

                if (timesCounter > maxTimesCounter) {
                    maxTimesCounter = timesCounter;
                    number = collection[i];
                }
            }

            return number + "(" + maxTimesCounter + " times)";
        }
    };

    arr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
    console.log("For the array : " + arr + " the the most frequent number is: " + mostFrequentNumberInArrayAndTimesMet(arr));
    console.log(" ");

    console.log("7.Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).");

    var binarySearch = function binarySearch(sortedCollection, searchValue) {
        if (sortedCollection.length > 0 && searchValue) {
            var minIndex = 0,
                maxIndex = sortedCollection.length - 1,
                currentIndex,
                currentElement;

            while (minIndex <= maxIndex) {
                currentIndex = (minIndex + maxIndex) / 2 | 0;
                currentElement = sortedCollection[currentIndex];

                if (currentElement < searchValue) {
                    minIndex = currentIndex + 1;
                } else if (currentElement > searchValue) {
                    maxIndex = currentIndex - 1;
                } else {
                    return currentIndex;
                }
            }
            return -1;
        }
    };

    arr = [4, 3, 2, 5, 7, 22, 88, 1, 99, 0, -52];
    selectionSort(arr);

    console.log("For the sorted array:" + arr + " we are looking for the index of value 3, and it is: " + binarySearch(arr, 3));
})();