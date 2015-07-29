(function ($) {
    $.fn.gallery = function (cols) {
        var $gallery = $(this),
            columns = cols || 4,
            $images = $gallery.find('.image-container')
                .css('width', (($gallery.width()/(columns + 1)) - 12))
                .css('height', (($gallery.width()/(columns + 1)) - 12));

        $gallery.addClass('gallery')
            .on('click', '.image-container', imageClick);

        $gallery.find('.current-image').on('click', currentImageClick);

        $gallery.find('.previous-image').on('click', previousImageClick);

        $gallery.find('.next-image').on('click', nextImageClick);

        function nextImageClick() {
            var $this = $(this),
                $newCurrentImage = $this.children().clone(),
                $newPreviousImage = $gallery.find('.current-image').children().clone(),
                $currentDataInfo = $newCurrentImage.attr('data-info'),
                $newNextImage,
                $oldNextImage;

            $this.empty();
            $gallery.find('.current-image').empty();
            $gallery.find('.previous-image').empty();
            $gallery.find('.next-image').empty();

            $gallery.find('.current-image').html($newCurrentImage);
            $gallery.find('.previous-image').html($newPreviousImage);

            $oldNextImage = $gallery.find('.image-container').find("[data-info='" + parseInt($currentDataInfo, 10) + "']").parent();

            if ($oldNextImage.is($oldNextImage.parent().children().last())) {
                $newNextImage = $oldNextImage.parent().children().first().children().clone();
            }
            else {
                $newNextImage = $oldNextImage.next().children().clone() ;
            }

            $gallery.find('.next-image').html($newNextImage);
        }

        function previousImageClick() {
            var $this = $(this),
                $newCurrentImage = $this.children().clone(),
                $newNextImage = $gallery.find('.current-image').children().clone(),
                $currentDataInfo = $newCurrentImage.attr('data-info'),
                $newPreviousImage,
                $oldPreviousImage;


            $this.empty();
            $gallery.find('.current-image').empty();
            $gallery.find('.previous-image').empty();
            $gallery.find('.next-image').empty();

            $gallery.find('.current-image').html($newCurrentImage);
            $gallery.find('.next-image').html($newNextImage);



            $oldPreviousImage = $gallery.find('.image-container').find("[data-info='" + parseInt($currentDataInfo, 10) + "']").parent();
            //console.log($currentDataInfo);
            if ($oldPreviousImage.is($oldPreviousImage.parent().children().first())) {
                $newPreviousImage = $oldPreviousImage.parent().children().last().children().clone();
            }
            else {
                $newPreviousImage = $oldPreviousImage.prev().children().clone() ;
            }

            $gallery.find('.previous-image').html($newPreviousImage);
        }

        function currentImageClick() {
            var $this = $(this);
            $this.empty();

            $gallery.find('.gallery-list').removeClass('.blurred').removeClass('.disabled-background');
            $gallery.on('click', '.image-container', imageClick);

            $gallery.find('.current-image').empty();
            $gallery.find('.previous-image').empty();
            $gallery.find('.next-image').empty();
        }

        function imageClick(item) {
            var $this = $(this) || item,
                $currentImage = $this.children().clone(),
                $previousImage,
                $nextImage;

            if ($this.is($this.parent().children().first())) {
                $previousImage = $this.parent().children().last().children().clone();
            }
            else {
                $previousImage = $this.prev().children().clone();
            }

            if ($this.is($this.parent().children().last())) {
                $nextImage = $this.parent().children().first().children().clone();
            }
            else {
                $nextImage = $this.next().children().clone();
            }

            $gallery.find('.gallery-list').addClass('.blurred').addClass('.disabled-background');
            $gallery.off('click', '.image-container', imageClick);

            $gallery.find('.current-image').empty();
            $gallery.find('.previous-image').empty();
            $gallery.find('.next-image').empty();

            $gallery.find('.current-image').html($currentImage);
            $gallery.find('.previous-image').html($previousImage);
            $gallery.find('.next-image').html($nextImage);
        }
    }
})(jQuery);