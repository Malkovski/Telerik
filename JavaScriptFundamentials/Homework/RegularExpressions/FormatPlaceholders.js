/**
 * Created by Mastermind on 6.6.2015 ã..
 */
if (!String.prototype.format) {
    String.prototype.format = function(params) {
        var option,
            regex,
            formattedString = this;

        for (option in params) {
            regex = new RegExp('#{' + option + '}', 'gm');

            formattedString = formattedString.replace(regex, params[option]);
        }

        return formattedString;
    }
}

var testOne = 'Hello, there! Are you #{name}?',
    testTwo = 'My name is #{name} and I am #{age}-years-old',
    testThree = '#{name} #{lastname} #{age} #{gender}';


console.log(testOne.format({name: 'Ivan'}));
console.log(testTwo.format({name: 'Pesho', age: 77}));
console.log(testThree.format({name: 'John', lastname: 'Smith', age: 33, gender: 'male'}));
