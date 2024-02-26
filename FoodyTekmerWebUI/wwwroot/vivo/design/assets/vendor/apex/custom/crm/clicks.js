var options = {
    series: [42, 47, 52, 58, 65],
    chart: {
        width: 320,
        type: 'polarArea'
    },
    labels: ['Home', 'About', 'Contact', 'Ads', 'Signup'],
    fill: {
        opacity: 1
    },
    stroke: {
        width: 1,
        colors: undefined
    },
    colors: ['#435EEF', '#59a2fb', '#8ec0fd', '#cce2fd', '#ebf4ff'],
    yaxis: {
        show: false
    },
    legend: {
        position: 'bottom',
    },
    tooltip: {
        y: {
            formatter: function(val) {
                return val + " K"
            }
        }
    },
    plotOptions: {
        polarArea: {
            rings: {
                strokeWidth: 0
            },
            spokes: {
                strokeWidth: 0
            },
        }
    },
};

  var chart = new ApexCharts(document.querySelector("#clicks"), options);
  chart.render();