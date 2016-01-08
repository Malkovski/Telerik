var controllers = require('./controllers');

module.exports = {
    registerUser: function (user) {
        controllers.users.registerUser(user);
    },
    sendMessage: function (message) {
        controllers.messages.sendMessage(message);
    },
    getMessage: function (users, callback) {
        controllers.messages.getMessage(users, callback);
    }
};
