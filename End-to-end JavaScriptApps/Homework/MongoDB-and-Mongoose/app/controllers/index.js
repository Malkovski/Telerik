var usersController = require('../controllers/UsersController'),
    messagesController = require('../controllers/MessagesController');

module.exports = {
    users: usersController,
    messages : messagesController
};