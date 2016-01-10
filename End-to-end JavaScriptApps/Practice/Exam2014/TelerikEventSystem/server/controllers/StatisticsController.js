"use strict";

var users = require('../data/users');

var usersCount = 0;

module.exports = {
    getStatistics: function (req, res, next) {

        var usersQuery = users.count();
        usersQuery.exec(function (err, count) {
            if (err) {
                req.session.error = err;
                return;
            }

            usersCount = count || 0;
        });

        res.render('index', { usersCount: usersCount });
    }
};