define(['jquery', 'kendo'], function ($) {
    var mainContent = $('#mainContent');

    var initHomePage = function () {
        initPage('#menu', '#menuContainer');
    };

    var initGetPersonsPage = function () {
        initPage('#menu', '#menuContainer');

        $('#mainContent').load('getPersons.html', function () {
            $('#getPersonsBtn').kendoButton();
            $('#searchLastName').kendoMaskedTextBox();
            $('#searchLastName').focus();
        });
    };

    var initCreatePersonPage = function () {
        initPage('#menu', '#menuContainer');

        $('#mainContent').load('createPerson.html', function () {
            $('#createPersonBtn').kendoButton();
            $('#firstName').kendoMaskedTextBox();
            $('#lastName').kendoMaskedTextBox();
            $('#age').kendoMaskedTextBox();
            $('#firstName').focus();
        });
    };

    var initPage = function (menu, container) {
        $(container).load('menu.html', function () {
            $(menu).kendoMenu();
        });

        mainContent.text(' ');
    };

    function drawKendoGrid(items) {
        $('#grid').kendoGrid({
            dataSource: {
                data: items,
            },
            groupable: true,
            sortable: true,
            filterable: true,
            pageable: {
                refresh: true,
                pageSizes: true,
                buttonCount: 5
            },
            columns: [{ field: "FirstName", title: "First Name" },
							{ field: "LastName", title: "Last Name" },
							{ field: "Age", title: "Age" },
							{ field: "Address", title: "Address" },
            ]
        });

    };

    function clearCreatePersonDiv() {
        $('#createPersonDiv').find("input[type=text]").val('');
    };

    return {
        initHomePage: initHomePage,
        initGetPersonsPage: initGetPersonsPage,
        drawKendoGrid: drawKendoGrid,
        initCreatePersonPage: initCreatePersonPage,
        clearCreatePersonDiv: clearCreatePersonDiv
    }
});