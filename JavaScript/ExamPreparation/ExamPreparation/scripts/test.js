function Solve(input) {
    var inpSum = parseInt(input);
    var fours = 0;
    var sixes = 0;
    var sum = 0;
    var count = 0;
    while (true) {

        while (true) {

            while (true) {
                sum += 3;
                if (sum === inpSum) {
                    count++;
                    sum = 0;
                    break;
                } else if (sum > inpSum) {
                    sum = 0;
                    break;
                }
            }
        }
    }
}