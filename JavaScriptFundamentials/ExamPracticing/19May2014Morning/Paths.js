/**
 * Created by Geogi Malkovski on 31.5.2015 ã..
 */

function solve(input) {

    var rowCols = input[0].split(' ').map(Number);
    var rows = rowCols[0];
    var cols = rowCols[1];
    var currentRow = 0;
    var currentCol = 0;

    var matrix = [];

    for (var i = 0; i < rows; i+=1) {
        matrix[i] = [];

        for (var j = 0; j < cols; j++) {
            matrix[i][j] = Math.pow(2, i) + j;
        }
    }

    var directionMatrix = [];

    for (var i = 1, len = input.length; i < len; i+=1) {
        directionMatrix[i - 1] = input[i].split(' ');
    }

    var exit = false;
    var sum = 0;


    while (true) {

        if(currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
            exit = true;
            break;
        }

        if(matrix[currentRow][currentCol] === 'f') {
            exit = false;
            break;
        }

        sum += matrix[currentRow][currentCol];
        matrix[currentRow][currentCol] = 'f';

       move(currentRow, currentCol);
    }

    return exit ? 'successed with ' + sum : 'failed at ' + '(' + currentRow + ', ' + currentCol + ')';


    function move(row, col) {

        switch (directionMatrix[row][col]) {

            case 'dr': currentRow += 1, currentCol += 1;
            break;
            case 'dl': currentRow += 1, currentCol -= 1;
                break;
            case 'ur': currentRow -= 1, currentCol += 1;
                break;
            case 'ul': currentRow -= 1, currentCol -= 1;
                break;
            default: break;
        }
    }
}

var args = [
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
];



console.log(solve(args));