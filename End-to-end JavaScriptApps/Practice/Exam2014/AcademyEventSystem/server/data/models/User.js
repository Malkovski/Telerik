"use strict";

var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption'),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId,
    User;

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

                salt = encryption.generateSalt();
                hashedPwd = encryption.generateHashedPassword(salt, '123456');
                User.create({
                    username: 'pesho',
                    firstName: 'Pesho',
                    lastName: 'Peshov',
                    email: 'pesho@abv.bg',
                    initiative: 'Software Academy',
                    season: ['Started 2010', 'Started 2011', 'Started 2012', 'Started 2013'],
                    salt: salt,
                    hashPass: hashedPwd
                });

                salt = encryption.generateSalt();
                hashedPwd = encryption.generateHashedPassword(salt, '123456');
                User.create({
                    username: 'gosho',
                    firstName: 'Gosho',
                    lastName: 'Goshov',
                    email: 'gosho@abv.bg',
                    initiative: 'Software Academy',
                    season: 'Started 2010',
                    salt: salt,
                    hashPass: hashedPwd
                });

                console.log("Starting users created");
            }
        });
};

module.exports.init = function() {
    var userSchema = new Schema({
        id: ObjectId,
        username: { type: String, required: true, unique: true },
        hashPass: String,
        salt: String,
        points: Number,
        firstName: { type: String, required: true },
        lastName: { type: String, required: true },
        phone: { type: String },
        email: { type: String, required: true, unique: true },
        picture: String,
        initiatives: [{ type: String, required: true }] ,
        seasons: [{ type: String, required: true }]
    });

    userSchema.method({
        authenticate: function(password) {
            return (encryption.generateHashedPassword(this.salt, password) === this.hashPass);
        }
    });

    userSchema.path('username').validate(function (v) {
        return v.length >= 3 && v.length < 25;
    });

    User = mongoose.model('User', userSchema);
    //seedInitialUsers();
};