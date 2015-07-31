/* globals $ */

/*
 Create a function that takes a selector and:
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided ID is not a **jQuery object** or a `string`
 */
function solve() {
    return function (selector) {
        var $container,
            $buttons;

        if (typeof selector === 'undefined') {
            throw new Error('Missing parameter!');
        }

        if (typeof selector === null) {
            throw new Error('Null parameter!');
        }

        if (typeof selector === 'string') {
            $container = $(selector);
        }

        if (!$container.length) {
            throw new Error('No such element in DOM!');
        }

        $buttons = $('.button');
        $buttons.html('hide');
        $container.on('click', '.button', buttonClick);

        function buttonClick() {
            var $this = $(this),
                $nextContent = $this.nextAll('.content').first(),
                isVisible;

            isVisible = $nextContent.css('display') === '';

            if (isVisible) {
                $nextContent.css('display', 'none');
                $this.html('show');
            }
            else {
                $nextContent.css('display', '');
                $this.html('hide');
            }
        }
    };
}

module.exports = solve;