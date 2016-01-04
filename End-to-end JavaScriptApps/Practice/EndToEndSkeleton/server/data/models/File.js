var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

module.exports.init = function() {
    var fileSchema = mongoose.Schema({
        url: { type: String },
        fileName: String
    });

    var File = mongoose.model('File', fileSchema);
};