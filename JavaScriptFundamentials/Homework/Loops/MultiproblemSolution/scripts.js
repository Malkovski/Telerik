/**
 * Created by Geogi Malkovski on 19.5.2015 ã..
 */
function showResult() {
    var data = document.getElementById('input1').value;
    var tempResult = '';
    var notDivis = '';

    for (var i = 1; i <= data; i++) {
        tempResult += i  + ' ';

        if ((i % 3 == 0) && (i % 7 == 0)) {
            notDivis += i + ' ';
        }
    }

    if (notDivis === '') {
        notDivis = 'no such number!';
    }

    document.getElementById('result1').innerHTML = tempResult;
    document.getElementById('result2').innerHTML = notDivis;
}
 function FindMinMax() {
     var inputData = document.getElementById('input2').value;

     var arr = new Array();
     arr = inputData.split(',');
     var max = 0;
     var min = parseInt(arr[0]);

     for (var i = 0; i < arr.length; i++) {
         if (max < parseInt(arr[i])) {
             max = arr[i];
         }

         if (min > parseInt(arr[i])) {
             min = arr[i];
         }
     }

     document.getElementById('result3').innerHTML = 'Max is: ' + max + ' and Min is: ' + min;
 }

var propArray = [];

for (var a in window) {
    if (window.hasOwnProperty(a)) {
        propArray.push(a)
    }
}

var lexiMin = propArray[0];
var lexiMax = propArray[0];

for (var i = 0; i < propArray.length; i++) {
    if (lexiMin > propArray[i]) {
        lexiMin = propArray[i];
    }

    if (propArray[i] > lexiMax) {
        lexiMax = propArray[i];
    }
}

console.log(lexiMax);
console.log(lexiMin);