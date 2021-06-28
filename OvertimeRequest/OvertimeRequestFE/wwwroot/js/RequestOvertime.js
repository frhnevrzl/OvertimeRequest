document.addEventListener("DOMContentLoaded", function () {
    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    var calendarEl = document.getElementById("calendar");
    var calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ["interaction", "dayGrid", "timeGrid", "resourceTimeline"],
        header: {
            left: "prev,next today",
            center: "title",
            right: "dayGridMonth,timeGridWeek,timeGridDay"
        },
        editable: true,
        events: [
            {
                title: "Sales Meeting",
                start: new Date(y, m, 2, 10, 30),
                end: new Date(y, m, 2, 11, 30),
                allDay: false
            },
            {
                title: "Marketing Meeting",
                start: new Date(y, m, 3, 11, 30),
                end: new Date(y, m, 3, 12, 30),
                allDay: false
            },
            {
                title: "Production Meeting",
                start: new Date(y, m, 4, 15, 30),
                end: new Date(y, m, 4, 16, 30),
                allDay: false
            }
        ]
    });

    calendar.render();
});

function approveOvertimeRequestManager() {
    var object = new Object();
    var Nip = $("#NIP").val();
    var idOvertime = $("#idOvertime").val();
    object.NIP = Nip;
    object.Status = 1;
    object.overtimeApplyId = idOvertime;
}

function approveOvertimeRequestFinance() {
    var object = new Object();
    var Nip = $("#NIP").val();
    var idOvertime = $("#idOvertime").val();
    object.NIP = Nip;
    object.Status = 2;
    object.overtimeApplyId = idOvertime;
}
function RejcetOvertimeRequest() {
    var Nip = $("#NIP").val();
    if ()
}
