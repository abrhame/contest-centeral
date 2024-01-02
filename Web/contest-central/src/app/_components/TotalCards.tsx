import Image from 'next/image'
import React from 'react'
import totalCandidates from '../../../public/totalCandidates.png'

const TotalCards = () => {
  return (
    <div className='flex h-auto shadow-lg shadow-gray-400 rounded-2xl py-3 pl-3 pr-20 gap-x-3 bg-white'>
      <Image src={totalCandidates} alt='alt' className='' /> 
      <div className='text-lg text-primaryGray-400'>
        <p>Total Contest</p>
        <p className='text-black font-semibold'>200</p>
      </div>
    </div>
  )
}

export default TotalCards