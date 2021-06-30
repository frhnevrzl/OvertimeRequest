function get(stringnik){
    $.ajax({
        url: 'https://localhost:44364/API/account/GetProfileById' + stringnik,
        dataSrc: ''
    }).done((result) => {
        $('#Nip').val(result.nik);
        $('#FirstName').val(result.firstName);
        $('#LastName').val(result.lastName);
        $('#Phone').val(result.phone);
        var today = new Date(result.birthDate);
        console.log(result.birthdate);
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth()).padStart(2, '0');
        var yyyy = today.getFullYear();
        today = yyyy + '-' + mm + '-' + dd;
        console.log(today);
        $('#Birthdate').val(today);
        $('#Salary').val(result.salary);
        $('#Email').val(result.email);
        $('#Password').val(result.password);
        $('#gender').val(result.gender);
        $('#religion').val(result.religion);
        $('#departmentId').val(result.departmentId);
        $('#inputManagerId').val(result.managerId);
    }).fail((error) => {
        console.log(error);
    });
}
function Update() {
    var obj = new Object();
    obj.NIK = $('#Nip').val();
    obj.FirstName = $("#FirstName").val();
    obj.LastName = $("#LastName").val();
    obj.Phone = parseInt($("#Phone").val());
    obj.BirthDate = $("#Birthdate").val();
    obj.Salary = ($("#Salary").val());
    obj.Email = $("#Email").val();
    obj.Password = $("#Password").val();
    obj.Gender = $("#gender").val();
    obj.Religion = parseInt($("#religion").val());
    obj.DepartmentId= parseInt($("#departmentId").val());
    obj.ManagerId= parseInt($("#inputManagerId").val());

    $.ajax({
        url: 'https://localhost:44364/API/account/updateprofile',
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
}