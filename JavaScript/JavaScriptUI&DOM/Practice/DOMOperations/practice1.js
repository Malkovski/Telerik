/*Write a script that creates a number of div elements. Each div element must have the following
 Random width and height between 20px and 100px
 Random background color
 Random font color
 Random position on the screen (position:absolute)
 A strong element with text "div" inside the div
 Random border radius
 Random border color
 Random border width between 1px and 20px
*/

function generateDivs(count) {
    var count = count || 1,
        divTemplate  = document.createElement('div'),
        fragment = document.createDocumentFragment(),
        positions = {
            1: 'relative',
            2: 'absolute',
            3: 'fixed',
            4: 'static'
        },
        strongElement = document.createElement('strong');

    strongElement.innerHTML = 'div';
    divTemplate.appendChild(strongElement);

    function getRandomColor() {
        var letters = '0123456789ABCDEF'.split('');
        var color = '#';
        for (var i = 0; i < 6; i++ ) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
    }

    function randomIntFromInterval(min,max)
    {
        return Math.floor(Math.random()*(max-min+1)+min);
    }

    for (var i = 0, len = count; i < len; i += 1) {

        divTemplate.style.color = getRandomColor();
        divTemplate.style.backgroundColor = getRandomColor();
        divTemplate.style.border.color = getRandomColor();
        divTemplate.style.width = randomIntFromInterval(20, 100) + 'px';
        divTemplate.style.height = randomIntFromInterval(20, 100) + 'px';
        divTemplate.style.border.width = randomIntFromInterval(1, 20) + 'px';
        divTemplate.style.borderRadius = randomIntFromInterval(1, 20) + 'px';
        divTemplate.style.position = positions[randomIntFromInterval(1, 4)];
        fragment.appendChild(divTemplate.cloneNode(true));
    }

    document.body.appendChild(fragment);
}