/**
 * Created by Geogi Malkovski on 10.6.2015 ã..
 */
function solve(params) {
    var n = parseInt(params[0]);
    var model = {};
    var result = [];

    for (var i = 0, len = n; i < len; i++) {
        var keyValuePair = params[i + 1].split('-');
        var key = keyValuePair[0];
        var value = keyValuePair[1];

        if (value == 'true') {
            value = true;
        }
        else if (value == 'false') {
            value = false;
        }
        else if (value.indexOf(';') > -1) {
            value = value.split(';');
        }

        value[key] = value;
    }

    var inModel = false;
    var inTemplate = false;
    var escaped = false;
    var inLoop = false;
    var render = true;


    var modelOpenTag = '<nk-model>';
    var modelCloseTag = '</nk-model>';
    var ifOpenTag = '<nk-if condition="';
    var ifClosedTag = '/nk-if';
    var loopOpenTag = 'nk-repeat for="';
    var loopClosedTag = '</nk-repeat>';
    var templateOpenTag = '<nk-template name"';
    var templateCloseTag = '/nk-template>';
    var templateRenderingOpenTag = '<nk-template render"';
    var escapeOpen = '{{';
    var escapeClose = '}}';

    var allTemplates = {};
    var currentModel = '';
    var currentTemplateName = '';
    var currentTemplateContent = [];
    var currentCollectionKey = '';
    var currentCollection = [];
    var currentLoopContent = '';

    var m = params[n + 1];

    for (var j = n + 2, len = m + n + 2; j < len; j++) {

        var currentLine = params[j];

        if (currentLine == undefined) {
            currentLine = '';
        }

        if (inTemplate) {
            currentTemplateContent.push('\n');
        }

        for (var k = 0, len = currentLine.length; k < len; k++) {
            var currentSymbol = currentLine[k];
//escaping
            if (checkForCommand(currentLine, escapeOpen)) {
                escaped = true;
                k += 1;
                continue;
            }

            if (escaped && checkForCommand(currentLine, escapeClose)) {

                escaped  = false;
                k += 1; continue;
            }

            if (escaped) {

                if (render && !inLoop) {
                    result.push(currentSymbol);
                }
                continue;
            }

// in loop
            if (checkForCommand(currentLine, loopOpenTag)) {

                inLoop = true;
                var loopParts = currentLine.split('"')[1];
                var collectionKeyValuePair = loopParts.split(' in ');
                currentCollectionKey = collectionKeyValuePair[0];
                currentCollection = collectionKeyValuePair[1];
                break;
            }

            if (checkForCommand(currentLine, loopClosedTag)) {
                inLoop = false;
                break;
            }

            if (inLoop) {
                continue;
                currentLoopContent += currentSymbol;
            }

// if condition
            if (checkForCommand(currentLine, ifOpenTag)) {
                var condition = currentLine.split('"')[1];
                if (!model[condition]) {
                    render = false;
                    break;
                }
            }

            if (checkForCommand(currentLine, ifClosedTag)) {
                render = true;
                break;
            }

//rendering templates

            if (checkForCommand(currentLine, templateRenderingOpenTag)) {
                var templateToRender = currentLine.split('"')[1];
                var templateContentToRender = allTemplates[templateToRender];
                if (render && !inLoop) {
                    result.push(templateContentToRender);
                }
                break;
            }

 //template
            if (checkForCommand(currentLine, templateOpenTag)) {

                inTemplate = true;
                currentTemplateName = currentLine.split('"')[1];
                break;
            }

            if (inTemplate && checkForCommand(currentLine, templateCloseTag)) {
                inTemplate = false;

                allTemplates[currentTemplateName] = currentTemplateContent.join('').trim();
                currentTemplateContent = [];
                currentTemplateName = '';
                break;
            }

            if (inTemplate) {

                if (render && !inLoop) {
                    currentTemplateContent.push(currentSymbol);
                }
                continue;
            }


//in model
            if (checkForCommand(currentLine, modelOpenTag)) {
                inModel = true;
                k += modelOpenTag.length - 1;
                continue;
            }

            if (inModel && checkForCommand(currentLine, modelCloseTag)) {
                inModel = false;

                if (model[currentModel] && render && !inLoop) {
                        result.push(model[currentModel]);

                }
                
                currentModel = '';
                k += modelCloseTag.length - 1;
                continue;
            }

            if (inModel) {
                currentModel += currentSymbol;
                continue;
            }

            if (render && !inLoop) {
                result.push(currentSymbol);
            }
        }

        result.push('\n');
    }

    console.log(result.join('').trim());

    function checkForCommand(currentLine, tag) {

        return currentLine.substr(k, tag.length) == tag;
    }
}