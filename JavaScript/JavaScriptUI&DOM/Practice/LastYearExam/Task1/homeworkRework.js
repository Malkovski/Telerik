function solve() {
    var divElement = document.createElement('div'),
        fragment = document.createDocumentFragment();

    function clearContent(element) {
        element.innerHTML = '';
    }

    return function(selector, contents){
        if (selector === undefined || contents === undefined) {
            throw new Error('One or more input parameters are missing!')
        }

        if (selector === null || contents === null) {
            throw new Error('One or more input parameters is null!')
        }

        if (typeof selector === 'string') {
            selector = document.querySelector(selector);
        }

        if (!(selector instanceof HTMLElement)) {
            throw new Error('DOM element does not exists!');
        }

        for (var i = 0, len = contents.length; i < len; i += 1) {
            var currentContent = contents[i],
                currentDivElement = divElement.cloneNode(true);

            if (typeof currentContent !== 'string' && typeof currentContent !== 'number') {
                throw new Error('Each content must be either string or number!');
            }
            currentDivElement.innerText = currentContent;
            fragment.appendChild(currentDivElement);
        }

        clearContent(selector);
        selector.appendChild(fragment);
    }
}