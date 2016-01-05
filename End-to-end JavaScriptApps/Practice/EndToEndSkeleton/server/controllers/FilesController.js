var encryption = require('../utilities/encryption'),
    uploading = require('../utilities/uploading'),
    files = require('../data/files');

var CONTROLLER_NAME = 'files';
var URL_PASSWORD = 'greeting eartrhlings...';

var uploadedFiles = {};

function getDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    return dd + '-' + mm + '-' + yyyy;
}

module.exports = {
    getUpload: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/uploadForm', {currentUser: req.user});
    },
    postUpload: function (req, res, next) {
        req.pipe(req.busboy);

        req.busboy.on('file', function (fieldname, file, filename) {
            var currentDate = getDate();
            var currentUser = req.user.username;
            var currentSalt = encryption.generateSalt();

            var filenameHashed = encryption.generateHashedPassword(currentSalt, filename);
            var path = '/' + currentUser + '/' + currentDate + '/';
            var url = path + filenameHashed;
            var urlEncripted = encryption.encrypt(url, URL_PASSWORD);

            var dbFile = uploadedFiles[fieldname] || {};
            dbFile.url = urlEncripted;
            dbFile.fileName = filename;


            uploading.saveFile(file, path, filenameHashed);
        });

        req.busboy.on('field', function(fieldname, val) {
            var index = fieldname.split('_')[1];
            var dbFile = uploadedFiles['file_' + index] || {};
            dbFile.isPrivate = !!val;
        });

        req.busboy.on('finish', function() {
            files.addFiles(uploadedFiles);
            req.session.uploadedFiles = uploadedFiles;
            uploadedFiles = {};
            res.redirect('/uploaded-files');
        });
    },
    getResults: function (req, res, next) {
        console.log(req.session.uploadedFiles);
        res.redirect('/');
    }
};
