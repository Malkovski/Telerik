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

    function showSortedStudents(data) {
        var dataJSON = data;
        templates.get('grid')
            .then(function (dataJSON) {
                main.html(dataJSON());
            });
    }

    function getAllStudents() {
        templates.get('allStudents')
            .then(function (template) {
                main.html(template());
            });
    }

    function getStudentById() {
        templates.get('studentById')
        .then(function (template) {
                main.html(template());
            })
    }

    return {
        getHomePage,
        getAllStudents,
        getStudentById,
        showSortedStudents
    };
})();

export default ui;
