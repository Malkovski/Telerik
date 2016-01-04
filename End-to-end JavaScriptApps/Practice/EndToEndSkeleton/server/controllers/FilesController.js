var CONTROLLER_NAME = 'files';

module.exports = {
    getUpload: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/uploadForm', {currentUser: req.user});
    }
};
