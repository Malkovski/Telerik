function solve(){
    return function(selector){
        var $select,
            $options,
            $mainDiv,
            $currentDiv,
            $containerDiv,
            $div = $('<div/>');

        if (typeof selector === 'string') {
            if (selector === 'select') {
                $select = $(selector);
            }
            else {
             throw new Error('Selector must be "select"!');
            }
        }

        $select.css('display', 'none');
        $options = $select.find('option');
        $mainDiv = $div.clone().addClass('dropdown-list');
        $currentDiv = $div.clone().addClass('current');
        $mainDiv.append($currentDiv);
        $mainDiv.prepend($select);
        $('body').append($mainDiv);
        $containerDiv = $div.clone().addClass('options-container').css('position', 'absolute').css('display', 'none');
        $mainDiv.append($containerDiv);


        for (var i = 0, len = $options.length; i < len; i++) {
            var $currentOption = $options[i],
                $divOption = $div.clone().addClass('dropdown-option').attr('data-value', $currentOption.value())
                    .attr('data-index', i).html($currentOption.html());
            $containerDiv.append($divOption);
        }

        $mainDiv.on('click', '.current', function () {
            $containerDiv.css('display') === 'none' ?
                ($containerDiv.show(),
                $currentDiv.html('Select a value')) :
                ($containerDiv.hide())
        });

        $mainDiv.on('click', '.dropdown-item', function () {
           var $this = $(this);
            $currentDiv.html($this.html()).attr('data-value', $this.value());
            $select.value($this.attr('data-value'));
            $containerDiv.hide();
        });


    };
}

module.exports = solve;