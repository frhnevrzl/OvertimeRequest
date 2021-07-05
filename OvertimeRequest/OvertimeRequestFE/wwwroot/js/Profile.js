var stringnip = $("#nip").val();
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44364/API/account/GetProfileById/' + stringnip,
        dataSrc: ''
    }).done((result) => {
        $('#Nip').val(result.nip);
        $('#FirstName').val(result.firstName);
        $('#LastName').val(result.lastName);
        $('#Phone').val(result.phone);
        var today = new Date(result.birthDate);
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth()).padStart(2, '0');
        var yyyy = today.getFullYear();
        today = yyyy + '-' + mm + '-' + dd;
        console.log(today);
        $('#Birthdate').val(today);
        $('#Salary').val(result.salary);
        $('#Email').val(result.email);
        /*        $('#Password').val(result.password);*/
        $('#gender').val(result.gender);
        $('#religion').val(result.religion);
        $('#departmentId').val(result.departmentId);
        $('#inputManagerId').val(result.managerId);
    }).fail((error) => {
        console.log(error);
    });
    console.log(stringnip);
});
   
function Update() {
    var obj = new Object();
    obj.NIP = $('#Nip').val();
    obj.FirstName = $("#FirstName").val();
    obj.LastName = $("#LastName").val();
    obj.Phone = parseInt($("#Phone").val());
    obj.BirthDate = $("#Birthdate").val();
    obj.Salary = ($("#Salary").val());
    obj.Email = $("#Email").val();
/*    obj.Password = $("#Password").val();*/
    obj.Gender = $("#gender").val();
    obj.Religion = $("#religion").val();
    obj.DepartmentId= parseInt($("#departmentId").val());
    obj.ManagerId= parseInt($("#inputManagerId").val());

    $.ajax({
        url: 'https://localhost:44364/API/account/updateprofile/',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj)
    }).done((result) => {
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
        //alert("Gagal");
        console.log(error);
    })
    console.log(obj);
}

$(document).ready(function () {
    var stringnip = $("#nips").val();
    $('#tableRequestHistory').DataTable({
        ajax: {
            url: "https://localhost:44364/API/overtimeapply/getrequestbynip/" + stringnip,
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
                "data": 'overtimeName'
            },
            {
                "render": function (data, type, row) {
                    return formatDate(row.submissionDate);
                }
                /*"data": 'submissionDate'*/
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
            }
        ]
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
function UpdatePassword() {
    var obj = new Object();
    obj.NIP = $("#nip").val();
    obj.OldPassword = $("#oldPassword").val();
    obj.NewPassword = $("#newPassword").val();
    $.ajax({
        url: 'https://localhost:44364/API/account/ChangePassword/',
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