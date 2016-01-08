var Message = require('mongoose').model('Message'),
    User = require('mongoose').model('User');

module.exports = {
    sendMessage: function (message) {
        var from;
        var to;

        User.findOne({userName: message.from})
            .exec(function (err, result) {
                if (err) {
                    return err.status(404).send('User not found' + err);
                }
                from = result;
            });

        User.findOne({userName: message.to})
            .exec(function (err, result) {
                if (err) {
                    return err.status(404).send('User not found' + err);
                }
                to = result;
            });

        Message.create({
            from: from,
            to: to,
            text: message.text
        })
    },
    getMessage: function (users, callback) {
        var from;
        var to;

        User.findOne({userName: users.with})
            .exec(function (err, result) {
                if (err) {
                    return err.status(404).send('User 1 not found' + err);
                }
                from = result;
            });

        User.findOne({userName: users.and})
            .exec(function (err, result) {
                if (err) {
                    return err.status(404).send('User 2 not found' + err);
                }
                to = result;
            });

        Message.find({from: from, to: to})
            .exec(function (err, result) {
                if (err) {
                    return err.status(404).send('No messages between the two users' + err);
                }

                callback(result);
            })
    }
};