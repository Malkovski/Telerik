/**
 * Created by Geogi Malkovski on 1.6.2015 ã..
 */

function solve(args) {
    var modelsCount = parseInt(args[0]),
        models = args.slice(1, modelsCount + 1),
        shaver = args.slice(modelsCount + 2),
        finalSections = [],
        finalModel = {},
        result = [];

    for (var i = 0, len = models.length; i < len; i++) {

        var parts = models[i].split(':');
        var modelKey = parts[0];

        if(parts[1].indexOf(',') >= 0) {
            finalModel[modelKey] = parts[1].split(',');
        }
        else {
            finalModel[modelKey] = parts[1];
        }
    }

    var index = shaver.indexOf('<!DOCTYPE html>');
    var section = {};
    var sectionValues = [],
        sectionName = '';

    for (var i = 0; i < index; i++) {

        var hasSection = shaver[i].indexOf('@section ') >= 0,
            hasClosingBracket = shaver[i].indexOf('}') >= 0;


        if (hasSection) {
            sectionName = shaver[i].split(' ')[1];
        }

        if (!hasClosingBracket && !hasSection) {
            sectionValues.push(shaver[i]);
        }

        if (hasClosingBracket) {
            section[sectionName] = sectionValues;
            finalSections.push(section);
            sectionValues = [];
        }
    }


    executeShaver(shaver);

    function executeShaver(shaver) {

        for (var i = index, len = shaver.length; i < len; i++) {

            var line = shaver[i];

            if (!checkForEt(line)) {

               result.push(line);
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
                        parsedLine += finalModel[command];
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

            result.push(line);
        }
        else {

            parseCommands(line);
        }
    }

    function parseCommands(line) {

        var openParIndex = line.indexOf('('),
            closeParIndex = line.indexOf(')'),
            commandPart = line.substring(1, openParIndex).trim(),
            argumentsPart = line.substring(openParIndex + 1, closeParIndex);

        switch (commandPart) {

            case 'renderSection':
                var currentArg = argumentsPart.substr(1, argumentsPart.length - 2);

                for (var obj in section) {

                    for (var i = 0, leni = section[obj].length; i < leni; i += 1) {
                        result.push(section[obj][i]);
                    }

                }

                break;
            case 'if':

                for (var model in finalModel) {

                    if (finalModel[argumentsPart] == true) {
                        checkForTags()
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

    console.log(result);
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
];

solve(args);
