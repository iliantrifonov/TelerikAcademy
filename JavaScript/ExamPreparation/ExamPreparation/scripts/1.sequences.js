function Solve(input) {
    input = input.map(Number);
    var n = input[0],
        count = 1;

    for (var i = 2; i < n + 1; i++) {
        if (input[i] < input[i-1]) {
            count++;
        }
    }

    return count;
}

var test1 = [
    '7',
    '1',
    '2',
    '-3',
    '4',
    '4',
    '0',
    '1',
];

console.log(Solve(test1));