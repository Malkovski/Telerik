/**
 * Created by Mastermind on 1.6.2015 ã..
 */



function solve(targetSum) {
    var truckWheels = 10,
        carWheels = 4,
        trikeWheels = 3,
        targetSum = parseInt(targetSum[0], 10),
        count = 0;

    for (var i = 0, leni = targetSum / truckWheels; i <= leni; i += 1) {

        for (var j = 0, lenj = targetSum / carWheels; j <= lenj; j += 1) {

            for (var k = 0, lenk = targetSum / trikeWheels; k <= lenk; k += 1) {

                var sum = i * truckWheels + j * carWheels + k * trikeWheels;

                if (sum === targetSum) {

                    count += 1;
                }
            }
        }
    }

    return count;
}

var params = [
    '40'
];
console.log(solve(params));