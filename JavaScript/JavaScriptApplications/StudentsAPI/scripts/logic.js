import $ from "bower_components/jquery/dist/jquery.js";

var logic = (function () {

    var url = 'http://persontest.apphb.com/api/',
    contentType = "application/x-www-form-urlencoded; charset=utf-8",
        acceptType = 'application/json';


    function getData() {
        var searchURL = url + 'Person/Get';

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: searchURL,
                method: 'GET',
                contentType: contentType,
               // dataType: 'json',
                success: function (data) {
                    console.log(data);
                    resolve(data);
                }
            });
        });

        return promise;
    }

    function addData() {
        var data = {
            name: 'toshko',
            EGN: 222,
            ID: 192
        };
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                method: 'POST',
                contentType: contentType,
                acceptType: acceptType,
                data: JSON.stringify(data),
                success: function (data) {
                    resolve(data);
                }
            });
        });

        return promise;
    }

    return {
        get: getData,
        add: addData
    }
}());

export default logic;