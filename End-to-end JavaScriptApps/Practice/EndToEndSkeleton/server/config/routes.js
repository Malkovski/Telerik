var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/list-users', auth.isAuthenticated, controllers.users.getAll);
    app.post('/filter-users', auth.isAuthenticated, controllers.users.getAll);
    app.get('/profile/:id?', auth.isAuthenticated, controllers.users.getById);
    app.get('/profile', auth.isAuthenticated, controllers.users.getById);

    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);

    app.get('/', controllers.stats.getUsersCount);

    app.get('*', controllers.stats.getUsersCount);
};