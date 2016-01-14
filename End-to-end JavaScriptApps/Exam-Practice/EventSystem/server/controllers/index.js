var UsersController = require('./UsersController'),
    StatisticsController = require('./StatisticsController'),
    EventsController = require('./EventsController');

module.exports = {
    users: UsersController,
    stats: StatisticsController,
    events: EventsController
};