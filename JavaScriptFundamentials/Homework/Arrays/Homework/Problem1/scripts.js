/**
 * Created by Mastermind on 20.5.2015 ã..
 */
function showArray() {
    var numbers = new Array(20);

    for (var i = 0; i < 20; i++){
        numbers[i] = (i + 1) * 5;
    }

    document.getElementById('problem1').innerHTML = numbers.join(', ');
}

function lexiCompare() {
    var first = [];
    var second = [];

    first = (document.getElementById('first').innerText).split(',');
    second = (document.getElementById('second').innerText).split(',');

    for (var i = 0; i < first.length; i++) {
        if (first[i] > second[i]) {
            document.getElementById('bigger').innerHTML = first.join(',');
        }
        else {
            document.getElementById('smaller').innerHTML = second.join(',');
        }
    }
}