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
    <div className="bg-white rounded-xl py-4 px-3">
        <div className="flex items-center justify-end space-x-4 mb-4 mx-5">
          <div className="flex">
            <div className="border border-gray-300 px-2 py-1 rounded text-gray-500">Box 1</div>
            <div className="border border-gray-300 px-2 py-1 rounded text-gray-500">Box 2</div>
            <div className="border border-gray-300 px-2 py-1 rounded bg-blue-300 text-blue-800">Box 3 (Active)</div>
          </div>

          <select className="border border-gray-300 text-gray-500 px-2 py-1 rounded">
            <option value="all">All</option>
            <option value="this-year">This Year</option>
            <option value="last-year">Last Year</option>
          </select>
        </div>

      <div className="row">
        <div className="mixed-chart">
          <Chart options={options} series={series} type="area" width="800" height="400" />
        </div>
      </div>
    </div>
  );
};

export default ApexChart;
