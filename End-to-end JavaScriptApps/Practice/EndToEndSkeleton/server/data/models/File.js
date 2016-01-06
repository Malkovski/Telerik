var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

module.exports.init = function() {
    var fileSchema = mongoose.Schema({
        url: { type: String, required: true, unique: true },
        uploadingDate: { type: Date, default: new Date() },
        //owner: { type: mongoose.Schema.UserId, ref: 'User'},
        fileName: String,
        isPrivate: Boolean
    });

    var File = mongoose.model('File', fileSchema);
};