var url = 'https://localhost:44364/API/roles/';

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

    var chart = new ApexCharts(document.querySelector("#SalCh"), options);
    chart.render();
});