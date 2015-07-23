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

function solve() {
    var divSample = document.createElement('div');

    function clearContent(element) {
        console.log(element);
        element.innerHTML = '';
        /*while (element.firstChild) {

            element.removeChild(element.firstChild);
        }*/
    }
    
    var replacer = function(container, contents) {
        if (container === undefined || contents === undefined) {
            throw new Error('Parameters cannot be undefined!');
        }

        if (container === null || contents === null) {
            throw new Error('Parameters cannot be null!');
        }

        if (typeof container === 'string') {
            container = document.getElementById(container);
        }

        if (!(container instanceof HTMLElement)) {
            throw new Error('There is no such element in the DOM');
        }

        clearContent(container);

        var fragment = document.createDocumentFragment();

        contents.forEach(function (content) {
            if (typeof content !== 'string' && typeof content !== 'number') {
                throw new Error('Content cannot be other than number or string!')
            }

            divSample.innerHTML = content;
            fragment.appendChild(divSample.cloneNode(true));
        });

        container.appendChild(fragment);
    };
    
    return replacer;
}

module.export = solve;

function change() {
    var a = solve();
    a('p', [1, 2, 3, 4, 5]);
}