import $ from "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";
import templates from "scripts/templates.js";
import ui from "scripts/ui.js";
import logic from "scripts/logic.js";

var events = (function () {
   var main = $('#main');

    main.on('click', '#login-form-btn', function () {
        ui.loadForm('login');
    });

    main.on('click', '#register-form-btn', function () {
        ui.loadForm('register');
    });

    main.on('click', '#register-account-btn', function () {
        var account = {
            username: $('#account-name').val(),
            password: $('#account-password').val()
        };

        logic.accounts.register(account);
    });

    main.on('click', '#login-account-btn', function () {
        var account = {
            username: $('#login-name').val(),
            password: $('#login-password').val()
        };

        logic.accounts.register(account);
    });

    main.on('click', '#show-all-users-btn', function () {
        logic.accounts.get()
        .then(function (data) {
                ui.loadGrid('usersGrid', data);
            })
    });

    main.on('click', '#show-all-threads-btn', function () {
        logic.threads.get()
            .then(function (data) {
                ui.loadGrid('threadsGrid', data);
            })
    });

    main.on('click', '#thread-by-id-btn', function () {
        var searchedID = $('#thread-id').val();

        logic.threads.get(searchedID)
            .then(function (data) {
                ui.loadGrid('threadsGrid', data);
            })
    });

    main.on('click', '#post-thread-btn', function () {
        ui.loadForm('postNewThread');
    });

    main.on('click', '#post-new-thread-btn', function () {
        var newThread = {
            title: $('#new-thread-title').val()
       };

        logic.threads.post(newThread);
    });
})();

export default events;