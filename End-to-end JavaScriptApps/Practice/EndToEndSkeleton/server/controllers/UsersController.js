var encryption = require('../utilities/encryption');
var users = require('../data/users');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/register')
    },
    postRegister: function(req, res, next) {
        var newUserData = req.body;

        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Passwords do not match!';
            res.redirect('/register');
        }
        else {
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
            users.create(newUserData, function(err, user) {
                if (err) {
                    req.session.error = 'Register failed';
                    res.redirect('/register');
                    console.log('Failed to register new user: ' + err);
                    return;
                }

                req.logIn(user, function(err) {
                    if (err) {
                        res.status(400);
                        req.session.error = {reason: err.toString()}; // TODO
                    }
                    else {
                        res.redirect('/');
                    }
                })
            });
        }
    },
    getLogin: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    getAll: function (req, res, next) {
        var query = users.getAll();
        query.exec(function (err, results) {
            if (err) {
                req.session.error = err;
                return;
            }

            var usersList = [];

            results.forEach(function (result) {
                usersList.push(result);
            });

            res.render(CONTROLLER_NAME + '/list-users', { usersList: usersList, currentUser: req.user })
        });
    },
    getById: function (req, res, next) {
        var id;
        if (req.params.id) {
            id = req.params.id;
        }
        else {
            id = req.user._id;
        }

        var query = users.byId(id);
        query.exec(function (err, result) {
            if (err) {
                req.session.error = err;
                return;
            }

            res.render(CONTROLLER_NAME + '/detailed-user', { current: result, currentUser: req.user })
        });
    }
};