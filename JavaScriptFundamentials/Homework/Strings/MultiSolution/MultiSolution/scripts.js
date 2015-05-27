/*Problem 1. Reverse string

Write a JavaScript function that reverses a string and returns it.
Example:

input	output
sample	elpmas
*/

function startReverse() {
    var str = document.getElementById('string1').value;
    document.getElementById('result1').value = reverseStr(str);
}

function reverseStr(str) {
    var reversed = '';

    for (var i = str.length - 1; i >= 0; i--) {
        reversed += str[i];
    }

    return reversed;
}

/*Problem 2. Correct brackets

Write a JavaScript function to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
*/

function startBracketCheck() {
    var str = document.getElementById('string2').value;
    document.getElementById('result2').value = checkBrackets(str);
}

function checkBrackets(str) {
    var correct = true;
    var openBrCnt = 0;

    for (var i = 0; i < str.length; i++) {

        if (str[i] === '(') {
            openBrCnt++;
        }

        if (str[i] === ')') {
            openBrCnt--;
        }

        if (openBrCnt < 0) {
            correct = false;
            break;
        }
    }

    if (openBrCnt != 0) {
        correct = false;
    }
    return correct;
}

/*Problem 3. Sub-string in text

Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).
Example:

The target sub-string is in

The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

The result is: 9
*/

function startSubstrCount() {
    var str = document.getElementById('string3').value;
    var sub = document.getElementById('string4').value;
    document.getElementById('result3').value = countSubstr(str, sub);
}

function countSubstr(str, sub) {
    var len = sub.length;
    var count = 0;

    for (var i = 0; i < str.length; i++) {
        var temp = str.substr(i, len);

        if (temp.toLowerCase() === sub.toLowerCase()) {
            count++;
        }
    }

    return count;
}

/*Problem 4. Parse tags

You are given a text. Write a function that changes the text in all regions:

<upcase>text</upcase> to uppercase.
<lowcase>text</lowcase> to lowercase
<mixcase>text</mixcase> to mix casing(random)
Example: We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.

The expected result:
We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.

Note: Regions can be nested.
*/

function startParsing() {
    var str = document.getElementById('string5').value;
    document.getElementById('result4').value = parseTags(str);
}

function parseTags(str) {
    var up = '<upcase>';
    var upEnd = '</upcase>';
    var low = '<lowcase>';
    var lowEnd = '</lowcase>';
    var mix = '<mixcase>';
    var mixEnd = '</mixcase>';
    var upStr = '';
    var lowStr = '';
    var mixStr = '';
    var openTagIndex = str.indexOf(up);
    var closeTagIndex = str.indexOf(upEnd);

    while (openTagIndex >= 0) {

        upStr = upStr + str.substring(0, openTagIndex);
        openTagIndex += up.length;

        var tempStr = changeCasing((str.substr(openTagIndex, closeTagIndex - openTagIndex)), 'UP');

        /*upStr = upStr + (str.substr(openTagIndex, closeTagIndex - openTagIndex)).toUpperCase();*/

        upStr = upStr + tempStr;
        str = str.substr(closeTagIndex + upEnd.length, str.length - closeTagIndex - upEnd.length);

        openTagIndex = str.indexOf(up);
        closeTagIndex = str.indexOf(upEnd);
    }

    upStr = upStr + str;
    openTagIndex = upStr.indexOf(low);
    closeTagIndex = upStr.indexOf(lowEnd);

    while (openTagIndex >= 0) {

        lowStr = lowStr + upStr.substring(0, openTagIndex);
        openTagIndex += low.length;

        lowStr = lowStr + (upStr.substr(openTagIndex, closeTagIndex - openTagIndex).toLowerCase());

        upStr = upStr.substr(closeTagIndex + lowEnd.length, upStr.length - closeTagIndex - lowEnd.length);

        openTagIndex = upStr.indexOf(low);
        closeTagIndex = upStr.indexOf(lowEnd);
    }

    lowStr = lowStr + upStr;
    openTagIndex = lowStr.indexOf(mix);
    closeTagIndex = lowStr.indexOf(mixEnd);

    while (openTagIndex >= 0) {

        mixStr = mixStr + lowStr.substring(0, openTagIndex);
        openTagIndex += mix.length;

        var mixedPart = lowStr.substr(openTagIndex, closeTagIndex - openTagIndex).toLowerCase();
        var mixed = '';
 

        for (var i = 0; i < mixedPart.length; i++) {

            if (Math.random() > 0.5) {
                mixed = mixed + mixedPart[i].toLowerCase();
            }
            else {
                mixed = mixed + mixedPart[i].toUpperCase();
            }
        }

        mixStr = mixStr + mixed;

        lowStr = lowStr.substr(closeTagIndex + mixEnd.length, lowStr.length - closeTagIndex - mixEnd.length);

        openTagIndex = lowStr.indexOf(mix);
        closeTagIndex = lowStr.indexOf(mixEnd);
    }

    mixStr = mixStr + lowStr;

    return mixStr;
}

function changeCasing(string, opt) {
    var temp = '';
    var closeTagndex = string.indexOf('>');

    switch (opt) {

        case 'UP':
            for (var i = 0; i < string.length; i++) {

                if (string[i] !== '<') {
                   temp += string[i].toUpperCase();
                }
                else {
                    temp += string.substring(i, closeTagndex + 1);
                    i = closeTagndex;
                    closeTagndex = string.indexOf('>', closeTagndex);
                }
               
            }
            break;
        case 'LOW':
            for (var i = 0; i < string.length; i++) {

                if (string[i] !== '<') {
                    string[i].toLowerCase();
                }
                else {
                    i = closeTagndex;
                    closeTagndex = string.indexOf('>', closeTagndex);
                }
                
            }
            break;
        case 'MIX':
            for (var i = 0; i < string.length; i++) {

                if (string[i] !== '<') {
                    randomCaps(string[i]);
                }
                else {
                    i = closeTagndex;
                    closeTagndex = string.indexOf('>', closeTagndex);
                }
                
            }
            break;
        default:

    }

    return temp;
}

function randomCaps(char) {
    var result = '';

    if (Math.random() > 0.5) {
        result = char.toLowerCase();
    }
    else {
        result = char.toUpperCase();
    }

    return result;
}

/*
 Problem 5. nbsp

 Write a function that replaces non breaking white-spaces in a text with &nbsp;
 */

function startReplacingSpaces() {

    var str = document.getElementById('string6').value;
    document.getElementById('result5').value = replaceSpace(str);
}

function replaceSpace(str) {

  var line = String(str).replace(/(\s)/g, '&nbsp');

    return line;
}

/*
 Problem 6. Extract text from HTML

 Write a function that extracts the content of a html page given as text.
 The function should return anything that is in a tag, without the tags.
 */

function startExtract() {

    var str = document.getElementById('string7').value;
    document.getElementById('result6').value = extractWithRegex(str);
    document.getElementById('result7').value = extractHTMLContent(str);
}

String.prototype.trim = function () {
    return this.replace(/^\s*/, "").replace(/\s*$/, "");
}

function extractWithRegex(str) {
   return String(str).replace(/(<([^>]+)>)/ig, '');
}


function extractHTMLContent(str) {

    var text = '';
    var closeTagIndex = str.indexOf('>');
    var openTagIndex = str.indexOf('<', 1);

    while (openTagIndex >= 0) {

        var tempText = str.substring(closeTagIndex + 1, openTagIndex);

        if (tempText.replace(/\s/g, '').length) {

            tempText.trim();
            text += tempText;
        }

        str = str.substr(openTagIndex, str.length - openTagIndex);

        closeTagIndex = str.indexOf('>');
        openTagIndex = str.indexOf('<', 1);
    }

    return text;
}






























