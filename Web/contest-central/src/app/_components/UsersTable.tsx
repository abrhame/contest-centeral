import React from 'react';
import { MdOutlineCheckCircle } from 'react-icons/md';
import { FiLoader } from "react-icons/fi";
import Link from 'next/link';
import ContestFilter from './ContestsFilter';


type User = {
    name: string;
    email: string;
    role: string;
    emailVerfication: string;
    actions: string;
};

type Prop = {
    data: User[]
    headers: string[];
};



const UsersTable = ({ data, headers }: Prop) => {
    return (
        <div className="absolute top-[150px] left-[350px] w-[1400px] overflow-x-auto sm:rounded-lg">
            <ContestFilter />
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
                            <td className="px-6 py-4">{item.email}</td>
                            <td className="px-6 py-4">{item.role}</td>
                            <td className="px-6 py-4">{item.emailVerfication}</td>
                            <td className="px-6 py-4">{item.actions}</td>

                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default UsersTable;