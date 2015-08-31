define(['jquery', 'logic'], function ($, logic) {
    // GET POSTS
    $(document).on("click", "#getPersonsBtn", function () {
        var searchLastName = $('#searchLastName').val();
        logic.getPersons(searchLastName);
    });

    $(document).on("click", "#createPersonBtn", function () {
        var params = {
            firstName: $('#firstName').val(),
            lastName: $('#lastName').val(),
            age: $('#age').val(),
        };

        if (params.firstName !== '' && params.lastName !== '' && params.age !== '') {

            logic.createPerson(params);
        }
        else {
            alert('Please enter correct data!');
        }
    });
});