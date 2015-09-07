import sammy from "bower_components/sammy/lib/sammy.js";
import $ from "bower_components/jquery/dist/jquery.js";
import ui from "scripts/ui.js";

var spa = (function () {
    var  main = $('#main'),
         menu = $('#menu');

    var spa = sammy('#menu', function () {
        this.get('#/', function () {
            ui.loadNavigation();
        });

        this.get('#/home', function (context) {
            context.redirect('#/');
        });

        this.get('#/users', function () {
            ui.loadNavigation();
            ui.loadForm(main, 'user-options');
        });

        this.get('#/threads', function () {
            ui.loadNavigation();
            ui.loadForm(main, 'threads-options');
        })

    });

    spa.run('#/')
})();

export default spa;


