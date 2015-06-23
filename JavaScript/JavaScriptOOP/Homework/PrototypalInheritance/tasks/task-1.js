/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * // method removeAttribute(attribute)
 */


/* Example
 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');
 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)
 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');
 div.content = 'Hello, world!';
 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');
 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);
 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */


function solve() {
    var domElement = (function () {

        function isValidType(type) {
            if (typeof type === 'string') {
                var regex = /^[A-Z0-9]+$/i;
                return regex.test(type);
            } else {
                throw new Error();
            }
        }

        function isValidAttributeName(name) {
            if (typeof name === 'string') {
                var regex = /^[A-Z0-9\-]+$/i;
                return regex.test(name);
            } else {
                throw new Error();
            }
        }

        function sortAttributes(attributes) {
            var attributesAsString = '',
                attributeNames = [];

            for (var obj in attributes) {
                attributeNames.push(obj);
            }

            attributeNames.sort();

            var currentKey;

            for(var i = 0, len = attributeNames.length; i < len; i += 1){
                currentKey = attributeNames[i];
                attributesAsString += ' ' + currentKey + '="' + attributes[currentKey] + '"';
            }

            return attributesAsString;
        }

        var domElement = {
            get type() {
                return this._type;
            },
            set type(value) {
                if (!isValidType(value)) {
                    throw new Error('Invalid!');
                }

                this._type = value;
            },
            get content() {
                if(this.children.length){
                    return '';
                }

                return this._content;
            },
            set content(value) {
                this._content = value;
            },
            get attributes() {
                return this._attributes;
            },
            set attributes(value) {
                this._attributes = value;
            },
            get children() {
                return this._children;
            },
            set children(value) {
                this._children = value;
            },
            get parent() {
                return this._parent;
            },
            set parent(value) {
                this._parent = value;
            },
            get innerHTML() {
                var innerHTML = '<' + this.type;
                var attributeAsString = sortAttributes(this.attributes);
                innerHTML += attributeAsString + '>';

                var child;
                for (var i = 0, len = this.children.length; i < len; i++) {
                    child = this.children[i];

                    if (typeof child === 'string') {
                        innerHTML += child;
                    }
                    else {
                        innerHTML += child.innerHTML;
                    }
                }

                innerHTML += this.content;
                innerHTML += '</' + this.type + '>';

                return innerHTML;
            },
            init: function(type) {
                this.type = type;
                this.content = '';
                this.attributes = [];
                this.children = [];
                this.parent;

                return this;
            },
            appendChild: function(child) {
                child.parent = this;
                this.children.push(child);

                return this;
            },
            addAttribute: function(name, value) {
                if (!isValidAttributeName(name)) {
                    throw new Error();
                }

                this.attributes[name] = value;

                return this;
            },
            removeAttribute: function(attribute) {
                if (!(this.attributes[attribute] && isValidAttributeName(attribute))) {
                    throw new Error();
                }

                delete this.attributes[attribute];

                return this;
            }
        };
        return domElement;
    } ());
    return domElement;
}

module.exports = solve;