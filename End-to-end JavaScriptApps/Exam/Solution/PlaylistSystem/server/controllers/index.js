var UsersController = require('./UsersController'),
    StatisticsController = require('./StatisticsController'),
    PlaylistController = require('./PlaylistController');

module.exports = {
    users: UsersController,
    stats: StatisticsController,
    playlists: PlaylistController
};