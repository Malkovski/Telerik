/**
 * Created by Geogi Malkovski on 20.6.2015 ã..
 */
/* Task Description */
/*
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/category has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function () {
        var books = [];
        var categories = [];

        function listBooks() {
            if (arguments.length === 0) {
                return books;
            }
            else {
                var collectionByOption = [],
                    param = arguments[0];

                for (var b in books) {

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

            var isRepeatedCategory = false;

            for (var i = 0, len = categories.length; i < len; i++) {
                if (book.category === categories[i]) {
                    isRepeatedCategory = true;
                }
            }

            if (!isRepeatedCategory) {
                categories.push(book.category);
            }

            return book;
        }

        function listCategories() {
            return categories;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };

    } ());
    return library;
}
module.exports = solve;


