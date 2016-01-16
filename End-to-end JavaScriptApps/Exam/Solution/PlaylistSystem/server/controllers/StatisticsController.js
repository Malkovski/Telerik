"use strict";

var users = require('../data/users'),
    playlistsService = require('../data/playlists'),
    utils = require('../utilities/utilities'),
    Cache = require('node-cache');

var statCache = new Cache({ stdTTL: 100, checkperiod: 120 });
var usersCount = 0,
    playlistCount = 0,
    passedEvents = [];

module.exports = {
    getStatistics: function (req, res, next) {

        statCache.get('usersCount', function (err, result) {
            if (!err) {
                if (result == undefined) {
                    users.count()
                        .exec(function (err, count) {
                            if (err) {
                                req.session.error = err;
                                return;
                            }

                            statCache.set( "usersCount", count, function( err, success ){
                                if( !err && success ){
                                    //console.log( 'users:' );
                                    //console.log( success );
                                }
                            });
                        });
                }
                else {
                    usersCount = result;
                }
            }
        });

        statCache.get('eventsCount', function (err, result) {
            if (!err) {
                if (result == undefined) {
                    playlistsService.count()
                        .exec(function (err, count) {
                            if (err) {
                                req.session.error = err;
                                return;
                            }

                            statCache.set( "eventsCount", count, function( err, success ){
                                if( !err && success ){
                                    //console.log( 'events:' );
                                    //console.log( success );
                                }
                            });
                        });
                }
                else {
                    playlistCount = result;
                }
            }
        });

        statCache.get('passedEvents', function (err, result) {
            if (!err) {
                if (result == undefined) {
                    playlistsService.getAll(1, 8, undefined, false, function (err, data) {
                        if (err) {
                            req.session.error = err;
                            return;
                        }

                        passedEvents = utils.queryToArray(data.eventsList);

                        statCache.set( "passedEvents", passedEvents, function( err, success ){
                            if( !err && success ){
                            }
                        });
                    });
                }
                else {
                    passedEvents =  result;
                }
            }
        });

        res.render('statistics', { usersCount: usersCount, playlistCount: playlistCount, playlists: passedEvents });
    }
};