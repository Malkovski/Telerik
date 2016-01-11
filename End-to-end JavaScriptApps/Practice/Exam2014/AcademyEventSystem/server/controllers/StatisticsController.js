"use strict";

var users = require('../data/users'),
    eventsService = require('../data/events'),
    utils = require('../utilities/utilities');


var usersCount = 0,
    eventsCount = 0,
    passedEvents = [];

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

        eventsService.count()
            .exec(function (err, count) {
            if (err) {
                req.session.error = err;
                return;
            }

            eventsCount = count || 0;
        });

        eventsService.getAll(1)
        .exec(function (err, eventList) {
            if (err) {
                req.session.error = err;
                return;
            }

            passedEvents = utils.queryToArray(eventList);
        });

        res.render('index', { usersCount: usersCount, eventsCount: eventsCount, eventsList: passedEvents });
    }
};