var allDivsInDivs = document.querySelectorAll('#qq div');
var allInnerDivs = document.getElementsByClassName('main');
var result = allInnerDivs.getElementsByTagName('div');

console.log(allInnerDivs);
console.log(allDivsInDivs);
console.log(result);

var p = document.getElementsByTagName('p');
p.innerText += allDivsInDivs.length;


