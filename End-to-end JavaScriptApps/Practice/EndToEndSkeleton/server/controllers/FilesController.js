var encryption = require('../utilities/encryption'),
    uploading = require('../utilities/uploading'),
    utils = require('../utilities/utilities'),
    files = require('../data/files');

var CONTROLLER_NAME = 'files';
var URL_PASSWORD = 'greeting eartrhlings...';

var uploadedFiles = [];

module.exports = {
    getUpload: function (req, res, next) {
<<<<<<< HEAD
        res.render(CONTROLLER_NAME + '/uploadForm', {currentUser: req.user});
    },
    postUpload: function (req, res, next) {
        req.pipe(req.busboy);
        var username = req.user.username;

        req.busboy.on('file', function (fieldname, file, filename) {
            var currentDate = utils.getDate();
            var currentSalt = encryption.generateSalt();

            var filenameHashed = encryption.generateHashedPassword(currentSalt, filename);
            var path = '/' + username + '/' + currentDate + '/';
            var url = path + filenameHashed;
            var urlEncrypted = encryption.encrypt(url, URL_PASSWORD);

            uploading.saveFile(file, path, filenameHashed);

            uploadedFiles[username] = uploadedFiles[username] || [];

            uploadedFiles[username][fieldname] = uploadedFiles[username][fieldname] || {};
            var dbFile = uploadedFiles[username][fieldname];
            dbFile.url = urlEncrypted;
            dbFile.fileName = filename;
        });

        req.busboy.on('field', function(fieldname, val) {
            var index = fieldname.split('_')[1];
            uploadedFiles[username] = uploadedFiles[username] || [];
            uploadedFiles[username]['file_' + index] = uploadedFiles[username]['file_' + index] || {};
            var dbFile = uploadedFiles[username]['file_' + index];
            dbFile.isPrivate = !!val;
        });

        req.busboy.on('finish', function() {
            files.addFiles(uploadedFiles[username]);
            res.redirect('/uploaded-files');
        });
    },
    getResults: function (req, res, next) {
        var host = req.get('host');
        var results = uploadedFiles[req.user.username];

        var  filesList = utils.queryToArray(results);

        uploadedFiles[req.user.username] = undefined;

        res.render(CONTROLLER_NAME + '/uploaded-list', { files: filesList, host: host, currentUser: req.user });
    },
    downloadFile: function (req, res, next) {
        var url = req.params.id;
        var decryptedUrl = encryption.decrypt(url, URL_PASSWORD);

        res.download(__dirname + '/../../files' + decryptedUrl);
    },
    getAll: function (req, res, next) {
        var host = req.get('host');
        var filesQuery = files.getAll()
            .limit(10)
            .sort('-uploadingDate')
            .exec(function (err, results) {
            if (err) {
                req.session.error = err;
                return;
            }

            var  filesList = utils.queryToArray(results);

            res.render(CONTROLLER_NAME + '/uploaded-list', { files: filesList, host: host, currentUser: req.user })
        })
=======
        res.render(CONTROLLER_NAME + '/uploadForm');
>>>>>>> 7a03fc90d89e696839a6c9ba32385d82ea13d3e1
    }
};



































