(function () {
    require.config({
        paths: {
            jquery: "libs/jquery.min",
            sammy: "libs/sammy-latest.min",
            handlebars: "libs/handlebars",
            kendo: "libs/kendo.web.min",
            Q: "libs/q.min",
            cryptojs: 'libs/cryptojs',
            sha1: 'libs/sha1',
            underscore: 'libs/underscore',
            logic: "Persons/logic",
            ui: "Persons/ui",
            events: "Persons/events"
        }
    });

    require(["sammy", "ui", "logic", "events"], function (sammy, ui, logic) {
        var app = sammy("#mainContent", function () {
            this.get("#/", function () {
                ui.initHomePage();
            });
            this.get("#/getPersons", function () {
                ui.initGetPersonsPage();
            });
            this.get("#/createPerson", function () {
                ui.initCreatePersonPage();
            });
        });

        app.run("#/");
    });
}());