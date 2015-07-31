function solve(){
    return function(selector){
        var $select,
            $options,
            $div = $('<div/>'),
            $mainDiv,
            $currentDiv,
            $containerDiv;

        if (typeof selector === 'string') {
            if (selector === 'select') {
                $select = $(selector);
            }
            else {
             throw new Error('Selector must be "select"!');
            }
        }

        $options = $select.find('option');
        $mainDiv = $div.clone().addClass('dropdown-list');
        $currentDiv = $div.clone().addClass('current');
        $mainDiv.append($currentDiv);
        $mainDiv.prepend($select);
        $containerDiv = $div.clone().addClass('options-container').css('position', 'absolute').css('display', 'none');
        $mainDiv.append($containerDiv);

        $options.each(function (option) {
            var $currentOption = $(option);

        });
    };
}

module.exports = solve;