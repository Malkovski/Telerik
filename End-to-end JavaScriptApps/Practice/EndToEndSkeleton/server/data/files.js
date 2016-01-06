var File = require('mongoose').model('File');

module.exports = {
    addFiles: function (files) {
        console.log('here');
        console.log(files);
        File.collection.insert(files, {});
    }
};