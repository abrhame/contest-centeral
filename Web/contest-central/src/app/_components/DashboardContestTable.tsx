import React from 'react';
import { MdOutlineCheckCircle } from 'react-icons/md';
import { FiLoader } from "react-icons/fi";
import Link from 'next/link';
import ContestFilter from './ContestFilter';

type Contest = {
  name: string;
  // createdBy: string;
  questions: string;
  allowedHours: string;
  participant: string;
  attendance: string;
  date: string;
  status: string;
};


type Prop = {
  data: Contest[]
  headers: string[];
};

const DashboardContestTable = ({ data, headers }: Prop) => {
  return (
    <div className="mx-2 my-10 lg:m-10 overflow-x-auto sm:rounded-lg">
      <table className="w-full border rounded-lg text-sm text-left rtl:text-right text-gray-500 shadow-md">
        <thead className="text-xs text-[#6B7280] uppercase bg-gray-50">
          <tr>
            {headers.map((header, index) => (
              <th key={index} scope="col" className="px-6 py-3">
                {header}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.map((item, index) => (
            <tr key={index} className="bg-white border-b hover:bg-gray-50">
              <th
                scope="row"
                className="px-6 py-4 font-medium text-[#6B7280] whitespace-nowrap"
              >
                <Link href={`/contest/${item.name}`}>{item.name}</Link>
              </th>
              {/* <td className="px-6 py-4">{item.createdBy}</td> */}
              <td className="px-6 py-4">{item.questions}</td>
              <td className="px-6 py-4">{item.allowedHours}</td>
              <td className="px-6 py-4">{item.participant}</td>
              <td className="px-6 py-4">{item.attendance}</td>
              <td className="px-6 py-4">{item.date}</td>
              <td className="px-6 py-2">
                {item.status === 'completed' ? (
                  <div className="flex gap-5 items-center">
                    <span className="text-green-400">
                      <MdOutlineCheckCircle size={28} />
                    </span>
                    <span>Completed</span>
                  </div>
                ) : (
                  <div className="flex gap-5 items-center">
                    <span className="text-red-400">
                      <FiLoader size={28} />
                    </span>
                    <span>Upcoming</span>
                  </div>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default DashboardContestTable