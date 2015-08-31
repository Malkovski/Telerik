define(["ui", "underscore", "cryptojs", "sha1"], function (ui) {
    var baseUrl = 'http://persontest.apphb.com/api/',
		contentType = "application/x-www-form-urlencoded; charset=utf-8",
		acceptType = 'application/json';

    var getPersons = function (searchLastName) {
        var url = '', searchURL, xhr;

        if (searchLastName) {
            url = url + '?lastname=' + searchLastName;
        }

        searchURL = baseUrl + 'Person/Get' + url;

        xhr = $.ajax({
            url: searchURL,
            type: 'GET',
            contentType: contentType,
            dataType: 'json'
        });

        xhr 
            .success(function (data) {
                ui.drawKendoGrid(data);
            })
            .error(function (err) {
                alert(JSON.parse(err.responseText).message);
            });
    };

    var createPerson = function (person) {
        var xhr, url;

        url = baseUrl + 'Person/CreatePerson';

        xhr = $.ajax({
            url: url,
            type: 'POST',
            data: person,
            contentType: contentType,
            dataType: 'json'
        });

        xhr
           .success(function (data) {
               ui.clearCreatePersonDiv(data);
               alert('Person created!');
           })
           .error(function (err) {
               alert(JSON.parse(err.responseText).message);
           });
    };

    return {
        getPersons: getPersons,
        createPerson: createPerson
    }
});