var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/list-users', auth.isAuthenticated, controllers.users.getAll);
<<<<<<< HEAD
    app.get('/profile/:id', auth.isAuthenticated, controllers.users.getById);
    app.get('/profile', auth.isAuthenticated, controllers.users.getById);
    app.get('/details', auth.isAuthenticated, controllers.users.getUserDetails);

    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);
    app.get('/uploaded-files', controllers.files.getResults);
=======
    app.post('/filter-users', auth.isAuthenticated, controllers.users.getAll);
    app.get('/profile/:id?', auth.isAuthenticated, controllers.users.getById);
    app.get('/profile', auth.isAuthenticated, controllers.users.getById);

    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
>>>>>>> 7a03fc90d89e696839a6c9ba32385d82ea13d3e1

    app.get('/downloads', auth.isAuthenticated, controllers.files.getAll)

    app.get('/files/download/:id', auth.isAuthenticated, controllers.files.downloadFile);

    app.get('/', controllers.stats.getStatistics);

    app.get('*', controllers.stats.getStatistics);
};