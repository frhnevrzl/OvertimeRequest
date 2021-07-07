var url = 'https://localhost:44364/API/roles/';
var stringnip = $("#nip").val();

$.getJSON(url, function (response) {
/*    console.log(response);*/
    var data = response.map(item => item.roleName).filter((value, index, self) => self.indexOf(value) === index);
    //console.log(data);
    var dataCount = response.map(item => item.accountRoles.length);
    //console.log(dataCount);

    var options = {
        series: dataCount,
        chart: {
            type: 'pie'
        },
        labels: data
    };

    var chart = new ApexCharts(document.querySelector("#UniCh"), options);
    chart.render();
});

var url2 = 'https://localhost:44364/API/overtimeapply/'/* + stringnip;*/

$.getJSON(url2, function (response) {
    console.log(response);
    var label = response.map(item => item.overtimeApplyEmployees.status).filter((value, index, self) => self.indexOf(value) === index);
    var count = response.map(item => item.length);
});