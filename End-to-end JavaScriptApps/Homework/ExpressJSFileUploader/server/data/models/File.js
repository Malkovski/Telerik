var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption'),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId;

module.exports.init = function() {
    var fileSchema = new Schema({
        id: ObjectId,
        url: { type: String, required: true, unique: true },
        uploadingDate: { type: Date, default: new Date() },
        owner: { type: mongoose.Schema.ObjectId, ref: 'User'},
        fileName: String,
        isPrivate: {type: Boolean, default: false }
    });

    var File = mongoose.model('File', fileSchema);
};