var animal = (function () {
    var animal = {};

    Object.defineProperty(animal, 'init', {
       value: function (name, age) {
           this.name = name;
           this.age = age;
           return this;
       }
    });

    Object.defineProperty(animal, 'walk', {
        value: function () {
            return 'walking...';
        }
    });

    return animal;
})();

var cat = (function (parent) {
    var cat = {};//Object.create(parent);

    Object.defineProperty(cat, 'init', {
        value: function (name, age, breed) {
            Object.create(parent).init.call(this, name, age);
            this.breed = breed;
            return this;
        }
    });

    Object.defineProperty(cat, 'walk', {
        value: function () {
            return parent.walk.call(this);
        }
    });

    return cat;
})(animal);


var someAnimal = animal.init('Pesho', 2);
var oneCat = cat.init('MishuGosu', 11, 'streetfighter');

console.log(someAnimal.name + ' ' + someAnimal.age);
console.log(oneCat.name + ' ' + oneCat.age + ' ' + oneCat.breed);
console.log(someAnimal.walk());
console.log(oneCat.walk());