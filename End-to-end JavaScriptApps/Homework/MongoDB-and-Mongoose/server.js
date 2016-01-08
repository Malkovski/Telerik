var express = require('express'),
    app = express(),
    config = require('./app/config/config');

require('./app/config/mongoose')(config);

app.listen(config.port);
console.log("Server running on port " + config.port);


