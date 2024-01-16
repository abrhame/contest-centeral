import Image, { StaticImageData } from 'next/image'
import React from 'react'

export  type Information = {
  image: StaticImageData
  text: string
  num: string
}

type Prop = {
  info: Information
}

const TotalCards = ({ info }: Prop) => {
  return (
    <div className='flex flex-col items-start justify-center md:flex-row md:items-center md:justify-start w-44 h-44 md:w-72 md:h-auto shadow-lg shadow-gray-400 rounded-lg md:rounded-2xl py-3 pl-6 gap-x-3 bg-white'>
      <Image src={info.image} alt='alt' className='' />
      <div className='text-lg text-primaryGray-400'>
        <p>{info.text}</p>
        <p className='text-black font-semibold'>{info.num}</p>
      </div>
    </div>
  )
}

export default TotalCards