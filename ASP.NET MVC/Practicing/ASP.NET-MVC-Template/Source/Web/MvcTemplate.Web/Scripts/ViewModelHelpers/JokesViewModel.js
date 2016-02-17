var JokesViewModel, JokesModel;

JokesViewModel = {
    init: function (model) {
        var self = JokesViewModel;

        self.model = model;
        self.initSelectors();
        self.likeClick();
    },

    initSelectors: function () {
        var self = JokesViewModel;

        self.Like = $('div[data-action="up"]');
        self.LikedId = self.Like.attr('data-id');

        self.Dislike = $('div[data-action="down"]');
        self.DislikedId = self.Dislike.attr('data-id');
    },

    likeClick: function () {
        var self = JokesViewModel;

        self.Like.on('click', function () {
            var id = self.LikedId;
            self.model.likeClick(1, id);
        })

        self.Dislike.on('click', function () {
            var id = self.DislikedId;
            self.model.likeClick(-1, id);
        })
    }
}

JokesModel = {
    likeClick: function (type, id) {
        $.post("/Likes/Like/", { jokeId: id, likeType: type }, function (data) {
            var likesCount = data.Count;
            //$('div[data-action="likesCount"] [data-id]="' + id + '"]').html(likesCount);
            $('#' + id).html(likesCount);
        })
    }
}

$(document).ready(function () {
    JokesViewModel.init(JokesModel);
});