/*
 Create a function that:
 *   Takes an array of students
 *   Each student has a `firstName` and `lastName` properties
 *   **Finds** all students whose `firstName` is before their `lastName` alphabetically
 *   Then **sorts** them in descending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   Then **prints** the fullname of founded students to the console
 *   **Use underscore.js for all operations**
 */

function solve(){
    return function (students) {
        function firstNameIsBeforeLastName(student) {
            return student.firstName < student.lastName;
        }

        var filtered = _.filter(students, firstNameIsBeforeLastName);
        var mapped = _.map(filtered, function(student) {
            student.fullName = student.firstName + ' ' + student.lastName;
            return student;
        });

        var sorted = _.sortBy(mapped, 'fullName');
        sorted.reverse();

        _.each(sorted, function(student) {
            console.log(student.fullName);
        })
    };
}

module.exports = solve;