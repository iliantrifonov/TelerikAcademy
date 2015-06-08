(function () {
    "use strict";
    console.log('1.Write a JavaScript function reverses string and returns it');
    function reverseString(text) {
        var reversedText = '';

        for (var i = text.length - 1; i >= 0; i--) {
            reversedText += text[i];
        }
        return reversedText;
    }

    var text = 'help;';
    console.log('Reversing the text: ' + text + " and the result is: " + reverseString(text));
    console.log(' ');

    console.log('2.Write a JavaScript function to check if in a given expression the brackets are put correctly. Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).');

    function checkBrackets(expressionAsString) {
        var countOpening = 0,
            countClosing = 0;
        for (var i = 0, len = expressionAsString.length; i < len; i++) {
            if (countClosing > countOpening) {
                return false;
            }

            if (expressionAsString[i] === '(') {
                countOpening++;
            } else if (expressionAsString[i] === ')') {
                countClosing++;
            }
        }

        if (countClosing !== countOpening) {
            return false;
        }

        return true;
    }

    console.log('For ((a+b)/5-d), the result is: ' + checkBrackets('((a+b)/5-d)') + ' and checking for )(a+b)) : ' + checkBrackets(')(a+b))'));
    console.log(' ');

    console.log('3.Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search)');

    function checkTimesSubstringIsContainedCaseInsensitive(text, substr) {
        var arrOfMatches = text.match(new RegExp(substr, 'gi'));

        return arrOfMatches.length;
    }

    console.log('For the text: "We are living in an yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.", for "in" the result should be 9, and is: ' + checkTimesSubstringIsContainedCaseInsensitive("We are living in an yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.", "in"));
    console.log(' ');

    console.log('4.You are given a text. Write a function that changes the text in all regions: <upcase>text</upcase> to uppercase. , <lowcase>text</lowcase> to lowercase, <mixcase>text</mixcase> to mix casing(random) ');

    function changeTextInTags(text) {
        var arr = text.split('upcase>');

        for (var i = 0, len = arr.length; i < len; i++) {
            if (arr[i][arr[i].length - 1] === '/' && arr[i - 1][arr[i - 1].length - 1] === '<') {
                arr[i - 1] = arr[i - 1].substring(0, arr[i - 1].length - 1);
                arr[i] = arr[i].substring(0, arr[i].length - 2).toUpperCase();
            }
        }

        arr = arr.join('');
        arr = arr.split('lowcase>');

        for (var i = 0, len = arr.length; i < len; i++) {
            if (arr[i][arr[i].length - 1] === '/' && arr[i - 1][arr[i - 1].length - 1] === '<') {
                arr[i - 1] = arr[i - 1].substring(0, arr[i - 1].length - 1);
                arr[i] = arr[i].substring(0, arr[i].length - 2).toLowerCase();
            }
        }

        arr = arr.join('');
        arr = arr.split('mixcase>');

        for (var i = 0, len = arr.length; i < len; i++) {
            if (arr[i][arr[i].length - 1] === '/' && arr[i - 1][arr[i - 1].length - 1] === '<') {
                arr[i - 1] = arr[i - 1].substring(0, arr[i - 1].length - 1);
                arr[i] = arr[i].substring(0, arr[i].length - 2);
                arr[i] = arr[i].split('');
                for (var k = 0, len2 = arr[i].length; k < len2; k++) {
                    if (Math.random() < 0.5) {
                        arr[i][k] = arr[i][k].toUpperCase();
                    } else {
                        arr[i][k] = arr[i][k].toLowerCase();
                    }
                }
                arr[i] = arr[i].join('');
            }
        }

        return arr.join('');
    }

    text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else. ";

    console.log('Testing for : ' + text + " the result is: " + changeTextInTags(text));
    console.log(' ');

    console.log('5. Write a function that replaces non breaking white space with &nbsp;');

    function replaceNonBreakingWhiteSpace(text) {
        var regEx = new RegExp(String.fromCharCode(160), 'g'); //160 is the code for non breaking white space
        return String(text).replace(regEx, '&nbsp;');
    }

    text = 'hello' + String.fromCharCode(160) + 'world';//160 is the code for non breaking white space
    console.log('For : ' + text + ' result is: ' + replaceNonBreakingWhiteSpace(text));
    console.log(' ');

    console.log('6.Write a function that extracts the content of a html page given as text. The function should return anything that is in a tag, without the tags');

    function extractTextFromHTML(stringContent) {
        var regEx = /(<([^>]+)>)/ig;
        return stringContent.replace(regEx, '');
    }

    text = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';

    console.log('For the html: ' + text + " after using the function : " + extractTextFromHTML(text));
    console.log(' ');

    console.log('7. Write a script that parses an URL address given in the format: [protocol]://[server]/[resource], and extracts from it the [protocol], [server] and [resource] elements. Return the elements in a JSON object.');

    function getJSONFromURL(url) {
        var protocolString = '',
            isProtocolFinished = false,
            serverString = '',
            isServerFinished = false,
            resourceString = '';

        for (var i = 0, len = url.length; i < len; i++) {
            if (isProtocolFinished) {
                if (isServerFinished) {
                    resourceString += url[i];
                } else {
                    if (url[i] === '/') {
                        isServerFinished = true;
                    } else {
                        serverString += url[i];
                    }
                }
            } else {
                if (url[i] === ':' && url[i + 1] === '/' && url[i + 2] === '/') {
                    isProtocolFinished = true;
                    i += 2;
                } else {
                    protocolString += url[i];
                }
            }
        }

        return {
            protocol: protocolString,
            server: serverString,
            resource: resourceString
        };
    }

    text = 'http://www.devbg.org/forum/index.php';
    console.log('Checking for the website: ' + text + " result is:");
    console.log(getJSONFromURL(text));
    console.log(' ');

    console.log('8.Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="...">…</a> with corresponding tags [URL=...].../URL]. Sample HTML fragment: ');

    function replaceAHrefWithURL(htmlString) {
        var result = htmlString.replace(/<a href="/gi, '[URL=');
        result = result.replace(/">/gi, ']');
        result = result.replace(/<\/a>/gi, '[/URL]');

        return result;
    }

    text = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p> ';
    console.log('For : ' + text);
    console.log('The result is: ' + replaceAHrefWithURL(text));
    console.log(' ');

    console.log('9. Write a function for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails. Return the emails as array of strings.');

    function extractEmails(text) {
        var result,
            regEx = /([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi;

        result = text.match(regEx);
        return result;
    }

    text = 'abv.bg sh@abv.bg, sadsa@gmail.com hello@gmail.com ';
    console.log('For: ' + text + ' extracted emails are: ');
    console.log(extractEmails(text));
    console.log(' ');

    console.log('10.Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe"');

    function extractPalindrome(text) {
        function isPolindrome(word) {
            var len = word.length;

            if (len < 2) {
                return false;
            }

            for (var i = 0; i < len; i++) {
                if (word[i] !== word[len - 1 - i]) {
                    return false;
                }
            }

            return true;
        }

        var textAsArray = text.split(/\W/),
            result = [];

        for (var i = 0, len = textAsArray.length; i < len; i++) {
            if (isPolindrome(textAsArray[i])) {
                result.push(textAsArray[i]);
            }
        }

        return result;
    }

    text = 'some text for test ssttss ssss sss ABBA lamal exe , dad other word/word wwwzmurr';
    console.log('For the text: ' + text + 'the result is:');
    console.log(extractPalindrome(text));
    console.log(' ');

    console.log('11.Write a function that formats a string using placeholders: var str = stringFormat(\'Hello {0}!\', \'Peter\'); //str = \'Hello Peter!\'; ');
    //This considered a very good way in stackoverflow, otherwise you could take each argument in a for loop, and replace "{i}" with the arguments[i+1] and replace it.
    function stringFormat(format) {
        var args = Array.prototype.slice.call(arguments, 1);
        return format.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
                ? args[number]
                : match
            ;
        });
    }

    text = '\'Hello {0}!\' {1}, {2} {3} {4} {5}';

    console.log("Test with: " + text);
    console.log(stringFormat(text, 'Peshkata', 'stuff1', 'stuff2', 'stuff3', 'stuff4', 'stuff5', 'dadas'));
    console.log(' ');

    console.log('12.Write a function that creates a HTML UL using a template for every HTML LI. The source of the list  should an array of elements. Replace all  placeholders marked with –{…}– with the value of the corresponding property of the object. Example');

    function generateList(objCollection, template) {
        var htmlString = '<ul>';
        for (var k = 0, objLen = objCollection.length; k < objLen; k++) {
            htmlString += '<li>';
            for (var i = 0, len = template.length; i < len; i++) {
                if (template[i] === '-' && template[i + 1] === '{') {
                    i += 2;
                    var propertyName = '';
                    while (template[i] !== '}' && template[i + 1] !== '-') {
                        propertyName += template[i];
                        i++;
                    }

                    i++;
                    htmlString += objCollection[k][propertyName];
                } else {
                    htmlString += template[i];
                }
            }

            htmlString += '</li>';
        }

        htmlString += '</ul>';

        return htmlString;
    }

    var people = [{ name: 'Peter', age: 14 },
              { name: 'Peshkata', age: 19 },
              { name: 'Ivancho', age: 17 },
              { name: 'Mariika', age: 25 }
    ];
    var template = '<strong>-{name}-</strong><span>-{age}-</span>';//document.getElementById('list-item').innerHtml; 
    var peopleList = generateList(people, template);

    console.log('For template: ' + template + ' , and objects: ');
    console.log(people);
    console.log('Result is:');
    console.log(peopleList);
})();