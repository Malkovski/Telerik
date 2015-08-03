/* Task Description */
/* 
 *   Create a function that replaces the content of an DOM element with divs with the provided contents
 *   Throws if:
 *   Any of the contents is not a string or a number
 *   Should not add any of the contents
 *   Any of the params is undefined or null
 *   The first parameter is neither string or HTMLElement
 *   The first parameter is an id (string) but there is not such element in the DOM
 *   The second parameter is not an array or an array-like object
 */

module.exports = function () {

    return function (element, contents) {
        var divSample = document.createElement('div');

        function clearContent(element) {
            element.innerHTML = '';
        }

        if (element === undefined || contents === undefined) {
            throw new Error('Parameters cannot be undefined!');
        }

        if (element === null || contents === null) {
            throw new Error('Parameters cannot be null!');
        }

        if (typeof element === 'string') {
            element = document.getElementById(element);
        }

        if (!(element instanceof HTMLElement)) {
            throw new Error('There is no such element in the DOM');
        }

        var fragment = document.createDocumentFragment();

        contents.forEach(function (content) {
            if (!(typeof content === 'string') && !(typeof content === 'number')) {
                throw new Error('Content cannot be other than number or string!')
            }

            divSample.innerHTML = content;
            fragment.appendChild(divSample.cloneNode(true));
        });

        clearContent(element);
        element.appendChild(fragment);
    };
};


