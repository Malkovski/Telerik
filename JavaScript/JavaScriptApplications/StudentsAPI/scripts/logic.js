import $ from "bower_components/jquery/dist/jquery.js";

var logic = (function () {

    var url = 'data/data.json';

    function getData() {
        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                method: 'GET',
                contentType: 'application/json',
                success: function (data) {
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
                contentType: 'application/json',
                acceptType: 'application/json',
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