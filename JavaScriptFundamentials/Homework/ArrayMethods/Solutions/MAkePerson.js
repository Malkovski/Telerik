/**
 * Created by Mastermind on 4.6.2015 ã..
 */
/*
 Problem 1. Make person

 Write a function for creating persons.
 Each person must have firstname, lastname, age and gender (true is female, false is male)
 Generate an array with ten person with different names, ages and genders
 */

console.log('----------------Make persons--------------------');

function createPersons(firstname, lastname, age, gender) {
    return {
        firstname: firstname,
        lastname: lastname,
        age: age,
        gender: gender ? 'female' : 'male',
        introduce: function() {
            return this.firstname + ' ' + this.lastname + ' ' + this.age + ' ' + this.gender;
        }
    };
}

var groupOfPeople = [
    createPersons('Angel', 'Stoyanov', 32),
    createPersons('Ivan', 'Ivanov', 23),
    createPersons('Petya', 'Petrova', 18, 1),
    createPersons('Martin', 'Iliev', 12),
    createPersons('Albena', 'Dimitrova', 17, 1),
    createPersons('Simona', 'Georgieva', 20, 1),
    createPersons('Stefan', 'Georgiev', 26),
    createPersons('Asen', 'Penev', 15),
    createPersons('Kalina', 'Petkova', 30, 1),
    createPersons('Maria' , 'Nikolova', 18, 1)
];

console.log(groupOfPeople);

/*
 Problem 2. People of age

 Write a function that checks if an array of person contains only people of age (with age 18 or greater)
 Use only array methods and no regular loops (for, while)
 */

console.log('----------------People of age 18+--------------------');

var IsEveryAge = groupOfPeople.every(greaterThan18);

function greaterThan18(element) {
    var i = arguments[1],
        arr = arguments[2];
    return element.age >= 18;
}

console.log(IsEveryAge);

/*
 Problem 3. Underage people

 Write a function that prints all underaged persons of an array of person
 Use Array#filter and Array#forEach
 Use only array methods and no regular loops (for, while)
 */
console.log('----------------Underage people--------------------');

function printFiltered(arr, func) {
    var filtered = arr.filter(func),
        result = '';

    filtered.forEach(function (element) {
        result = element.introduce();
        console.log(result);
    });
}

function underaged(element) {
    var i = arguments[1],
        arr = arguments[2];

    return element.age < 18;
}

printFiltered(groupOfPeople, underaged);
printFiltered(groupOfPeople, greaterThan18);

/*
 Problem 4. Average age of females

 Write a function that calculates the average age of all females, extracted from an array of persons
 Use Array#filter
 Use only array methods and no regular loops (for, while)
 */
console.log('----------------Average age of females--------------------');

function calculateAverageAge(arr, func) {
    var females = arr.filter(func),
        sum = 0;

    females.forEach(function (el) {
        sum += el.age;
    });

    console.log(sum / females.length);
}

function extractFemale(element) {
    var i = arguments[1],
        arr = arguments[2];
    return element.gender;
}

calculateAverageAge(groupOfPeople, extractFemale);

/*
 Problem 5. Youngest person

 Write a function that finds the youngest male person in a given array of people and prints his full name
 Use only array methods and no regular loops (for, while)
 Use Array#find
 */

console.log('----------------Youngest person--------------------');

if (!Array.prototype.find) {
    Array.prototype.find = function (callback) {
        var i,
            len = this.length;
        for (i = 0; i < len; i += 1) {

            if (callback(this[i], i, this)) {
                return this[i];
            }
        }
    }
}

function findYoungest(arr, func) {
    var males = arr.filter(func),
        minAge = males[0].age,
        result;

    males.forEach(function (element) {
        if (element.age < minAge) {
            minAge = element.age;
        }
    });

    result = males.find(function (item) {
         return item.age == minAge;
    });

    console.log(result.firstname + ' ' + result.lastname);
}

function extractMales (element) {
    var i = arguments[1],
        arr = arguments[2];
    return element.gender == 'male';

}

findYoungest(groupOfPeople, extractMales);