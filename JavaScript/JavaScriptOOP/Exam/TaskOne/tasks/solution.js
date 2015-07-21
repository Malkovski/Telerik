function solve(){
    var academyCatalog = (function () {

        var item,
            book,
            media,
            validator,
            catalog,
            bookCatalog,
            mediaCatalog;

        function indexOfElementWithIdInCollection(collection, id) {
            var i, len;
            for (i = 0, len = collection.length; i < len; i++) {
                if (collection[i].id == id) {
                    return i;
                }
            }

            return -1;
        }

        function indexOfElementWithNameInCollection(collection) {
            var i, len;
            for (i = 0, len = collection.length; i < len; i++) {
                if (collection[i].name == id) {
                    return i;
                }
            }

            return -1;
        }

        validator = {
            validateIfUndefined: function (val) {

                if (val === undefined) {
                    throw new Error('Cannot be undefined');
                }
            },
            validateIfNumber: function (val) {
                var pattern = /^\d+$/;

                if (!pattern.test(val)) {
                    throw new Error('ISBN must be a number');
                }
            },
            validateIfNonEmptyString: function (val, name) {
                name = name || 'Value';
                this.validateIfUndefined(val, name);

                if (val === '') {
                    throw new Error(name + ' must be non empty string');
                }
            },
            validateItemName: function (val, name) {
                name = name || 'Value';

                if (typeof val !== 'string') {
                    throw new Error(name + ' must be a string');
                }

                if (val.length < 2 || 40 < val.length) {
                    throw new Error(name + ' must be between ' + 2 +
                        ' and ' + 40 + ' symbols');
                }
            },
            validateCatalogName: function (val, name) {
                name = name || 'Value';

                if (typeof val !== 'string') {
                    throw new Error(name + ' must be a string');
                }

                if (val.length < 2 || 40 < val.length) {
                    throw new Error(name + ' must be between ' + 2 +
                        ' and ' + 40 + ' symbols');
                }
            },
            validateGenre: function (val, name) {
                name = name || 'Value';

                if (typeof val !== 'string') {
                    throw new Error(name + ' must be a string');
                }

                if (val.length < 2 || 20 < val.length) {
                    throw new Error(name + ' must be between ' + 2 +
                        ' and ' + 20 + ' symbols');
                }
            },
            validateISBN: function (val) {

                //this.validateIfNumber(val);

                if (val.length !== 10 && val.length !== 13) {
                    throw new Error('Invalid ISBN')
                }
            },
            validateDuration: function (val) {

                this.validateIfNumber(val);

                if (val.length <= 0) {
                    throw new Error('Duration cant be negative or zero')
                }
            },
            validateRating: function (val) {

                if (typeof val !== 'number') {
                    throw new Error('ISBN must be a number');
                }

                if (val.length < 1 || 5 < val.length) {
                    throw new Error('Duration cant be negative or zero')
                }
            },
            validateIfObject: function (val) {
                if (typeof val !== 'object') {
                    throw new Error('Item must be an object');
                }
            }
        };

        catalog = (function () {
            var currentCatalogId = 0;
            catalog = Object.create({});

            Object.defineProperty(catalog, 'init', {
                value: function (name) {
                    this.name = name;
                    this._id = ++currentCatalogId;
                    this._items = [];
                    return this;
                }
            });

            Object.defineProperty(catalog, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (value) {
                    validator.validateIfUndefined(value);
                    validator.validateCatalogName(value);
                    this._name = value;
                }
            });

            Object.defineProperty(catalog, 'id', {
                get: function () {
                    return this._id;
                }
            });

            Object.defineProperty(catalog, 'add', {
                value: function (obj) {
                    // var obj = [].slice.call(arguments);
                    validator.validateIfUndefined(obj);

                    var currentArray = obj[0];
                    if (currentArray instanceof Array) {

                        for (var j = 0, lenj = currentArray.length; j < lenj; j += 1) {
                            validator.validateIfObject(currentArray[j]);
                            this._items.push(currentArray[j]);
                        }
                    }
                    else {
                        for (var i = 0, leni = obj.length; i < leni; i += 1) {
                            validator.validateIfObject(obj[i]);
                            this._items.push(obj[i]);
                        }
                    }

                    return this;
                }
            });

            Object.defineProperty(catalog, 'find', {
                value: function (option) {
                    validator.validateIfUndefined(option);

                    if (typeof option !== 'object') {
                        validator.validateIfNumber(option);

                        var foundIndex = indexOfElementWithIdInCollection(this._items, option);
                        if (foundIndex < 0) {
                            return null;
                        }

                        return this._items[foundIndex];
                    }
                    else {
                        var optionID = option.id,
                            optionNAME = option.name;

                        if (optionID !== undefined) {
                            var foundIndex = indexOfElementWithIdInCollection(this._items, optionID);
                            if (foundIndex < 0) {
                                return [];
                            }

                            var found = this._items[foundIndex];

                            if (optionNAME !== undefined) {
                                if (found.name !== optionNAME) {
                                    return [];
                                }

                                return found;
                            }

                            return found;
                        }
                        else {
                            if (optionNAME !== undefined) {
                                var foundIndex = indexOfElementWithNameInCollection(this._items, optionNAME);
                                if (foundIndex < 0) {
                                    return [];
                                }

                                return this._items[foundIndex];
                            }
                        }
                    }

                    return this;
                }
            });

            Object.defineProperty(catalog, 'search', {
                value: function (pattern) {
                    if (typeof pattern !== 'string') {
                        throw new Error('Pattern must be a string');
                    }

                    if (pattern.length < 1) {
                        throw new Error('Pattern must be greater than 0');
                    }

                    return this._items.filter(function (item) {
                        var wholeInfo = item.name + item.description;
                        return wholeInfo.toLowerCase().indexOf(pattern.toLowerCase()) >= 0
                    });
                }
            });

            return catalog;
        })();

        bookCatalog = (function (parent) {
            bookCatalog = Object.create(parent);

            Object.defineProperty(bookCatalog, 'init', {
                value: function (name) {
                    parent.init.call(this, name);
                    return this;
                }
            });

            Object.defineProperty(bookCatalog, 'add', {
                value: function () {
                    var itemsToAdd = [].slice.call(arguments);

                    if (itemsToAdd[0] instanceof Array) {
                        var currentArray = itemsToAdd[0];

                        for (var j = 0, lenj = currentArray.length; j < lenj; j += 1) {
                            if (!currentArray[j].hasOwnProperty('_genre')) {
                                throw new Error('Cannot add other than books!')
                            }
                        }
                    }
                    else {
                        for (var i = 0, leni = itemsToAdd.length; i < leni; i += 1) {
                            if (!itemsToAdd[i].hasOwnProperty('_genre')) {
                                throw new Error('Cannot add other than books!')
                            }
                        }
                    }

                    return parent.add.call(this, itemsToAdd);
                }
            });

            Object.defineProperty(bookCatalog, 'find', {
                value: function (book) {
                    return parent.find.call(this, book);
                }
            });

            Object.defineProperty(bookCatalog, 'getGenres', {
                value: function () {
                    var genres = [],
                        items = this._items;

                    for (var i = 0, leni = items.length; i < leni; i += 1) {
                        var currentGenre = items[i].genre.toLowerCase();

                        if (!genres.some(function (element) {
                                return element === currentGenre;
                            })) {
                            genres.push(currentGenre);
                        }
                    }

                    return genres;
                }
            });

            return bookCatalog;
        })(catalog);

        mediaCatalog = (function (parent) {
            mediaCatalog = Object.create(parent);

            Object.defineProperty(mediaCatalog, 'init', {
                value: function (name) {
                    parent.init.call(this, name);
                    return this;
                }
            });

            Object.defineProperty(mediaCatalog, 'add', {
                value: function () {
                    var itemsToAdd = [].slice.call(arguments);

                    if (itemsToAdd[0] instanceof Array) {
                        var currentArray = itemsToAdd[0];

                        for (var j = 0, lenj = currentArray.length; j < lenj; j += 1) {
                            if (!currentArray[j].hasOwnProperty('_duration')) {
                                throw new Error('Cannot add other than media!')
                            }
                        }
                    }
                    else {
                        for (var i = 0, leni = itemsToAdd.length; i < leni; i += 1) {
                            if (!itemsToAdd[i].hasOwnProperty('_duration')) {
                                throw new Error('Cannot add other than media!')
                            }
                        }
                    }

                    return parent.add.call(this, itemsToAdd);
                }
            });

            Object.defineProperty(mediaCatalog, 'getTop', {
                value: function (count) {
                    validator.validateIfNumber(count);

                    if (count < 1) {
                        throw new Error('Count must be greater than 0');
                    }

                    var sorted = this._items.sort(function (first, second) {
                        return second.rating - first.rating;
                    }).splice(0, count);

                    return sorted;
                }
            });

            Object.defineProperty(mediaCatalog, 'getSortedByDuration', {
                value: function () {
                    return this._items
                        .sort(function (firstMedia, secondMedia) {
                            return secondMedia.duration - firstMedia.duration;
                        }).sort(function (first, second) {
                            return first.id - second.id;
                        })
                }
            });

            return mediaCatalog;
        })(catalog);

        item = (function () {
            var currentItemId = 0;
            item = Object.create({});

            Object.defineProperty(item, 'init', {
                value: function (description, name) {
                    this._id = ++currentItemId;
                    this.name = name;
                    this.description = description;

                    return this;
                }
            });

            Object.defineProperty(item, 'id', {
                get: function () {
                    return this._id;
                }
            });

            Object.defineProperty(item, 'description', {
                get: function () {
                    return this._description;
                },
                set: function (value) {
                    validator.validateIfUndefined(value);
                    validator.validateIfNonEmptyString(value);
                    this._description = value;
                }
            });

            Object.defineProperty(item, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (value) {
                    validator.validateIfUndefined(value);
                    validator.validateItemName(value);
                    this._name = value;
                }
            });

            return item;
        })();

        book = (function (parent) {
            var book = Object.create(parent);

            Object.defineProperty(book, 'init', {
                value: function (name, isbn, genre, description) {
                    parent.init.call(this, name, description);
                    this.isbn = isbn;
                    this.genre = genre;
                    return this;
                }
            });

            Object.defineProperty(book, 'isbn', {
                get: function () {
                    return this._isbn;
                },
                set: function (value) {
                    validator.validateIfUndefined(value);
                    validator.validateISBN(value);
                    this._isbn = value;
                }
            });

            Object.defineProperty(book, 'genre', {
                get: function () {
                    return this._genre;
                },
                set: function (value) {
                    validator.validateIfUndefined(value);
                    validator.validateGenre(value);
                    this._genre = value;
                }
            });

            return book;
        })(item);

        media = (function (parent) {
            media = Object.create(parent);

            Object.defineProperty(media, 'init', {
                value: function (name, rating, duration, description) {
                    parent.init.call(this,  name, description);
                    this.duration = duration;
                    this.rating = rating;
                    return this;
                }
            });

            Object.defineProperty(media, 'duration', {
                get: function () {
                    return this._duration;
                },
                set: function (value) {
                    validator.validateIfUndefined(value);
                    validator.validateDuration(value);
                    this._duration = value;
                }
            });

            Object.defineProperty(media, 'rating', {
                get: function () {
                    return this._rating;
                },
                set: function (value) {
                    validator.validateIfUndefined(value);
                    validator.validateRating(value);
                    this._rating = value;
                }
            });

            return media;
        })(item);


        return {
            getBook: function (name, isbn, genre, description) {
                validator.validateIfUndefined(name);
                validator.validateIfUndefined(isbn);
                validator.validateIfUndefined(genre);
                validator.validateIfUndefined(description);
                return Object.create(book).init(name, isbn, genre, description)
            },
            getMedia: function (name, rating, duration, description) {
                validator.validateIfUndefined(name);
                validator.validateIfUndefined(rating);
                validator.validateIfUndefined(duration);
                validator.validateIfUndefined(description);
                return Object.create(media).init(name, rating, duration, description);
            },
            getBookCatalog: function (name) {
                validator.validateIfUndefined(name);
                return Object.create(bookCatalog).init(name);
            },
            getMediaCatalog: function (name) {
                validator.validateIfUndefined(name);
                return Object.create(mediaCatalog).init(name);
            }
        }

    })();

    return academyCatalog;
}

module.exports = solve;