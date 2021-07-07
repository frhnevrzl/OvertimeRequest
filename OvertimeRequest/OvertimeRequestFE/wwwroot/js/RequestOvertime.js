var table = null;
var listOvertime = [];
var totalOvertime = 0;
var table = null;
var rowIndex = 0;
var nips = $("#nips").val();
var emails = $("#emails").val();

function AddListOvertime() {
    //hitung durasi
    var difference = moment($("#etime").val(), 'hh:mm:ss').diff(moment($("#stime").val(), 'hh:mm:ss'), 'hours');
    totalOvertime = totalOvertime + difference;
    if (totalOvertime > 3) {
        document.getElementById("overtimeLimit").style.display = "block";
    } else {
        document.getElementById("overtimeLimit").style.display = "none";
        var tempList = {
            NIP: nips,
            Email: emails,
            SubmissionDate : $("#date").val(),
            OvertimeName: $("#overtimeTitle").val(),
            StartTime: concatDateWithHoursMinute($("#date").val(), $("#stime").val()),
            EndTime: concatDateWithHoursMinute($("#date").val(), $("#etime").val()),
            Task: $("#task").val(),
            Difference: difference
        }
        listOvertime.push(tempList);
        var tableBody = document.querySelector("table > tbody");
        const row = tableBody.insertRow(rowIndex);
        const cell1 = row.insertCell(0);
        const cell2 = row.insertCell(1);
        const cell3 = row.insertCell(2);
        const cell4 = row.insertCell(3);
        const cell5 = row.insertCell(4);
        cell1.textContent = rowIndex + 1;
        cell2.innerHTML = `<td><input style="border:none;" name="etime" value="${document.getElementById("stime").value}" readonly></input></td>`;
        cell3.innerHTML = `<td><input style="border:none;" name="etime" value="${document.getElementById("etime").value}" readonly></input></td>`;
        cell4.innerHTML = `<td><input style="border:none;" name="task" value="${document.getElementById("task").value}" readonly></input></td>`;
        cell5.innerHTML = `<td><button type="button" class="btn btn-info" onclick="deleteItem(this)"><i class="fa fa-trash" aria-hidden="true" data-placement="top" title="Delete"></i></button></td>`
        //cell5.innerHTML = `<td><input style="border:none;" name="addintionalSalary" value="${additionalSalary(difference)}" readonly></input><td>`;
        rowIndex = rowIndex + 1;
    }
}
function deleteItem(e) {
    var index = e.parentNode.parentNode.rowIndex - 1;
    document.getElementById("bodyTableRequest").deleteRow(index);
    totalOvertime = totalOvertime - listOvertime[index].difference;
    rowIndex--;
    listOvertime.splice(index, 1);
}
//function additionalSalary(param) {
//    //ambil tengah dr 68k - 86k untuk data dummy dulu
//    return param * 74000;
//}

function concatDateWithHoursMinute(date, hoursMinute) {
    return date + ' ' + hoursMinute + ":00";
}

function AddOvertimeForm() {
    console.log(JSON.stringify(listOvertime));
    $.ajax({
        url: 'https://localhost:44364/API/overtimeapply/addlistovertime',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(listOvertime)
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'Your Request Has Been Added, Waiting For Approval',
            icon: 'success',
            confirmButtonText: 'Next'
        })
    }).fail((error) => {
        Swal.fire({
            position : 'center',
            title: 'Error!',
            text: 'Please Check Your Data',
            icon: 'error',
            confirmButtonText: 'Back'
        })
        console.log(error);
    });
}
