var users = require('../data/users');

module.exports = {
    getUsersCount: function (req, res, next) {
        var query = users.count();
        query.exec(function (err, count) {
            if (err) {
                req.session.error = err;
                return;
            }

            res.render('index', {usersCount: count});
        })
    },
    getAll: function (req, res, next) {

    }
};