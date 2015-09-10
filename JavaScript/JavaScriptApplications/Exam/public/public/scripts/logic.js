import $ from "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";
import templates from "scripts/templates.js";
import ui from "scripts/ui.js";
import CryptoJS from "bower_components/sha1/index.js";
import toastr from "bower_components/toastr/toastr.js";

var logic = (function () {

    const USERNAME_STORAGE_KEY = 'username-key',
        AUTH_KEY_STORAGE_KEY = 'auth-key-key';

    var contentType = 'application/json',
        acceptType = 'application/json';


    // Account Section ---------------------------------------------

    var registerAccount = function (account) {
        console.log(account);
        var currentAccount = {
            username: account.username,
            passHash: CryptoJS.SHA1(account.password).toString()
        };
        console.log(currentAccount);
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/users',
                method: 'POST',
                contentType: contentType,
                acceptType: acceptType,
                data: JSON.stringify(currentAccount),
                success: function (account) {
                    console.log(account);
                    localStorage.setItem(USERNAME_STORAGE_KEY, account.result.username);
                    localStorage.setItem(AUTH_KEY_STORAGE_KEY, account.result.authKey);
                    resolve(account);

                    ui.loadLoginStatus(true);
                    ui.setRolesRestrictions();
                    toastr.success("Register successful");
                },
                error: function(err) {
                    toastr.error(err.responseText);
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
                    localStorage.setItem(USERNAME_STORAGE_KEY, account.result.username);
                    localStorage.setItem(AUTH_KEY_STORAGE_KEY, account.result.authKey);
                    //localStorage.setItem(ROLE_KEY_STORAGE_KEY, 'Company');
                    resolve(account);

                    ui.loadLoginStatus(true);
                    ui.setRolesRestrictions();
                    toastr.success("Login successful");
                },
                error: function(err) {
                    toastr.error(err.responseText);
                }
            })
        });

        return promise;
    };

    var logoutAccount = function () {
        var promise = new Promise(function(resolve, reject) {

            localStorage.removeItem(AUTH_KEY_STORAGE_KEY);
            localStorage.removeItem(USERNAME_STORAGE_KEY);
            //localStorage.removeItem(ROLE_KEY_STORAGE_KEY);
            resolve();
            toastr.success('Logout successful');
            ui.setRolesRestrictions();
        });

        return promise;
    };

    // GET ACCOUNTS------------------------------------------------

    var getAccounts = function () {
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/users',
                method: 'GET',
                headers: {
                    'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
                },
                contentType: contentType,
                acceptType: acceptType,
                success: function (data) {
                    resolve(data);
                },
                error: function(err) {
                    toastr.error(err.responseText);
                }
            })
        });

        return promise;
    };


    // COOKIES REQUESTS----------------------------------

    var getCookies = function (categoryName) {
        var currentUrl = 'api/cookies';

        if (categoryName) {
            currentUrl = '/#/home?category=' + categoryName;
        }

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: currentUrl,
                method: 'GET',
                contentType: contentType,
                acceptType: acceptType,
                success: function (data) {
                    resolve(data);
                },
                error: function(err) {
                    toastr.error(err.responseText);
                }
            })
        });

        return promise;
    };

    var addCookie = function (cookie) {

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/cookies',
                method: 'POST',
                headers: {
                    'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
                },
                contentType: contentType,
                acceptType: acceptType,
                data: JSON.stringify(cookie),
                success: function (data) {
                    resolve(data);
                    toastr.success('Cookie successfully shared!');
                },
                error: function(err) {
                    toastr.error(err.responseText);
                }
            })
        });

        return promise;
    };

    var updateCookie = function (id, liked) {
        var vote;

        if (liked) {
            vote = {
                type: 'like'
            };
        }
        else {
            vote = {
                type: 'dislike'
            };
        }


        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/cookies/' + id,
                method: 'PUT',
                headers: {
                    'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
                },
                contentType: contentType,
                acceptType: acceptType,
                data: JSON.stringify(vote),
                success: function (data) {
                    resolve(data);
                    toastr.success('Cookie liked!');
                },
                error: function(err) {
                    toastr.error(err.responseText);
                }
            })
        });

        return promise;
    };

    var getCategories = function () {

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/categories',
                method: 'GET',
                contentType: contentType,
                acceptType: acceptType,
                success: function (data) {
                    console.log(data);
                    resolve(data);
                },
                error: function(err) {
                    toastr.error(err.responseText);
                }
            })
        });

        return promise;
    };

    var getMyCookie = function () {

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'api/my-cookie',
                method: 'GET',
                headers: {
                    'x-auth-key': localStorage.getItem(AUTH_KEY_STORAGE_KEY)
                },
                contentType: contentType,
                acceptType: acceptType,
                success: function (data) {
                    console.log(data);
                    resolve(data);
                },
                error: function(err) {
                    toastr.error(err.responseText);
                }
            })
        });

        return promise;
    };

    /*var postMessage = function (id, message) {

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
    };*/

    return {
        accounts: {
            register: registerAccount,
            login: loginAccount,
            get: getAccounts,
            logout: logoutAccount
        },
        cookies: {
            get: getCookies,
            add: addCookie,
            update: updateCookie,
            my: getMyCookie
        },
        categories: {
            get: getCategories
        }

    };
})();

export default logic;