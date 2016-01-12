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

    app.get('/active-events', auth.isAuthenticated, controllers.events.getActive);
    app.get('/past-events', auth.isAuthenticated, controllers.events.getPast);

    app.get('/create-event', auth.isAuthenticated, controllers.events.getCreate);
    app.post('/create-event', auth.isAuthenticated, controllers.events.create);
    app.get('/delete-event/:id', auth.isAuthenticated, controllers.events.delete);

    app.post('/filter-events', auth.isAuthenticated, controllers.events.getOwnedEvents);

    app.get('/', controllers.stats.getStatistics);
    app.get('*', controllers.stats.getStatistics);
};