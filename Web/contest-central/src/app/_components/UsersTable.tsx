import React from "react";
import { MdOutlineCheckCircle } from "react-icons/md";
import { FiLoader } from "react-icons/fi";
import Link from "next/link";
import { BsThreeDotsVertical } from "react-icons/bs";

type User = {
  name: string;
  email: string;
  role: string;
  emailVerfication: string;
  actions: "";
};

type Prop = {
  data: User[];
  headers: string[];
};

const UsersTable = ({ data, headers }: Prop) => {
  return (
    <div className="relative w-full  px-6 pt-4 overflow-x-auto sm:rounded-lg rounded-xl ">
      <table className="w-4/5 border rounded-2xl text-sm text-left rtl:text-right text-gray-600 shadow-md py-1.5 mb-10">
        <thead className="text-xs text-gray-600 uppercase bg-gray-100 font-normal">
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
            <tr
              key={index}
              className="bg-white border-b hover:bg-gray-50 cursor-pointer"
            >
              <th
                scope="row"
                className="px-6 py-4 font-medium text-[#6B7280] whitespace-nowrap"
              >
                <Link href={`/contest/${item.name}`}>{item.name}</Link>
              </th>
              <td className="px-6 py-4">{item.email}</td>
              <td className="px-6 py-4">{item.role}</td>
              <td className="px-6 py-4 ">{item.emailVerfication}</td>
              <td className="px-6 py-4">
                <span
                  onClick={() => {
                    alert("hello");
                  }}
                >
                  <BsThreeDotsVertical />
                </span>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default UsersTable;
