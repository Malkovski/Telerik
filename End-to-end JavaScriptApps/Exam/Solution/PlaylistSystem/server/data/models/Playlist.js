"use strict";

var mongoose = require('mongoose'),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId,
    Playlist;


module.exports.init = function() {
    var playlistSchema = new Schema({
        id: ObjectId,
        title: { type: String, required: true },
        description: { type: String, required: true },
        date: { type: Date, default: new Date()},
        category: { type: String, required: true },
        videos: [{ type: String }],
        rating: { type: Number, default: 0 },
        creatorName: { type: String, required: true },
        private: { type: Boolean, default: false },
        comments: [{ type: String, default: [] }],
        users: [{ type: mongoose.Schema.ObjectId, ref: 'User' } ]
    });

    Playlist = mongoose.model('Playlist', playlistSchema);
    seedInitialPlaylists();
};

var seedInitialPlaylists = function () {
    Playlist
        .find({})
        .exec(function (err, collection) {
            if (err) {
                console.log('Cannot find playlists: ' + err);
                return;
            }

            if (collection.length === 0) {
                for (var i = 0, leni = 6; i < leni; i += 1) {
                    Playlist.create({
                        title: 'muzika' + (i * 2),
                        deswcription: 'Peene' + (i * 2),
                        category: 'Cats' + (i * 2),
                        creatorName: 'pesho'
                    });

                    Playlist.create({
                        title: 'tanci' + (i * 2),
                        description: 'Dancing - boring stuff' + (i * 2),
                        category: 'Spiders' + (i * 2),
                        creatorName: 'gosho'
                    });

                }

                console.log("Initial playlist created");
            }
        });
};