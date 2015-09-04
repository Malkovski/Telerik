import $ from "bower_components/jquery/dist/jquery.js";
import _ from "bower_components/underscore/underscore.js";
import logic from "scripts/logic.js";
import ui from "scripts/ui.js";
import templates from "scripts/templates.js";

var content = $('#main-content');

content.on('click', '#add-student-btn', function () {
    logic.add()
    .then(function () {
            console.log('ADDED!');
        })
});

content.on('click', '#search-btn', function () {
    var searchOption = $('#search-option-input').val();

    logic.get()
        .then(function (data) {
            var searchedData = _.filter(data, function (item) {

                if (item.EGN == searchOption) {
                    return item;
                }
            });
            ui.showStudentsGrid(searchedData);
        });
});

content.on('click', '#sort-btn', function () {
    var sortOption = $('#sort-option-input').val();

    logic.get()
        .then(function (data) {
            var sortedData = _.chain(data).sortBy(sortOption).value();
            ui.showStudentsGrid(sortedData);
        });
});



