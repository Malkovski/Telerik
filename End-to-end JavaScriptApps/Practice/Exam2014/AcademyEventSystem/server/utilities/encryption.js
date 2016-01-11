var crypto = require('crypto');

function generateSalt() {
    return crypto.randomBytes(128).toString('base64');
}

function generateHashedPassword(salt, pwd) {
    var hmac = crypto.createHmac('sha1', salt);
    return hmac.update(pwd).digest('hex');
}

function encrypt(text, key) {
    var cipher = crypto.createCipher('aes256', key);
    var encr = cipher.update(text, 'binary', 'hex');
    return (encr + cipher.final('hex'));
}

function decrypt(cipher, key) {
    var decipher = crypto.createDecipher('aes256', key);
    var decr = decipher.update(cipher, 'hex', 'binary');
    return (decr + decipher.final('binary'));
}

module.exports = {
    generateSalt: generateSalt,
    generateHashedPassword: generateHashedPassword,
    encrypt: encrypt,
    decrypt: decrypt
};

//module.exports = {
//    generateSalt: function () {
//        return crypto.randomBytes(128).toString('base64');
//    },
//    generateHashedPassword: function (salt, pwd) {
//        var hmac = crypto.createHmac('sha1', salt);
//        return hmac.update(pwd).digest('hex');
//    },
//    encrypt: function (text, key) {
//        var cipher = crypto.createCipher('aes256', key);
//        var encr = cipher.update(text, 'binary', 'hex');
//        return (encr + cipher.final('hex'));
//    },
//    decrypt: function (cipher, key) {
//        var decipher = crypto.createDecipher('aes256', key);
//        var decr = decipher.update(cipher, 'hex', 'binary');
//        return (decr + decipher.final('binary'));
//    }
//};