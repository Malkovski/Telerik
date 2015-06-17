/**
 * Created by Mastermind on 19.5.2015 ã..
 */

function showResult() {
    var first = document.getElementById('tb-first').value;
    var second = document.getElementById('tb-second').value;

    if (first > second) {
        console.log(second + " " + first);
        document.getElementById('result').innerHTML = second + " " + first;
    }
    else {
        console.log(first + " " + second);
        document.getElementById('result').innerHTML = first + " " + second;
    }
}
