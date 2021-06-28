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
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-danger" onclick="deleted('${row['nip']}')"><i class="fa fa-trash" aria-hidden="true"></i></button > `
                }
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-info" onclick="get('${row['nip']}')" data-toggle="modal" data-target="#modalChangePass"><i class="fa fa-edit" aria-hidden="true"></i></button > `
                }
            }
        ]
    });
    console.log();
});