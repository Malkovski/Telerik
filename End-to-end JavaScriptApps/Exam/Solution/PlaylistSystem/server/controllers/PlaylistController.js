"use strict";

var Playlist = require('mongoose').model('Playlist'),
    playlistService = require('../data/playlists'),
    usersService = require('../data/users'),
    processor = require('../data/processors/processors'),
    utils = require('../utilities/utilities');

var CONTROLLER_NAME = 'playlists';
var categories = ['Cats', 'Dogs', 'Snakes', 'Spiders', 'Boring things'];
var usersList = [];
var currentPlaylist = {};

module.exports = {
    getCreate: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/create-playlist', {
            categories: categories
        });
    },
    postCreate: function (req, res, next) {
        console.log('here');
        var user = req.user;
        var newPlaylistData = req.body;
        newPlaylistData.creatorName = user.username;
        newPlaylistData.users = [];
        newPlaylistData.users.push(user._id);

        playlistService.create(newPlaylistData, function (err, playlist) {
            if (err) {
                req.session.err = 'Event creation failed!!!'
            }

            req.session.success = 'Playlist created successfully!';
            res.redirect('/'); //todo ......
        })
    },
    getPublic: function (req, res, next) {
        var page = req.query.page;
        var pageSize = req.query.pageSize;

        playlistService.getAll(page, pageSize, undefined, false, function (err, data) {
            res.render(CONTROLLER_NAME + '/public-playlist', {
                data: data
            });
        });
    },
    getMyPublic: function (req, res, next) {
        var page = req.query.page;
        var pageSize = req.query.pageSize;
        var user = req.user;

        playlistService.getAll(page, pageSize, user, false, function (err, data) {
            res.render(CONTROLLER_NAME + '/private-playlist', {
                data: data
            });
        });
    },
    getPrivate: function (req, res, next) {
        var page = req.query.page;
        var pageSize = req.query.pageSize;
        var user = req.user;

        playlistService.getAll(page, pageSize, user, true, function (err, data) {
            res.render(CONTROLLER_NAME + '/private-playlist', {
                data: data
            });
        });
    },
    filterPrivate: function (req, res, next) {
        var user = req.user;
        var query = playlistService.getAllByFilter(1, user);
        processor.processQuery(req, query)
            .exec(function (err, results) {
                if (err) {
                    req.session.error = 'Bad request';
                    res.redirect('/');
                }

                var eventsList = utils.queryToArray(results);

                //TODO fix calculations !!!

                var data = {
                    groupName: 'private',
                    eventsList: eventsList,
                    currentPage: 1,
                    pageSize: eventsList.length / 2,
                    total: eventsList.length
                };

                res.render(CONTROLLER_NAME + '/private-playlist', {
                    data: data
                });
            });
    },
    filterPublic: function (req, res, next) {
        var query = playlistService.getAllByFilter(-1);
        processor.processQuery(req, query)
            .exec(function (err, results) {
                if (err) {
                    req.session.error = 'Bad request';
                    res.redirect('/');
                }

                var eventsList = utils.queryToArray(results);

                //TODO fix calculations !!!

                var data = {
                    groupName: 'public',
                    eventsList: eventsList,
                    currentPage: 1,
                    pageSize: eventsList.length / 2,
                    total: eventsList.length
                };

                res.render(CONTROLLER_NAME + '/public-playlist', {
                    data: data
                });
            });
    },
    getDetails: function (req, res, next) {
        var id = req.params.id;
        playlistService.getById(id, function (err, result) {
            if (err) {
                req.session.error = 'Playlist not found!';
                return;
            }

            var prevUrl = req.get('referer').toString();
            var url = prevUrl.split('/');
            var index = url.length - 1;

            res.render(CONTROLLER_NAME + '/playlist-details', { current: result, prev: url[index] })
        })
    },
    getCurrentVideos: function (req, res, next) {
        var id = req.params.id;
        playlistService.getById(id, function (err, result) {
            if (err) {
                req.session.error = 'Playlist not found!';
                return;
            }

            var prevUrl = req.get('referer').toString();
            var url = prevUrl.split('/');
            var index = url.length - 1;

            res.render(CONTROLLER_NAME + '/playlist-videos', { current: result, prev: url[index] })
        });
    },
    getAddVideo: function (req, res, next) {
        var id = req.params.id;
        playlistService.getById(id, function (err, result) {
            if (err) {
                req.session.error = 'Playlist not found!';
                return;
            }

            var prevUrl = req.get('referer').toString();
            var url = prevUrl.split('/');
            var index = url.length - 1;

            res.render(CONTROLLER_NAME + '/edit-playlist', { current: result, prev: url[index] })
        });
    },
    addVideo: function (req, res, next) {
        var newData = req.body;
        var id = req.params.id;

        playlistService.update({ _id: id }, { $push: {videos: newData.link } }, function (err, result) {
            if (err) {
                req.session.error = 'Adding new video failed!';
                res.redirect('/private-playlists');
            }
            else {
                req.session.success = 'Edit successful!';
                console.log('Playlist populated successfully!');
                res.redirect('/private-playlists');
            }
        });
    },
    addComments: function (req, res, next) {
        var id = req.params.id;
        var newData = req.body;

        playlistService.update({ _id: id }, { $push: {comments: newData.comments } }, function (err, result) {
            if (err) {
                req.session.error = 'Adding new comment failed!';
                res.redirect('/private-playlists');
            }
            else {
                req.session.success = 'Comment saved successful!';
                console.log('Playlist populated successfully!');
                res.redirect('/private-playlists');
            }
        });
    },
    getFanView: function (req, res, next) {
        var id = req.params.id;

        playlistService.getById(id, function (err, playlist) {
            if (err) {
                req.session.error = 'Playlist not found';
                res.redirect('/private-playlists');
            }
            else {

                currentPlaylist = playlist;

                usersService.getAll().exec(function (err, results) {
                    if (err) {
                        req.session.error = err;
                        res.redirect('/'); //TODO !!!
                    }

                    usersList = utils.queryToArray(results);

                    res.render(CONTROLLER_NAME + '/users-to-add', { usersList: usersList, playlist: playlist })
                });
            }
        });
    },
    addNewFan: function (req, res, next) {
        var userId = req.body.userId;
        var playlistId = req.body.playlistId;
        var flag = true;

        playlistService.getById(playlistId, function (err, playlist) {
            if (err) {
                req.session.error = err;
                res.redirect('/'); //TODO !!!
            }

            for(var item in playlist.users) {
                if (playlist.users[item] == userId) {
                    flag = false;
                }
            }

            if (flag) {
                playlistService.update(playlistId, { $push: { users: userId } }, function (err, result) {
                    if (err) {
                        req.session.error = err;
                        res.redirect('/'); //TODO !!!
                    }

                    req.session.success = 'Fan added!';
                    console.log('User added to playlist successfully!');
                    res.render(CONTROLLER_NAME + '/users-to-add', { usersList: usersList, playlist: currentPlaylist });
                })
            }
            else {
                req.session.error = 'User is already a fan!';
                res.redirect('/');
            }
        });
    },
    ratePlaylist: function (req, res, next) {
        var id = req.params.id;
        var rating = req.body.rating;

        playlistService.getById(id, function (err, result) {
            if (err) {
                throw err;
            }

            var currentRating = parseInt(result.rating);
            result.rating = currentRating + parseInt(rating);

            playlistService.update({ _id: id }, result, function (err, votedFor) {
                if (err) {
                    req.session.error = 'Vote failed!';
                    res.redirect('/');
                }
                else {
                    usersService.byName(result.creatorName, function (err, eventOwner) {
                        if (err) {
                            req.session.error = 'Owner not found !';
                            return;
                        }

                        var points = parseInt(eventOwner.rating);
                        console.log(points);
                        eventOwner.rating = points + (parseInt(result.rating) /2);
                        console.log(eventOwner.rating);

                        for (var i in eventOwner) {
                            if (eventOwner[i] === null || eventOwner[i] === undefined || eventOwner[i] === '') {
                                delete eventOwner[i];
                            }
                        }

                        console.log(eventOwner);
                        usersService.update({ _id: eventOwner._id }, eventOwner, function (err, result) {
                            if (err) {
                                req.session.error = 'Points not added!';
                                res.redirect('/');
                            }
                            else {

                                req.session.success = 'Vote success!';
                                console.log('Updating user points successful!');

                                res.redirect('/');
                            }
                        })
                    });
                }
            });
        })
    },
    deletePlaylist: function (req, res, next) {
        var id = req.params.id;
        var user = req.user;

        playlistService.getById(id, function (err, playlist) {
            if (err) {
                req.session.error = err.toString();
                res.redirect('/edit-playlist');
            }
            else {
                var ownerId = playlist.users[0];
                console.log(ownerId);
                console.log(user._id);

                if (user._id.toString() !== ownerId.toString()) {
                    req.session.error = 'Not authorized to delete this!';
                    res.redirect('/edit-playlist');
                }
                else {
                    playlistService.delete(id, function (err, result) {
                        if (err) {
                            req.session.error = 'Deletion failed!';
                            res.redirect('/edit-playlist');
                        }

                        req.session.success = 'Deleted!';
                        console.log('Playlist deleted successfully!');
                        res.redirect('/edit-playlist');
                    })
                }
            }
        });
    },
    deleteVideo: function (req, res, next) {
        var id = req.params.id;
        var link = req.params.link;

        playlistService.update(id, { $pull: { videos: link }}, function (err, result) {
            if (err) {
                req.session.error = 'Deleting video failed!';
                res.redirect('/edit-playlist');
            }
            else {
                req.session.success = 'Video deleted!';
                console.log('Playlist populated successfully!');
                res.redirect('/private-playlists');
            }
        });
    }
};