//Task 3. _ClickON_TheButton in JavaScript
//Refactor the following examples to produce code with well-named identifiers in JavaScript
//function _ClickON_TheButton( THE_event, argumenti) {
//var moqProzorec= window,
//brauzyra = moqProzorec.navigator.appCodeName,
//ism=brauzyra=="Mozilla";
//if(ism) {
//alert("Yes");
//} else {
//alert("No");
//}
//}

function initiateButtonClick(event, params) {

    'use strict';

    var currentWindow = this.window,
        currentBrowser = currentWindow.navigator.appCodeName;

    function isMozilla(currentBrowser) {

        return currentBrowser === "Mozilla";
    }

    if (isMozilla(currentBrowser)) {

        alert("Yes");
    }
    else {

        alert("No");
    }
}