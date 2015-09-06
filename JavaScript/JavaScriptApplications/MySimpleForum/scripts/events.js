import $ from "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";
import templates from "scripts/templates.js";
import ui from "scripts/ui.js";
import logic from "scripts/logic.js";

var events = (function () {
   var  menu = $('#menu'),
       main = $('#main');

    var navigateTo = function (location) {
        window.location.hash = location;
    };

    main.on('click', '#login-form-btn', function () {
        var container = $('.grid-container');
        ui.loadForm(container, 'login');
    });

    main.on('click', '#register-form-btn', function () {
        var container = $('.grid-container');
        ui.loadForm(container, 'register');
    });

    var initRegister = function () {
        main.on('click', '#register-account-btn', function () {
            var account = {
                username: $('#account-name').val(),
                password: $('#account-password').val()
            };

            logic.accounts.register(account)
                .then(function (account) {
                    console.log(account);
                    navigateTo('#/');
                })
        });
    };

    var initLogin = function () {
        main.on('click', '#login-account-btn', function () {
            var account = {
                username: $('#login-name').val(),
                password: $('#login-password').val()
            };

            logic.accounts.login(account)
                .then(function () {
                    navigateTo('#/');
                    ui.loadLoginStatus();
                })
        });
    };

    var initLogout = function () {
        menu.on('click', '#logout-account-btn', function () {
            logic.accounts.logout()
                .then(function () {
                    ui.loadNavigation();
                })
        });
    };


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
                ui.loadGrid('threadByIDGrid', data);
            })
    });

    main.on('click', '#post-thread-btn', function () {
        var container = $('.grid-container');
        ui.loadForm(container, 'postNewThread');
    });

    main.on('click', '#post-new-thread-btn', function () {
        var newThread = {
            title: $('#new-thread-title').val()
       };

        logic.threads.post(newThread)
        .then(function () {
                $('.grid-container').html('');
            })
    });

    main.on('click', '#submit-message-btn', function () {
        var container = $('.grid-container');
        ui.loadForm(container, 'newThreadMessage')
    });

    main.on('click', '#submit-new-message-btn', function () {
        var threadId = $('#thread-id-message').val(),
            message = $('#new-message').val();

        logic.message.post(threadId, message)
            .then(function () {
                $('.grid-container').html('');
            })
    });

    return {
        initRegister,
        initLogin,
        initLogout
    }
})();

export default events;