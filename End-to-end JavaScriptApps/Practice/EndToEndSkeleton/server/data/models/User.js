"use strict";

var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption'),
    Schema = mongoose.Schema,
    User;

module.exports.init = function() {
     var userSchema = new Schema({
        //_creator: { type: String, ref: 'File'},
        username: { type: String, required: true, unique: true },
        hashPass: String,
        salt: String,
        points: Number
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
};