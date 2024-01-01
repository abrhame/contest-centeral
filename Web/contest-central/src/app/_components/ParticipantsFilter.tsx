import React from 'react'

const ParticipantsFilter = () => {
    return (
        <div className="mb-10 flex justify-start gap-10 font-poppins ">

            <select
                id="country"
                className="bg-white border border-gray-300 p-2 text-gray-800 text-sm rounded-md focus:ring-blue-500 focus:border-blue-500 block w-full   placeholder-gray-400 "
            >
                <option selected="">Choose a country</option>
                <option value="all">All</option>
                <option value="ethiopia">Ethiopia</option>
                <option value="ghana">Ghana</option>
            </select>
            <select
                id="generation"
                className="bg-white border border-gray-300 p-2 text-gray-800 text-sm rounded-md focus:ring-blue-500 focus:border-blue-500 block w-full   placeholder-gray-400 "
            >
                <option selected="">Choose a Generation</option>
                <option value="5">Gen - 5</option>
                <option value="4">Gen - 4</option>
                <option value="3">Gen - 3</option>
                <option value="1">Gen - 1</option>
            </select>
            <select
                id="university"
                className="bg-white border border-gray-300 p-2 text-gray-800 text-sm rounded-md focus:ring-blue-500 focus:border-blue-500 block w-full   placeholder-gray-400 "
            >
                <option selected="">Choose a university</option>
                <option value="all">All</option>
                <option value="aastu">AASTU</option>
                <option value="aait">AAIT</option>
            </select>
            <select
                id="group"
                className="bg-white border border-gray-300 p-2 text-gray-800 text-sm rounded-md focus:ring-blue-500 focus:border-blue-500 block w-full   placeholder-gray-400 "
            >
                <option selected="">Choose a group</option>
                <option value="46">Group 46</option>
                <option value="45">Group 45</option>
                <option value="44">Group 44</option>
            </select>


        </div>
    )
}

export default ParticipantsFilter