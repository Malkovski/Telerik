import $ from "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";
import templates from "scripts/templates.js";
import events from "scripts/events.js";


var ui = (function () {
    var main = $('#main'),
        menu = $('#menu'),
        loadNavigation,
        loadGrid,
        loadForm;

    loadForm = function (option) {
        loadNavigation();

       templates.load(option)
        .then(function (template) {
               main.html(template);
           });
    };

    loadNavigation = function () {
        templates.load('menu')
        .then(function (template) {
                menu.html(template);
            });

        main.html('');
    };

    loadGrid = function (name, data) {
        templates.load(name)
        .then(function (template) {
                $('.grid-container').html(template(data));
            })
    };

    return {
        loadNavigation,
        loadForm,
        loadGrid
    }
})();

export default ui;