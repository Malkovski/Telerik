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

        str = upStr + str;

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
    var temp = '',
        openTagIndex = string.indexOf('<'),
        closeTagIndex = string.indexOf('>');


    switch (opt) {

        case 'UP':
            while (closeTagIndex >= 0) {
                temp += string.substring(0, openTagIndex).toUpperCase();
                temp += string.substring(openTagIndex, closeTagIndex + 1);
                string = string.substr(closeTagIndex + 1, string.length - closeTagIndex);
                openTagIndex = string.indexOf('<');
                closeTagIndex = string.indexOf('>');
            }
            temp += string.toUpperCase();
            break;
        case 'LOW':
            for (var i = 0; i < string.length; i++) {

                if (string[i] !== '<') {
                    string[i].toLowerCase();
                }
                else {
                    i = closeTagIndex;
                    closeTagIndex = string.indexOf('>', closeTagIndex);
                }
                
            }
            break;
        case 'MIX':
            for (var i = 0; i < string.length; i++) {

                if (string[i] !== '<') {
                    randomCaps(string[i]);
                }
                else {
                    i = closeTagIndex;
                    closeTagIndex = string.indexOf('>', closeTagIndex);
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

    return String(str).replace(/(\s)/g, '&nbsp');
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
};

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

/*
 Problem 7. Parse URL

 Write a script that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
 Return the elements in a JSON object.
 Example:

 URL	result
 http://telerikacademy.com/Courses/Courses/Details/239	{ protocol: http,
 server: telerikacademy.com
 resource: /Courses/Courses/Details/239
 */

function startParseURL() {
    var str = document.getElementById('string8').value;
    document.getElementById('result8').value = parseURL(str);
}

function parseURL(str) {
    var protocolIndex = str.indexOf('://'),
        serverEndIndex = str.indexOf('/', protocolIndex + 3);

    return JSON.stringify({ protocol: str.substring(0, protocolIndex),
        server: str.substring(protocolIndex + 1, serverEndIndex),
        resource: str.substr(serverEndIndex, str.length - serverEndIndex)});
}


/*
 Problem 8. Replace tags

 Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
 Example:

 input	output
 <p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.
 Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
 <p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course.
 Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
 */


function startReplaceTags() {
    var str = document.getElementById('string9').value;
    document.getElementById('result9').value = replaceTags(str);
}

function replaceTags(str) {

   return str.replace(/<a href="/g, '[URL=').replace(/">/g, ']').replace(/<\/a>/g, '/URL');
}

/*
 Problem 9. Extract e-mails

 Write a function for extracting all email addresses from given text.
 All sub-strings that match the format @… should be recognized as emails.
 Return the emails as array of strings.
 */

function startExtractEmails() {
    var str = document.getElementById('string10').value;
    document.getElementById('result10').value = extractEmails(str);
}

function extractEmails(str) {
    var arr,
        emails,
        re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;


    arr = str.split(' ');

    for (var elem in arr) {

        if (re.test(arr[elem])) {
            emails.push(arr[elem]);
        }
    }

    return emails.join(' --/-- ');
}

/*
 Problem 10. Find palindromes

 Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
 */

function startPalindromeSearch() {
    var str = document.getElementById('string11').value;
    document.getElementById('result11').value = findPalindromes(str);
}

function findPalindromes(str) {
    var arr,
        palindromes = [];

    arr = str.split(' ');

    for (var i in arr) {

        if (isPalindrome(arr[i])) {
            palindromes.push(arr[i]);
        }
    }

    return palindromes.join(', ');
}


function isPalindrome(str) {
    var rev = str.split('').reverse().join('');


    if(str.substr(0, str.length / 2 | 0) === rev.substr(0, rev.length / 2 | 0)) {
        return true;
    }

    return false;
}

/*
 Problem 11. String format

 Write a function that formats a string using placeholders.
 The function should work with up to 30 placeholders and all types.
 */

if (!String.format) {
    String.format = function () {
        var formattedString = arguments[0];

        for (var index = 0; index < arguments.length - 1; index++) {
            var regex = new RegExp("\\{" + index + "\\}", "gm");
            formattedString = formattedString.replace(regex, arguments[index + 1]);
        }

        return formattedString;
    };
}
console.log(String.format('{0} {1} a {2}', 'This' , 'is', 'test!'));

function startStringFormat() {
    var firstEntry = document.getElementById('string12').value;
    var secondEntry = document.getElementById('string13').value;
    var thirdEntry = document.getElementById('string14').value;
    document.getElementById('result12').value = String.format('{0} {1} {2}', firstEntry, secondEntry, thirdEntry);
}

/*
 Problem 12. Generate list

 Write a function that creates a HTML <ul> using a template for every HTML <li>.
 The source of the list should be an array of elements.
 Replace all placeholders marked with –{…}– with the value of the corresponding property of the object.
 Example: HTML:

 <div data-type="template" id="list-item">
 <strong>-{name}-</strong> <span>-{age}-</span>
 /div>
 JavaScript:

 var people = [{name: 'Peter', age: 14},…];
 var tmpl = document.getElementById('list-item').innerHtml;
 var peopleList = generateList(people, template);
 //peopleList = '<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>'
 */

function ulCreator() {
    var people = [
            { name: 'Peter', age: 14 },
            { name: 'Mike', age: 13 },
            { name: 'John', age: 22 },
        ],
        template = document.getElementById('list-item').innerHTML.valueOf(),
        peopleList = generateList(people, template);
    document.getElementById('display').innerHTML = peopleList;
}
function generateList(people, template) {
    var list = '<ul>';
    for (var i = 0; i < people.length; i++) {
        list += '<li>';
        list += template.replace('-{name}-', people[i]['name']);
        list = list.replace('-{age}-', people[i]['age']);
        list += '</li>';
    }
    list += '</ul>';
    return list;
}