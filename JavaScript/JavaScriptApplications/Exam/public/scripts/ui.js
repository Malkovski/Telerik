import 'jquery';
import templates from 'scripts/templates.js';
import events from "scripts/events.js";
import logic from "scripts/logic.js";
import toastr from "toastr";
import moment from 'moment';

var ui = (function () {
    var main = $('#main');

    // HOME ------------------------------------------

    var initHomePage = function() {
        main.html('');
        ui.initListCookiesPage();
    };

    // USER ------------------------------------------

    var initRegisterPage = function() {
        main.html('');
        ui.loadForm(main, 'register');
    };

    var initLoginPage = function() {
        main.html('');
        ui.loadForm(main, 'login');
    };

    var initLogoutPage = function() {
        $('#login-status').html('');
        logic.accounts.logout();
        window.location.hash = '#/';
    };

    var initListUserPage = function () {
        logic.accounts.get()
            .then(function (data) {
                ui.loadForm(main, 'usersGrid', data);
            })
    };

    var loadLoginStatus = function (redirect) {
        if (redirect) {
            window.location.hash = '#/';
        }

        templates.load('loginStatus')
            .then(function (template) {
                $('#login-status').html(template(localStorage.getItem('username-key')));
            })
    };

    //COOKIES ------------------------------------------

    var initCreateCookiePage = function() {
        if (isAuthorized()) {
            main.html('');
            ui.loadForm(main, 'createCookie');
        } else {
            toastr.error('Not Authorized');
            window.location.hash = '#/';
        }
    };

    var initListCookiesPage = function (categoryName) {
        logic.cookies.get(categoryName)
            .then(function (data) {
                ui.loadForm(main, 'cookiesGrid', data);
            })
    };

    var initFilterCookiesPage = function () {

        //TODO regular can search????

        if (isAuthorized()) {
            main.html('');
            ui.loadForm(main, 'search');
        } else {
            toastr.error('Not Authorized');
            window.location.hash = '#/';
        }
    };

    var initMyCookiePage = function () {
        logic.cookies.my()
            .then(function (data) {
                console.log(data);
                ui.loadForm(main, 'fortune', data);
            })
    };

    var initCategoriesPage = function () {
        logic.categories.get()
            .then(function (data) {
                console.log(data);
                ui.loadForm(main, 'categories', data);
            })
    };

    var fortuneCookieRegister = function (cookieId) {


       /* var currentFortuneCookie = localStorage.getItem('current-fortune');

        if (currentFortuneCookie) {
            if (currentFortuneCookie.owner === localStorage.getItem('auth-key-key')) {
                if (currentFortuneCookie.timeReg) {

                }

            }
        }

        var currentFortune = {
            owner: localStorage.getItem('auth-key-key'),
            fortuneCookie: cookieId,
            timeReg: moment().format('MMMM Do YYYY, h:mm:ss a')
        };

        localStorage.setItem('current-fortune', currentFortune)*/
    };



    // UI LOADER -------------------------------------------------

    var loadForm = function (container, templateName,  data) {
        setRolesRestrictions();
        templates.load(templateName)
        .then(function (template) {
                if (data) {
                    container.html(template(data));
                }
                else {
                    container.html(template());
                }
            })
            .then(function () {
                if (localStorage.getItem('username-key')) {
                    ui.loadLoginStatus();
                }
            });
    };






    var setRolesRestrictions = function() {
        var member = localStorage.getItem('username-key');

        if (member) {
            $('.member').show();
        }
        else {
            $('.member').hide();
        }

    };

    var isAuthorized = function() {
        return localStorage.getItem('username-key');
    };

    return {
        loadForm,
        loadLoginStatus,
        initHomePage,
        initRegisterPage,
        initLoginPage,
        initLogoutPage,
        setRolesRestrictions,
        initCreateCookiePage,
        initListUserPage,
        initListCookiesPage,
        initFilterCookiesPage,
        initMyCookiePage,
        fortuneCookieRegister,
        initCategoriesPage
    }
})();

export default ui;