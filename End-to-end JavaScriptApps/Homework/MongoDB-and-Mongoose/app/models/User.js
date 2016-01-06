var mongoose = require('mongoose');

var userSchema = mongoose.Schema({
   userName: {type: String, require: true, unique: true},
   password: {type: String, require: true}
});

User = mongoose.model('User', userSchema);

module.exports.seedInitialUsers = function () {
   User
       .find({})
       .exec(function (err, collection) {
          if (err) {
             console.log('Cannot find users: ' + err);
             return;
          }

          if (collection.length === 0) {
             User.create({userName: 'firstUser', pass: '123456'});
             User.create({userName: 'secondUser', pass: '123456'});
             console.log("Few sample users created");
          }
       });
};