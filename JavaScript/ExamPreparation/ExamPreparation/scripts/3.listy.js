function Solve(input) {
    var lineCount = input.length;
    var objectCollection = [];
    var a = 1;
    if (a.length) {

    }

    for (var i = 0; i < lineCount; i++) {

        var currentLetter = '';
        var lineText = input[i];
        var defVariable = '';
        var inBrackets = false;
        var numberArray = [];
        var methodName = '';
        for (var k = 0; k < input[i].length; k++) {

            currentLetter = lineText[k];

            if (inBrackets) {
                if (i === lineCount - 1) {
                    return getResultFromMethods(numberArray, methodName);
                }

                if (defVariable !== '') {
                    if (methodName === '') {
                        objectCollection[defVariable] = numberArray;
                    } else {
                        objectCollection[defVariable] = getResultFromMethods(numberArray, methodName);
                    }
                }
            }

            if (currentLetter === ' ') {
                continue;
            }

            if (lineText.substring(k, 4) === 'def ') {

                k += 3;

                while (lineText[k] === ' ') {
                    k++;
                }

                defVariable = '';

                while (lineText[k] !== ' ' && lineText[k] !== '[') {
                    defVariable += lineText[k];
                    k++;
                }

                if (lineText[k] === '[') {
                    k--;
                }

                continue;
            }

            if (lineText.substr(k, 3) === 'min' || lineText.substr(k, 3) === 'max' || lineText.substr(k, 3) === 'sum' || lineText.substr(k, 3) === 'avg') {
                if (lineText.substr(k, 3) === 'min') {
                    methodName = 'min';
                    k += 3;
                } else if (lineText.substr(k, 3) === 'max') {
                    methodName = 'max';
                    k += 3;
                } else if (lineText.substr(k, 3) === 'sum') {
                    methodName = 'sum';
                    k += 3;
                } else if (lineText.substr(k, 3) === 'avg') {
                    methodName = 'avg';
                    k += 3;
                }

                k--;
                continue;
            }

            if (!inBrackets && currentLetter === '[') {
                inBrackets = true;

                k++;

                var textBetweenBrackets = '';

                while (lineText[k] !== ']') {
                    textBetweenBrackets += lineText[k];
                    k++;
                }
                k--;

                textBetweenBrackets = textBetweenBrackets.replace(/,/g, ' ');
                textBetweenBrackets = textBetweenBrackets.split(' ');

                for (var index = 0; index < textBetweenBrackets.length; index++) {

                    if (textBetweenBrackets[index] === undefined || textBetweenBrackets[index] === '' || textBetweenBrackets[index] === ' ') {

                    } else if (isNaN(parseInt(textBetweenBrackets[index], 10))) {
                        numberArray.push(objectCollection[textBetweenBrackets[index]]);
                    } else {
                        numberArray.push(parseInt(textBetweenBrackets[index], 10));
                    }
                }

                continue;
            }
        }
    }

    function getResultFromMethods(arrOfNums, nameOfMethod) {
        if (arrOfNums.length === 1 && !arrOfNums[0].length) {

            return arrOfNums[0];
        }

        var num = arrOfNums[0];
        if (arrOfNums[0].length) {
            num = arrOfNums[0][0];
        }

        if (nameOfMethod === 'min') {
            var min = num;
            for (var i = 0; i < arrOfNums.length; i++) {
                if (arrOfNums[i].length) {
                    for (var z = 0; z < arrOfNums[i].length; z++) {
                        if (min > arrOfNums[i][z]) {
                            min = arrOfNums[i][z];
                        }
                    }
                } else if (min > arrOfNums[i]) {
                    min = arrOfNums[i];
                }
            }

            return min;
        } else if (nameOfMethod === 'max') {
            var max = num;
            for (var i = 0; i < arrOfNums.length; i++) {
                if (arrOfNums[i].length) {
                    for (var z = 0; z < arrOfNums[i].length; z++) {
                        if (max < arrOfNums[i][z]) {
                            max = arrOfNums[i][z];
                        }
                    }
                } else if (max < arrOfNums[i]) {
                    max = arrOfNums[i];
                }
            }

            return max;
        } else if (nameOfMethod === 'sum') {
            var sum = 0;
            for (var i = 0; i < arrOfNums.length; i++) {
                if (arrOfNums[i].length) {
                    for (var z = 0; z < arrOfNums[i].length; z++) {
                        sum += arrOfNums[i][z];
                    }
                } else {
                    sum += arrOfNums[i];
                }
            }

            return sum;
        } else if (nameOfMethod === 'avg') {
            var sum = 0;
            for (var i = 0; i < arrOfNums.length; i++) {
                if (arrOfNums[i].length) {
                    for (var z = 0; z < arrOfNums[i].length; z++) {
                        sum += arrOfNums[i][z];
                    }
                } else {
                    sum += arrOfNums[i];
                }
            }

            return Math.floor(sum / arrOfNums.length);
        }
    }
}