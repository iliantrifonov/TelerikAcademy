function Solve(input) {
    var firstRowAsArr = input[0].split(' ').map(Number);
    var rows = firstRowAsArr[0];
    var cols = firstRowAsArr[1];

    var field = [];
    var visitedField = [];
    var counter = 1;
    for (var i = 0; i < rows; i++) {

        field[i] = [];
        visitedField[i] = [];
        for (var k = 0; k < cols; k++) {
            field[i][k] = counter;
            visitedField[i][k] = 'no';
            counter++;
        }
    }

    var instructionsField = [];
    for (var i = 2; i < input.length; i++) {
        instructionsField.push(input[i]);
    }

    var startPosAsArr = input[1].split(' ').map(Number);

    var currentRow = startPosAsArr[0];
    var currentCol = startPosAsArr[1];
    var sum = 0;
    var count = 0;

    while (true) {
        if (currentRow >= rows || currentRow < 0 || currentCol >= cols || currentCol < 0) {
            return 'out ' + sum;
        }

        if (visitedField[currentRow][currentCol] === 'x') {
            return 'lost ' + count;
        }

        count++;
        sum += field[currentRow][currentCol];
        var currentDirection = instructionsField[currentRow][currentCol];
        visitedField[currentRow][currentCol] = 'x';

        if (currentDirection === 'l') {
            currentCol--;
        } else if (currentDirection === 'r') {
            currentCol++;
        } else if (currentDirection === 'u') {
            currentRow--;
        } else if (currentDirection === 'd') {
            currentRow++;
        }
    }
}

//var test1 = [
// "5 8",
// "0 0",
// "rrrrrrrd",
// "rludulrd",
// "durlddud",
// "urrrldud",
// "ulllllll"]
//;

//console.log(Solve(test1));
