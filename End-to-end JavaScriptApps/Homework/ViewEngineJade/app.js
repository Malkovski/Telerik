var express = require('express');
var http = require('http');
var jade = require('jade');
var fs = require('fs');
var templatesPath = 'app';
var viewEngine = 'jade';

var app = express();

app.set('port', 1234);
app.set('views', templatesPath);
app.set('view engine', viewEngine);

var model = {
    nav: [{
        url: 'home',
        title: 'Home'
    }, {
        url: 'phones',
        title: 'Smart phones'
    }, {
        url: 'tablets',
        title: 'Tablets'
    }, {
        url: 'wearables',
        title: 'Wearables'
    }],
    title: 'Lorem ipsum',
    content: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ratione, eos, nostrum commodi nihil blanditiis quam recusandae praesentium deserunt consequatur dignissimos nemo earum distinctio mollitia sapiente numquam sed a facere rerum.'
};

var phones = [{name: 'XperiaS', price: 800}, {name: 'XperiaZ', price: 1200}, {name: 'Lenovo', price: 220}];
var tablets = [{name: 'Assus', price: 1400}, {name: 'Toshiba', price: 1100}, {name: 'Lenovo', price: 1220}];
var wearables = [{name: 'Earphones Lux', price: 200}, {name: 'Earphones', price: 12}, {name: 'Leather Case', price: 100}];

app.get('/home', function (req, res) {
   res.render('index', {nav: model.nav, content: model.content});
});

app.get('/phones', function (req, res) {
    res.render('items-list', {nav: model.nav, content: model.content, products: phones})
});

app.get('/tablets', function (req, res) {
    res.render('items-list', {nav: model.nav, content: model.content, products: tablets})
});

app.get('/wearables', function (req, res) {
    res.render('items-list', {nav: model.nav, content: model.content, products: wearables})
});

app.get('*', function (req, res) {
    res.render('index', {nav: model.nav, content: model.content});
});

http.createServer(app).listen(app.get('port'), function ()
{
    console.log("Express server listening on port " + app.get('port'));
});