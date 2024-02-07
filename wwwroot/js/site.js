// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    getDatatable('#table-contacts');
    getDatatable('#table-users');

    $('.btn-total-contacts').click(function () {
        $('#ContactsUserModal').modal();
    });
});
/*$(document).ready(function () {
    $('#table-contacts').DataTable();
});
$(document).ready(function () {
    $('#table-users').DataTable();
});*/


$('.btn-total-contacts').click(function () {
    var userID = $(this).attr('user-id');

    $.ajax({
        type: 'GET', 
        url: '/Users/ListContactsByUserId/' + userID,
        success: function (result) {
            $('#UserContactList').html(result);
            getDatatable('#table-contacts-users');
            $('#ContactsUserModal').modal('show');
        }
    });

});


function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "No contact has been found.",
            "sInfo": "Show _START_ until _END_ of _TOTAL_ registers",
            "sInfoEmpty": "Show 0 until 0 de 0 registers",
            "sInfoFiltered": "(Filter of _MAX_ total registers)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Show _MENU_ registers per page",
            "sLoadingRecords": "Loading...",
            "sProcessing": "Processing...",
            "sZeroRecords": "No register has been found.",
            "sSearch": "Search",
            "oPaginate": {
                "sNext": "Next",
                "sPrevious": "Back",
                "sFirst": "First",
                "sLast": "Last"
            },
            "oAria": {
                "sSortAscending": ": Order colums ascending",
                "sSortDescending": ": Order colums descending"
            }
        }
    });
}



$('.close-alert').click(function (){
    $('.alert').hide('hide');
});