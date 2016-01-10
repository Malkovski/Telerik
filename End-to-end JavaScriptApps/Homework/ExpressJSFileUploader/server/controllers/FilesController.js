var encryption = require('../utilities/encryption'),
    uploading = require('../utilities/uploading'),
    utils = require('../utilities/utilities'),
    files = require('../data/files');

var CONTROLLER_NAME = 'files';
var URL_PASSWORD = 'greeting eartrhlings...';

var uploadedFiles = [];

module.exports = {
    getUpload: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/uploadForm');
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
            console.log(uploadedFiles[username]);
            files.addFiles(uploadedFiles[username], req.user._id);
            res.redirect('/uploaded-files');
        });
    },
    getResults: function (req, res, next) {
        var host = req.get('host');
        var results = uploadedFiles[req.user.username];

        var  filesList = utils.queryToArray(results);

        uploadedFiles[req.user.username] = undefined;

        res.render(CONTROLLER_NAME + '/list-files', { files: filesList, host: host });
    },
    downloadFile: function (req, res, next) {
        var url = req.params.id;
        var decryptedUrl = encryption.decrypt(url, URL_PASSWORD);

        res.download(__dirname + '/../../files' + decryptedUrl);
    },
    getAll: function (req, res, next) {
        var options;

        if (utils.isEmptyObj(req.query)) {
            options = req.body;
        }
        else {
            options = req.query;
        }

        var host = req.get('host');
        files.getAll(options, req.user)
            .exec(function (err, results) {
            if (err) {
                req.session.error = err;
                return;
            }

            var  filesList = utils.queryToArray(results);


            res.render(CONTROLLER_NAME + '/list-files', { files: filesList, host: host })
        });
    },
    getById: function (req, res, next) {

    },
    deleteFile: function (req, res, next) {
        var id = req.params.id;
        var query = files.byId(id);
        query.exec(function (err, result) {
            if (err) {
                req.session.error = err;
                return;
            }

            var url = result.url;
            var decryptedUrl = encryption.decrypt(url, URL_PASSWORD);
            uploading.deleteFile(decryptedUrl);
        });

        files.delete(id);

        res.redirect('/downloads')
    }
};



































