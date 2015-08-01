$.fn.tabs = function () {
    var self = this;

    self.addClass('tabs-container');
    var current = $('.tab-item').first().addClass('current');
    $('.tab-item-content').hide();
    $('.current .tab-item-content').show();

    self.on('click', '.tab-item', function () {
        $('.current').removeClass('current');
        $('.tab-item-content').hide();
        $(this).children('.tab-item-content').show();
        $(this).addClass('current');
    })
};