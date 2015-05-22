function lastDigitInWord() {
    var data = document.getElementById('data').value;
    var digit = parseInt(data) % 10;
    var temp;

    switch (digit) {
       
        case 0: temp = 'Zero';
            break;
        case 1: temp = 'One';
            break;
        case 2: temp = 'Two';
            break;
        case 3: temp = 'Three';
            break;
        case 4: temp = 'Four';
            break;
        case 5: temp = 'Five';
            break;
        case 6: temp = 'Six';
            break;
        case 7: temp = 'Seven';
            break;
        case 8: temp = 'Eight';
            break;
        case 9: temp = 'Nine';
            break;
        default: temp = 'not such number';
            break;

            return temp;
    }

    document.getElementById('result').innerHTML = temp;
}

function reverseNumber() {
    var data = document.getElementById('data2').value;
    var result = data.split("").reverse().join("");

    document.getElementById('result2').innerHTML = result;
}

function wordCount() {
    var word = document.getElementById('data3').value;
    var sensitive = document.getElementById('data4').value;
    var text = document.getElementById('lorem').innerText;
    text = text.split(' ');

    var counter = countWords(word, sensitive);

    function countWords(word, sensitive) {

        if (sensitive == '' || sensitive == 'false') {
           return caseInsensitiveCount(word);
        }
        else {
           return caseSensitiveCount(word);
        }

        function caseInsensitiveCount(word) {
            var counter = 0;
        
            for (var i = 0; i < text.length; i++) {

                if (word.toLowerCase() == text[i].toLowerCase()) {
                    counter++;
                }
            }

            return counter;
        }

        function caseSensitiveCount(word) {
            var counter = 0;

            for (var i = 0; i < text.length; i++) {

                if (word === text[i]) {
                    counter++;
                }
            }

            return counter;
        }
    }

    document.getElementById('result3').innerHTML = counter;
}

function divCount() {

    var divs = document.getElementsByTagName('div');

    document.getElementById('result4').innerHTML = divs.length;
}

function appearanceCount() {
    var inputData = document.getElementById('data5').value;
    inputData = inputData.split(',');
    var searched = document.getElementById('data6').value;
    var count = 0;

    for (var i = 0; i < inputData.length; i++) {
        
        if (searched == inputData[i]) {
            ++count;
        }
    }

    document.getElementById('result5').innerHTML = count;
}

function neighbourLarger() {
    var inputData = document.getElementById('data7').value;
    inputData = inputData.split(',');
    var index = document.getElementById('data8').value;
    index = parseFloat(index);

    var result = neighbourhoodSearch(inputData, index);

    document.getElementById('result6').innerHTML = result;
    
}

function neighbourhoodSearch(inputData, index) {
    if (inputData.length == 1 && index == 0) {
        document.getElementById('result6').innerHTML = 'No neighbours found!';
    }
    else {
        if (index >= inputData.length || index < 0) {
            return 'Index is outside of the array range!';
        }
        else {

            if (index == 0) {

                if (inputData[1] < inputData[index]) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (index == (inputData.length - 1)) {

                if (inputData[index - 1] < inputData[index]) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if (inputData[index - 1] < inputData[index] && inputData[index + 1] < inputData[index]) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    }
}


function firstNeighbourLarger() {
    var inputData = document.getElementById('data9').value;
    inputData = inputData.split(',');
    var index = -1;

    for (var i = 0; i < inputData.length; i++) {
        var result;

        result = neighbourhoodSearch(inputData, i);
        
        if (result) {
            index = i;
            break;
        }
    }

    document.getElementById('result7').innerHTML = index;
}