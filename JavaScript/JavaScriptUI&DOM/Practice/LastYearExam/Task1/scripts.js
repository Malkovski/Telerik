function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector),
        fragment = document.createDocumentFragment(),
        divElement = document.createElement('div'),
        image = document.createElement('img'),
        elements = document.createElement('div'),
        filterElement = document.createElement('input');

    var filter = filterElement.cloneNode(true);
    filter.style.width = '100%';
    filter.type = 'text';
    filter.addEventListener('change', onSearch, false);

    elements.style.overflowY = 'scroll';

    function createTitleDiv(selector, text, fontSize, fontWeight) {
        var title = selector.cloneNode(true);
        title.innerHTML = text;
        title.style.fontSize = fontSize;
        title.style.fontWeight = fontWeight;
        title.style.textAlign = 'center';

        return title;
    }

    function createImage(selector, url, width, borderRadius) {
        var image = selector.cloneNode(true);
        image.src = url;
        image.style.width = width;
        image.style.borderRadius = borderRadius;
        image.style.display = 'block';
        image.style.marginLeft = '10px';

        return image;
    }

    function createDivWithStyle(selector, title, image, width, float, paddingBottom, paddingLeft) {
        var div = selector.cloneNode(true);
        div.appendChild(title);
        div.appendChild(image);
        div.style.width = width;
        div.style.float = float;
        div.style.paddingBottom = paddingBottom;

        return div;
    }

    var aside = divElement.cloneNode(true),
        initialTitle = createTitleDiv(divElement, items[0].title, '30px', 'bold'),
        initialImage = createImage(image, items[0].url, '95%', '25px'),
        leftDiv = createDivWithStyle(divElement, initialTitle, initialImage, '75%', 'left', '10px');

    aside.style.width = '25%';
    aside.style.float = 'left';

    var filterContent = divElement.cloneNode(true);
    filterContent.innerText = 'Filter';
    filterContent.style.textAlign ='center';
    filterContent.appendChild(filter);

    aside.appendChild(filterContent);
    aside.appendChild(elements);

    for (var i = 0, len = items.length; i < len; i += 1) {
        var currentTitle = createTitleDiv(divElement, items[i].title, '16px', 'bold'),
            currentImage = createImage(image, items[i].url, '95%', '10px'),
            currentDiv = createDivWithStyle(divElement, currentTitle, currentImage, '100%', 'left', '10px');

        currentDiv.addEventListener('mouseover', onMouseOver, false);
        currentDiv.addEventListener('mouseout', onMouseOut, false);
        currentDiv.addEventListener('click', onClick, false);

        fragment.appendChild(currentDiv);
    }

    elements.appendChild(fragment);
    aside.appendChild(elements);

    container.appendChild(leftDiv);
    container.appendChild(aside);

    function onMouseOver() {
        return this.style.backgroundColor = 'red';
    }

    function onMouseOut() {
        return this.style.backgroundColor = 'white';
    }

    function onClick() {
        leftDiv.innerHTML = '';

        leftDiv.innerHTML = this.innerHTML;
        leftDiv.childNodes[0].style.fontSize = '30px';

    }

    function onSearch() {
        fragment.innerHTML = '';
        elements.innerHTML = '';

        for (var i = 0, len = items.length; i < len; i += 1) {
            var currentTitle = createTitleDiv(divElement, items[i].title, '16px', 'bold'),
                currentImage = createImage(image, items[i].url, '95%', '10px'),
                currentElement = createDivWithStyle(divElement, currentTitle, currentImage, '100%', 'left', '10px'),
                template = this.value,
                title = items[i].title.toLowerCase();

            if (template = '' || title.indexOf(template) > -1) {

                currentElement.addEventListener('mouseover', onMouseOver, false);
                currentElement.addEventListener('mouseout', onMouseOut, false);
                currentElement.addEventListener('click', onClick, false);

                fragment.appendChild(currentElement);
            }
        }

        elements.appendChild(fragment);
    }
}