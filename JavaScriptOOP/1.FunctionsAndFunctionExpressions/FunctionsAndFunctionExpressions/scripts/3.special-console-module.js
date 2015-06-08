var consoleModule = function consoleModule() {
    'use strict';

    function writeLine() {
        var argsToString = [];

        for (var i = 0; i < arguments.length; i++) {
            argsToString.push(arguments[i].toString());
        }

        console.log(formatString(argsToString));
    }

    function writeError() {
        var argsToString = [];

        for (var i = 0; i < arguments.length; i++) {
            argsToString.push(arguments[i].toString());
        }

        console.error(formatString(argsToString));
    }

    function writeWarning() {
        var argsToString = [];

        for (var i = 0; i < arguments.length; i++) {
            argsToString.push(arguments[i].toString());
        }

        console.warn(formatString(argsToString));
    }

    function formatString(argsToString) {

        var formatString = argsToString[0];
        var index = 0;
        var lenOfFormatString = formatString.length;
        var resultString = '';

        if (!formatString) {
            throw new Error('Arguments are missing from the format string in formatString()');
        }

        if (argsToString.length < 2) {
            return argsToString[0];
        }

        while (lenOfFormatString > index) {

            if (formatString[index] === '{') {
                var number = '';
                index++;

                while (formatString[index] !== '}') {
                    number += formatString[index];
                    index++;
                }

                number = parseInt(number);
                if (!argsToString[number + 1]) {
                    throw new Error('Invalid format string');
                }

                resultString += argsToString[number + 1];
            } else {
                resultString += formatString[index];
            }

            index++;
        }

        return resultString;
    }

    return {
        writeLine: writeLine,
        writeWarning: writeWarning,
        writeError: writeError,
    }
};