
function removeElement(arr, x) {

    for (var i = 0; i < arr.length; i++) {

        if (arr[i] === x) {
            arr.splice(i, 1);
            --i;
        }
    }

    return arr;
}

Array.prototype.remove = function (x) {
    return removeElement(this, x);
}

function startRemoving() {
    var arr = document.getElementById('data1').value;
    arr = arr.split(',');
    var element = document.getElementById('element').value;

    arr.remove(element);

    var result = arr.join(',');

    document.getElementById('result1').innerHTML = result;
}