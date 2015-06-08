console.log('3.Crеate a function that gets the value of <input type="color"> and sets the background of the body to this value');

function changeBackgroundOfBodyToValueOfInputWithId(id) {
	var element = document.getElementById(id);
	document.body.style.background = element.value;
}