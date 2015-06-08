/// <reference path="3.special-console-module.js" />
(function () {
    var specialConsole = consoleModule();

    specialConsole.writeLine('Message: hello');
    specialConsole.writeLine("Message: {0}", 'hello');
    specialConsole.writeLine("Message: {1} {0} {2}", 'world', 'hello', '!');

    specialConsole.writeError("Error: {0}", "Something happened");
    specialConsole.writeWarning("Warning: {0}", "A warning");

})();