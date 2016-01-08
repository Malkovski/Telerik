var users = require('../data/users');
var files = require('../data/files');

var usersCount = 0;
var filesCount = 0;

module.exports = {
    getStatistics: function (req, res, next) {

        var usersQuery = users.count();
        usersQuery.exec(function (err, count) {
            if (err) {
                req.session.error = err;
                return;
            }

            usersCount = count;
        });

        var filesQuery = files.count();
        filesQuery.exec(function (err, count) {
            if (err) {
                req.session.error = err;
                return;
            }

            filesCount = count;
        });

        res.render('index', {usersCount: usersCount, filesCount: filesCount, currentUser: req.user});
    }
};