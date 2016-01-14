var eventsService = require('../data/events'),
    usersService = require('../data/users'),
    processor = require('../data/processors/processors'),
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
        var page = req.query.page;
        var pageSize = req.query.pageSize;

        eventsService.getAll(page, pageSize, 'asc', false, [], [], function (err, data) {
            res.render(CONTROLLER_NAME + '/past-events', {
                data: data
            });
        });
        //var query = eventsService.getAll(-1);
        //processor.processQuery(req, query)
        //    .exec(function (err, results) {
        //        if (err) {
        //            req.session.error = 'Bad request';
        //            res.redirect('/');
        //        }
        //
        //        //var eventsList = utils.queryToArray(results);
        //
        //        res.render(CONTROLLER_NAME + '/past-events', { eventsList: results, current: req.user, groupName: 'past' });
        //    });
    },
    getActive: function (req, res, next) {
        var page = req.query.page;
        var pageSize = req.query.pageSize;

        eventsService.active(page, pageSize, 'asc', true,  [], [], function (err, data) {
            res.render(CONTROLLER_NAME + '/list-events', {
                data: data
            });
        });
    },
    filterActive: function (req, res, next) {
        var query = eventsService.getAllByFilter(1);
        processor.processQuery(req, query)
            .exec(function (err, results) {
                if (err) {
                    req.session.error = 'Bad request';
                    res.redirect('/');
                }

                var eventsList = utils.queryToArray(results);

                //TODO fix calculations !!!

                var data = {
                    groupName: 'active',
                    eventsList: eventsList,
                    currentPage: 1,
                    pageSize: eventsList.length / 2,
                    total: eventsList.length
                };

                res.render(CONTROLLER_NAME + '/list-events', {
                    data: data
                });
            });
    },
    filterOwnedEvents: function (req, res, next) {
        var params = processor.processRequestBody(req);

        if (params.filter === 'past') {
            proceedRequest(eventsService.getOwned(params.ownerName, true));
        }
        else if (params.filter === 'joined') {
            proceedRequest(eventsService.getJoined(params.ownerId));
        }
        else {
            proceedRequest(eventsService.getOwned(params.ownerName));
        }

        function proceedRequest(query) {
            processor.processQuery(req, query)
                .exec(function (err, results) {
                    if (err) {
                        req.session.error = err;
                        return;
                    }

                    var eventsList = utils.queryToArray(results);

                    res.render(CONTROLLER_NAME + '/my-events', { eventsList: eventsList, current: req.user })
                });
        }
    },
    getById: function (req, res, next) {
        var id = req.params.id;
        eventsService.getById(id, function (err, result) {
            if (err) {
                req.session.error = 'Event not found!';
                return;
            }

            var prevUrl = req.get('referer').toString();
            var url = prevUrl.split('/');
            var index = url.length - 1;

            res.render(CONTROLLER_NAME + '/event-details', { current: result, prev: url[index] })
        })
    },
    getVote: function (req, res, next) {
        var id = req.params.id;
        eventsService.getById(id, function (err, result) {
            if (err) {
                req.session.error = 'Event not found!';
                return;
            }

            var prevUrl = req.get('referer').toString();
            var url = prevUrl.split('/');
            var index = url.length - 1;

            res.render(CONTROLLER_NAME + '/event-voting', { current: result, prev: url[3] })
        })
    },
    vote: function (req, res, next) {
        var id = req.params.id;
        var newData = req.body;

        eventsService.getById(id, function (err, result) {
            if (err) {
                req.session.error = 'Event not found !';
                return;
            }

            console.log(result);
            var organization = parseInt(result.organizationPoints);
            var venue = parseInt(result.venuePoints);

            result.venuePoints = venue + parseInt(newData.venuePoints);
            result.organizationPoints =  organization + parseInt(newData.organizationPoints);

            eventsService.update({ _id: id }, result, function (err, votedFor) {
                if (err) {
                    req.session.error = 'Vote failed!';
                }
                else {
                    usersService.byName(result.creatorName, function (err, eventOwner) {
                        if (err) {
                            req.session.error = 'Owner not found !';
                            return;
                        }

                        var points = parseInt(eventOwner.points);
                        console.log(points);
                        eventOwner.points = points + ((parseInt(result.organizationPoints) + parseInt(result.venuePoints)) /2);
                        console.log(eventOwner.points);

                        for (var i in eventOwner) {
                            if (eventOwner[i] === null || eventOwner[i] === undefined || eventOwner[i] === '') {
                                delete eventOwner[i];
                            }
                        }

                        console.log(eventOwner);
                        usersService.update({ _id: eventOwner._id }, eventOwner, function (err, result) {
                            if (err) {
                                req.session.error = 'Points not added!';

                            }
                            else {

                                console.log('Updating user points successful!');
                               // req['referer'] = 'xx/xx/xxx/past-events';
                                res.redirect('/event/' + id);
                            }
                        })
                    });
                }
            });
        });
    },
    join: function (req, res, next) {
        var id = req.params.id ;
        var newMemberId = req.user._id;
         eventsService.updateById({ _id: id }, { $push: {users: newMemberId } }, function (err, result) {
             if (err) {
                 req.session.error = 'Failed to add member!';
             }

             console.log('yeeee');
             res.redirect('/');
         })
    },
    delete: function (req, res, next) {
        var id = req.params.id;
        eventsService.delete(id, function (err, result) {
            if (err) {
                req.session.error = 'Deletion failed!';
                return;
            }

            res.redirect('/details')
        })
    }
};































