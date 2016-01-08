var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback) {
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

        console.log(sortType + sortBy);

        return User.find({})
            .where({ username: new RegExp(template, "i") })
            .sort(sortType + sortBy);
    },
    byId: function (id) {
        return User.findOne({_id: id});
    },
    count: function () {
        return User.count({});
    }
};