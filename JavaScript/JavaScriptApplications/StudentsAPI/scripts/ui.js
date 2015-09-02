define(['jquery', 'templates'], function ($) {
    var nav = $('#navigation-menu'),
        main = $('#main-content');

    function getHomePage() {
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
});

