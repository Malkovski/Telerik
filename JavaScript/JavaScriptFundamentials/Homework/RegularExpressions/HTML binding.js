/**
 * Created by Mastermind on 6.6.2015 ã..
 */

String.prototype.insertAt = function(index, string) {
    return this.substring(0, index) + string + this.substr(index);
}

if (!String.prototype.bind) {
    String.prototype.bind = function() {
        var match,
            regex = /(?:data\-bind\-(\w+)="(\w+)")/g,
            matches = {},
            formattedString = arguments[0];


        while  (match = regex.exec(formattedString)) {
            matches[match[1]] = match[2];
        }

        for (var key in matches) {
            var closeTagIndex = formattedString.indexOf('>');

            if (matches.hasOwnProperty(key)) {
                if (key === 'content') {

                   formattedString = formattedString.insertAt(closeTagIndex + 1, arguments[1][matches[key]]);
                }
                else {
                    formattedString = formattedString.insertAt(closeTagIndex, ' ' + key + '\"=' + arguments[1][matches[key]] + '\"');
                }
            }
        }

        return formattedString;
    }
}

var str = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></à>';

console.log(str.bind(str, {name: 'Elena', link: 'http://telerikacademy.com'}));