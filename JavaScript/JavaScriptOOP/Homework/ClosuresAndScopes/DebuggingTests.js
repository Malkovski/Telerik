/**
 * Created by Geogi Malkovski on 20.6.2015 ã..
 */

var books = [];

function addBook(book) {

    if (book.title === 'undefined' || book.author === 'undefined' || book.isbn === 'undefined' || book.category === 'undefined') {
        throw  new Error();
    }

    if (book.title.length < 2 && book.title.length > 100) {
        throw  new Error();
    }

    if (book.author == '') {
        throw  new Error();
    }

    if ((book.isbn.length > 10 || book.isbn.length < 10) && (book.isbn.length > 13 || book.isbn.length < 13)) {
        throw new Error();
    }

    if (book.category == '') {
        book.category = 'unknown';
    }

    if (books.length > 0) {
        for (var i = 0, len = books.length; i < len; i++) {
            if (book.title == books[i].title) {
                throw new Error();
            }

            if (book.isbn == books[i].isbn) {
                throw new Error();
            }
        }
    }

    book.ID = books.length + 1;
    books.push(book);
    return book;
}

function listBooks() {
    if (arguments.length === 0) {
        return books;
    }
    else {
        var collectionByOption = [],
            param = arguments[0];

        for (var b in books) {
           /* console.log(books.length);
            console.log(books[b].category);
            console.log(param.category);*/
            if (books[b].category === param.category) {

                collectionByOption.push(books[b]);
            }

            if (books[b].author === param.author) {
                collectionByOption.push(books[b]);
            }
        }

        return collectionByOption;
    }
}

var book = {
    title: 'sssssssssss',
    isbn: 1234567890,
    author: 'aaasdssdfxsdv',
    category: 'fofofofofofof'
};


addBook(book);
console.log(listBooks({author: book.author}));


