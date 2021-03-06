"use strict";

var Event = require('mongoose').model('Event'),
    utils = require('../utilities/utilities');

var currentDate = utils.getDate();

module.exports = {
    create: function (event, callback) {
         Event.create(event, callback);
    },
    getById: function (id, callback) {
        return Event.findOne({ _id: id }, callback);
    },
    getAll: function (option) {

        if (option < 0) {
            return Event.find({ "date": { "$lt": new Date(currentDate) } });
        }
        else if (option > 0) {

            return Event.find({ 'date': { '$gte': new Date(currentDate) } });
        }
        else {
            return Event.find({});
        }
    },
    getOwned: function (ownerName, passed) {
        if (passed) {
            return Event.find({ creatorName: ownerName})
                .where({ "date": { "$lt": new Date(currentDate) } });
        }
        else {
            return Event.find({ creatorName: ownerName})
        }
    },
    getJoined: function (id) {
        return Event.find({ users: id });
    },
    count: function () {
        return Event.count({});
    },
    updateById: function (id, data, callback) {
        Event.findByIdAndUpdate(id, data, callback);
    },
    update: function (id, newData, callback) {
        Event.update(id, newData, callback);
    },
    delete: function (id, callback) {
        Event.findByIdAndRemove(id, callback);
    }
};