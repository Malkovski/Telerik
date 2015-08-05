var selector = {},
    $container = [{},{}],
    count = '6',
    element = '',
    content = '',
    serial = 'ddd555';

console.log('selector is ' + typeof selector);
console.log($container.length);

// Validate for undefined
if (typeof selector === 'undefined') {
    throw new Error('Missing parameter!');
}

// Validate for null
if (selector === null) {
    throw new Error('Null parameter!');
}

// Validate if selector is object
if (!(typeof selector === 'object')) {
    throw new Error('Item must be an object');
}

// Check if parameter has .length -  array-like object
if (!($container.length)) {
    throw new Error('Selected element must be array-like object');
}

// Validate string contains only digits
if (!(/^\d+$/.test(count))) {
    throw new Error('Count must be convertible to number!');
}

// Validate string contains only alpha-numeric
if (!(/^[A-Z0-9]+$/i.test(serial))) {
    throw new Error('Serial must contain only alpha-numeric characters!');
}

// Validate for STRING value
if (typeof selector !== 'string') {
    throw new Error('Selector must be string!');
}

// Selecting DOM element when parameter sting
if (typeof selector === 'string') {
    // $container = $(selector);
}

// Validate for string or number value
if (!(typeof content === 'string') && !(typeof content === 'number')) {
    throw new Error('Content cannot be other than number or string!')
}

/*// Validate selected element exist in DOM
if (!(element instanceof HTMLElement)) {
    throw new Error('There is no such element in the DOM');
}*/

// Validate if empty string
if (selector === '') {
    throw new Error('Selector cannot be empty string! 555');
}
if (selector.length === 0) {
    throw new Error('Selector cannot be empty string!');
}

// Validate length is between 2 passed values inclusive
if (selector.length < 2 || 40 < selector.length) {
    throw new Error('Selector must be between 2 an 40 symbols long');
}

// Validate if length is one of two passed values
if (selector.length !== 10 && selector.length !== 13) {
    throw new Error('Invalid selector length -  must be 10 or 13 symbols long')
}