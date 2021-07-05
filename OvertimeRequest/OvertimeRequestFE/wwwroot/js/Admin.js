var url = 'https://localhost:44364/API/roles/';

$.getJSON(url, function (response) {
    console.log(response);
    var data = response.map(item => item.roleName).filter((value, index, self) => self.indexOf(value) === index);
    console.log(data);
    var dataCount = response.map(item => item.accountRoles.length);
    console.log(dataCount);

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