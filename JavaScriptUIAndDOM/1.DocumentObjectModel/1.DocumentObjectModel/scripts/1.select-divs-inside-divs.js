console.log('1.Write a script that selects all the div nodes that are directly inside other div elements');

function getDivDirectlyInsideDivWithLive() {
    var elements = document.body.getElementsByTagName('div');
    var arr = [];
    for (var i = 0, len = elements.length; i < len; i++) {
        var innerDiv = elements[i].childNodes;

        for (var k = 0; k < innerDiv.length; k++) {
            if (innerDiv[k].tagName === 'DIV') {
                arr.push(innerDiv[k]);
            }
        }
    }

    return arr;
}

function getDivDirectlyInsideDivStatic() {
    return document.querySelectorAll('div > div');
}

console.log('The number of divs inside divs is:');
console.log(getDivDirectlyInsideDivStatic().length);
console.log('and with live list:');
console.log(getDivDirectlyInsideDivWithLive().length);