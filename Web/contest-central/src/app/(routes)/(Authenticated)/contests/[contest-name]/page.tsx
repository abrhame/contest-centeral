
import Chart from '@/app/_components/Chart';
import ParticipantsTable from '@/app/_components/ParticipantsTable';
import { PieChart } from '@mui/icons-material';
import React from 'react'

type Participant = {
    name: string;
    codeforceHandle: string;
    totalSubmission: string;
    wrongSubmission: string;
    problemSolved: string;
    conversionRate: string;
    rank: string;
};

const participants: Participant[] = [
    {
        name: 'Ibsa Abraham',
        codeforceHandle: '@Ibsa',
        totalSubmission: '6',
        wrongSubmission: '2',
        problemSolved: '30',
        conversionRate: '0.83',
        rank: '2'
    },
    {
        name: 'Ibsa Abraham',
        codeforceHandle: '@Ibsa',
        totalSubmission: '6',
        wrongSubmission: '2',
        problemSolved: '30',
        conversionRate: '0.83',
        rank: '2'
    },
    {
        name: 'Ibsa Abraham',
        codeforceHandle: '@Ibsa',
        totalSubmission: '6',
        wrongSubmission: '2',
        problemSolved: '30',
        conversionRate: '0.83',
        rank: '2'
    },
    {
        name: 'Ibsa Abraham',
        codeforceHandle: '@Ibsa',
        totalSubmission: '6',
        wrongSubmission: '2',
        problemSolved: '30',
        conversionRate: '0.83',
        rank: '2'
    }
]

const ParticipantsHeader = [
    'Student Name', 'Codeforce Handle', 'Total Sumission', 'Wrong Submission', 'Problems Solved', 'Conversion Rate', 'Rank'
]

const ContestDetail = () => {
    return (
        <div className='bg-[#F6F6F9] h-screen flex flex-col-reverse md:flex-row'>
            <ParticipantsTable data={participants} headers={ParticipantsHeader} />
            <div >
                <Chart />
                <PieChart />
            </div>
        </div>
    )
}

export default ContestDetail
