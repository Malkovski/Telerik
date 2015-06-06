/**
 * Created by Mastermind on 5.6.2015 ã..
 */
function solve(params) {
    var numbers = [];
    for (var i = 0, leni = params.length; i < leni; i += 1) {
        numbers.push(params[i].split(' ').map(Number));
    }

    var rows = numbers[0][0],
        cols = numbers[0][1],
        jumps = numbers[0][2],
        currentRow = numbers[1][0],
        currentCol = numbers[1][0],
        currentPosition,
        moves = numbers.slice(2),
        count = 1,
        hops = 0,
        sum = 0;

    var matrix = [];
    for (var i = 0, leni = rows; i < leni; i += 1) {
        matrix[i] = [];
        for (var j = 0, lenj = cols; j < lenj; j += 1) {
            matrix[i][j] = count;
            count += 1;
        }
    }

    var escaped;

    for (var i = 0, leni = jumps; i < leni; i += 1) {


        if (currentCol < 0 || currentCol >= cols || currentRow < 0 || currentRow >= rows) {
            escaped = true;
            break;
        }

        currentPosition = matrix[currentRow][currentCol];


        if (currentPosition === '!') {
            escaped = false;
            break;
        }

        sum += currentPosition;
        currentPosition = '!';
        hops += 1;
        currentRow += moves[i][0];
        currentCol += moves[i][1];

        if (i === jumps -1) {

            i = -1;
        }
    }

    return escaped ? 'escaped ' + sum : 'caught ' + hops;
}

var test1 = [
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1'
];

var test2 = [
 '100 100 200',
 '0 0',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '0 1',
 '1 0',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '0 -1',
 '1 0'
];

console.log(solve(test2));