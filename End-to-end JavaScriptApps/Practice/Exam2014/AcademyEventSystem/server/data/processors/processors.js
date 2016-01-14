"use strict";

var processQuery = function (req, query) {
    var params = this.processRequestBody(req);

    return query.or([{ title: new RegExp(params.template, "i") }, { description: new RegExp(params.template, "i") } ])
            .sort(params.sortType + params.sortBy)
            .skip(params.skip)
            .limit(params.take)
};

var processRequestBody = function (req) {
    var options = req.body;

    var ownerName = req.user.username;
    var ownerId = req.user._id;
    var filter = options.filterBy || '';

    var take = options.pageSize || 10;
    take = take * 1;
    if (take < 0) {
        take = 10;
    }

    var skip = ((options.page * take) - take) || 0;
    if (skip < 0) {
        skip = 0;
    }

    var template = options.contains || '';
    var sortBy = options.sortBy || '';

    var sortType = '';
    if (options.orderType === 'desc') {
        sortType = '-';
    }

    return {
        ownerName: ownerName,
        ownerId: ownerId,
        filter: filter,
        take: take,
        skip: skip,
        template: template,
        sortType: sortType,
        sortBy: sortBy
    }
};


module.exports = {
    processRequestBody: processRequestBody,
    processQuery: processQuery
};