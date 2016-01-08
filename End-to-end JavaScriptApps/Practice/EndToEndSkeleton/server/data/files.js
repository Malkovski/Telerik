var File = require('mongoose').model('File');

module.exports = {
    addFiles: function (files) {
        for (var file in files) {
            File.create(files[file]);
        }
    },
    getAll: function (options) {
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

        return File.find(condition)
            .where({ fileName: new RegExp(template, "i") })
            .sort(sortType + sortBy)
            .skip(skip)
            .limit(take);
    },
    count: function () {
        return File.count({});
    }
};