var encryption = require('../utilities/encryption'),
    users = require('../data/users'),
    utils = require('../utilities/utilities'),
    uploading = require('../utilities/uploading');

var CONTROLLER_NAME = 'users';
var searchedUser = {};

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
                    if (err.message == 'User validation failed') {
                        req.session.error = 'Register failed! Username or password too short!';
                    }
                    else{
                        req.session.error = 'Register failed';
                    }

                    res.redirect('/register');
                    console.log('Failed to register new user: ' + err);
                    return;
                }

                //creating dir for the current user
                uploading.createDir('/', user.username);


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
        var options = req.body;

        var template = options.contains;
        var sortBy = '_id';
        if (options.orderBy === 'Name') {
            sortBy = 'username';
        }

        var sortType = '';
        if (options.orderType === 'Descending') {
            sortType = '-';
        }

        var query = users.getAll();
        query.where({ username: new RegExp(template, "i") })
            .sort(sortType + sortBy)
            .exec(function (err, results) {
            if (err) {
                req.session.error = err;
                return;
            }

            var usersList = utils.queryToArray(results);

            res.render(CONTROLLER_NAME + '/list-users', { usersList: usersList })
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

            searchedUser = result;
            res.redirect('/details');
        });
    },
    getUserDetails: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/detailed-user', { current: searchedUser });
    },
    getEditProfile: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/edit-user', { current: searchedUser })
    },
    updateProfile: function (req, res, next) {
        var newData = req.body;

        for (var i in newData) {
            if (newData[i] === null || newData[i] === undefined || newData[i] === '') {
                delete newData[i];
            }
        }

        users.update({ _id: req.user._id }, newData, function (err, result) {
            if (err) {
                throw err;
            }
            else {
                console.log('User populated successfully! - ' + result);
                res.redirect('/edit-user');
            }
        });
    }
};