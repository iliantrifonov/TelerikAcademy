/// <reference path="jquery-2.1.1.min.js" />
(function () {
    "use strict";
    function printTopResults() {
        var highscores = [],
            list = [];

        for (var i = 0; i < localStorage.length; i++) {
            var nickname = localStorage.key(i),
                score = localStorage.getItem(nickname)

            highscores.push([nickname, score]);
        }

        highscores.sort(function (a, b) {
            a = parseInt(a[1]);
            b = parseInt(b[1]);

            return a < b ? -1 : (a > b ? 1 : 0);
        });

        var count = 1;
        for (var player in highscores) {
            list.push(count + '. ' + highscores[player][0] + ' - ' + highscores[player][1] + ' tries.');
            count++;
        }
        $('#top-score').html(list.join('<br/>'));
    }

    function writeToTopResults(name, guesses) {
        localStorage.setItem(name, guesses);
    }

    function win() {
        var name = getName();
        writeToTopResults(name, numberOfGuesses);
        printTopResults();
        restartGame();
    }

    function getName() {
        var name = $('#name').val();
        if (name.length < 1) {
            throw {
                message: 'Invalid name, result not added to top score'
            }
        }

        return name;
    }

    function restartGame() {
        numberOfGuesses = 0;
        generatedNumber = generateNumber();
        bulls = 0;
        cows = 0;
        printTopResults();
    }

    function generateNumber() {
        function randomBetween(min, max) {
            return Math.floor(Math.random() * (max - min + 1) + min);
        }

        var numberArr = [];
        for (var i = 0; i < 4; i++) {
            if (i === 0) {
                numberArr.push(randomBetween(1, 9));
            } else {
                numberArr.push(randomBetween(0, 9));
            }
        }

        return numberArr;
    }

    $('#clear').on('click', function () {
        localStorage.clear()
    });

    var numberOfGuesses = 0;
    var generatedNumber = generateNumber();
    console.log(generatedNumber);
    var bulls = 0;
    var cows = 0;
    printTopResults();
    var button = $('#btn');
    button.on('click', function () {
        var guess = $('#guess').val();

        if (guess.length !== 4) {
            throw {
                message: 'Invalid Input, must enter 4 digits'
            }
        }

        var guessArr = [];

        for (var i = 0; i < 4; i++) {

            var digit = guess[i];
            digit = parseInt(digit, 10);
            if (isNaN(digit)) {
                throw {
                    message: 'Invalid Input, must enter 4 digits'
                }
            }

            guessArr.push(digit);
        }
        bulls = 0;
        cows = 0;
        console.log(guessArr);
        console.log(generatedNumber);
        for (var i = 0; i < 4; i++) {
            for (var k = 0; k < 4; k++) {
                if (generatedNumber[i] === guessArr[k]) {
                    if (i === k) {
                        bulls += 1;
                    } else {
                        cows += 1;
                    }
                }
            }
        }

        cows -= bulls;

        numberOfGuesses += 1;
        console.log(bulls);
        console.log(cows);
        $('#result').html('Bulls: ' + bulls + '; Cows: ' + cows);

        if (bulls === 4) {
            win();
        }
    });

})();