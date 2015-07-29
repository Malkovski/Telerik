/*Create a text area and two inputs with type="color"
    Make the font color of the text area as the value of the first color input
Make the background color of the text area as the value of the second input*/

function textareaColorGange() {
    var area = document.getElementsByTagName('textarea')[0];
    var inputs = document.getElementsByTagName('input');
    area.style.color = inputs[0].color;
}