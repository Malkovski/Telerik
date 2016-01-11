"use strict";

var mongoose = require('mongoose'),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId,
    Comment;

module.exports.init = function() {
    var commentSchema = new Schema({
        id: ObjectId,
        content: { type: String },
        owner: { type: mongoose.Schema.ObjectId, ref: 'User' }
    });

    Comment = mongoose.model('Comment', commentSchema);
};