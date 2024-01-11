'use client'
import React, { useState } from 'react';
import ReactApexChart from 'react-apexcharts';

const PieChart = () => {
    const [series] = useState([44, 55, 13, 43, 22]);
    const [options] = useState({
        chart: {
            width: 400,
            type: 'pie',
        },
        labels: ['Team A', 'Team B', 'Team C', 'Team D', 'Team E'],
        legend: {
            position: 'bottom', // Display the legend at the bottom
            horizontalAlign: 'left', // Center align the legend
        },
        responsive: [
            {
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200,
                    },
                    legend: {
                        position: 'bottom',

                    },
                },
            },
        ],
    });

    return (
        <div className='my-10'>
            <h1 className='font-bold py-5 font-poppins'>Average Conversion Rate</h1>
            <div id="chart" className='w-[300px] h-[300px] bg-white p-2  rounded-lg shadow-lg ' >
                <ReactApexChart options={options} series={series} type="pie" width={360} />
            </div>
        </div>
    );
};

export default PieChart;