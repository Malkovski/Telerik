/**
 * Created by Mastermind on 1.6.2015 ã..
 */



function solve(targetSum) {
    var sumSets = [];
    var numbers = [10, 4, 3];
    var numberSets = powerset(numbers);

    for (var i=0; i < numberSets.length; i++) {
        var numberSet = numberSets[i];
        if (sum(numberSet) == targetSum)
            sumSets.push(numberSet);
    }
    return sumSets.length;

    function powerset(arr) {
        var ps = [[]];
        for (var i=0; i < arr.length; i++) {
            for (var j = 0, len = ps.length; j < len; j++) {
                ps.push(ps[j].concat(arr[i]));
            }
        }
        return ps;
    }

    function sum(arr) {
        var total = 0;
        for (var i = 0; i < arr.length; i++)
            total += arr[i];
        return total
    }
}


console.log(solve(40));