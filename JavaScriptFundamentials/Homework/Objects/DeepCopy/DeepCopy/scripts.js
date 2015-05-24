/* Task 3. Write a function that makes a deep copy of an object
            The function should work for both primitive and reference types
        */

function deepCopy(obj) {

    if ((obj == null) || 'object' != typeof(obj)) {
        return obj;
    }

    if (obj instanceof Date) {

        var copy = new Date();
        copy.setTime(obj.getTime());
        return copy;
    }

    if (obj instanceof Array) {

        var copy = [];
        for (var i = 0; i < obj.length; i++) {
            copy[i] = deepCopy(obj[i]);
        }

        return copy;
    }

    if (obj instanceof Object) {

        var copy = {};

        for (var attr in obj) {

            if (obj.hasOwnProperty(attr)) {

                copy[attr] = deepCopy(obj[attr]);
            }
        }

        return copy;
    }
}


/* Task 4. Write a function that checks if a given object contains a given property
            var obj  = …;
            var hasProp = hasProperty(obj, 'length');
        */

function hasProperty(obj, x) {

    for (var prop in obj) {

        if (prop === x) {
            return true;
        }
    }
    return false;
}

function testForProp() {
    var char = {
        fname: 'Hanko',
        lname: 'Brat',
        age: 1350,
        friends: 'Chuck Norris'
    }

    if (hasProperty(char, document.getElementById('property').value)) {
        document.getElementById('result2').innerHTML = 'EXISTS';
    }
    else {
        document.getElementById('result2').innerHTML = 'NOT EXISTING';
    }
}


/* Task 5. Write a function that finds the youngest person in a given array of persons and prints his/hers full name Each person have properties firstname, lastname and age, as shown:
            var persons = [
                { firstname : 'Gosho', lastname: 'Petrov', age: 32 }, 
                { firstname : 'Bay', lastname: 'Ivan', age: 81},… ];
        */

function findByAge() {
    var idols = [
                { fname: 'Hanko', lname: 'Brat', age: document.getElementById('age0').value },
                { fname: 'Misho', lname: 'Shamara', age: document.getElementById('age1').value },
                { fname: 'Krisko', lname: 'Beats', age: document.getElementById('age2').value },
                { fname: 'Sto', lname: 'Kila', age: document.getElementById('age3').value }];

    var start = idols[0].age;
    var name = idols[0].fname + ' ' + idols[0].lname;

    for (var i = 0; i < idols.length; i++) {

        if (start > idols[i].age) {
            start = idols[i].age;
            name = idols[i].fname + ' ' + idols[i].lname;
        }
    }

    document.getElementById('result3').innerHTML = name;
}



/* Task 6. Write a function that groups an personsay of persons by age, first or last name. The function must return an associative personsay, with keys - the groups, and values -personsays with persons in this groups(Use function overloading (i.e. just one function))
            var persons = {…};
            var groupedByFname = group(persons, 'firstname');
            var groupedByAge= group(persons, 'age');
        */

function startGrouping() {
    var groupedBy = group(createGroup(), document.getElementById('property2').value);


    for (var i = 0; i < groupedBy.length; i++) {

        for (var j = 0; j < groupedBy[i].Value.length; j++) {

            var para = document.createElement('div');
            var text = document.createTextNode('KEY: ' + groupedBy[i].Key + ' ; VALUE: ' + groupedBy[i].Value[j].toString());
            para.appendChild(text);
            document.body.appendChild(para);

        }      
    }
}

function createPerson(fname, lname, age) {
    return {
        fname: fname,
        lname: lname,
        age: age,
        toString: function () { return 'name: ' + this.fname + ' ' + this.lname + ', age: ' + this.age; }
    }
}

function createGroup() {
    var arrOfPersons = [
               createPerson('Hanko', 'Brat', 1350 ),
               createPerson('Misho', 'Shamara', 1350 ),
               createPerson('Krisko', 'Beats', 22 ),
               createPerson('Drisko', 'Beats', 11 ),
               createPerson('Sto', 'Kila', 22 ),
               createPerson('Sto', 'Tona',  22 ),
               createPerson('Sto', 'Grama', 2),
    ];

    return arrOfPersons;
}

function group(arr, property) {
    var grouped = [];
    var groupedFinal = [];

    switch (property) {

        case 'fname':
            var uniqueFname = [];

            for (var i = 0; i < arr.length; i++) {

                var unique = false;

                for (var j = 0; j < i; j++) {

                    if (arr[i].fname === arr[j].fname) {

                        unique = true;
                        break;
                    }
                }

                if (!unique) {
                    uniqueFname.push(arr[i]);
                }
            }


            for (var i = 0; i < uniqueFname.length; i++) {

                var groupByFname = [];

                for (var j = 0; j < arr.length; j++) {


                    if (uniqueFname[i].fname === arr[j].fname) {
                        groupByFname.push(arr[j]);
                    }
                }

                grouped.push(groupByFname);
            }

            for (var i = 0; i < grouped.length; i++) {
                groupedFinal.push({ Key: grouped[i][0].fname, Value: grouped[i] });
            }

            break;

        case 'lname':
            var uniqueLname = [];

            for (var i = 0; i < arr.length; i++) {

                var unique = false;

                for (var j = 0; j < i; j++) {

                    if (arr[i].lname === arr[j].lname) {
                        unique = true;
                        break;
                    }
                }

                if (!unique) {
                    uniqueLname.push(arr[i]);
                }

            }

            for (var i = 0; i < uniqueLname.length; i++) {
                var groupedByLname = [];

                for (var j = 0; j < arr.length; j++) {

                    if (uniqueLname[i].lname === arr[j].lname) {
                        groupedByLname.push(arr[j]);
                    }
                }

                grouped.push(groupedByLname);
            }

            for (var i = 0; i < grouped.length; i++) {
                groupedFinal.push({ Key: grouped[i][0].lname, Value: grouped[i] });
            }

            break;

        case 'age':
            var uniqueAge = [];

            for (var i = 0; i < arr.length; i++) {
                var unique = false;

                for (var j = 0; j < i; j++) {

                    if (arr[i].age === arr[j].age) {
                        unique = true;
                        break;
                    }
                }

                if (!unique) {
                    uniqueAge.push(arr[i])
                }
            }

            for (var i = 0; i < uniqueAge.length; i++) {
                var groupedByAge = [];

                for (var j = 0; j < arr.length; j++) {

                    if (uniqueAge[i].age === arr[j].age) {
                        groupedByAge.push(arr[j]);
                    }
                }

                grouped.push(groupedByAge);
            }

            for (var i = 0; i < grouped.length; i++) {
                groupedFinal.push({ Key: grouped[i][0].age, Value: grouped[i] });
            }

            break;
    }

    return groupedFinal;
}