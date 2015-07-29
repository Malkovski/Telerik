//Write a script that creates 5 div elements and moves them in circular path with interval of 100 milliseconds

function circulateDivs() {
    var fragment = document.createDocumentFragment(),
        divTemplate = document.createElement('div');

    for (var i = 0, len = 5; i < len; i += 1) {
        divTemplate.innerHTML = i;
        fragment.appendChild(divTemplate.cloneNode(true))
    }

    var container = document.getElementById('circle-div');
    container.appendChild(fragment);

    setInterval(function () {
        var first = container.firstChild;
        first.parentNode.removeChild(first);
        container.appendChild(first.cloneNode(true));
    }, 1000);
}