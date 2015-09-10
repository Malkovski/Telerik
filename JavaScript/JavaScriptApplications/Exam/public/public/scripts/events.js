import 'jquery';
import ui from 'scripts/ui.js';
import logic from 'scripts/logic.js';
import toastr from 'toastr';
import validator from 'scripts/validator.js';

var events = (function () {
    var main = $('#main'),
        menu = $('#menu');


    // Create cookie ----------------------------------------

    main.on('click', '#create-and-save', function () {
        var newCookie = {
            text: $('#text-cookie').val(),
            category: $('#category-cookie').val(),
            img: $('#img-cookie').val()
        };

        if (typeof newCookie.text !== 'string') {
            toastr.error('Text must be a string');
            return;
        }

        if (typeof newCookie.img !== 'string') {
            toastr.error('Text must be a string');
            return;
        }

        if (newCookie.text === '') {
            toastr.error('Please enter text');
            return;
        }

        if (newCookie.category === '') {
            toastr.error('Please enter category');
            return;
        }

        if (!validator.validate.nameLength(newCookie.text, 6, 30)) {
            toastr.error('Text must be between 6 and 20 symbols');
            return;
        }

        if (!validator.validate.validateURL(newCookie.img)) {
            toastr.error('URL is not a valid one!');
            return;
        }


        logic.cookies.add(newCookie)
        .then(function () {
                ui.initListCookiesPage();
            })
    });

    main.on('click', '#search-cookies', function () {
        var categoryName = $('#search-category').val();
        window.location.hash = '#/home?category=' + categoryName;
    });


    main.on('click', '#like', function () {
        var selectedCookieId = $('#selected-cookie-id').attr('data-id');
        console.log(selectedCookieId);
        logic.cookies.update(selectedCookieId, true)
        .then(function () {
                ui.initListCookiesPage();
            });
    });

    main.on('click', '#dislike', function () {
        var selectedCookieId = $('#selected-cookie-id').attr('data-id');
        logic.cookies.update(selectedCookieId)
            .then(function () {
                ui.initListCookiesPage();
            });
    });

    main.on('change', '.update-box',  function() {
        var checkbox = $(this).find('input');
        var isChecked = checkbox.prop('checked');
        var id = $(this).attr('data-id');
        console.log(id);
        logic.vouchers.update(id, {
            state: isChecked
        });
    });

    // Account Section

    main.on('click', '#register-account-btn', function () {
        var account = {
            username: $('#account-name').val(),
            password: $('#account-password').val(),
            password2: $('#account-password2').val()
        };

        if (typeof account.username !== 'string') {
            toastr.error('Username must be a string');
            return;
        }

        if (account.username === '') {
            toastr.error('Please enter username');
            return;
        }

        if (!validator.validate.nameLength(account.username, 6, 30)) {
            toastr.error('Name must be between 6 and 20 symbols');
            return;
        }

        if (!validator.validate.validatePattern(account.username)) {
            toastr.error('Use only alphanumeric characters please!');
            return;
        }

        if (account.password === '') {
            toastr.error('Please enter password');
            return;
        }

        if (!validator.validate.matchingPasswords(account.password, account.password2)) {
            toastr.error('Password do not match');
            return;
        }

        logic.accounts.register(account);
        console.log(account);
    });

    main.on('click', '#login-account-btn', function () {
        var account = {
            username: $('#login-name').val(),
            password: $('#login-password').val()
        };

        if (account.username === '') {
            toastr.error('Please enter username');
            return;
        }

        if (account.password === '') {
            toastr.error('Please enter password');
            return;
        }

        logic.accounts.login(account);
    });

    $('#login-status').on('click', '#logout-account-btn', function () {
        $('#login-status').html('');
        logic.accounts.logout();
        window.location.hash = '#/';
    });

    // --------------------------------------------------------
})();

export default events;