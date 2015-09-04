/*define(['jquery', 'templates'], function ($, templates) {
    var nav = $('#navigation-menu'),
        main = $('#main-content');

    function getHomePage() {
        console.log('HERE');
        templates.get('navigation')
        .then(function(template) {
                nav.html(template());
            });

        //nav.load('navigation.html');
        main.text(' ');
    }

    function getAllStudents() {
        main.load('allStudents.html');
    }

    function getStudentById() {
        main.load('studentById.html');
    }

    return {
        getHomePage,
        getAllStudents,
        getStudentById
    }
});*/

import $ from  "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";
import templates from "scripts/templates.js";
import logic from "scripts/logic.js";
import "scripts/events.js";

var ui = (function () {
    var nav = $('#navigation-menu'),
        main = $('#main-content');

    function getHomePage() {
        templates.get('navigation')
            .then(function(template) {
                nav.html(template());
            });

        main.text(' ');
    }

    function showStudentsGrid(data) {
        templates.get('grid')
            .then(function (template) {
                $('#grid-content').html(template(data));
            });
    }

    function getAllStudents() {
        this.getHomePage();
        templates.get('allStudents')
            .then(function (template) {
                main.html(template());
            });
        logic.get()
            .then(function (data) {
                ui.showStudentsGrid(data);
            });
    }

    function getStudentById() {
        this.getHomePage();
        templates.get('studentById')
        .then(function (template) {
                main.html(template());
            })
    }

    function getAddStudents() {
        this.getHomePage();
        templates.get('studentForm')
            .then(function (template) {
                main.html(template());
            })
    }

    return {
        getHomePage,
        getAllStudents,
        getStudentById,
        showStudentsGrid,
        getAddStudents
    };
})();

export default ui;
