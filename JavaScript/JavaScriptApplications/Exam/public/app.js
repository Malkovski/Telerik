import 'sammy';
import 'jquery';
import ui from 'scripts/ui.js';

export default (function () {
    var  main = $('#main'),
        menu = $('#menu');

    var app = Sammy('#menu', function () {

        this.get('#/', function (context) {
            context.redirect('#/home');
        });

        this.get('#/home', function () {
            ui.initHomePage();
        });

        this.get('#/register', function () {
            ui.initRegisterPage();
        });

        this.get('#/login', function () {
            ui.initLoginPage();
        });

        this.get('#/logout', function () {
            ui.initLogoutPage();
        });

        this.get('#/listUsers', function () {
            ui.initListUserPage();
        });

        this.get('#/listCookies', function () {
            ui.initListCookiesPage();
        });

        this.get('#/categories', function () {
            ui.initCategoriesPage();
        });

        this.get('#/createCookie', function () {
            ui.initCreateCookiePage();
        });

        this.get('#/filterCookies', function () {
            ui.initFilterCookiesPage();
        });

        this.get('#/pickCookie', function () {
            ui.initMyCookiePage();
        });
    });

    app.run('#/');
})();