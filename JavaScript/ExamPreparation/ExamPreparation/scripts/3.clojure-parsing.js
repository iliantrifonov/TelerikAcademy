function Solve(input) {
	var len = input.length;
	var currentChar = '';
	var totalResult = 0;
	var mathSign = '';
	var objectStorage = [];

	for (var k = 0; k < len; k++) {

		var rowLength = input[k].length;
		var currentRow = input[k];
		var currentNumber = '';
		var arrayOfNumbers = [];
		var innerArrayOfNumbers = [];
		var innerMathSign = '';
		mathSign = '';
		var defVariableName = '';
		var inOuterBrackets = false;
		var inInnerBrackets = false;

		for (var i = 0; i < rowLength; i++) {

			currentChar = currentRow[i];
			if (currentChar === ' ') {
				continue;
			}

			if (!inOuterBrackets && currentChar === '(') {
			    inOuterBrackets = true;
			    continue;
			}

			if (inInnerBrackets) {
			    if (isMathSign(currentChar)) {

			        if (currentChar === '-' && isDigit(currentRow[i + 1])) {
			            currentNumber += currentChar;
			            continue;
			        }
			        innerMathSign = currentChar;
			        continue;
			    }

			    if (isDigit(currentChar)) {

			        currentNumber += currentChar;
			        if (isDigit(currentRow[i + 1])) {
			            continue;
			        }

			        innerArrayOfNumbers.push(parseInt(currentNumber));
			        currentNumber = '';
			        continue;
			    }

			    if (currentChar === ')') {
			        inInnerBrackets = false;
			        var calcResult = calculate(innerArrayOfNumbers, innerMathSign);

			        if (calcResult === 'Zero') {
			            return 'Division by zero! At Line:' + (k + 1);
			        }

			        if (defVariableName !== '') {
			            objectStorage[defVariableName] = calcResult;
			            defVariableName = '';
			            continue;
			        }

			        totalResult = calcResult;
			        continue;
			    }

			    if (true) {
			        var currentVarForArr = '';

			        while (currentRow[i] === ' ') {
			            i++;
			        }

			        while (currentRow[i] !== ' ' && currentRow[i] !== ')') {
			            currentVarForArr += currentRow[i];
			            i++;
			        }

			        if (currentRow[i] === ')') {
			            i--;
			        }

			        if (objectStorage[currentVarForArr] === 0 || objectStorage[currentVarForArr]) {
			            innerArrayOfNumbers.push(objectStorage[currentVarForArr]);
			        }

			        continue;
			    }
			}

			if (inOuterBrackets && currentChar === '(' && !inInnerBrackets) {
			    inInnerBrackets = true;
			    continue;
			}

			if (isMathSign(currentChar)) {

				if (currentChar === '-' && isDigit(currentRow[i + 1])) {
					currentNumber += currentChar;
					continue;
				}
				mathSign = currentChar;
				continue;
			}

			if (isDigit(currentChar)) {

				currentNumber += currentChar;
				if (isDigit(currentRow[i + 1])) {
					continue;
				}

				arrayOfNumbers.push(parseInt(currentNumber));
				currentNumber = '';
				continue;
			}

			if (currentChar === ')') {
			    var calcResult = calculate(arrayOfNumbers, mathSign);

			    if (calcResult === 'Zero') {
				    return 'Division by zero! At Line:' + (k + 1);
				}

			    if (defVariableName !== '') {
			        objectStorage[defVariableName] = calcResult;
			        defVariableName = '';
			        continue;
			    }

			    totalResult = calcResult;
				continue;
			}

			if (currentChar === 'd' && currentRow[i + 1] === 'e' && currentRow[i + 2] === 'f' && currentRow[i + 3] === ' ' && (currentRow[i - 1] === ' ' || currentRow[i - 1] === '(')) {
				defVariableName = '';
				i += 4;
				while (currentRow[i] === ' ') {
				    i++;
				}

				while (currentRow[i] !== ' ') {
				    defVariableName += currentRow[i];
				    i++;
				}

				continue;
			}

			if (true) {
				var currentVarForArr = '';

				while (currentRow[i] === ' ') {
				    i++;
				}

				while (currentRow[i] !== ' ' && currentRow[i] !== ')') {
				    currentVarForArr += currentRow[i];
				    i++;
				}

				if (currentRow[i] === ')') {
				    i--;
				}

				if (objectStorage[currentVarForArr] === 0 || objectStorage[currentVarForArr]) {
				    arrayOfNumbers.push(objectStorage[currentVarForArr]);
				}

				continue;
			}
		}
	}

	return totalResult;

	function isMathSign(character) {
		if (character === '*' || character === '/' || character === '-' || character === '+') {
		    return true;
		}
		
		return false;
	}

	function isDigit(character) {
		switch (character) {
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
			case '0': return true;
			default: return false;
		}
	}

	function calculate(arrOfNums, sign) {
		
		var result = arrOfNums[0];
		var len = arrOfNums.length;
		if (len === 1) {
			return result;
		}

		if (sign === '*') {
			for (var j = 1; j < len; j++) {
				result *= arrOfNums[j];
			}
		} else if (sign === '+') {
			for (var j = 1; j < len; j++) {
				result += arrOfNums[j];
			}

		} else if (sign === '-') {
			for (var j = 1; j < len; j++) {
				result -= arrOfNums[j];
			}
		} else if (sign === '/') {
		    for (var j = 1; j < len; j++) {
		        if (arrOfNums[j] === 0) {
		            return "Zero";
		        }
				result /= arrOfNums[j];
				result = Math.floor(result);
			}
		}
		return result;
	}
}



//var test1 = [
//    '  (   + 1    2    ) ',
//    '(+ 5 2 7 1)',
//    '(- 4 2) ',
//    '(/ 10 3 0) '
//];

//var test2 = [
//    ' (   def hak221 25)',
//    '( + 2 3 hak221 1 ) '
//];

//var test3 = [
//    '(def myFunc 5) ',
//    '(def myNewFunc (+  myFunc  myFunc 2))',
//    '(def MyFunc (* 2  myNewFunc)) ',
//    '(/   MyFunc  myFunc) ',
//];

//console.log(Solve(test3));