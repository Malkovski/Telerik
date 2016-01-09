var File = require('mongoose').model('File');
var User = require('mongoose').model('User');
var userService = require('./users');

module.exports = {
    addFiles: function (files, userId) {

        for (var file in files) {
            var current = files[file];
            current.owner = userId;

            File.create(current, function (err, createdFile) {
                if (err) {
                    throw err;
                }
                else {
                    var condition = { _id: userId };
                    var option = { $push: { filesOwned: createdFile._id } };
                    userService.update(condition, option);
                }
            });
        }
    },
    byId: function (id) {
        return File.findOne({_id: id});
    },
    getAll: function (options, currentUser) {
        var take = options.pageSize || 15;
        take = take * 1;
        if (take < 0) {
            take = 10;
        }

        var skip = ((options.page * take) - take) || 0;
        if (skip < 0) {
            skip = 0;
        }

        var condition = { isPrivate: false };
        var isPrivate = options.isPrivate;
        if (isPrivate == 'on') {
            condition = {};
        }

        var template = options.contains;

        var sortBy = '_id';
        if (options.orderBy === 'filename') {
            sortBy = 'fileName';
        }
        else if (options.orderBy === 'url') {
            sortBy = 'url';
        }
        else if (options.orderBy === 'uploadingDate') {
            sortBy = 'uploadingDate';
        }

        var sortType = '';
        if (options.orderType === 'desc') {
            sortType = '-';
        }

        if (options.onlyMine == 'on') {
            return File.find({ owner: currentUser._id})
                .find(condition)
                .where({ fileName: new RegExp(template, "i") })
                .sort(sortType + sortBy)
                .skip(skip)
                .limit(take);
        }
        else {
            return File.find(condition)
                .where({ fileName: new RegExp(template, "i") })
                .sort(sortType + sortBy)
                .skip(skip)
                .limit(take);
        }
    },
    getUserFiles: function (id) {
         return File.find({ owner: id });
    },
    count: function () {
        return File.count({});
    },
    delete: function (id) {
        File.findByIdAndRemove(id, function (err, file) {
            if (err) {
                throw err;
            }

            var param = { filesOwned: file._id };
            var user = userService.findOne(param);

            user.exec(function (err, founded) {
                if (err) {
                    throw err;
                }
                else {
                    var condition = { _id: founded._id };
                    var option = { $pull: { filesOwned: id } };
                    userService.update(condition, option);
                }
            });

            return file;
        })
    }
};