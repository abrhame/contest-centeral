import Image from 'next/image'
import React from 'react'
import medal from '../../../public/TopContestantMedal.png'

const TopContestantCard = () => {
  return (
    <div className='flex gap-x-2'>
      <div className='font-medium text-2xl p-2 bg-primaryBlue-200'>
        1.
      </div>
      <div className='flex'>
        <p className='border border-primaryBlue-200 font-medium text-2xl text-center w-60 flex justify-center gap-x-6 items-center'>
          <Image src={medal} alt='Alt' />
           <span>Group 45</span>
           </p>
        <p className='font-medium text-2xl p-2 bg-primaryBlue-200' >80%</p>
      </div>
    </div>
  )
}

export default TopContestantCard