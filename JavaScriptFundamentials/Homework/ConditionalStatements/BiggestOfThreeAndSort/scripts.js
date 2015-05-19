/**
 * Created by Mastermind on 19.5.2015 ã..
 */
function showResult() {
    var first = document.getElementById('tb-first').value;
    var second = document.getElementById('tb-second').value;
    var third = document.getElementById('tb-third').value;

    var result;

    if ( parseFloat(first) > parseFloat(second)) {
        if (parseFloat(first) > parseFloat(third)) {
            result = first;
        }
        else {
            result = third;
        }
    }
    else {
        if (parseFloat(second) > parseFloat(third)) {
            result = second;
        }
        else {
            result = third;
        }
    }

    document.getElementById('result').innerHTML = result;

    var descending;

    if (parseFloat(first) > parseFloat(second)) {
        if  (parseFloat(first) > parseFloat(third)) {

            if (parseFloat(second) > parseFloat(third)) {
                descending = first + ' ' + second + ' ' + third;
            }
            else {
                descending = first + ' ' + third + ' ' + second;
            }
        }
        else {
            descending = third + ' ' + first + ' ' + second;
        }
    }
    else {
        if (parseFloat(second) > parseFloat(third)) {
            if (parseFloat(first) > parseFloat(third)) {
                descending = second + ' ' + first + ' ' + third;
            }
            else {
                descending = second + ' ' + third + ' ' + first;
            }
        }
        else {
            descending = third + ' ' + second + ' ' + first
        }
    }

    document.getElementById('sorted').innerHTML = descending;
}