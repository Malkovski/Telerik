var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/profile/:id', auth.isAuthenticated, controllers.users.getById);
    app.get('/profile', auth.isAuthenticated, controllers.users.getById);
    app.get('/details', auth.isAuthenticated, controllers.users.getUserDetails);
    app.post('/details', auth.isAuthenticated, controllers.users.updateProfile);

    app.get('/edit-user', auth.isAuthenticated, controllers.users.getEditProfile);
    app.post('/edit-user', auth.isAuthenticated, controllers.users.getEditProfile);
    app.post('/filter-users', auth.isAuthenticated, controllers.users.getAll);
    app.get('/list-users', auth.isAuthenticated, controllers.users.getAll);


    app.get('/create-playlist', auth.isAuthenticated, controllers.playlists.getCreate);
    app.post('/create-playlist', auth.isAuthenticated, controllers.playlists.postCreate);

    app.get('/public-playlists',  controllers.playlists.getPublic);
    app.get('/my-public-playlists', auth.isAuthenticated,  controllers.playlists.getMyPublic);
    app.post('/public-playlists', auth.isAuthenticated,  controllers.playlists.filterPublic);
    app.get('/private-playlists', auth.isAuthenticated, controllers.playlists.getPrivate);
    app.post('/private-playlists', auth.isAuthenticated, controllers.playlists.filterPrivate);

    app.get('/playlist/:id/videos/add', auth.isAuthenticated, controllers.playlists.getAddVideo);

    app.get('/playlists/:id/add-fan', auth.isAuthenticated, controllers.playlists.getFanView);
    app.post('/playlists/add-fan', auth.isAuthenticated, controllers.playlists.addNewFan);
    app.post('/playlists/rate/:id', auth.isAuthenticated, controllers.playlists.ratePlaylist);

    app.get('/playlist/:id/videos', auth.isAuthenticated, controllers.playlists.getCurrentVideos);
    app.get('/delete-video/:id/:link', auth.isAuthenticated, controllers.playlists.deleteVideo);

    app.post('/playlist/:id', auth.isAuthenticated, controllers.playlists.addVideo);
    app.post('/playlist/:id/comment', auth.isAuthenticated, controllers.playlists.addComments);

    app.get('/playlist/:id', auth.isAuthenticated, controllers.playlists.getDetails);
    app.get('/playlist/delete/:id', auth.isAuthenticated, controllers.playlists.deletePlaylist);

    app.get('/', controllers.stats.getStatistics);
    app.get('*', controllers.stats.getStatistics);
};