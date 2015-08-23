/*
 Create a function that:
 *   Takes an array of students
 *   Each student has:
 *   `firstName`, `lastName` and `age` properties
 *   Array of decimal numbers representing the marks
 *   **finds** the student with highest average mark (there will be only one)
 *   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve(){
    return function (students) {
        //var average;

        var bestStudent = _.chain(students).map(function(student) {
            student.fullName = student.firstName + ' ' + student.lastName;
            var sumOfGrades = 0;
            var grades = student.marks;

            for (var i = 0, len = grades.length; i < len; i++) {
                sumOfGrades += grades[i];
            }

            student.averageScore = sumOfGrades / grades.length;

            return student;
        }).sortBy('averageScore').reverse().first().value();

        console.log(bestStudent.fullName + ' has an average score of ' + bestStudent.averageScore);
    };
}

module.exports = solve;