/*(function () {
    require.config({
        paths: {
            jquery: "../libs/jquery.min",
            sammy: "../libs/sammy-latest.min",
            handlebars: "../libs/handlebars",
            Q: "../libs/q.min",
            cryptojs: '../libs/cryptojs',
            sha1: '../libs/sha1',
            underscore: '../libs/underscore',
            logic: ".././scripts/logic",
            ui: ".././scripts/ui",
            templates: ".././scripts/templates",
            events: ".././scripts/events"
        }
    });

    require(['sammy', 'ui', 'templates'], function (sammy, ui, templates) {
        var app =  sammy('#main-content', function () {
            this.get('#/', function () {
                ui.getHomePage();
            });

            this.get('#/all-students', function () {
                ui.getAllStudents();
            });

            this.get('#/get-student-by-id', function () {
                ui.getStudentById();
            });

            this.get('#/add-new-student', function () {
                ui.getAllStudents();
            })
        });

        app.run('#/');
    });
})();*/

import sammy from "bower_components/sammy/lib/sammy.js";
import ui from "scripts/ui.js";
import "scripts/templates.js";
import "scripts/events.js";

(function () {
    var app =  sammy('#main-content', function () {
        this.get('#/', function () {
            ui.getHomePage();
        });

        this.get('#/all-students', function () {
            ui.getAllStudents();
        });

        this.get('#/get-student-by-id', function () {
            ui.getStudentById();
        });

        this.get('#/add-new-student', function () {
            ui.getAddStudents();
        })
    });

    app.run('#/');
})();