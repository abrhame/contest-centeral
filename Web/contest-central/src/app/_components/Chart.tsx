'use client'
import React from 'react';
import ReactApexChart from 'react-apexcharts';

const Chart = () => {
    const series = [
        {
            name: 'Problems',
            data: [44, 55, 41, 67, 22, 43, 21],
        },
    ];

    const options = {
        annotations: {
            points: [
                {
                    x: 'Bananas',
                    seriesIndex: 0,
                    label: {
                        borderColor: '#775DD0',
                        offsetY: 0,
                        style: {
                            color: '#fff',
                            background: '#775DD0',
                        },
                        text: 'Bananas are good',
                    },
                },
            ],
        },
        chart: {
            height: 350,
            type: 'bar',
        },
        plotOptions: {
            bar: {
                borderRadius: 5,
                columnWidth: '30%',
            },
        },
        dataLabels: {
            enabled: false,
        },
        stroke: {
            width: 0,
        },
        grid: {
            row: {
                colors: ['#fff'],
            },
        },
        xaxis: {
            labels: {
                rotate: -45,
            },
            categories: ['1', '2', '3', '4', '5', '6', '7'],
            tickPlacement: 'on',
        },
        yaxis: {
            title: {},
        },
        fill: {
            type: 'gradient',
            gradient: {
                shade: 'dark',
                type: 'vertical',
                shadeIntensity: 0.5,
                gradientToColors: ['#264ECA'],
                inverseColors: true,
                opacityFrom: 1,
                opacityTo: 0.4,
                stops: [0, 100],
            },
        },
    };

    return (
        <div className='my-10'>
       
            <h1 className='font-bold py- font-poppins'>Problem Status</h1>
            <div id="chart" className='w-[320px] h-[360px]  bg-white p-2  rounded-lg shadow-lg ' >
                <ReactApexChart options={options} series={series} type="bar" height={350} />
            </div>
       
        </div>
    );
};

export default Chart;