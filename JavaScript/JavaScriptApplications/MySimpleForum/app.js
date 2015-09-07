import sammy from "bower_components/sammy/lib/sammy.js";
import ui from "scripts/ui.js";

(function () {
    var app = sammy('#menu', function () {
        this.get('#/', function () {
            ui.loadNavigation();
        });

        this.get('#/home', function (context) {
            context.redirect('#/');
        });

        this.get('#/users', function () {
            ui.loadForm('user-options');
        });

        this.get('#/threads', function () {
            ui.loadForm('threads-options');
        })

    });

    app.run('#/')
})();


