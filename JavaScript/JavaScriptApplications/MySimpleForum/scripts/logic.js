import $ from "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";
import templates from "scripts/templates.js";
import ui from "scripts/ui.js";
import CryptoJS from "bower_components/sha1/index.js";

var logic = (function () {

    const USERNAME_STORAGE_KEY = 'username-key',
        AUTH_KEY_STORAGE_KEY = 'auth-key-key';

    var contentType = 'application/json',
        acceptType = 'application/json';

    var registerAccount = function (account) {
        var currentAccount = {
            username: account.username,
            passHash: CryptoJS.SHA1(account.password).toString()
        };

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/users',
                method: 'POST',
                contentType: contentType,
                acceptType: acceptType,
                data: JSON.stringify(currentAccount),
                success: function (account) {
                    localStorage.setItem(USERNAME_STORAGE_KEY, account.username);
                    localStorage.setItem(AUTH_KEY_STORAGE_KEY, account.authKey);
                    resolve(account);
                }
            })
        });

        return promise;
    };

    var loginAccount = function (account) {
        var currentAccount = {
            username: account.username,
            passHash: CryptoJS.SHA1(account.password).toString()
        };

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/auth',
                method: 'PUT',
                contentType: contentType,
                acceptType: acceptType,
                data: JSON.stringify(currentAccount),
                success: function (account) {
                    localStorage.setItem(USERNAME_STORAGE_KEY, account.username);
                    localStorage.setItem(AUTH_KEY_STORAGE_KEY, account.authKey);
                    resolve(account);
                }
            })
        });

        return promise;
    };

    var logoutAccount = function () {
        var promise = new Promise(function(resolve, reject) {

            localStorage.removeItem(AUTH_KEY_STORAGE_KEY);
            localStorage.removeItem(USERNAME_STORAGE_KEY);
            resolve();
        });

        return promise;
    };

    var getAccounts = function () {
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/users',
                method: 'GET',
                contentType: contentType,
                acceptType: acceptType,
                success: function (data) {
                    resolve(data);
                }
            })
        });

        return promise;
    };

    var getThreads = function (id) {
        var currentUrl = 'api/threads';

        if (id) {
            currentUrl = `api/threads/${id}`;
        }

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: currentUrl,
                method: 'GET',
                contentType: contentType,
                acceptType: acceptType,
                success: function (data) {
                    resolve(data);
                }
            })
        });

        return promise;
    };

    var postThread = function (thread) {

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/threads',
                method: 'POST',
                headers: {
                    'x-authkey': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
                },
                contentType: contentType,
                acceptType: acceptType,
                data: JSON.stringify(thread),
                success: function (data) {
                    resolve(data);
                }
            })
        });

        return promise;
    };

    var postMessage = function (id, message) {

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: `api/threads/${id}/messages`,
                method: 'POST',
                headers: {
                    'x-authkey': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
                },
                contentType: contentType,
                acceptType: acceptType,
                data: JSON.parse(message),
                success: function (data) {
                    resolve(data);
                }
            })
        });

        return promise;
    };

    return {
        accounts: {
            register: registerAccount,
            login: loginAccount,
            get: getAccounts,
            logout: logoutAccount
        },
        threads: {
            get: getThreads,
            post: postThread
        },
        message: {
            post: postMessage
        }

    };
})();

export default logic;