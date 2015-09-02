define(['jquery', 'handlebars'], function () {

    var templates = function () {

        function get(name) {
            var promise = new Promise(function(resolve, reject){
                var url = `.././templates/${name}.html`;
                $.ajax({
                    url: url,
                    method: 'GET',
                    success: function (templateHtml) {
                        var currentTemplate = Handlebars.compile(templateHtml);
                        resolve(currentTemplate);
                    }

                })
            });

            return promise;
        }

        return {
            get
        }
    };
    return templates;
});
