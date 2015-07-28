$(document).ready(function () {
    $('#btnShowAddContact').click(function () {
        $('#addContactModal').modal('show');
    });

    $('#btnSaveContact').click(function() {

        var contact = {};

        contact.Name = $('#name').val();
        contact.PhoneNumber = $('#phonenumber').val();

        $.post(uri, contact)
            .done(function() {
                loadContacts();
                $('#addContactModal').modal('hide');
            })
            .fail(function(jqXhr, status, err) {
                alert(status + ' - ' + err);
            });
    });
});