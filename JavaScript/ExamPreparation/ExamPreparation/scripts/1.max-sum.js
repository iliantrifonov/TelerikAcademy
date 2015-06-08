function Solve(input) {
	input = input.map(Number);

	var n = input[0];
	
	var curSum = input[1];
	var maxSum = curSum;

	for (var i = 2; i < n + 1; i++) {
		var currentNum = input[i];
		if (maxSum < curSum) {
			maxSum = curSum;
		}

		if (curSum < 0) {
			curSum = currentNum;
		}
		else {
			curSum += currentNum;
		}
	}

	if (maxSum < curSum) {
		maxSum = curSum;
	}
	return maxSum;
}