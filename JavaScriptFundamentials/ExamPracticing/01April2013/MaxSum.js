/**
 * Created by Mastermind on 3.6.2015 ã..
 */
function solve(params) {
    var maxSum = parseInt(params[1], 10),
        currentSum = 0;

    for (var i = 1, leni = params.length; i < leni; i += 1) {

        for (var j = i, lenj = params.length; j < lenj; j += 1) {

            currentSum += parseInt(params[j], 10);

            if (currentSum > maxSum) {
                maxSum = currentSum;
            }
        }
        currentSum = 0;
    }

    console.log(maxSum);
}

var test1 = [
    '8',
    '1',
    '6',
    '-9',
    '4',
    '4',
    '-2',
    '10',
    '-1'
];

var test2 = [
   '6',
    '1',
    '3',
    '-5',
    '8',
    '7',
    '-6'
];

var test3 = [
    '9',
    '-9',
    '-8',
    '-8',
    '-7',
    '-6',
    '-5',
    '-1',
    '-7',
    '-6'
];
solve(test3);