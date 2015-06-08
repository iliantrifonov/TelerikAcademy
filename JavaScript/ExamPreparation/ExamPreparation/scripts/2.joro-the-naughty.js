function Solve(input) {
    var splitFirstRow = input[0].split(' ');
    splitFirstRow = splitFirstRow.map(Number);

    var rows = splitFirstRow[0],
        cols = splitFirstRow[1],
        numberOfJumps = splitFirstRow[2];

    var startPosAsArr = input[1].split(' ');
    startPosAsArr = startPosAsArr.map(Number);

    var startRow = startPosAsArr[0],
        startCol = startPosAsArr[1];

    var field = [],
        counter = 1;

    for (var i = 0; i < rows; i++) {
        field[i] = [];
        for (var k = 0; k < cols; k++) {
            field[i][k] = counter;
            counter++;
        }
    }

    var jumps = [];
    for (var i = 2; i < numberOfJumps + 2; i++) {
        var currentJump = input[i].split(' ');
        currentJump = currentJump.map(Number);

        jumps.push(currentJump);
    }
    
    var countJumps = 0,
        sumOfNumbers = 0,
        currentPositionRow = startRow,
        currentPositionCol = startCol;
    while (true) {
        for (var i = 0; i < numberOfJumps; i++) {
            if (currentPositionRow < 0 || currentPositionCol < 0 || currentPositionRow >= rows || currentPositionCol >= cols) {
                return 'escaped ' + sumOfNumbers;
            } else if (field[currentPositionRow][currentPositionCol] === 'x') {
                return 'caught ' + countJumps;
            }

            var currentNum = field[currentPositionRow][currentPositionCol];

            sumOfNumbers += currentNum;

            field[currentPositionRow][currentPositionCol] = 'x';
            currentPositionRow += jumps[i][0];
            currentPositionCol += jumps[i][1];
            countJumps++;
        }
    }
}

var firstTest = [
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1'
];

console.log(Solve(firstTest));