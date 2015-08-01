function solve(){
    return function(){
        $.fn.listview = function(data){
            var $this = $(this),
                currentTemplateHTML = $('#' + $this.attr('data-template')).html();
            var compiledTemplate = handlebars.compile(currentTemplateHTML);

            for (var i = 0, len = data.length; i < len; i += 1) {
                var currentDataElement = data[i];
                $this.append(compiledTemplate(currentDataElement));
            }
        };
    };
}

module.exports = solve;

/*(function ($) {
 $.fn.listview = function(data){
 var $this = $(this),
 currentTemplateHTML = $('#' + $this.attr('data-template')).html();
 var compiledTemplate = Handlebars.compile(currentTemplateHTML);

 for (var i = 0, len = data.length; i < len; i += 1) {
 var currentDataElement = data[i];
 $this.append(compiledTemplate(currentDataElement));
 }
 };
 })(jQuery);*/
