"use strict";

var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback) {
        console.log(user);
        User.create(user, callback);
    },
    getAll: function (options) {
        var template = options.contains;
        var sortBy = '_id';
        if (options.orderBy === 'Name') {
            sortBy = 'username';
        }

        var sortType = '';
        if (options.orderType === 'Descending') {
            sortType = '-';
        }

        return User.find({})
            .where({ username: new RegExp(template, "i") })
            .sort(sortType + sortBy);
    },
    byId: function (id) {
        return User.findOne({_id: id});
    },
    count: function () {
        return User.count({});
    },
    update: function (condition, option) {
        User.update(condition, option, function (err, raw) {
            if (err) {
                throw err;
            }
            else {
                console.log('User populated successfully!');
            }
        })
    },
    findOne: function (param) {
        return User.findOne(param);
    }
};