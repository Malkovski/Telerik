module.exports = {
    getDate: function () {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }

        return  yyyy + '-' + mm + '-' + dd;
    },
    queryToArray: function (query) {
        var  array = [];

        for(var item in query) {
            array.push(query[item]);
        }

        return array;
    },
    isEmptyObj: function (obj) {
        for(var prop in obj) {
            if(obj.hasOwnProperty(prop))
                return false;
        }

        return true;
    }
};