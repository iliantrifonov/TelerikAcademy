$(document).ready(function() {
    $('#add-file').on('click', function() {
        var inputs = $('#upload-form input[type="file"]').length;
        var label = $('<label />');
        label.attr('for', 'file' + inputs);
        label.text('File');

        var inputFile = $('<input />');
        inputFile.attr('type', 'file');
        inputFile.attr('name', 'file_' + inputs);
        inputFile.attr('id', 'file' + inputs);
        inputFile.addClass('form-control');

        var labelPrivate = $('<label />');
        labelPrivate.attr('for', 'private' + inputs);
        labelPrivate.text('Private');

        var inputPrivate = $('<input />');
        inputPrivate.attr('type', 'checkbox');
        inputPrivate.attr('name', 'file_' + inputs + 'private');
        inputFile.attr('id', 'private' + inputs);

        inputPrivate.addClass('checkbox');

        var div = $('<div />').addClass('form-group')
        div.append(label)
        div.append(inputFile)
        div.append(labelPrivate)
        div.append(inputPrivate);
        var d = $('<div />');
        $('#upload-form').prepend(div);
    })
});