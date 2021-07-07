$(document).ready(function () {
    $('#tableEmployee').DataTable({
        ajax: {
            url: 'https://localhost:44364/API/account/GetAllProfile',
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
                "render": function (data, type, row) {
                    return row['firstName'];
                }
            },
            {
                "render": function (data, type, row) {
                    return row['lastName'];
                }
            },
            {
                "data": 'phone'
            },
            {
                "data": 'email'
            },
            {
                "data": 'managerId'
            },
            {
                "data": 'roleId'
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-danger" onclick="deleted('${row.nip}')"><i class="fa fa-trash" aria-hidden="true" data-placement="top" title="Delete"></i></button > `
                }
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-info" onclick="get('${row['nip']}')" data-toggle="modal" data-target="#modalAssignRole"><i class="fa fa-edit" aria-hidden="true" data-placement="top" title="Edit"></i></button > `
                }
            }
        ]
    });
    console.log();
});
function deleted(stringnip) {
    Swal.fire({
        title: 'Yakin ingin menghapus data?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ya',
        cancelButtonText: 'Tidak'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44364/API/account/deleteprofile/' + stringnip,
                type: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
            }).done((result) => {
                $('#tableEmployee').DataTable().ajax.reload();
                Swal.fire({
                    title: 'Success!',
                    text: 'Data Has Been Deleted',
                    icon: 'success',
                    confirmButtonText: 'Next'
                })
            }).fail((error) => {
                Swal.fire({
                    title: 'Error!',
                    text: 'Data Cannot Deleted',
                    icon: 'Error',
                    confirmButtonText: 'Next'
                })
            });
        }
    })
    
}
function get(stringnip) {
    $.ajax({
        url: 'https://localhost:44364/API/account/getprofilebyid/' + stringnip,
        dataSrc: ''
    }).done((result) => {
        $("#nip").val(result.nip);
/*        $('#oldPassword').val(result.password);*/
    }).fail((error) => {
        console.log(error);
    });
}

function UpdateRoles() {
    var obj = new Object();
    obj.NIP = $("#nip").val();
    obj.RoleId = $("#role").val();
    $.ajax({
        url: 'https://localhost:44364/API/account/updateroles',
        type: "PUT",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        $('#tableEmployee').DataTable().ajax.reload();
        Swal.fire({
            title: 'Success!',
            text: 'Your Data Has Been Updated',
            icon: 'success',
            confirmButtonText: 'Next'
        })
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Update',
            icon: 'error',
            confirmButtonText: 'Back'
        })
        console.log(error);
    })
}