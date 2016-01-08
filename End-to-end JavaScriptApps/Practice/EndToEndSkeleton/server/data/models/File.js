var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

module.exports.init = function() {
    var fileSchema = mongoose.Schema({
        //_id: String,
        url: { type: String, required: true, unique: true },
        uploadingDate: { type: Date, default: new Date() },
        //owner: { type: mongoose.Schema.ObjectId, ref: 'User'},
        fileName: String,
        isPrivate: {type: Boolean, default: false }
    });

    var File = mongoose.model('File', fileSchema);
};