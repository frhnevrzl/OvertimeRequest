﻿var url = 'https://localhost:44364/API/roles/';
var stringnip = $("#nip").val();

$.getJSON(url, function (response) {
/*    console.log(response);*/
    var data = response.map(item => item.roleName).filter((value, index, self) => self.indexOf(value) === index);
/*    console.log(data);*/
    var dataCount = response.map(item => item.accountRoles.length);
/*    console.log(dataCount);*/
    var options = {
        series: [{
            data: dataCount
        }],
        chart: {
            type: 'bar',
            height: 350
        },
        plotOptions: {
            bar: {
                borderRadius: 4,
                horizontal: true,
            }
        },
        dataLabels: {
            enabled: true
        },
        xaxis: {
            categories: data,
        }
    };

    var chart = new ApexCharts(document.querySelector("#UniCh"), options);
    chart.render();
});

$.ajax({
    url: 'https://localhost:44364/API/account/Getallprofile/',
    dataSrc: ''
}).done((result) => {
/*    console.log(result.length);*/
    $("#lblEmp").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44364/API/overtimeapply/getallrequest/',
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblOvt").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44364/API/account/Getallprofile/',
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblReg").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44364/API/roles/',
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblRole").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44364/API/overtimeapply/getrequestbynip/' + stringnip,
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblReq").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44364/api/overtimeapply/GetAllRequestByStatusAndNip?status=2&nip=' + stringnip,
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblApv").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44364/api/overtimeapply/GetAllRequestByStatusAndNip?status=3&nip=' + stringnip,
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblRjc").html(result.length);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: 'https://localhost:44364/api/overtimeapply/GetAllRequestByStatusAndNip?status=0&nip=' + stringnip,
    dataSrc: ''
}).done((result) => {
    /*    console.log(result.length);*/
    $("#lblWait").html(result.length);
}).fail((error) => {
    console.log(error);
});