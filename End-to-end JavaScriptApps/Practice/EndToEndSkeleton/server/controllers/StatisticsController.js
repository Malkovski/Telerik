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

<<<<<<< HEAD
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
=======
            res.render('index', {usersCount: count});
        })
    },
    getAll: function (req, res, next) {

>>>>>>> 7a03fc90d89e696839a6c9ba32385d82ea13d3e1
    }
};