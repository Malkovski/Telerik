var validator = (function () {

    var validateNameLength = function (name, min, max) {
        if (min <= name.length && name.length <= max) {
            return true;
        }

        return false;
    };

    var validateMatchingPasswords = function (passOne, passTwo) {
        if (passOne === passTwo) {
            return true;
        }

        return false;
    };

    var validatePattern = function (val) {
        var regexp = /^[a-zA-Z0-9-_]+$/;
         return regexp.test(val);
    };

    var validateURL = function (val) {
        var regexp = /(http|https):\/\/(\w+:{0,1}\w*)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%!\-\/]))?/;

        return regexp.test(val);
    };

    return {
        validate: {
            nameLength: validateNameLength,
            matchingPasswords: validateMatchingPasswords,
            validatePattern: validatePattern,
            validateURL: validateURL
        }
    }
})();

export default validator;