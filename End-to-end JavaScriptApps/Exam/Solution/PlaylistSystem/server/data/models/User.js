"use strict";

var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption'),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId,
    User;

module.exports.init = function() {
    var userSchema = new Schema({
        id: ObjectId,
        username: { type: String, match: /^[a-zA-Z0-9_.]*$/, required: true, unique: true },
        hashPass: String,
        salt: String,
        rating: { type: Number, default: 0 },
        firstName: { type: String, required: true },
        lastName: { type: String, required: true },
        email: { type: String, required: true, unique: true },
        picture: { type: String, default: 'img/Koala.jpg' }, //TODO!!!!!!
        youtube: { type: String },
        facebook: { type: String }
    });

    userSchema.method({
        authenticate: function(password) {
            return (encryption.generateHashedPassword(this.salt, password) === this.hashPass);
        }
    });

    userSchema.path('username').validate(function (v) {
        return v.length >= 6 && v.length < 20;
    });

    User = mongoose.model('User', userSchema);
    seedInitialUsers();
};

var seedInitialUsers = function () {
    User
        .find({})
        .exec(function (err, collection) {
            if (err) {
                console.log('Cannot find users: ' + err);
                return;
            }

            if (collection.length === 0) {
                var salt;
                var hashedPwd;

                for (var i = 0, leni = 3; i < leni; i += 1) {
                    salt = encryption.generateSalt();
                    hashedPwd = encryption.generateHashedPassword(salt, '123456');
                    User.create({
                        username: 'pesho' + (i * 2),
                        firstName: 'Pesho' + (i * 2),
                        lastName: 'Peshov' + (i * 2),
                        email: 'pesho@abv.bg' + (i * 2),
                        youtube: 'pesho@ab' + (i * 2),
                        facebook: 'pesho@abv' + (i * 2),
                        salt: salt,
                        hashPass: hashedPwd
                    });

                    salt = encryption.generateSalt();
                    hashedPwd = encryption.generateHashedPassword(salt, '123456');
                    User.create({
                        username: (i * 2) + 'gosho',
                        firstName:  (i * 2) + 'Gosho',
                        lastName:  (i * 2) + 'Goshov',
                        email:  (i * 2) + 'gosho@abv.bg',
                        youtube: 'gogata' + (i * 2),
                        facebook: 'gogata@abv' + (i * 2),
                        salt: salt,
                        hashPass: hashedPwd
                    });

                }

                console.log("Starting users created");
            }
        });
};