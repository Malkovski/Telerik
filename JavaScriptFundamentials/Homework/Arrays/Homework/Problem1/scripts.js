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
    var first = document.getElementById('first').value;
    var second = document.getElementById('second').value;

    first = first.split(',');
    second = second.split(',');

    for (var i = 0; i < first.length; i++) {
        if (first[i] > second[i]) {
            document.getElementById('bigger').innerHTML = first.join(',');
            document.getElementById('smaller').innerHTML = second.join(',');
        }
        else {
            document.getElementById('bigger').innerHTML = second.join(',');
            document.getElementById('smaller').innerHTML = first.join(',');
        }
    }
}

function longestEqDigits() {
    var inputData = document.getElementById('digits').value;
    inputData = inputData.split(',');

    var maxCount = 0;
    var winner = inputData[0];

    var counter = 0;
    var digit = inputData[0];

    for (var i = 0; i < inputData.length; i++) {

        if (digit === inputData[i]) {
            counter++;

            if (counter >= maxCount) {
                maxCount = counter;
                winner = digit;
            }
        }
        else {
            digit = inputData[i];
            counter = 1;
        }
    }

    console.log(maxCount);
    console.log(winner);

    var result = winner;

    for (var i = 1; i < maxCount; i++) {
        if (i < maxCount) {
            result += ',';
        }

        result += winner;
    }

    document.getElementById('result').innerHTML = result;
}

function longestIncrSequence() {
    var inputData = document.getElementById('sequence').value;
    inputData = inputData.split(',');

    var num = parseFloat(inputData[0]);
    var arr = [num];
    var maxArr = arr;

    for (var i = 1; i < inputData.length; i++) {

        if (num + 1 === parseFloat(inputData[i])) {
            arr.push(inputData[i]);

            if (arr.length > maxArr.length) {
                maxArr = arr;
            }
        }
        else {
            arr = [inputData[i]];
        }

        num = parseFloat(inputData[i]);
    }

    document.getElementById('result2').innerHTML = maxArr.join(',');
}