/**
 * Created by Geogi Malkovski on 1.6.2015 ã..
 */

function solve(args) {
    var modelsCount = parseInt(args[0]);
    var models = args.slice(1, modelsCount + 1);
    var shaver = args.slice(modelsCount + 2);
    var finalModel = {};
    var finalModels = [];
    var result = [];

    for (var i = 0, len = models.length; i < len; i++) {

        var parts = models[i].split(':');
        finalModel.key = parts[0];

        if(parts[1].indexOf(',') > 0) {
            finalModel.value = parts[1].split(',');
        }
        else {
            finalModel.value = parts[1];
        }

        finalModels.push(finalModel);
    }

    executeShaver(shaver);

    function executeShaver(shaver) {

        for (var i = 0, len = shaver.length; i < len; i++) {

            var line = shaver[i];

            if (!line.indexOf('@') && !line.indexOf('{') && !line.indexOf('}')) {

               result.push(line);
            }
            else {


            }

        }


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

solve(args2);
