'use client'
import React from 'react'
import { FaEye } from 'react-icons/fa'

const PasswordForm = () => {
    return (
        <form className=' w-full bg-white md:w-4/5 md:mx-auto lg:w-1/3 rounded-md p-5 lg:p-10 flex flex-col gap-10 shadow-md'>
            <span>
                <h1 className='text-xl px-2 pb-2 text-primaryBlue-300 font-poppins font-semibold'>Change Password</h1>
                <hr />
            </span>

            <div className='flex flex-col gap-5'>

                <div className="flex flex-col items-start gap-3">
                    <h3 className="text-gray-600 text-base font-medium font-poppins leading-tight">old password</h3>
                    <div className="relative w-full">
                        <input type="password" className="py-3 px-4 w-full bg-slate-100 rounded-md shadow-inner border focus:border-gray-600 focus:outline-none  text-gray-600" />
                        <div className="w-px h-9 bg-gray-600 absolute top-2 right-12"></div>
                        <div className="w-6 h-6 absolute right-3 top-3.5 text-gray-600  flex items-center justify-center">
                            <FaEye />
                        </div>
                    </div>
                </div>

                <div className="flex flex-col items-start gap-3">
                    <h3 className="text-gray-600 text-base font-medium font-poppins leading-tight">New password</h3>
                    <div className="relative w-full">
                        <input type="password" className="py-3 px-4 w-full bg-slate-100 rounded-md shadow-inner border focus:border-gray-600 focus:outline-none  text-gray-600" />
                        <div className="w-px h-9 bg-gray-600 absolute top-2 right-12"></div>
                        <div className="w-6 h-6 absolute right-3 top-3.5 text-gray-600 flex items-center justify-center">
                            <FaEye />
                        </div>
                    </div>
                </div>

                <div className="flex flex-col items-start gap-3">
                    <h3 className="text-gray-600 text-base font-medium font-poppins leading-tight">Confirm password</h3>
                    <div className="relative w-full">
                        <input type="password" className="py-3 px-4 w-full bg-slate-100 rounded-md shadow-inner border focus:border-gray-600 focus:outline-none  text-gray-600" />
                        <div className="w-px h-9 bg-gray-600 absolute top-2 right-12"></div>
                        <div className="w-6 h-6 absolute right-3 top-3.5 text-gray-600 flex items-center justify-center">
                            <FaEye />
                        </div>
                    </div>
                </div>


            </div>
            <button className='w-full px-5 py-3 font-poppins rounded bg-primaryBlue-300 text-white'>
                Reset Password
            </button>
        </form>
    )
}

export default PasswordForm


