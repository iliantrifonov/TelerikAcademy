console.log('2.Create a function that gets the value of <input type="text"> ands prints its value to the console');
function getValueOfInput(idOfInput) {
	var element = document.getElementById(idOfInput);
	var innerText = element.value;
	return innerText;
}

function printInnerValueOfInputInConsole(idOfInput) {
	console.log(getValueOfInput(idOfInput));
}

printInnerValueOfInputInConsole('input');