function Login() {
    var objectInsert = new Object();
    objectInsert.Email = $("#inputEmailLogin").val();
    objectInsert.Password = $("#inputPasswordLogin").val();
    $.ajax({
        url: 'https://localhost:44308/Login/auth',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(objectInsert),
        dataType: "json"
    }).done((result) => {
        console.log("resultDone: " + result);
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'You Have Logged in',
            showConfirmButton: false,
            timer: 1500
        }) //buat alert pemberitahuan jika success
    }).fail((error) => {
        console.log("eror: " + error);
        alert("Wrong Email or Password");
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: 'Wrong Email or Password!',
            showConfirmButton: false,
            timer: 2000
        });
    });
}
function showSignIn() {
    $("#sectionSignUp").hide();
    $("#sectionSignIn").show();
}
function showSignUp() {
    $("#sectionSignIn").hide();
    $("#sectionSignUp").show();
}
function Insert() {

    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    obj.FirstName = $("#inputFirstName").val();
    obj.LastName = $("#inputLastName").val();
    obj.Phone = parseInt($("#inputPhone").val());
    obj.BirthDate = $("#inputBirthdate").val();
    obj.Salary = parseInt($("#inputSalary").val());
    obj.Email = $("#inputEmail").val();
    obj.Password = $("#inputPassword").val();
    obj.Gender = $("#gender").val();
    obj.Religion = $("#religion").val();
    obj.DepartmentId = $("#departmentId").val();
    //obj.ManagerId = parseInt($("#inputManagerId").val());
    var url = "https://localhost:44364/API/account/GetAllProfile"; 
    $.get(url, function (data) {
        if (data.find(element => element.email == obj.Email)) {
            Swal.fire({
                title: 'Error!',
                text: 'Email Duplicated',
                icon: 'error',
                confirmButtonText: 'Back'
            });
            return false;
        } else {
            $.ajax({
                url: 'https://localhost:44364/API/Account/register',
                type: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(obj)
            }).done((result) => {
                Swal.fire({
                    title: 'Success!',
                    text: 'You Have Been Registered',
                    icon: 'success',
                    confirmButtonText: 'Next'
                }).then((result) => {
                    if (result.isConfirmed) {
                        $('#registerForm').trigger('reset');
                        showSignIn();
                    }
                });
            }).fail((error) => {
                Swal.fire({
                    title: 'Error!',
                    text: 'Failed To Register',
                    icon: 'error',
                    confirmButtonText: 'Back'
                })
                console.log(error);
            });
            return false;
        }
    });
    
}
(function () {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})()