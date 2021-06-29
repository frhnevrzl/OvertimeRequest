$(document).ready(function () {
    $('#tableOvertimeapply').DataTable({
        ajax: {
            url: 'https://localhost:44364/api/overtimeapply/getallrequest',
            dataSrc: ''
        },
        columns: [
            {
                "data": null, "sortable": true,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": 'nip'
            },
            {
                "data": 'status'
            },
            {
                "data": 'overtimeapplyId'
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-info" onclick="get('${row['nip']}')" data-toggle="modal" data-target="#detailapprove"><i class="fa fa-edit" aria-hidden="true"></i></button > `
                }
            }
        ]
    });
    console.log();
});
//function deleted(stringnip) {
//    $.ajax({
//        url: 'https://localhost:44364/API/account/deleteprofile/' + stringnip,
//        type: "POST",
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//    }).done((result) => {
//        $('#tableEmployee').DataTable().ajax.reload();
//        Swal.fire({
//            title: 'Success!',
//            text: 'Data Has Been Deleted',
//            icon: 'success',
//            confirmButtonText: 'Next'
//        })
//    }).fail((error) => {
//        Swal.fire({
//            title: 'Error!',
//            text: 'Data Cannot Deleted',
//            icon: 'Error',
//            confirmButtonText: 'Next'
//        })
//    });
//}