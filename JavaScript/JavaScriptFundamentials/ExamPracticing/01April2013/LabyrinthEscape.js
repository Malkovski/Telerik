/**
 * Created by Mastermind on 3.6.2015 ã..
 */
function solve(params) {
    var size = params[0].split(' '),
        rows = parseInt(size[0], 10),
        cols = parseInt(size[1], 10),
        startPos = params[1].split(' '),
        row = parseInt(startPos[0], 10),
        col = parseInt(startPos[1], 10),
        directions = params.slice(2),
        counter = 1,
        sum = 0,
        jumps = 0,
        currentPos = '',
        deltaDirections = {},
        matrix = [];


    deltaDirections = {
        l: {
            row: 0,
            col: -1
        },

        r: {
            row: 0,
            col: +1
        },

        u: {
            row: -1,
            col: 0
        },

        d: {
            row: +1,
            col: 0
        }
    };

    for (var i = 0, leni = rows; i < leni; i += 1) {
        matrix[i] = [];
        for (var j = 0, lenj = cols; j < lenj; j += 1) {
            matrix[i][j] = counter;
            counter += 1;
        }
    }

    while (true) {

        if (row < 0 || row >= rows || col < 0 || col >= cols) {
            return 'out ' + sum;
        }

        if (matrix[row][col] === 'F') {
            return 'lost ' + jumps;
        }

        currentPos = directions[row][col];
        sum += matrix[row][col];
        matrix[row][col] = 'F';
        jumps += 1;

        row += deltaDirections[currentPos].row;
        col += deltaDirections[currentPos].col
    }
}

var test1 = [
        "5 8",
        "0 0",
        "rrrrrrrd",
        "rludulrd",
        "lurlddud",
        "urrrldud",
        "ulllllll"];

console.log(solve(test1));