function showCountOfNestedDivsWithQuerry() {
    var allDivsInDivs = document.querySelectorAll('div div');
    var p = document.getElementsByTagName('p')[0];
    var nestedDivCount = allDivsInDivs.length;

    p.innerText = 'result with querrySelectorAll:';
    p.innerText += ' ' + nestedDivCount;
}

function showCountOfNestedDivsByTag() {

    var allInnerDivs = document.getElementsByTagName('div'),
        nestedDivCount = 0;

    for (var i = 0, len = allInnerDivs.length; i < len; i++) {

        var currentChild = allInnerDivs[i].getElementsByTagName('div');
        if (currentChild.length !== 0) {
            nestedDivCount += 1;
        }
    }

    var p = document.getElementById('by-tag-name');
    p.innerText = 'result with getElementsByTagName:';
    p.innerText += ' ' + nestedDivCount;
}
