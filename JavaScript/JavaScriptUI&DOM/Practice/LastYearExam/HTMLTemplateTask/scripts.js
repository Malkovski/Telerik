window.onload = function () {
    var authors = [{
        name: "������� ������",
        image: "images/niki.jpg",
        titles: ["Technical <b>Trainer</b>", "Rapper"],
        urls: ["http://nikolay.it", "https://github.com/NikolayIT"],
        right: false,
    }, {
        name: "������ �����",
        image: "images/ivo.jpg",
        titles: ["Technical <b>Trainer</b>", "Rapper"],
        urls: ["http://ivaylo.bgcoder.com", "https://github.com/ivaylokenov"],
        right: true,
    }, {
        name: "����� ������",
        image: "images/doncho.jpg",
        titles: ["Technical <b>Trainer</b>"],
        urls: ["http://minkov.it", "https://github.com/Minkov"],
        right: false,
    }, {
        id: 4,
        name: "����� �������",
        image: "images/todor.jpg",
        titles: ["Software <b>Developer</b>"],
        urls: ["https://github.com/todorstoianov"],
        right: true,
    }];

    var authorsListContainer = document.getElementById('authors'),
        templateHtml = document.getElementById('authors-template').innerHTML,
        authorsListTemplate = Handlebars.compile(templateHtml);

    while (authorsListContainer.firstChild) {
        authorsListContainer.removeChild(authorsListContainer.firstChild);
    }

    authorsListContainer.innerHTML = authorsListTemplate({
        authors: authors
    });
};