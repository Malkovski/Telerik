$.fn.gallery = function (count) {
    var $gallery = $(this),
        cols = count || 4,
        $images = $gallery.find('.image-container')
            .css('width', ($gallery.width() / cols) - 12)
            .css('height', ($gallery.width() / cols) - 12);

    $gallery.addClass('gallery');
    $gallery.on('click', '.image-container', imageClick);

    $gallery.find('.current-image').on('click', currentImageClick);

    $gallery.find('.previous-image').on('click', previousImageClick);

    $gallery.find('.next-image').on('click', nextImageClick);

    function imageClick() {
        var $this = $(this),
            $current = $this.children().clone(),
            $previous,
            $next;

        if ($this.is($this.parent().children().first())) {
            $previous = $this.parent().children().last().children().clone();
        }
        else {
            $previous = $this.prev().children().clone();
        }

        if ($this.is($this.parent().children().last())) {
            $next = $this.parent().children().first().children().clone();
        }
        else {
            $next = $this.next().children().clone();
        }

        $gallery.find('.gallery-list').addClass('blurred').addClass('disabled-background');
        $gallery.off('click', '.image-container', imageClick);

        $gallery.find('.current-image').empty();
        $gallery.find('.previous-image').empty();
        $gallery.find('.next-image').empty();

        $gallery.find('.current-image').html($current);
        $gallery.find('.previous-image').html($previous);
        $gallery.find('.next-image').html($next);
    }

    function currentImageClick() {
        var $this = $(this);
        $this.empty();

        $gallery.find('.gallery-list').removeClass('blurred').removeClass('disabled-background');
        $gallery.on('click', '.image-container', imageClick);

        $gallery.find('.previous-image').empty();
        $gallery.find('.next-image').empty();
    }

    var initialPrevDataInfo = $gallery.find('#previous-image').attr('src');
    function previousImageClick() {
        var $this = $(this),
            $current = $this.children().clone(),
            $next = $gallery.find('.current-image').children().clone(),
            $currentDataInfo = initialPrevDataInfo,
            $previous,
            $newPrevious;




        $this.empty();
        $gallery.find('.current-image').empty();
        $gallery.find('.next-image').empty();

        $gallery.find('.current-image').html($current);
        $gallery.find('.next-image').html($next);

        $previous = $gallery.find('.image-container').find('[src="' + $currentDataInfo + '"]').parent();

        if ($previous.is($gallery.find('.gallery-list').children().first())) {
            $newPrevious = $previous.parent().children().last().children().clone();
        }
        else {
            $newPrevious = $previous.prev().children().clone();
        }

        $gallery.find('.previous-image').html($newPrevious);
        initialPrevDataInfo = $this.children().attr('src');
    }

    var initialNextDataInfo = $gallery.find('#next-image').attr('src');
    function nextImageClick() {
        var $this = $(this),
            $newCurrent = $this.children().clone(),
            $newPrevious = $gallery.find('.current-image').children().clone(),
            $currentDataInfo = initialNextDataInfo,
            $oldNext,
            $newNext;

        $this.empty();
        $gallery.find('.current-image').empty();
        $gallery.find('.previous-image').empty();

        $gallery.find('.current-image').html($newCurrent);
        $gallery.find('.previous-image').html($newPrevious);

        $oldNext = $gallery.find('.image-container').find('[src="' + $currentDataInfo + '"]').parent();

        if ($oldNext.is($oldNext.parent().children().last())) {
            $newNext = $oldNext.parent().children().first().children().clone();
        }
        else {
            $newNext = $oldNext.next().children().clone();
        }

        $gallery.find('.next-image').html($newNext);
        initialNextDataInfo = $this.children().attr('src');
    }
};