import React from 'react'

const ContestFilter = () => {
    return (
        <div className="mb-10 flex gap-5 lg:justify-between">

            <form className="flex items-center gap-2 lg:gap-10 w-full md:w-2/3 lg:w-1/2">
                <label htmlFor="simple-search" className="sr-only">
                    Search
                </label>
                <div className="relative w-full">
                    <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                        <svg
                            aria-hidden="true"
                            className="w-5 h-5 text-gray-500 "
                            fill="currentColor"
                            viewBox="0 0 20 20"
                            xmlns="http://www.w3.org/2000/svg"
                        >
                            <path
                                fillRule="evenodd"
                                d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z"
                                clipRule="evenodd"
                            />
                        </svg>
                    </div>
                    <input
                        type="text"
                        id="simple-search"
                        className=" border border-gray-300 text-[#6B7280] text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full pl-10 p-2 "
                        placeholder="Search"
                        required
                    />
                </div>

                <input type="date" className=" border border-gray-300 text-[#6B7280] text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full pl-10 p-2 " />
            </form>

            <button className='px-6 py-1 rounded bg-[#264ECA] text-white font-semibold'>Create</button>

        </div>
    )
}

export default ContestFilter
