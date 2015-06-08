function onButtonClick() {
    var browserCodeName = window.navigator.appCodeName;
    if (browserCodeName === "Mozilla") {
        alert("This is Mozilla");
    } else {
        alert("This is not Mozilla");
    }
}