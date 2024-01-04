'use client';

import { useState } from "react";
import { IoMdClose } from "react-icons/io";

export default function LeaderBoardLayout(props: React.PropsWithChildren) {
  const [isCountryOpen, setisCountryOpen] = useState(false);
  const [countryFilter, setCountryFilter] = useState("Country")
  const [isGenOpen, setisGenOpen] = useState(false);
  const [genFilter, setGenFilter] = useState("Gen")
  const [filters, setFilters] = useState<String[]>([])

  const handleAddFilters = (data: String) => {
    console.log('Selected option:', data)

    if (!filters.includes(data)) {
      const temp = [...filters, data]
      setFilters(temp)
    } else {
      console.log(`Value "${data}" already exists in filters.`)
    }
  };

  const handleRemoveFilters = (data: String) => {
    const updatedFilters = filters.filter(filter => filter !== data);
    setFilters(updatedFilters);
  };

  return (
    <div className="bg-primaryGray-100 h-screen p-6">
      <div className="flex flex-col gap-y-3 mb-3">
        <div className="flex justify-start items-center gap-x-4" >
          <div className="relative inline-block text-left bg-white">
            <button
              onClick={() => setisCountryOpen(!isCountryOpen)}
              className="px-2 py-1 text-gray-700 rounded-md flex items-center justify-between shadow gap-x-6 bg-white hover:bg-gray-300 border-2 border-primaryGray-400"
            >
              {countryFilter}
              <svg
                className="w-4 h-4 inline-block ml-1 transform transition-transform duration-300"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
                style={{
                  transform: isCountryOpen ? 'rotate(180deg)' : 'rotate(0deg)',
                }}
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth="2"
                  d="M19 9l-7 7-7-7"
                />
              </svg>
            </button>
            {isCountryOpen && (
              <div className="absolute z-10 mt-2 w-48 bg-white border border-gray-200 shadow-lg rounded-md">
                <ul>
                  <li
                    className="block px-4 py-2 text-gray-800 hover:bg-gray-200"
                    onClick={() => {
                      setCountryFilter("Option 1")
                      handleAddFilters('Option 1');
                    }} >
                    Option 1
                  </li>
                  <li
                    className="block px-4 py-2 text-gray-800 hover:bg-gray-200"
                    onClick={() => {
                      setCountryFilter("Option 2")
                      handleAddFilters('Option 2');
                    }} >
                    Option 2
                  </li>
                </ul>
              </div>
            )}
          </div>
          <div className="relative inline-block text-left bg-white">
            <button
              onClick={() => setisGenOpen(!isGenOpen)}
              className="px-2 py-1 text-gray-700 rounded-md flex items-center  shadow justify-between gap-x-6 bg-white hover:bg-gray-300 border-2 border-primaryGray-400"
            >
              {genFilter}
              <svg
                className="w-4 h-4 inline-block ml-1 transform transition-transform duration-300"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
                style={{
                  transform: isGenOpen ? 'rotate(180deg)' : 'rotate(0deg)',
                }}
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth="2"
                  d="M19 9l-7 7-7-7"
                />
              </svg>
            </button>
            {isGenOpen && (
              <div className="absolute z-10 mt-2 w-48 bg-white border border-gray-200 shadow-lg rounded-md">
                <ul>
                  <li
                    className="block px-4 py-2 text-gray-800 hover:bg-gray-200"
                    onClick={() => {
                      setGenFilter("Option 3")
                      handleAddFilters('Option 3');
                    }} >
                    Option 3
                  </li>
                  <li
                    className="block px-4 py-2 text-gray-800 hover:bg-gray-200"
                    onClick={() => {
                      setGenFilter("Option 4")
                      handleAddFilters('Option 4');
                    }} >
                    Option 4
                  </li>
                </ul>
              </div>
            )}
          </div>
        </div>

        <div className="flex items-center gap-x-3">
          {
            filters.map((filter, index) => (
              <div key={index} className="flex bg-white justify-center gap-x-3 border-2 border-primaryGray-200 w-36 rounded-full py-1 text-primaryGray-300">
                <p>
                  {filter}
                </p>
                <IoMdClose className="w-4 h-auto text-black cursor-pointer" onClick={(event: any) => handleRemoveFilters(filter)} />
              </div>
            ))
          }
        </div>
      </div>

      {props.children}
    </div>
  )
}