/**
 * Created by Geogi Malkovski on 7.6.2015 ã..
 */
function solve(params) {
    var index,
        modelInput = params.slice(1, 7),
        templates = {},
        templateContent = [],
        models = {},
        output = [];


    for (var i = 0, len = modelInput.length; i < len; i++) {
        var modelContent = modelInput[i].split('-'),
            modelName = modelContent[0],
            modelValues = modelContent[1],
            contentArray = [];

        if (modelValues.indexOf(';') >= 0) {
            contentArray = modelValues.split(';');
            models[modelName] = contentArray;
        }
        else {
            models[modelName] = modelValues;
        }
    }

    for (var i = 8, len = params.length; i < len; i++) {

        if (params[i] !== '<!DOCTYPE html>') {

            var openTemplate = '<nk-template name="',
                openTemplateIndex = params[i].indexOf(openTemplate),
                closeTemplateNameIndex = params[i].indexOf('>');


            if (openTemplateIndex == 0) {
                var templateName = params[i].substring(openTemplateIndex + openTemplate.length, closeTemplateNameIndex - 1);
            }

            if (params[i] !== '</nk-template>' && openTemplateIndex < 0) {
                templateContent.push(params[i]);
            }

            if (params[i] === '</nk-template>') {
                templates[templateName] = templateContent;
                templateContent = [];
            }
        }
        else {
            index = i;
            break;
        }
    }

    for (var i = index, len = params.length; i < len; i++) {
        var nkModel = '<nk-model>',
            nkModelEnd = '</nk-model>',
            nkRepeat = '<nk-repeat for="',
            nkRepeatEnd = '</nk-repeat>',
            nkIf = '<nk-if condition="',
            nkIfEnd = '</nk-if>',
            nkRender = '<nk-template render="',
            nkRenderEnd = '" />',
            nk = '<nk-',
            escapeOpen = '{{',
            escapeClose = '}}';


        if (params[i].indexOf(nk) >= 0) {

            parseLine(params[i])
        }
        else {
            if (params[i] !== nkIfEnd) {
                output.push(params[i]);
            }
        }

        function parseLine(str, name) {

            if (str.indexOf(nk) < 0) {

                output.push(params[i]);
            }
            else {

                if (str.indexOf(escapeOpen) >= 0) {
                    output.push(parseWithEscape(str));
                }
                else if (str.indexOf(nkModel) >= 0) {
                    output.push(parseModels(str, name));
                }
                else if (str.indexOf(nkRender) >= 0) {
                    parseRenderer(str);
                }
                else if (str.indexOf(nkIf) >= 0) {
                    parseCondition(str);
                }
                else if (str.indexOf(nkIfEnd) >= 0) {

                }
                else if (str.indexOf(nkRepeat) >= 0) {
                    parseLoop(str);
                }
            }
        }

        function parseWithEscape(str) {
            return str.substring(0, str.indexOf(escapeOpen)) + str.substring(str.indexOf(escapeOpen) + 2, str.indexOf(escapeClose)) + str.substr(str.indexOf(escapeClose) + 2);
        }

        function parseModels(str, name) {
            var currentModelName = name;

            if (currentModelName == undefined) {
                currentModelName = str.substring(str.indexOf(nkModel) + nkModel.length, str.indexOf(nkModelEnd));
                return str.substring(0, str.indexOf(nkModel)) + models[currentModelName] + str.substr(str.indexOf(nkModelEnd) + nkModelEnd.length);
            }
            else {
                return str.substring(0, str.indexOf(nkModel)) + currentModelName + str.substr(str.indexOf(nkModelEnd) + nkModelEnd.length);
            }
        }

        function parseRenderer(str) {
            var currentTemplateName = str.substring(str.indexOf(nkRender) + nkRender.length, str.indexOf(nkRenderEnd));

            for (var item in templates[currentTemplateName]) {
                output.push(templates[currentTemplateName][item]);
            }
        }

        function parseCondition(str) {
            var currentCondition = str.substring(str.indexOf(nkIf) + nkIf.length, str.indexOf('">'));

            if (models[currentCondition] == 'true') {

            }
            else {
                while (params[i] !== nkIfEnd) {
                    i += 1;
                }
            }

        }

        function parseLoop(str) {
            var currentLoopStatement = str.substring(str.indexOf(nkRepeat) + nkRepeat.length, str.indexOf('">')),
                currentLoop = currentLoopStatement.split(' '),
                currentItem = currentLoop[0],
                currentLoopItems = currentLoop[2],
                currentIndex = i;

            for (var item = 0, len = models[currentLoopItems].length; item < len; item += 1) {
                i += 1;

                while (params[i] !== nkRepeatEnd) {
                    if (params[i].indexOf(currentItem) >= 0) {
                        parseLine(params[i], models[currentLoopItems][item]);
                    }
                    else {
                        parseLine(params[i]);
                    }

                    i += 1;
                }

                if (item < models[currentLoopItems].length - 1) {
                    i = currentIndex;
                }

            }

        }
    }

    for (var element in output) {
        console.log(output[element]);
    }

}



//solve(test2);


var test1 = [
    '6',
    'title-Telerik Academy',
    'showSubtitle-true',
    'subTitle-Free training',
    'showMarks-false',
    'marks-3;4;5;6',
    'students-Ivan;Gosho;Pesho',
    '42',
    '<nk-template name="menu">',
    '<ul id="menu">',
    '<li>Home</li>',
    '<li>About us</li>',
    '</ul>',
    '</nk-template>',
    '<nk-template name="footer">',
    '<footer>',
    'Copyright Telerik Academy 2014',
    '</footer>',
    '</nk-template>',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '<title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '<nk-template render="menu" />',

    '<h1><nk-model>title</nk-model></h1>',
    '<nk-if condition="showSubtitle">',
    '<h2><nk-model>subTitle</nk-model></h2>',
    '<div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
    '</nk-if>',

    '<ul>',
    '<nk-repeat for="student in students">',
    '<li>',
    '<nk-model>student</nk-model>',
    '</li>',
    '<li>Multiline <nk-model>title</nk-model></li>',
    '</nk-repeat>',
    '</ul>',
    '<nk-if condition="showMarks">',
    '<div>',
    '<nk-model>marks</nk-model>',
    '</div>',
    '</nk-if>'
];

//solve(test1);

var params = [
    '6',
    'title-Telerik Academy',
    'showSubtitle-true',
    'subTitle-Free training',
    'showMarks-false',
    'marks-3;4;5;6',
    'students-Ivan;Gosho;Pesho',
    '42',
    '<nk-template name="menu">',
    '<ul id="menu">',
    '<li>Home</li>',
    '<li>About us</li>',
    '</ul>',
    '</nk-template>',
    '<nk-template name="footer">',
    '<footer>',
    'Copyright Telerik Academy 2014',
    '</footer>',
    '</nk-template>',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '<title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '<nk-template render="menu" />',

    '<h1><nk-model>title</nk-model></h1>',
    '<nk-if condition="showSubtitle">',
    '<h2><nk-model>subTitle</nk-model></h2>',
    '<div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
    '</nk-if>',

    '<ul>',
    '<nk-repeat for="student in students">',
    '<li>',
    '<nk-model>student</nk-model>',
    '</li>',
    '<li>Multiline <nk-model>title</nk-model></li>',
    '</nk-repeat>',
    '</ul>',
    '<nk-if condition="showMarks">',
    '<div>',
    '<nk-model>marks</nk-model>',
    '</div>',
    '</nk-if>',

    '<nk-template render="footer" />',
    '</body>',
    '</html>'
];

solve(params);