import $ from "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";
import templates from "scripts/templates.js";
import events from "scripts/events.js";

var ui = (function () {
    var menu = $('#menu'),
        main = $('#main'),
        isLogged = localStorage.getItem('username-key'),
        loadNavigation,
        loadGrid,
        loadLoginStatus,
        loadForm;

    loadForm = function (container, option) {

       templates.load(option)
        .then(function (template) {
               container.html(template);
           })
        .then(function () {
               if (option === 'register') {
                   events.initRegister();
               }
               else if (option === 'login') {
                   events.initLogin();
               }
           });
    };

    loadNavigation = function () {
        templates.load('menu')
        .then(function (template) {
                menu.html(template);
            })
        .then(function () {
                if (localStorage.getItem('username-key')) {
                    loadLoginStatus();
                }
            });

        main.html('');
    };

    loadGrid = function (name, data) {
        templates.load(name)
        .then(function (template) {
                $('.grid-container').html(template(data));
            })
    };

    loadLoginStatus = function () {
        templates.load('loginStatus')
        .then(function (template) {
                $('#login-status').html(template(localStorage.getItem('username-key')));
                events.initLogout();
            })
    };

    return {
        loadNavigation,
        loadForm,
        loadGrid,
        loadLoginStatus
    }
})();

export default ui;