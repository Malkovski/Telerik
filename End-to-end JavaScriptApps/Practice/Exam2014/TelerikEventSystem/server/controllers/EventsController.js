var eventsService = require('../data/events'),
    usersService = require('../data/users');

var CONTROLLER_NAME = 'events';

module.exports = {
    getCreate: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/event-create-form')
    },
    create: function (req, res, next) {
        var userId = req.user._id;
        var newEventData = req.body;
        var creator = usersService.byId(userId)
            .exec(function (err, user) {
                if (err) {
                    res.status(400);
                    req.session.error = 'User not found!';
                    console.log(err.toString());
                    return;
                }

                if (!user.phone) {
                    res.status(400);
                    req.session.error = 'User must provide phone number in order to crate events!';
                    console.log(err.toString());
                    res.redirect('/'); //TODO
                }
                else {
                    //TODO validate pls!!!
                    if (user.initiatives.indexOf(newEventData.initiative) < 0) {

                    }
                    else if (user.initiatives.indexOf(newEventData.initiative) < 0) {

                    }
                    else {
                        newEventData.creatorName = user.username;
                        newEventData.creatorPhone = user.phone;

                        eventsService.create(newEventData, function (err, event) {
                            if (err) {
                                req.session.err = 'Event creation failed see why...!!!'
                            }

                           // newEventData.users.push(user._id);
                            console.log('event is created!');
                            res.redirect('/'); //todo ......
                        })
                    }

                }
            })
    }
};