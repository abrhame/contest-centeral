'use client'
import React from 'react';
import ReactApexChart from 'react-apexcharts';

const UserChart = () => {
    const series = [
        {
            name: 'series1',
            data: [31, 40, 28, 51, 42, 109, 100]
        },
        {
            name: 'series2',
            data: [11, 32, 45, 32, 34, 52, 41]
        }
    ];

    const options = {
        chart: {
            height: 350,
            type: 'area'
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth'
        },
        xaxis: {
            type: 'datetime',
            categories: [
                "2018-09-19T00:00:00.000Z",
                "2018-09-19T01:30:00.000Z",
                "2018-09-19T02:30:00.000Z",
                "2018-09-19T03:30:00.000Z",
                "2018-09-19T04:30:00.000Z",
                "2018-09-19T05:30:00.000Z",
                "2018-09-19T06:30:00.000Z"
            ]
        },
        tooltip: {
            x: {
                format: 'dd/MM/yy HH:mm'
            }
        }
    };

    return (
        <div className='w-full shadow-md md:w-4/5 md:mx-auto lg:w-5/12 bg-white p-2 md:p-4 lg:p-8 rounded-md font-poppins'>
            <h1 className='text-xl p-2 text-primaryBlue-300 font-poppins font-semibold'>Status</h1>
            <hr />
            <div className='flex justify-between py-3'>
                <div className=' text-xl my-auto text-primaryGray-500 '>Conversion Rate : <span>40%</span></div>
                <select id="months" className="bg-gray-50 border p-2 border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block :border-blue-500">
                    <option selected>select</option>
                    <option value="january">January</option>
                    <option value="february">February</option>
                    <option value="march">March</option>
                    <option value="april">April</option>
                </select>
            </div>
            <div id="chart">
                <ReactApexChart options={options} series={series} type="area" height={350} />
            </div>
        </div>

    );
};

export default UserChart;