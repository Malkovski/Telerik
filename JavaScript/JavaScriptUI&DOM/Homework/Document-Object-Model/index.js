/*Write a script that selects all the div nodes that are directly inside other div elements
Create a function using querySelectorAll()
Create a function using getElementsByTagName()*/


function showCountOfNestedDivsWithQuerry() {
    var allDivsInDivs = document.querySelectorAll('div div');
    var p = document.getElementsByTagName('p')[0];
    var nestedDivCount = allDivsInDivs.length;

    p.innerText = 'result with querrySelectorAll:';
    p.innerText += ' ' + nestedDivCount;
}

function showCountOfNestedDivsByTag() {

    var allInnerDivs = document.getElementsByTagName('div'),
        nestedDivCount = 0;

    for (var i = 0, len = allInnerDivs.length; i < len; i++) {

        var currentChild = allInnerDivs[i].getElementsByTagName('div');
        if (currentChild.length !== 0) {
            nestedDivCount += 1;
        }
    }

    var p = document.getElementById('by-tag-name');
    p.innerText = 'result with getElementsByTagName:';
    p.innerText += ' ' + nestedDivCount;
}

/*Create a function that gets the value of <input type="text"> ands prints its value to the console*/

function showInputContent() {
    var inputTextValue = document.querySelector('input').value;
    console.log(inputTextValue);
    document.getElementById('input-text-result').innerText += inputTextValue;
}

/* Cråate a function that gets the value of <input type="color"> and sets the background of the body to this value
 */

function changeBackgroundColor() {
    var desiredColor = document.querySelectorAll('input')[1].value;
    document.body.style.backgroundColor = desiredColor;
}