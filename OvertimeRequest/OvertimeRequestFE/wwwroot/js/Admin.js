var url = 'https://localhost:44364/API/roles/';
var stringnip = $("#nip").val();

$.getJSON(url, function (response) {
    console.log(response);
    var data = response.map(item => item.roleName).filter((value, index, self) => self.indexOf(value) === index);
    console.log(data);
    var dataCount = response.map(item => item.accountRoles.length);
    console.log(dataCount);
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

var url2 = 'https://localhost:44364/API/overtimeapply/'
$.getJSON(url2, function (response) {
    console.log(response);
    var data = response.map(item => item.overtimeApplyEmployees.status).filter((value, index, self) => self.indexOf(value) === index);
    console.log(data);
    var dataCount = response.map(item => item.overtimeApplyEmployees.length);
    console.log(dataCount);

    var options = {
        series: dataCount,
        chart: {
            type: 'donut'
        },
        labels: data
    };

    var chart = new ApexCharts(document.querySelector("#ReqCh"), options);
    chart.render();
});