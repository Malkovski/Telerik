/**
 * Created by Geogi Malkovski on 1.6.2015 ã..
 */

function solve(args) {
    var modelsCount = parseInt(args[0]);
    var models = args.slice(1, modelsCount + 1);
    var shaver = args.slice(modelsCount + 2);
    var finalModels = [];
    var finalSections = [];
    var result = [];

    for (var i = 0, len = models.length; i < len; i++) {
        var finalModel = {};
        var parts = models[i].split(':');
        finalModel.key = parts[0];

        if(parts[1].indexOf(',') >= 0) {
            finalModel.value = parts[1].split(',');
        }
        else {
            finalModel.value = parts[1];
        }

        finalModels.push(finalModel);
    }

    var index = shaver.indexOf('<!DOCTYPE html>');
    var section = {};
    var sectionValues = [];

    for (var i = 0; i < index; i++) {

        var hasSection = shaver[i].indexOf('@section ') >= 0;
        var hasClosingBracket = shaver[i].indexOf('}') >= 0;

        if (hasSection) {
            section.key = shaver[i].split(' ')[1];
        }

        if (!hasClosingBracket && !hasSection) {
            sectionValues.push(shaver[i]);
            section.value = sectionValues;
        }

        if (hasClosingBracket) {
            finalSections.push(section);
            sectionValues = [];
            section = {};
        }
    }


    executeShaver(shaver);

    function executeShaver(shaver) {

        for (var i = index, len = shaver.length; i < len; i++) {

            var line = shaver[i];

            if (!checkForEt(line)) {

                console.log(line);;
            }
            else {

               checkForTags(line);
            }

        }


    }

    function checkForTags(line) {

        var parsedLine = '';

        if (line.indexOf('<') >= 0) {

            var openTagIndex = line.indexOf('<'),
                closeTagIndex = line.indexOf('>');

            while (closeTagIndex >= 0) {
                var  part = '';
                part += line.substring(0, openTagIndex);

                if (checkForEt(part)) {

                    if (checkForParenthesis(part)) {

                        //TODO parse the command

                    }
                    else {
                        var command = part.substr(1);
                        parsedLine += finalModels[command].value;
                    }
                }
                else {
                    parsedLine += part;
                }

                parsedLine += line.substr(openTagIndex, closeTagIndex + 1);
                line = line.substr(closeTagIndex + 1);

                openTagIndex = line.indexOf('<');
                closeTagIndex = line.indexOf('>');
            }
        }
        else {

           parsedLine =  parseCommands(line);
        }

        console.log(parsedLine);
    }

    function parseCommands(line) {

        var openParIndex = line.indexOf('('),
            closeParIndex = line.indexOf(')'),
            commandPart = line.substring(1, openParIndex).trim(),
            argumentsPart = line.substring(openParIndex + 1, closeParIndex);

        switch (commandPart) {

            case 'renderSection':
                var currentArg = argumentsPart.substr(1, argumentsPart.length - 2);

                for (var obj in finalSections) {

                    if (obj.key == currentArg) {

                        for (var item in this.value) {

                            console.log(this.value);
                        }
                    }
                }

                break;
        }
    }

    function checkForEt(line) {
        return (line.indexOf('@') >= 0);
    }

    function checkForParenthesis(part) {
        return (part.indexOf('(') >= 0);
    }
}


var args2 = [
    '1',
    'title:Telerik Academy',
    '42',
    '<head>',
    '<title>@title</title>',
    '</head>',
    '<body>',
];


var args = [
    '6',
    'title:Telerik Academy',
    'showSubtitle:true',
'subTitle:Free training',
'showMarks:false',
'marks:3,4,5,6',
'students:Pesho,Gosho,Ivan',
'42',
'@section menu {',
    '<ul id="menu">',
    '<li>Home</li>',
    '<li>About us</li>',
    '</ul>',
    '}',
'@section footer {',
    '<footer>',
    'Copyright Telerik Academy 2014',
    '</footer>',
    '}',
'<!DOCTYPE html>',
'<html>',
'<head>',
'<title>Telerik Academy</title>',
'</head>',
'<body>',
'@renderSection("menu")',

'<h1>@title</h1>',
'@if (showSubtitle {',
    '<h2>@subTitle</h2>',
    '<div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '}',

'<ul>',
'@foreach (var student in students) {',
    '<li>',
    '@student',
    '</li>',
    '<li>Multiline @title</li>',
    '}',
'</ul>',
'@if (showMarks) {',
    '<div>',
    '@marks',
    '</div>',
    '}',

'@renderSection("footer")',
'</body>',
'</html>',
'Output',
'<!DOCTYPE html>',
'<html>',
'<head>',
'<title>Telerik Academy</title>',
'</head>',
'<body>',
'<ul id="menu">',
'<li>Home</li>',
'<li>About us</li>',
'</ul>',

'<h1>Telerik Academy</h1>',
'<h2>Free training</h2>',
'<div>@JustNormalTextWithDoubleKliomba ;)</div>',

'<ul>',
'<li>',
'Pesho',
'</li>',
'<li>Multiline Telerik Academy</li>',
'<li>',
'Gosho',
'</li>',
'<li>Multiline Telerik Academy</li>',
'<li>',
'Ivan',
'</li>',
'<li>Multiline Telerik Academy</li>',
'</ul>',

'<footer>',
'Copyright Telerik Academy 2014',
'</footer>',
'</body>',
'</html>'

];

solve(args);
