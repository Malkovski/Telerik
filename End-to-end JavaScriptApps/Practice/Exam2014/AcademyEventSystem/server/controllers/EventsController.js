var eventsService = require('../data/events'),
    utils = require('../utilities/utilities');

var CONTROLLER_NAME = 'events';

module.exports = {
    getCreate: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/event-create-form')
    },
    create: function (req, res, next) {
        var user = req.user;
        var newEventData = req.body;

        if (!user.phone) {
            res.status(400);
            req.session.error = 'User must provide phone number in order to crate events!';
            res.redirect('/create-event');
        }
        else {
            if ((user.initiatives.indexOf(newEventData.initiative) < 0) || (user.seasons.indexOf(newEventData.season) < 0)) {
                req.session.error = 'No rights to create this type of event';
                res.redirect('/create-event');
            }
            else {
                newEventData.creatorName = user.username;
                newEventData.creatorPhone = user.phone;
                newEventData.users = [];
                newEventData.users.push(user._id);


                eventsService.create(newEventData, function (err, event) {
                    if (err) {
                        req.session.err = 'Event creation failed see why...!!!'
                    }

                    console.log('event is created!');
                    res.redirect('/'); //todo ......
                })
            }

        }
    },
    getPast: function (req, res, next) {
        eventsService.getAll(-1)
            .exec(function (err, results) {
                if (err) {
                    req.session.error = 'Bad request';
                    res.redirect('/');
                }

                var eventsList = utils.queryToArray(results);

                res.render(CONTROLLER_NAME + '/list-events', { eventsList: eventsList, current: req.user, groupName: 'PAST' });
            })
    },
    getActive: function (req, res, next) {
        eventsService.getAll(1)
            .exec(function (err, results) {
                if (err) {
                    req.session.error = 'Bad request';
                    res.redirect('/');
                }

                var eventsList = utils.queryToArray(results);

                res.render(CONTROLLER_NAME + '/list-events', { eventsList: eventsList, current: req.user, groupName: 'ACTIVE' });
            })
    },
    getOwnedEvents: function (req, res, next) {
        var ownerName = req.user.username;
        var ownerId = req.user._id;
        var options = req.body;
        var filter = options.filterBy;

        var take = options.pageSize || 10;
        take = take * 1;
        if (take < 0) {
            take = 10;
        }

        var skip = ((options.page * take) - take) || 0;
        if (skip < 0) {
            skip = 0;
        }

        var template = options.contains;

        var sortBy = options.sortBy;
        var sortType = '';
        if (options.orderType === 'desc') {
            sortType = '-';
        }

        function proceedRequest(data) {
            data.or([{ title: new RegExp(template, "i") }, { description: new RegExp(template, "i") } ])
            .sort(sortType + sortBy)
            .skip(skip)
            .limit(take)
            .exec(function (err, results) {
                if (err) {
                    req.session.error = err;
                    return;
                }

                var eventsList = utils.queryToArray(results);

                res.render(CONTROLLER_NAME + '/owned-events-list', { eventsList: eventsList, current: req.user })
            });
        }

        if (filter === 'created') {
            proceedRequest(eventsService.getOwned(ownerName));
        }
        else if (filter === 'joined') {
            proceedRequest(eventsService.getJoined(ownerId));
        }
        else if (filter === 'passed') {
            proceedRequest(eventsService.getOwned(ownerName, true));

        }
    },
    delete: function (req, res, next) {
        var id = req.params.id;
        console.log(id);
        eventsService.delete(id, function (err, result) {
            if (err) {
                req.session.error = 'Deletion failed!';
                return;
            }

            res.redirect('/details')
        })
    }
};































