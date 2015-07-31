/* globals $ */

/* 
 Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:
 * The UL must have a class `items-list`
 * Each of the LIs must:
 * have a class `list-item`
 * content "List item #INDEX"
 * The indices are zero-based
 * If the provided selector does not selects anything, do nothing
 * Throws if
 * COUNT is a `Number`, but is less than 1
 * COUNT is **missing**, or **not convertible** to `Number`
 * _Example:_
 * Valid COUNT values:
 * 1, 2, 3, '1', '4', '1123'
 * Invalid COUNT values:
 * '123px' 'John', {}, []
 */

function solve() {
    return function (selector, count) {
        if (typeof selector === 'undefined' || typeof count === 'undefined') {
            throw new Error('Either selector or count is missing!')
        }

        if (typeof selector === null || typeof count === null) {
            throw new Error('Either selector or count is null value!')
        }

        if (!(/^\d+$/.test(count))) {
            throw new Error('Count must be convertible to number!');
        }

        count = parseInt(count, 10);

        if (count < 1) {
            throw new Error('Count must be at least 1');
        }

        if (typeof selector !== 'string') {
            throw new Error('Selector must be string!');
        }

        var $container = $(selector),
            $ul = $('<ul></ul>');
       $ul.addClass('items-list');

        for (var i = 0, len = count; i < len; i += 1) {
            var $currentLi = $('<li></li>');
            $currentLi.addClass('list-item').html('List item #' + i)

            $currentLi.appendTo($ul);
        }

        $container.append($ul);
    };
}

module.exports = solve;