"use strict";

var Playlist = require('mongoose').model('Playlist');


module.exports = {
    create: function (event, callback) {
        Playlist.create(event, callback);
    },
    count: function () {
        return Playlist.count({});
    },
    getAll: function (page, pageSize, user, isPrivate, callback) {
        page = page || 1;
        pageSize = pageSize || 10;

        var groupName = 'public';
        if (isPrivate) {
            groupName = 'private';
        }

        if (user) {
            var userRights = user._id;
            Playlist.find({
                    $and: [
                        { users: userRights },
                        { private: isPrivate}
                    ]
                })
                .sort({
                    date: 'desc'
                })
                .limit(parseInt(pageSize))
                .skip((page - 1) * pageSize)
                .exec(function(err, foundEvents) {
                    if (err) {
                        callback(err);
                        return;
                    }

                    Playlist.count().exec(function(err, numberOfEvents) {
                        var data = {
                            groupName: groupName,
                            eventsList: foundEvents,
                            currentPage: page,
                            pageSize: pageSize,
                            total: numberOfEvents
                        };

                        callback(err, data);
                    });
                });
        }
        else {
            Playlist.find({ private: isPrivate})
                .sort({
                    date: 'desc'
                })
                .limit(parseInt(pageSize))
                .skip((page - 1) * pageSize)
                .exec(function(err, foundEvents) {
                    if (err) {
                        callback(err);
                        return;
                    }

                    Playlist.count().exec(function(err, numberOfEvents) {
                        var data = {
                            groupName: groupName,
                            eventsList: foundEvents,
                            currentPage: page,
                            pageSize: pageSize,
                            total: numberOfEvents
                        };

                        callback(err, data);
                    });
                });
        }

    },
    getAllByFilter: function (option, user) {
        if (user) {
            var userRights = user._id;
            console.log(userRights);

            if (option < 0) {
                return Playlist.find({})
            }
            else if (option > 0) {
                return Playlist.find({
                    $and: [
                        { users: userRights },
                        { private: true}
                    ]
                })
            }
            else {
                return Playlist.find({});
            }
        }
        else {
            if (option < 0) {
                return Playlist.find({})
            }
            else if (option > 0) {

                return Playlist.find({private: true});
            }
            else {
                return Playlist.find({});
            }
        }
    },
    getById: function (id, callback) {
        return Playlist.findOne({ _id: id }, callback);
    },
    update: function (id, newData, callback) {
        Playlist.findByIdAndUpdate(id, newData, callback);
    },
    delete: function (id, callback) {
        Playlist.findByIdAndRemove(id, callback);
    }
};