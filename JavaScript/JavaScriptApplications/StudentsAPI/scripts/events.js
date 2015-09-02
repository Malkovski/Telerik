import $ from "bower_components/jquery/dist/jquery.js";
import logic from "scripts/logic.js";
import ui from "scripts/ui.js";

var body = $('#main-content');

body.on('click', '#search-btn', function () {
    logic.get()
        .then(function (data) {
            ui.showSortedStudents(data);
        });
});

body.on('click', '#sort-btn', function () {
    console.log('sorting....');
});



