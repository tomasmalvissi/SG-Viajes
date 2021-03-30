$(document).ready(function () {
    //peticion api
    $.ajax({
        type: "GET",
        contentType: "application/json; charset:ufo-8",
        dataType: "json",
        url: "",
        success: function (data) {
            console.log(data);
            Grafica(data);
        }
    })
});

function Grafica(data) {

    const chart = Highcharts.chart('container', {
        title: {
            text: 'Chart.update'
        },
        subtitle: {
            text: 'Plain'
        },
        xAxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
        },
        series: [{
            type: 'column',
            colorByPoint: true,
            data: data,
            showInLegend: false
        }]
    });

    document.getElementById('plain').addEventListener('click', () => {
        chart.update({
            chart: {
                inverted: false,
                polar: false
            },
            subtitle: {
                text: 'Plain'
            }
        });
    });

    document.getElementById('inverted').addEventListener('click', () => {
        chart.update({
            chart: {
                inverted: true,
                polar: false
            },
            subtitle: {
                text: 'Inverted'
            }
        });
    });

    document.getElementById('polar').addEventListener('click', () => {
        chart.update({
            chart: {
                inverted: false,
                polar: true
            },
            subtitle: {
                text: 'Polar'
            }
        });
    });


}