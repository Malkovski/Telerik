var UsersController = require('./UsersController');
var StatisticsController = require('./StatisticsController');
var FilesController = require('./FilesController');

module.exports = {
    users: UsersController,
    stats: StatisticsController,
    files: FilesController
};