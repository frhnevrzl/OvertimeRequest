$(document).ready(function () {
    var urlPost = "";
    if ($("#role").val() == "Manager") {
        urlPost = "https://localhost:44364/api/overtimeapply/GetAllRequestByStatusAndManagerId?status=0&managerId="+$("#managerId").val();
    } else if ($("#role").val()  == "Finance") {
        urlPost = "https://localhost:44364/api/overtimeapply/GetAllRequestByStatus?status=1";
    }
    console.log(urlPost);
    $('#tableOvertimeapply').DataTable({
        ajax: {
            url: urlPost,
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
                    return row.firstName + " " + row.lastName;
                }
            },
            {
                "render": function (data, type, row) {
                    return formatDate(row.submissionDate);
                }
                /*"data": 'submissionDate'*/
            },
            {
                "data" : 'task'
            },
            {
/*                "data": 'status'*/
                "render": function (data, type, row) {
                    if (row.status != null) {
                        if (row.status == 0) {
                            return ("Waiting For Approval");
                        }
                        else if (row.status == 1) {
                            return ("Approved By Manager");
                        }
                        else if (row.status == 2) {
                            return ("Approved By Finance Manager");
                        }
                        else if (row.status == 3) {
                            return ("Rejected");
                        }
                    }
                    else {
                        return ("No Data");
                    }
                }
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-info" onclick="detail('${row['overtimeId']}')" data-toggle="modal" data-placement="top" title="Detail" data-target="#detailapprove"><i class="fa fa-edit" aria-hidden="true"></i></button > `
                }
            }
        ]
    });
/*    console.log($("#role").val());*/
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
        $("#overtimeid").val(result[0]['overtimeId']);
        $("#nip").val(result[0]['nip']);
        $("#email").val(result[0]['email']);
        $("#submissionDate").val(formatDate(result[0]['submissionDate']));
        $("#requestDetail").val(result[0]['task']);
        $("#overtimeTitle").val(result[0]['overtimeName']);
        var durasi = result[0]['additionalSalary'] / 74000 + "jam";
        $("#durasi").val(durasi);
        $("#additionalsalary").val(result[0]['additionalSalary']);
        $("#stime").val(formatHour(result[0]['startTime']));
        $("#etime").val(formatHour(result[0]['endTime']));
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Show',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
    console.log(durasi);
}


$("#UpdateBtn").on("click", function () {
    var objectData = new Object();
    objectData.NIP = $("#nip").val();
    objectData.Email = $("#email").val();
    objectData.overtimeApplyId = $("#overtimeid").val();
    if ($("#role").val() == "Manager") {
        objectData.Status = 1;
    } else if ($("#role").val() == "Finance") {
        objectData.Status = 2;
    }
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
            icon: 'success',
            confirmButtonText: 'Next'
        });
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Approve',
            icon: 'error',
            confirmButtonText: 'Next'
        });
    });
    console.log(objectData.Email);
});

$("#rejectBtn").on("click", function () {
    var objectData = new Object();
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

function formatDate(param) {
    var date = new Date(param);
    var month = String(date.getMonth() + 1);
    var day = String(date.getDate());
    var year = String(date.getFullYear());
    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    return `${day}-${month}-${year}`;
}
function formatHour(param) {
    var date = new Date(param);
    var hour = String(date.getHours());
    var min = String(date.getMinutes());
    var sec = String(date.getSeconds());
    if (hour.length < 2) hour = '0' + hour;
    if (min.length < 2) min = '0' + min;
    if (sec.length < 2) sec = '0' + sec;
    return `${hour}:${min}:${sec}`;
}

////