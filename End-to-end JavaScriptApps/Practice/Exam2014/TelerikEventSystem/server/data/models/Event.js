"use strict";

var mongoose = require('mongoose'),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId,
    Event;

module.exports.init = function() {
    var eventSchema = new Schema({
        id: ObjectId,
        title: { type: String, required: true },
        description: { type: String, required: true },
        date: { type: Date, default: new Date() },
        longitude: { type: Number },
        latitude: { type: Number },
        category: { type: String, required: true },
        initiative: { type: String, required: true },
        season: { type: String, required: true },
        organization: { type: Number },
        venue: { type: Number},
        creatorName: { type: String, required: true },
        creatorPhone: { type: String, required: true },
        comments: [{ type: mongoose.Schema.ObjectId, ref: 'Comment' }],
        users: [{ type: mongoose.Schema.ObjectId, ref: 'User' } ]
    });

    Event = mongoose.model('Event', eventSchema);
};
