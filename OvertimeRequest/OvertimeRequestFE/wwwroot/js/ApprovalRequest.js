$(document).ready(function () {
    //var urlPost = "";
    //if ($("#role").val() == "Manager") {
    //    urlPost = "https://localhost:44364/api/overtimeapply/GetAllRequestByStatus?status=0";
    //} else if ($("#role").val() == "Finance") {
    //    urlPost = "https://localhost:44364/api/overtimeapply/GetAllRequestByStatus?status=1";
    //}
    $('#tableOvertimeapply').DataTable({
        ajax: {
            url: "https://localhost:44364/api/overtimeapply/GetAllRequestByStatus?status=0",
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
                "data": 'overtimeId'
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-info" onclick="detail('${row['overtimeId']}')" data-toggle="modal" data-target="#detailapprove"><i class="fa fa-edit" aria-hidden="true"></i></button > `
                }
            }
        ]
    });
    console.log();
});
function detail(overtimeid) {
    $.ajax({
        url: 'https://localhost:44364/api/overtimeapply/GetRequestById/' + overtimeid,
        type: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
    }).done((result) => {
        console.log(JSON.stringify(result));
        $("#overtimeId").val(result[0]['overtimeId']);
        $("#nip").val(result[0]['nip']);
        $("#submissionDate").val(formatDate(result[0]['submissionDate']));
        $("#requestDetail").val(result[0]['task']);
        var urlGet = "https://localhost:44364/API/account/GetProfileById/" + result[0]['nip'];
        $.get(urlGet, function (data) {
            $("#employeename").val(data['firstName'] + " " + data['lastName']);
        });
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Show',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
}

$("#UpdateBtn").on("click", function () {
    var objectData = new Obect();
    objectData.NIP = $("#nip").val();
    objectData.overtimeApplyId = $("#overtimeid").val();
    //if (role == "Manager") {
    //    objectData.Status = 1;
    //} else if (role == "Finance") {
    //    objectData.Status = 2;
    //}
    objectData.Status = 1;
    $.ajax({
        url: 'https://localhost:44364/api/overtimeapply/approval',
        type: "PUT",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(objectData)
    }).done((result) => {
        $("#tableOvertimeapply").DataTable().ajax.reload();
        Swal.fire({
            title: 'Berhasil!',
            text: 'Data Berhasil Di Approve!',
            icon: 'Success',
            confirmButtonText: 'Next'
        });
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Approve',
            icon: 'Error',
            confirmButtonText: 'Next'
        });
    });
});

$("#rejectBtn").on("click", function () {
    var objectData = new Obect();
    objectData.NIP = $("#nip").val();
    objectData.overtimeApplyId = $("#overtimeid").val();
    objectData.Status = 3;
    $.ajax({
        url: 'https://localhost:44364/api/overtimeapply/approval',
        type: "PUT",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(objectData)
    }).done((result) => {
        $("#tableOvertimeapply").DataTable().ajax.reload();
        Swal.fire({
            title: 'Berhasil!',
            text: 'Data Berhasil Di Reject!',
            icon: 'Success',
            confirmButtonText: 'Next'
        });
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Reject',
            icon: 'Error',
            confirmButtonText: 'Next'
        });
    });
});

function formatDate(date) {
    var month = String(d.getMonth() + 1);
    var day = String(d.getDate());
    var year = String(d.getFullYear());
    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    return `${day}-${month}-${year}`;
}