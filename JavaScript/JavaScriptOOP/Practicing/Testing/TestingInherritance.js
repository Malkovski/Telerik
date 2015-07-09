var Animal = function () {
    var animal = Object.create({});

    Object.defineProperty(animal, 'init', {
        value: function (type) {
            this.type = type;
            return this;
        }
    });

    Object.defineProperty(animal, 'type', {
       get: function() {
           return this._type;
       },
       set: function (value) {
           this._type = value;
       }
    });

    return animal;
}();

var Cat = function(parent) {
    var cat = Object.create({});

    Object.defineProperty(cat, 'init', {
        value: function (type, age, breed) {
            parent.init.call(this, type);
            this._breed = breed;
            this._age = age;
            return this;
        }
    });

    Object.defineProperty(cat, 'breed', {
        get: function () {
            return this._breed;
        },
        set: function (value) {
            this._breed = value;
        }
    });

    Object.defineProperty(cat, 'age', {
        get: function () {
            return this._age;
        },
        set: function (value) {
            this._age = value;
        }
    });

    return cat;
}(Animal);

var myCat = Object.create(Cat);
var myAnimal = Object.create(Animal);
myAnimal.init('gazela');
myCat.init('cat', 2, 'angorska');
console.log(myCat.age);
console.log(myAnimal.type);

