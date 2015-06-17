/**
 * Created by Mastermind on 2.6.2015 ã..
 */
function solve(params) {
    var money = parseInt(params[0], 10),
        priceOne = parseInt(params[1], 10),
        priceTwo = parseInt(params[2], 10),
        priceThree = parseInt(params[3], 10),
        answer = 0;


    for (var i = 0, lenA = money / priceOne; i <= lenA; i += 1) {

        for (var j = 0, lenB = money/priceTwo; j < lenB; j += 1) {

            for (var k = 0, lenC = money/priceThree; k < lenC; k += 1) {

                var sum = i * priceOne + j * priceTwo + k * priceThree,
                    currentSum = parseInt(sum, 10);

                if ((currentSum > answer) && currentSum <= money) {

                    answer = sum;
                }
            }
        }
    }

    return answer;
}




var params1 = [
    '110',
    '13',
    '15',
    '17'
]

var params2 = [
    '20',
    '11',
    '200',
    '300'
]


console.log(solve(params2));