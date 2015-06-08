console.log("1.Check if odd or even");

var num = 5;

var oddOrEven = function (number) {
    //make sure we have an integer
    number = parseInt(number);
    if (number) {
        if (number % 2 === 0) {
            console.log("The number is even")
        } else {
            console.log("The number is odd");
        }
    }
}

console.log("For the number 5");
console.log(oddOrEven(num));
num = 4;
console.log("For the number 4");
console.log(oddOrEven(num));
console.log("");

console.log("2.Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time");

var isDivisibleByFiveAndSeven = function (number) {
    //make sure we have an integer
    number = parseInt(number);
    if (number) {
        if (number % 5 === 0 && number % 7 === 0) {
            return true;
        } else {
            return false;
        }
    }
}

num = 22;
console.log("Check with 22");
console.log(isDivisibleByFiveAndSeven(num));

num = 35;
console.log("Check with 35");
console.log(isDivisibleByFiveAndSeven(num));
console.log("");

console.log("3.Write an expression that calculates rectangle’s area by given width and height.");

var areaOfRectangle = function (height, width) {
    if (parseFloat(height) && parseFloat(width)) {
        return height * width;
    }
}

var h = 5;
var w = 2;
console.log("The area of a rectangle with sides 5 and 2 is " + areaOfRectangle(h, w));
console.log("");

console.log("4.Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true");

var isThirdDigit = function (number, digit) {
    number = parseInt(number);
    digit = parseInt(digit);

    if (number && digit && digit >= 0 && digit <= 9) {
        var numString = number.toString();
        if (numString[numString.length - 3] === digit.toString()) {
            return true;
        } else {
            return false;
        }
    }
}

var digit = 7;
num = 1732;
console.log("Is the third digit from right to left " + digit + "? Answer will be true/false");
console.log("The number 1732? " + isThirdDigit(num, digit));
console.log("");

console.log("5.Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.");

var isThirdBitZero = function (number) {
    number = parseInt(number);
    if (number) {
        if (((number >> 3) & 1) === 1) {
            return false;
        } else {
            return true;
        }
    }
}

num = 7;
console.log("For the number 7, is the third bit zero?");
console.log(isThirdBitZero(num));

num = 15;
console.log("For the number 15, is the third bit zero?");
console.log(isThirdBitZero(num));

console.log("");

console.log("6.Write an expression that checks if given point (x,  y) is within a circle K(O, 5).");

var isPointInCircleCoordZeroRadiusFive = function(coordX,coordY) {
    coordX = parseInt(coordX);
    coordY = parseInt(coordY);
    if (coordX && coordY){
        var radius = 5;

        if ((coordX * coordX + coordY * coordY) < radius * radius) {
            return true;
        } else {
            return false;
        }
    }
}
var num = 2;
console.log("Is point(2, 2) in a circle K(O, 5)?");
console.log(isPointInCircleCoordZeroRadiusFive(num, num));
console.log("");

console.log("7.Write an expression that checks if given positive integer number n (n <= 100) is prime. E.g. 37 is prime.");

var isPrime = function (number) {
    number = parseInt(number);
    if (number && number > 1 && number < 101) {

        for (var i = 2; i < number; i++) {
            if (number % i === 0) {
                return false;
            }
        }
        return true;
    }
}

num = 37;
console.log("Is 37 prime ?");
console.log(isPrime(num));
console.log("");

console.log("8.Write an expression that calculates trapezoid's area by given sides a and b and height h.");

var areaTrapezoid = function (sideA, sideB, height) {
    sideA = parseFloat(sideA);
    sideB = parseFloat(sideB);
    height = parseFloat(height);
    if (sideA && sideB && height) {
        return ((sideA + sideB) * height )/ 2;
    }
}

var height = 3;
var a = 1;
num = 2;
console.log("A trapezoid with sides a = 1 b = 2 and height = 3, has an area of: " + areaTrapezoid(a, num, height));
console.log("");

console.log("9.Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).");
// this is so precise that I will not write a "method" for it.

console.log("Checking for point(2,3)");
var pointX = 2;
var pointY = 3;
var circleX = 1;
var circleY = 1;
var radius = 3;
var xLeft = -1;
var yLeft = 1;
var width = 6;
var height = 2;
var xRight = xLeft + width;
var yRight = yLeft - height;
var inCircle = false;
var inRectangle = false;

if (((pointX - circleX) * (pointX - circleX) + (pointY - circleY) * (pointY - circleY)) < radius * radius) {
    inCircle = true;
} else {
    inCircle = false;
}

if ((pointX > xLeft && pointX < xRight) && (pointY < yLeft && pointY > yRight)) {
    inRectangle = true;
} else {
    inRectangle = false;
}

if (inCircle === true && inRectangle === false) {
    console.log("Point (" + pointX + ", " + pointY +") is within circle K((" + circleX +","+ circleY +")," + radius + ") and out of rectangle R(top=" + xLeft + ", left=" + yLeft + ", width=" + width + ", height={" + height + ").");
} else {
    console.log("Point (" + pointX + ", " + pointY +") is NOT within circle K((" + circleX +","+ circleY +")," + radius + ") and out of rectangle R(top=" + xLeft + ", left=" + yLeft + ", width=" + width + ", height={" + height + ")");
}	

