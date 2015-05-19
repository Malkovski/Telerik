/**
 * Created by Mastermind on 19.5.2015 ã..
 */
function showResult() {
    var first = document.getElementById('tb-first').value;
    var result;

    switch (first) {
        case '0': result = 'zero';
            break;
        case '1': result = 'one';
            break;
        case '2': result = 'two';
            break;
        case '3': result = 'three';
            break;
        case '4': result = 'four';
            break;
        case '5': result = 'five';
            break;
        case '6': result = 'six';
            break;
        case '7': result = 'seven';
            break;
        case '8': result = 'eight';
            break;
        case '9': result = 'nine';
            break;
        default: result = 'not a digit'
            break;
    }

    document.getElementById('result').innerHTML = result;
}