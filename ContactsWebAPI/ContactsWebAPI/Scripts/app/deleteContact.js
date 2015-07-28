$(document).ready(function() {
    $('#btnShowDeleteContact').click(function() {
        $('#deleteContactModal').modal('show');
    });

    $('#btnDeleteContact').click(function() {
        var contact = {};

        contact.ContactID = $('#contactID').val();

        $.ajax({
            url: uri + contact.ContactID,
            type: 'delete',
            success: function() {
                loadContacts();
                $('#deleteContactModal').modal('hide');
            },
            error: function(xhr, status, err) {
                alert('error:' + err);
            }
        });
    });
});