console.log("1. Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.");

var firstNum = 5;
var secondNum = 2;

console.log("First number is " + firstNum + ", and the second number is " + secondNum + " before the swap");
//making sure its an integer and that it exists
firstNum = parseInt(firstNum);
secondNum = parseInt(secondNum);
if (firstNum && secondNum) {
    if (firstNum > secondNum) {
        var largest = firstNum;
        firstNum = secondNum;
        secondNum = largest;
    }
}

console.log("First number is " + firstNum + ", and the second number is " + secondNum + " after the swap");
console.log("");

console.log("2.Write a script that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.");

firstNum = -5;
secondNum = 2;
var thirdNum = -1;
var countNegative = 0;
if (firstNum < 0) {
    countNegative++;
}
if (secondNum < 0) {
    countNegative++;
}
if (thirdNum < 0) {
    countNegative++;
}

if (countNegative % 2 === 0) {
    console.log("The sign of the numbers " + firstNum + ", " + secondNum + ", " + thirdNum + " is '+'");
} else {
    console.log("The sign of the numbers " + firstNum + ", " + secondNum + ", " + thirdNum + " is '-'");
}
console.log("");

console.log("3.Write a script that finds the biggest of three integers using nested if statements.");

firstNum = 5;
secondNum = 55;
thirdNum = -1;
//making sure its int
firstNum = parseInt(firstNum);
secondNum = parseInt(secondNum);
thirdNum = parseInt(thirdNum);

if (firstNum > secondNum) {
    if (firstNum > thirdNum) {
        console.log("The largest number is " + firstNum);
    } else {
        console.log("The largest number is " + thirdNum);
    }
} else {
    if (secondNum > thirdNum) {
        console.log("The largest number is " + secondNum);
    } else {
        console.log("The largest number is " + thirdNum);
    }
}
console.log("");

console.log("4.Sort 3 real values in descending order using nested if statements.");

firstNum = 5;
secondNum = 2;
thirdNum = 8;
var swapHelper;
console.log("The unsorted numbers are:");
console.log(firstNum + " " + secondNum + " " + thirdNum);

for (var i = 0; i < 2; i++) {
    if (firstNum < secondNum) {
        swapHelper = secondNum;
        secondNum = firstNum;
        firstNum = swapHelper;
        if (firstNum < thirdNum) {
            swapHelper = thirdNum;
            thirdNum = firstNum;
            firstNum = swapHelper;
        }
    } else {
        if (secondNum < thirdNum) {
            swapHelper = thirdNum;
            thirdNum = secondNum;
            secondNum = swapHelper;
        }
    }
}

console.log("The sorted numbers are:");
console.log(firstNum + " " + secondNum + " " + thirdNum);
console.log("");

console.log("5.Write script that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.");

function getDigit() {
    var num = document.getElementById("number").value;
    var result = "";
    num = parseInt(num);
    switch (num) {
        case 0: result = "zero";
            break;
        case 1: result = "one";
            break;
        case 2: result = "two";
            break;
        case 3: result = "three"
            ;break;
        case 4: result = "four";
            break;
        case 5: result = "five";
            break;
        case 6: result = "six";
            break;
        case 7: result = "seven";
            break;
        case 8: result = "eight";
            break;
        case 9: result = "nine";
            break;
        default: result = "You have not entered a digit"; 
            break;
    }
    document.getElementById('result').innerHTML = result;
}
console.log("");

console.log("6.Write a script that enters the coefficients a, b and c of a quadratic equation a*x2 + b*x + c = 0 and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.");

firstNum = 2;
secondNum = 5;
thirdNum = 1;
var x1,
    x2, 
    determinant;

if (isNaN(firstNum) || isNaN(secondNum) || isNaN(thirdNum))
{
    console.log("a, b, c must be a number");
} else {
    console.log("Roots of "+ firstNum +"x" + '\u00B2' + "+" + secondNum + "x+" + thirdNum + ":");

    if (firstNum !== 0) {
        determinant = secondNum * secondNum - 4 * firstNum * thirdNum;

        if (determinant > 0) {
            x1 = (-secondNum + Math.sqrt(determinant)) / (2 * firstNum);
            x2 = (-secondNum - Math.sqrt(determinant)) / (2 * firstNum);

            console.log("x1= " + x1 + "; x2= " + x2);
        } else if (determinant === 0) {
            x1 = (-secondNum) / (2 * firstNum);

            console.log("x1,2 = " + x1);
        } else if (determinant < 0) {
            console.log("There are no real roots");
        }
    } else if (secondNum !== 0) {
        x1 = (-thirdNum) / secondNum;

        console.log("x1,2 = " + x1);
    }
}
console.log("");

console.log("7. Write a script that finds the greatest of given 5 variables.");

var arr = [2, 3, 7, 4, 1],
    max = arr[0];
if (isNaN(arr[0]) || isNaN(arr[1]) || isNaN(arr[2]) || isNaN(arr[3]) || isNaN(arr[4])) {
    console.log("all array members must be numbers");
} else {
    for (i = 1; i < arr.length; i++) {
        if (max < arr[i]) {
            max = arr[i];
        }
    }
    console.log("Greatest number is: " + max);
}
console.log("");

console.log("8. Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:");

function getNumber() {
    var num = parseInt(document.getElementById("number").value),
        result = "";

    if (isNaN(num)) {
        result = "You have not entered a valid integer number!";
    } else {
        if (num >= 100) {
            result += getOneToNine(Math.floor(num / 100));
            result += " hundred ";
            num %= 100;
        }

        if (num > 19) {
            result += getTwentyToNinety(Math.floor(num / 10));
            result += " ";
            num %= 10;
        } else if (num > 9) {
            result += getTenToNineteen(num);
            result += " ";
            num = 0
        }

        if (num > 0) {
            result += getOneToNine(num);
            result += " ";
            num = 0;
        }

        if (num === 0) {
            if (result.length === 0) {
                result += "zero";
            }
        }
    }
    document.getElementById("resultForEight").innerHTML = result;

    function getOneToNine(digit) {
        switch (digit) {
            case 0: return "";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default: return "";
        }
    }

    function getTenToNineteen(number) {
        switch (number) {
            case 10: return "ten";
            case 11: return "eleven";
            case 12: return "twelve";
            case 13: return "thirteen";
            case 14: return "fourteen";
            case 15: return "fifteen";
            case 16: return "sixteen";
            case 17: return "seventeen";
            case 18: return "eighteen";
            case 19: return "nineteen";
            default: return "";
        }
    }

    function getTwentyToNinety(digit) {
        switch (digit) {
            case 2: return "twenty";
            case 3: return "thirty";
            case 4: return "fourty";
            case 5: return "fifty";
            case 6: return "sixty";
            case 7: return "seventy";
            case 8: return "eighty";
            case 9: return "ninety";
            default: return "";
        }
    }
}