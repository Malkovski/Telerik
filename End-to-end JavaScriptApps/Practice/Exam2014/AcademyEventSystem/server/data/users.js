"use strict";

var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback) {
        User.create(user, callback);
    },
    getAll: function () {
        return User.find({})
    },
    byId: function (id) {
        return User.findOne({_id: id});
    },
    byName: function (name, callback) {
        return User.findOne({ username: name}, callback);
    },
    count: function () {
        return User.count({});
    },
    update: function (id, newData, callback) {
        User.update(id, newData, callback);
    },
    delete: function (id, callback) {
        User.remove(id, callback);
    }
};