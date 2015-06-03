/**
 * Created by Mastermind on 3.6.2015 ã..
 */
function solve(params) {
    var items = [],
        count = 1;

    for (var i = 1, leni = params.length; i < leni; i += 1) {
        items[i - 1] = parseInt(params[i], 10);
    }

    for (var i = 1, leni = items.length; i < leni; i += 1) {

        if (items[i] < items[i - 1]) {
            count += 1;
        }
    }

    return count;
}

var test1 = [
   '9',
    '1',
    '8',
    '8',
    '7',
    '6',
    '5',
    '7',
    '7',
    '6'

];

console.log(solve(test1));