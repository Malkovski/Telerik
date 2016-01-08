var fs = require('fs');

var FILES_DIR = __dirname + '/../../files';

module.exports = {
    createDir: function (path, dirName) {
        dirName = dirName || '';
      fs.mkdirSync(FILES_DIR + path + dirName);
    },
    saveFile: function (file, path, fileName) {
        if (!fs.existsSync(FILES_DIR + path)) {
            var pathParts = path.split('/');
            if (!fs.existsSync((FILES_DIR + '/' + pathParts[1]))) {
                this.createDir('/' + pathParts[1]);
            }
            this.createDir(path);
        }

        var fsStream = fs.createWriteStream(FILES_DIR + path + fileName);
        file.pipe(fsStream);
    }
};