/**
 * Created by Mastermind on 19.5.2015 ã..
 */
function showResult() {
    var first = document.getElementById('tb-first').value;
    var second = document.getElementById('tb-second').value;
    var third = document.getElementById('tb-third').value;

    var result;
    var negatives = 0;

    if (first != 0 && second != 0 && third != 0) {
        if (first < 0) {
            negatives++;
        }
        if ( second < 0) {
            negatives++;
        }
        if (third < 0) {
            negatives++;
        }

        if (negatives === 0 || negatives === 2) {
            result = '+';
        }
        else {
            result = '-';
        }
    }
    else {
        result = 0;
    }

    document.getElementById('result').innerHTML = result;
}