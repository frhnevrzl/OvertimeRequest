var table = null;
var listOvertime = [];
var totalOvertime = 0;
var table = null;
var rowIndex = 0;

function AddListOvertime() {
    var difference = moment($("#etime").val(), 'hh:mm:ss').diff(moment($("#stime").val(), 'hh:mm:ss'), 'hours');
    totalOvertime = totalOvertime + difference;
    if (totalOvertime > 3) {
        document.getElementById("overtimeLimit").style.display = "block";
    } else {
        document.getElementById("overtimeLimit").style.display = "none";
        var tempList = {
            StartTime: $("#stime").val(),
            EndTime: $("#etime").val(),
            Task: $("#task").val(),
            AdditionalSalary: difference * 100000
        }
        listOvertime.push(tempList);
        var tableBody = document.querySelector('table > tbody');
        const row = tableBody.insertRow(rowIndex);
        const cell1 = row.insertCell(0);
        const cell2 = row.insertCell(1);
        const cell3 = row.insertCell(2);
        const cell4 = row.insertCell(3);
        const cell5 = row.insertCell(4);
        cell1.textContent = rowIndex + 1;
        cell2.textContent = document.getElementById("stime").value;
        cell3.textContent = document.getElementById("etime").value;
        cell4.textContent = document.getElementById("task").value;
        cell5.textContent = difference * 100000;
        rowIndex = rowIndex + 1;
        //$("#stime").val(null);
        //$("#etime").val(null);
        //$("#task").val(null);
    }
}

function AddOvertimeForm() {
    var obj = new Object();
    obj.NIP = parseInt( $("#nip").val());
    obj.OvertimeName = $("#overtimeTitle").val();
    obj.SubmissionDate = $("#date").val();
    obj.StartTime = $("#stime").val();
    obj.EndTime = $("#etime").val();
    obj.Task = $("#task").val();
    console.log(obj);

    $.ajax({
        url: 'https://localhost:44364/API/overtimeapply/addovertime',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'Your Request Has Been Added, Waiting For Approval',
            icon: 'success',
            confirmButtonText: 'Next'
        })
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Your Request Failed to Submit',
            text: 'Please Check Your Data',
            icon: 'error',
            confirmButtonText: 'Back'
        })
        console.log(error);
    })
}
