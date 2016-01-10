$(document).ready(function () {

    $('#add-input-file').on('click', function () {
        var form = $('#form-upload');

        var count = form.children('input[type="file"]').length;

        var inputTypeFile = $('<input />');
        inputTypeFile.attr('type', 'file');
        inputTypeFile.attr('name', 'file_' + count);
        inputTypeFile.attr('class', 'form-control');

        var inputTypeCheckbox = $('<input />');
        inputTypeCheckbox.attr('type', 'checkbox');
        inputTypeCheckbox.attr('name', 'private_' + count);
        inputTypeCheckbox.attr('class', 'col-md-1');

        var span = $('<span/>');
        span.text('Private');

        form.prepend($('<br/>'))
            .prepend($('<br/>'))
            .prepend(span)
            .prepend(inputTypeCheckbox)
            .prepend($('<br/>'))
            .prepend(inputTypeFile);
    });
});