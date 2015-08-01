function solve(){
    return function(selector){
        var $select,
            $options,
            $mainDiv,
            $currentDiv,
            $containerDiv,
            $div = $('<div/>');

        $select = $(selector)

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
            var $currentOption = $($options[i]),
                $divOption;

            $divOption = $div.clone().addClass('dropdown-item').attr('data-value', $currentOption.val())
                    .attr('data-index', i).html($currentOption.html());
            $containerDiv.append($divOption);
        }

        $currentDiv.html('Select Value...');

        $mainDiv.on('click', '.current', function () {
            $containerDiv.css('display') === 'none' ?
                ($containerDiv.show(),
                $currentDiv.html('Select a value')) :
                ($containerDiv.hide())
        });

        $mainDiv.on('click', '.dropdown-item', function () {
           var $this = $(this);
            $currentDiv.html($this.html()).attr('data-value', $this.val());
            $select.val($this.attr('data-value'));
            $containerDiv.hide();
        });


    };
}

module.exports = solve;