import React from 'react'

const TopGroupCard = () => {
  return (
    <div className='flex gap-x-2'>
      <div className='font-medium text-2xl p-2 bg-primaryYellow-100'>
        1.
      </div>
      <div className='flex'>
        <p className='border border-primaryYellow-100 font-medium text-2xl text-center w-52 flex justify-center items-center'><span>Group 45</span></p>
        <p className='font-medium text-2xl p-2 bg-primaryYellow-100' >80%</p>
      </div>
    </div>
  )
}

export default TopGroupCard