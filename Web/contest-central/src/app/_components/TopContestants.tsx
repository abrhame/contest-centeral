import React from 'react'
import topGroup from '../../../public/topGroups.png'
import TopGroupCard from './TopGroupCard'
import Image from 'next/image'
import TopContestantCard from './TopContestantCard'

const TopContestants = () => {
  return (
    <div className='bg-white w-96 flex flex-col justify-center items-center gap-y-3 py-4 rounded-xl'>
      <div className='flex justify-center items-center gap-x-3 text-primaryGray-300 text-xl'>
        <div className='p-2.5 w-14 h-14 flex justify-center items-center shadow-lg rounded-full bg-blue-100'>
          <Image src={topGroup} className=' w-11 h-11' alt="Hi" />
        </div>
        <p>Top Groups</p>
      </div>
      <div className='flex flex-col gap-y-2'>
        <TopContestantCard />
        <TopContestantCard />
        <TopContestantCard />
        <TopContestantCard />
        <TopContestantCard />
      </div>
      <button type="button" className="text-primaryGray-300 hover:text-black border border-primaryBlue-200 hover:bg-primaryBlue-200 focus:ring-4 focus:outline-none focus:ring-primaryBlue-200 font-medium rounded-lg text-sm px-5 py-2 text-center me-2 mb-2">See More</button>
    </div>
  )
}

export default TopContestants