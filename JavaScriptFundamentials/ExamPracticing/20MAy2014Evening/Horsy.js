/**
 * Created by Mastermind on 2.6.2015 ã..
 */

function solve(params) {

    var startPos = params[0].split(' '),
        rows = parseInt(startPos[0]),
        cols = parseInt(startPos[1]),
        moves = params.slice(1),
        matrix = [],
        row = rows - 1,
        col = cols - 1,
        sum = 0,
        count = 0;


    var deltaMoves = {
        1: {
            row: -2,
            col: +1
        },
        2: {
            row: -1,
            col: +2
        },
        3: {
            row: +1,
            col: +2
        },
        4: {
            row: +2,
            col: +1
        },
        5: {
            row: +2,
            col: -1
        },
        6: {
            row: +1,
            col: -2
        },
        7: {
            row: -1,
            col: -2
        },
        8: {
            row: -2,
            col: -1
        }
    };


    for (var i = 0, leni = rows; i < leni; i += 1) {
        matrix.push([]);
        for (var j = 0, lenj = cols; j < lenj; j += 1) {
            matrix[i][j] = Math.pow(2, i) - j;
        }
    }

    while (true) {

        if (!(0 <= row &&  row < rows) || !(0 <= col && col < cols)) {
            return 'Go go Horsy! Collected ' +  sum + ' weeds';
        }

        if (matrix[row][col] == 'V') {
            return 'Sadly the horse is doomed in ' + count + ' jumps';
        }

        var currentPos = moves[row][col];
        sum += matrix[row][col];
        matrix[row][col] = 'V';
        count += 1;
        row += deltaMoves[currentPos].row;
        col += deltaMoves[currentPos].col;
    }
}

var params1 = [
    '3 5',
    '54561',
    '43328',
    '52388'
];

var params2 = [
    '3 5',
    '54361',
    '43326',
    '52188'
];

console.log(solve(params1));
console.log(solve(params2));
