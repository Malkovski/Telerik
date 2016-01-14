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
    getAllByFilter: function (option) {
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
    getAll: function (page, pageSize, orderType, isActive, initiatives, seasons, callback) {
        page = page || 1;
        pageSize = pageSize || 3;
        orderType = orderType || 'desc';
        var dateCompare =  isActive ?  { 'date': { '$gte': new Date(currentDate) } } : { 'date': { '$lt': new Date(currentDate) } };

        var groupName = 'past';
        if (isActive) {
            groupName = 'active';
        }

        Event
            .find({
                $and: [
                    dateCompare
                    //{ 'type.initiative': { $in: initiatives } },
                    //{ 'type.season': { $in: seasons } }
                ]
            })
            .sort({
                date: 'desc'
            })
            .limit(parseInt(pageSize))
            .skip((page - 1) * pageSize)
            .exec(function(err, foundEvents) {
                if (err) {
                    callback(err);
                    return;
                }

                Event.count().exec(function(err, numberOfEvents) {
                    var data = {
                        groupName: groupName,
                        eventsList: foundEvents,
                        currentPage: page,
                        pageSize: pageSize,
                        total: numberOfEvents
                    };

                    callback(err, data);
                });
            });
    },
    active: function(page, pageSize, orderType, isActive, initiatives, seasons, callback) {
        page = page || 1;
        pageSize = pageSize || 3;
        orderType = orderType || 'desc';

        Event
            .find({
                $and: [
                      { 'date': { '$gte': new Date(currentDate) } }
                    //{ 'type.initiative': { $in: initiatives } },
                    //{ 'type.season': { $in: seasons } }
                ]
            })
            .sort({
                date: 'desc'
            })
            .limit(parseInt(pageSize))
            .skip((page - 1) * pageSize)
            .exec(function(err, foundEvents) {
                if (err) {
                    callback(err);
                    return;
                }

                Event.count().exec(function(err, numberOfEvents) {
                    var data = {
                        groupName: 'active',
                        eventsList: foundEvents,
                        currentPage: page,
                        pageSize: pageSize,
                        total: numberOfEvents
                    };

                    callback(err, data);
                });
            })
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