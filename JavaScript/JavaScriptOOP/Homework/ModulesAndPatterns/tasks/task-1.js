/* Task Description */
/*
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {

    function isValidTitle(value) {
        if (value.length < 1) {
            return false;
        }

        if (value === '' || value[0] === ' ' || value[value.length - 1] === ' ') {
            return false;
        }

        for (var i = 1, len = value.length - 2; i < len; i++) {

            if (value[i] === ' ' && value[i + 1] === ' ') {
                return false;
            }
        }

        return true;
    }

    function areValidPresentations(value) {
        if (value.length === 0) {
            return false;
        }
        else {
            var currentPresentationState = true;

            for (var j = 0, len = value.length; j < len; j++) {
               currentPresentationState = isValidTitle(value[j]);

                if (currentPresentationState == false) {
                    return false;
                }
            }

            return true;
        }
    }

    function isValidName(name) {
        if (typeof name === 'string') {
            var splitNameParts = name.split(' ');

            if (splitNameParts.length === 2) {
                var first = splitNameParts[0],
                    second = splitNameParts[1];

                if ((first[0] == first[0].toUpperCase()) && (second[0] == second[0].toUpperCase())) {

                    if (first.length > 1) {
                        return checkForLowerLetters(first.slice(1));
                    }

                    if (second.length > 1) {
                        return checkForLowerLetters(second.slice(1));
                    }

                    return true;
                }
            }
        }

        return false;
    }

    function checkForLowerLetters(str) {
        for (var k = 0, len = str.length; k < len; k++) {
            if (str[k] !== str[k].toLowerCase()) {
                return false;
            }
        }

        return true;
    }

    function isRealStudentID(value, count) {
        if (value % 1 === 0 && value > 0 && value <= count) {

            return true;
        }

        return false;
    }

    function isRealHomeworkID(value, count) {
        if (value % 1 === 0 && value > 0 && value <= count) {

            return true;
        }

        return false;
    }

    var Course = {
        get title() {
            return this._title;
        },
        set title(value) {
            if (isValidTitle(value)) {
                this._title = value;
            }
            else {
                throw new Error('Invalid title!');
            }
        },
        get presentations() {
            return this._presentations;
        },
        set presentations(value) {
            if (areValidPresentations(value)) {
                this._presentations = value;
            }
            else{
                throw new Error('Invalid title!');
            }
        },
        get students() {
            return this._students;
        },
        set students(value) {
            this._students = value;
        },
        init: function(title, presentations) {
            this.title = title;
            this.presentations = presentations;
            this.students = [];
        },
        addStudent: function(name) {
            if (isValidName(name)) {
                var fullName = name.split(' '),
                    firstName = fullName[0],
                    lastName = fullName[1],
                    ID = this.students.length + 1;

                var student = {
                    firstname: firstName,
                    lastname: lastName,
                    id: ID
                };

                this.students.push(student);

                return ID;
            }
            else {
                throw new Error('Invalid student!')
            }
        },
        getAllStudents: function() {
            var list = this.students;
            return list;
        },
        submitHomework: function(studentID, homeworkID) {
           var studentsCount = this.students.length,
               presentationCount = this.presentations.length;

            if (!(isRealStudentID(studentID, studentsCount)) || !(isRealHomeworkID(homeworkID, presentationCount))) {
                throw new Error("Invalid ID's!")
            }
        },
        pushExamResults: function(results) {
        },
        getTopStudents: function() {
        }
    };

    return Course;
}


module.exports = solve;


/*
var jsoop = solve();
jsoop.init('aaaa', ['bbbb']);
jsoop.addStudent('Georgi' + ' ' + 'Malkovski');
jsoop.addStudent('Georgi' + ' ' + 'Malkovski');
jsoop.addStudent('Georgi' + ' ' + 'Malkovski');
jsoop.addStudent('Georgi' + ' ' + 'Malkovski');
jsoop.addStudent('Georgi' + ' ' + 'Malkovski');
jsoop.addStudent('Georgi' + ' ' + 'Malkovski');
console.log(jsoop.getAllStudents());*/
