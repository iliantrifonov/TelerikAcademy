function Solve(input) {
    var targetSum = parseInt(input, 10);
    var sum = 0;
    var count = 0;
    var i4 = 0,
        i6 = 0;
    while (true) {
        sum = 0;
        sum += 6 * i6;
        
        if (sum === targetSum) {
            sum = 0;
            count++;
            break;
        } else if (sum > targetSum) {
            sum = 0;
            break;
        }
        
        i4 = 0;
        while (true) {
            sum = 0;
            sum += 6 * i6;
            sum += 4 * i4;
            
            if (sum === targetSum) {
                
                sum = 0;
                count++;
                break;
            } else if (sum > targetSum) {
                sum = 0;
                break;
            }
            
            while (true) {
                if (sum === targetSum) {
                    sum = 0;
                    count++;
                    break;
                } else if (sum > targetSum) {
                    sum = 0;
                    break;
                }
                
               sum += 3;
            }
            
            i4++;
        }
        
        i6++;
    }
    
    return count;
}




