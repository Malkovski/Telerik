var crypto = require('crypto');

module.exports = {
    generateSalt: function () {
        return crypto.randomBytes(128).toString('base64');
    },
    generateHashedPassword: function (salt, pwd) {
        var hmac = crypto.createHmac('sha1', salt);
        return hmac.update(pwd).digest('hex');
    },
    encrypt: function (text, key) {
        var cipher = crypto.createCipher('aes192', key);
        cipher.update(text, 'bynary', 'hex');
        return cipher.final('hex');
    },
    decrypt: function (cipher, key) {
        var decipher = crypto.createDecipher('aes192', key);
        decipher.update(cipher, 'hex', 'binary');
        return decipher.final('binary');
    }
};