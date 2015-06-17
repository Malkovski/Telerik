function createPiont(x, y) {

    var point = {
        x: x,
        y: y,
        toString: function () {
            return this.x + ' ' + this.y;
        }
    };

    return point;
}

function createLine(p1, p2) {

    var line = {
        a: p1,
        b: p2,
        toString: function () {
            return this.p1 + ' ' + this.p2;
        }
    };

    return line;
}

function distance() {

    var x1 = parseFloat(document.getElementById('x1').value);
    var y1 = parseFloat(document.getElementById('y1').value);
    var x2 = parseFloat(document.getElementById('x2').value);
    var y2 = parseFloat(document.getElementById('y2').value);

    var result = calculateDistance(x1, y1, x2, y2);
    document.getElementById('result1').innerHTML = result;
}

function distanceLineOne() {
    var x1 = parseFloat(document.getElementById('x3').value);
    var y1 = parseFloat(document.getElementById('y3').value);
    var x2 = parseFloat(document.getElementById('x4').value);
    var y2 = parseFloat(document.getElementById('y4').value);

    var result = calculateDistance(x1, y1, x2, y2);
    document.getElementById('result2').innerHTML = result;
}

function distanceLineTwo() {
    var x1 = parseFloat(document.getElementById('x5').value);
    var y1 = parseFloat(document.getElementById('y5').value);
    var x2 = parseFloat(document.getElementById('x6').value);
    var y2 = parseFloat(document.getElementById('y6').value);

    var result = calculateDistance(x1, y1, x2, y2);
    document.getElementById('result3').innerHTML = result;
}

function distanceLineThree() {
    var x1 = parseFloat(document.getElementById('x7').value);
    var y1 = parseFloat(document.getElementById('y7').value);
    var x2 = parseFloat(document.getElementById('x8').value);
    var y2 = parseFloat(document.getElementById('y8').value);

    var result = calculateDistance(x1, y1, x2, y2);
    document.getElementById('result4').innerHTML = result;
}

function calculateDistance(x1, y1, x2, y2) {

    var p1 = createPiont(x1, y1);
    var p2 = createPiont(x2, y2);
    var line = createLine(p1, p2);

    var powP1 = Math.pow((p2.x - p1.x), 2);
    var powP2 = Math.pow((p2.y - p1.y), 2);

    var result = Math.sqrt(powP1 + powP2);

    return result;
}

function triangleCheck() {
    var a = document.getElementById('result2').innerText;
    var b = document.getElementById('result3').innerText;
    var c = document.getElementById('result4').innerText;

    if (((a + b) > c) && ((a + c) > b) && ((b + c) > a)) {

        document.getElementById('result5').innerHTML = true;
    }
    else {
        document.getElementById('result5').innerHTML = false;
    }
}