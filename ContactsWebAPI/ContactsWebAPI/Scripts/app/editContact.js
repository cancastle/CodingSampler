$(document).ready(function () {
    $('#btnShowEditContact').click(function() {
        $('#editContactModal').modal('show');
    });

    //a function to get by ID to populate the form prior to editing

    $('#btnLookupContact').click(function () {

        var id = $('#contactIDforEdit').val();
        var uri = '/api/contacts/';

        $.getJSON(uri + id)
        .done(function(data) {
            $('#nameForEdit').val(data.Name);
            $('#phonenumberForEdit').val(data.PhoneNumber);
        })
        .fail(function (jqXhr, status, err) {
            $('#errorTextHere').text('Error: ' + err);
        });    
    });

    $('#btnSaveEditedContact').click(function () {
        var contact = {};
        //name must be different for contactId since this is used in other script
        contact.ContactID = $('#contactIDforEdit').val();
        contact.Name = $('#nameForEdit').val();
        contact.PhoneNumber = $('#phonenumberForEdit').val();

        $.ajax({
            url: uri,
            type: 'put',
            data: contact,
            success: function() {
                loadContacts();
                $('#editContactModal').modal('hide');
            },
            error: function(xhr, status, err) {
                alert('error:' + err);
            }
        });
    });
});

