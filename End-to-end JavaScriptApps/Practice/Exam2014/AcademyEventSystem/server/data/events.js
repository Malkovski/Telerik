"use strict";

var Event = require('mongoose').model('Event'),
    utils = require('../utilities/utilities');

module.exports = {
    create: function (event, callback) {
         Event.create(event, callback);
    },
    getAll: function (option) {
        var currentDate = utils.getDate();

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
    count: function () {
        return Event.count({});
    }
};