import React from 'react'
import { FaUserAlt } from 'react-icons/fa'


const About = () => {
    return (
        <div className='bg-white rounded-lg shadow-md p-5 lg:p-8 w-full md:w-4/5 md:mx-auto lg:w-1/4 '>
            <h1 className='text-xl px-2 py-2 text-primaryBlue-300 font-poppins font-semibold'>About</h1>
            <ul className='text-gray'>
                <li className='flex gap-5 py-4 hover:text-primaryBlue-400 px-5'>
                    <span className='my-auto '>
                        <FaUserAlt size={20} />
                    </span>
                    <span>
                        Male
                    </span>
                </li>
                <li className='flex gap-5 py-4 hover:text-primaryBlue-400 px-5'>
                    <span className='my-auto '>
                        <FaUserAlt size={20} />
                    </span>
                    <span>
                        Male
                    </span>
                </li>
                <li className='flex gap-5 py-4 hover:text-primaryBlue-400 px-5'>
                    <span className='my-auto '>
                        <FaUserAlt size={20} />
                    </span>
                    <span>
                        Male
                    </span>
                </li>
                <li className='flex gap-5 py-4 hover:text-primaryBlue-400 px-5'>
                    <span className='my-auto '>
                        <FaUserAlt size={20} />
                    </span>
                    <span>
                        Male
                    </span>
                </li>
                <li className='flex gap-5 py-4 hover:text-primaryBlue-400 px-5'>
                    <span className='my-auto '>
                        <FaUserAlt size={20} />
                    </span>
                    <span>
                        Male
                    </span>
                </li>
            </ul>
        </div>
    )
}

export default About
