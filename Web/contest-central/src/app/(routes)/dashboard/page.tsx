'use client';

import ApexChart from '@/app/_components/ApexChart'
import TopContestants from '@/app/_components/TopContestants';
import TopGroupCard from '@/app/_components/TopGroupCard';
import TopGroups from '@/app/_components/TopGroups';
import TotalCards from '@/app/_components/TotalCards'
import React from 'react'

const page = () => {
  return (
    <div className='py-7 flex flex-col gap-y-20'>
      <div className='flex justify-around items-center'>
        <TotalCards />
        <TotalCards />
        <TotalCards />
        <TotalCards />
      </div>

      <h2 className='font-bold text-xl pl-10'>Average Contest Conversion</h2>
      <div className='flex justify-center items-start w-full gap-x-8'>
      <div className='w-8/12 flex flex-col gap-y-6'>
        <ApexChart />
        <div className='h-screen bg-black'>

        </div>
      </div>
      <div className='flex flex-col gap-y-6'>
        <TopGroups />
        <TopContestants />
      </div>
      </div>
    </div>
  )
}

export default page