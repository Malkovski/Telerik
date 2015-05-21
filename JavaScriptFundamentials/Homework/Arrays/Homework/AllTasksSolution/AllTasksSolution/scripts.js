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

function selectionSort() {
    var inputData = document.getElementById('sequence2').value;
    inputData = inputData.split(',');

    var len = inputData.length;
    var sorted = [];
    var index;

    while (sorted.length < len) {

        var temp = inputData[0];

        for (var i = 1; i < inputData.length; i++) {

            if (parseInt(temp) > parseInt(inputData[i])) {
                temp = inputData[i];
            }
        }

        index = inputData.indexOf(temp);
        sorted.push(temp);
        inputData.splice(index, 1);
    }

    document.getElementById('result3').innerHTML = sorted.join(',');
}

function mostFrequent() {
    var inputData = document.getElementById('sequence3').value;
    inputData = inputData.split(',');

    var count = 0;
    var maxCount = 0;
    var index = 0;
    var result;

    while (index < inputData.length) {

        var temp = inputData[index];

        for (var i = index; i < inputData.length; i++) {

            if (temp === inputData[i]) {
                count++;
            }
        }

        index++;

        if (maxCount < count) {
            result = temp;
            maxCount = count;
        }

        count = 0;
    }

    document.getElementById('result4').innerHTML = result + ' (' + maxCount + 'times)';
}

function FindIndex() {
    var inputData = document.getElementById('sequence4').value;
    inputData = inputData.split(',');

    var element = document.getElementById('sequence5').value;
    var result;
    var saved = inputData;
    var mid = inputData.length / 2 | 0;

    while (true) {

        if (element == inputData[mid]) {
            result = saved.indexOf(inputData[mid]);
            break;
        }
        else {

            if (element > inputData[mid]) {
                mid += ((inputData.length - mid) / 2);
            }
            else {
                mid -= (mid / 2);
            }
        }

        mid = mid | 0;
        console.log(mid);
    }

    document.getElementById('result5').innerHTML = result;
}