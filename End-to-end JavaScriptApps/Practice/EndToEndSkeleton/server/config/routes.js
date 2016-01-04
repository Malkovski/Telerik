var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.logout);

    app.get('/list-users', controllers.users.getAll);
    app.get('/profile/:id?', controllers.users.getById);
    app.get('/profile', controllers.users.getById);

    app.get('/upload', controllers.files.getUpload);

    app.get('/', controllers.stats.getUsersCount);

    app.get('*', controllers.stats.getUsersCount);
};