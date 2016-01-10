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

    app.post('/filter-users', auth.isAuthenticated, controllers.users.getAll);
    app.get('/list-users', auth.isAuthenticated, controllers.users.getAll);

    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);
    app.get('/remove/:id', auth.isAuthenticated, controllers.files.deleteFile);
    app.get('/uploaded-files', auth.isAuthenticated, controllers.files.getResults);

    app.get('/downloads', auth.isAuthenticated, controllers.files.getAll);
    app.post('/filter-files', auth.isAuthenticated, controllers.files.getAll);
    app.get('/files/download/:id', auth.isAuthenticated, controllers.files.downloadFile);

    app.get('/', controllers.stats.getStatistics);
    app.get('*', controllers.stats.getStatistics);
};