var passport = require('passport');

module.exports = {
    login: function(req, res, next) {
        var auth = passport.authenticate('local', function(err, user) {
            if (err) return next(err);
            if (!user) {
                req.session.error = 'Invalid username and/or password!';
                res.redirect('/login');
            }

            req.logIn(user, function(err) {
                if (err) return next(err);
                res.redirect('/');
            })
        });

        auth(req, res, next);
    },
    logout: function(req, res, next) {
        req.logout();
        //req.locals.currentUser = undefined;
        res.redirect('/');
    },
    isAuthenticated: function(req, res, next) {
        if (!req.isAuthenticated()) {
            res.render('../views/shared/unauthorized');
        }
        else {
            next();
        }
    }
};