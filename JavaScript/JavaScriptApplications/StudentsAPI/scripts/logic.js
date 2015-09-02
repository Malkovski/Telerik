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
            })
        });

        return promise;
    }

    return {
        get: getData
    }
}());

export default logic;