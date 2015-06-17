/**
 * Created by Geogi Malkovski on 17.6.2015 ã..
 */
/* Task description */
/*
 Write a function that finds all the prime numbers in a range
 1) it should return the prime numbers in an array
 2) it must throw an Error if any on the range params is not convertible to `Number`
 3) it must throw an Error if any of the range params is missing
 */

function findPrimes(from, to) {
    var divisor,
        maxDivisor,
        isPrime,
        i,
        primes = [];

    if (arguments.length <= 1) {
        throw new Error();
    }
    
    from = +from;
    to = +to;

    for (i = from; i <= to; i += 1) {

        maxDivisor = Math.sqrt(i);
        isPrime = true;
        
        for (divisor = 2; divisor <= maxDivisor; divisor++) {
            if (!(i % divisor)) {
                isPrime = false;
                break;
            }
        }

        if (isPrime && i > 1) {
            primes.push(i);
        }
    }

    return primes;
}

module.exports = findPrimes;