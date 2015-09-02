/*
 define(['jquery', 'handlebars'], function ($, handlebars) {

 var templates = function () {
 console.log('HERE too');

 var get = function (name) {
 var promise = new Promise(function(resolve, reject){
 var url = `.././templates/${name}.html`;
 $.ajax({
 url: url,
 method: 'GET',
 success: function (templateHtml) {
 var currentTemplate = handlebars.compile(templateHtml);
 resolve(currentTemplate);
 }
 })
 });

 return promise;
 };

 return {
 get: get
 }
 };
 return templates;
 });
 */

import $ from "bower_components/jquery/dist/jquery.js";
import handlebars from "bower_components/handlebars/handlebars.js";
import "scripts/events.js";

var templates = (function () {

    var get = function (name) {
        var promise = new Promise(function(resolve, reject){
            var url = `templates/${name}.html`;
            $.ajax({
                url: url,
                method: 'GET',
                success: function (templateHtml) {
                    var currentTemplate = handlebars.compile(templateHtml);
                    resolve(currentTemplate);
                }
            })
        });

        return promise;
    };

    return {
        get: get
    }
}());

export default templates;