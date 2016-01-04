var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback) {
        User.create(user, callback);
    },
    getAll: function () {
        return User.find({});
    },
    byId: function (id) {
        return User.findOne({_id: id});
    },
    count: function () {
        return User.count({});
    }
};