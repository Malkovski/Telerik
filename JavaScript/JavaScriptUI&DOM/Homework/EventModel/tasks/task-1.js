function solve(){
    return function (selector) {
        var container,
            buttons;

        if (typeof selector === 'string') {
            container = document.querySelector('#' + selector);
        }

        if (typeof selector === undefined) {
            throw new Error('Selector CANNOT be undefined!');
        }

        if (typeof selector === null) {
            throw new Error('Selector CANNOT be null!');
        }

        if (!(container instanceof HTMLElement)) {
            throw new Error('This element do not exist in current DOM!');
        }

        buttons = container.getElementsByClassName('button');

        for (var j = 0, len = buttons.length; j < len; j += 1) {
            buttons[j].innerHTML = 'hide';
        }

        for (var k = 0, len = buttons.length; k < len; k += 1) {
            var currentButton = buttons[k];

            currentButton.addEventListener('click', function (ev) {
                var current = ev.target,
                    next = current.nextElementSibling;

                while (next && next.className.indexOf('content') < 0) {
                    next = next.nextElementSibling;
                }

                var isVisible = next.style.display === '';

                if (isVisible) {
                    next.style.display = 'none';
                    current.innerHTML = 'show';
                }
                else {
                    next.style.display = '';
                    current.innerHTML = 'hide';
                }
            });
        }
    }
}

module.exports = solve;