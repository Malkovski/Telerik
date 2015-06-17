/**
 * Created by Geogi Malkovski on 17.6.2015 ã..
 */
/* Task Description */
/*
 Write a function that sums an array of numbers:
 numbers must be always of type Number
 returns `null` if the array is empty
 throws Error if the parameter is not passed (undefined)
 throws if any of the elements is not convertible to Number
 */

function sum(params) {

    var sum = 0;

    if (params.length === 0) {
        return null;
    }

    for (var i = 0, len = params.length; i < len; i++) {
        if (isNaN(params[i])) {
            throw new Error();
        }

        sum += parseInt(params[i], 10);
    }

  return sum;
}

module.exports = sum;