import React from "react";
import Chart from "react-apexcharts";

const ApexChart = () => {
  const options: any = {
    chart: {
      id: "basic-line",
    },
    dataLabels: {
      enabled: false
    },
    xaxis: {
      categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    },
    yaxis: {
      title: {
        text: 'Sales',
      },
      min: 0,
      max: 150,
      labels: {
        formatter: function (value: any) {
          return value.toFixed(0);
        },
      },
    },
    stroke: {
      curve: 'smooth',
      width: 2,
    },
    fill: {
      type: 'gradient',
      gradient: {
        shade: 'light',
        type: 'vertical',
        shadeIntensity: 0.9,
        gradientToColors: ['#ADD8E6'],
        inverseColors: false,
        opacityFrom: 0.9,
        opacityTo: 0.8,
        stops: [0, 100],
      },
    },
  };

  const series = [
    {
      name: "series-1",
      data: [30, 40, 35, 50, 49, 60, 70, 91, 125, 94, 98, 120],
    },
  ];

  return (
    <div className="app">
      <div className="row">
        <div className="mixed-chart">
          <Chart options={options} series={series} type="area" width="500" height="300" />
        </div>
      </div>
    </div>
  );
};

export default ApexChart;
