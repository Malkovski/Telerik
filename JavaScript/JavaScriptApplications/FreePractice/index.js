var db = (function () {

    function getJSON(url, contentType, acceptType) {
        $.ajax({
            url: url,
            method: 'GET',
            contentType: contentType || '',
            acceptType: acceptType || '',
            success: function (data) {

            },
            error: function (err) {

            }
        })
    }

    function postJSON(url, contentType, acceptType, data) {
        $.ajax({
            url: url,
            method: 'POST',
            contentType: contentType,
            acceptType: acceptType,
            data: JSON.stringify(data),
            success: function (data) {

            },
            error: function (err) {

            }
        })
    }

    return {
        getJSO: getJSON,
        postJSON: postJSON
    }
}());