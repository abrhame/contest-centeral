import React from 'react'
import Link from 'next/link'

type member = {
    name: string,
    email: string,
    phone: string,
    username: string,
    studentId: string,
    CV: string,
    leetcode: string,
    codeforce: string,
    github: string
}
const members: member[] = [
    {
        name: 'Jhon Doe',
        email: "DgT5A@example.com",
        phone: "+91 1234567890",
        username: 'jhon',
        studentId: 'ETS0987/12',
        CV: 'drive.goole.com',
        leetcode: 'https://leetcode.com/jhon',
        codeforce: 'https://codeforces.com/profile/jhon',
        github: 'https://github.com/jhon',
    },
    {
        name: 'Jhon Doe',
        email: "DgT5A@example.com",
        phone: "+91 1234567890",
        username: 'jhon',
        studentId: 'ETS0987/12',
        CV: 'drive.goole.com',
        leetcode: 'https://leetcode.com/jhon',
        codeforce: 'https://codeforces.com/profile/jhon',
        github: 'https://github.com/jhon',
    },
    {
        name: 'Jhon Doe',
        email: "DgT5A@example.com",
        phone: "+91 1234567890",
        username: 'jhon',
        studentId: 'ETS0987/12',
        CV: 'drive.goole.com',
        leetcode: 'https://leetcode.com/jhon',
        codeforce: 'https://codeforces.com/profile/jhon',
        github: 'https://github.com/jhon',
    },
    {
        name: 'Jhon Doe',
        email: "DgT5A@example.com",
        phone: "+91 1234567890",
        username: 'jhon',
        studentId: 'ETS0987/12',
        CV: 'drive.goole.com',
        leetcode: 'https://leetcode.com/jhon',
        codeforce: 'https://codeforces.com/profile/jhon',
        github: 'https://github.com/jhon',
    },
    {
        name: 'Jhon Doe',
        email: "DgT5A@example.com",
        phone: "+91 1234567890",
        username: 'jhon',
        studentId: 'ETS0987/12',
        CV: 'drive.goole.com',
        leetcode: 'https://leetcode.com/jhon',
        codeforce: 'https://codeforces.com/profile/jhon',
        github: 'https://github.com/jhon',
    },
    {
        name: 'Jhon Doe',
        email: "DgT5A@example.com",
        phone: "+91 1234567890",
        username: 'jhon',
        studentId: 'ETS0987/12',
        CV: 'drive.goole.com',
        leetcode: 'https://leetcode.com/jhon',
        codeforce: 'https://codeforces.com/profile/jhon',
        github: 'https://github.com/jhon',
    },
    {
        name: 'Jhon Doe',
        email: "DgT5A@example.com",
        phone: "+91 1234567890",
        username: 'jhon',
        studentId: 'ETS0987/12',
        CV: 'drive.goole.com',
        leetcode: 'https://leetcode.com/jhon',
        codeforce: 'https://codeforces.com/profile/jhon',
        github: 'https://github.com/jhon',
    },
    {
        name: 'Jhon Doe',
        email: "DgT5A@example.com",
        phone: "+91 1234567890",
        username: 'jhon',
        studentId: 'ETS0987/12',
        CV: 'drive.goole.com',
        leetcode: 'https://leetcode.com/jhon',
        codeforce: 'https://codeforces.com/profile/jhon',
        github: 'https://github.com/jhon',
    }
]

const Headers: string[] = ['Name', 'Email', 'Phone Number', 'Telegram Username', 'Student Id', 'CV', 'Leetcode', 'Codeforce', 'Github']

const MembersTable = ({headers, data}: {headers: string[], data: member[]}) => {
    return (
        <section className=" py-3 sm:py-5 font-poppins">
            <div className="flex flex-col mx-auto px-4 lg:px-12 max-w-screen-2xl flex-shrink-0 space-y-3 md:flex-row md:items-center lg:justify-end md:space-y-0 md:space-x-3 mb-5">
                <button
                    type="button"
                    className="flex items-center justify-center px-4 py-2 text-sm font-medium text-gray-500 rounded-lg border border-green-700 ring-green-400 "
                >
                    <svg
                        className="h-3.5 w-3.5 mr-2"
                        fill="currentColor"
                        viewBox="0 0 20 20"
                        xmlns="http://www.w3.org/2000/svg"
                        aria-hidden="true"
                    >
                        <path
                            clipRule="evenodd"
                            fillRule="evenodd"
                            d="M10 3a1 1 0 011 1v5h5a1 1 0 110 2h-5v5a1 1 0 11-2 0v-5H4a1 1 0 110-2h5V4a1 1 0 011-1z"
                        />
                    </svg>
                    Invite
                </button>
                <button
                    type="button"
                    className="flex items-center justify-center flex-shrink-0 px-3 py-2 text-sm font-medium text-gray-500 bg-white border border-gray-600 rounded-lg  "
                >                    
                   Select All
                </button>
                <button
                    type="button"
                    className="flex items-center justify-center flex-shrink-0 px-3 py-2 text-sm font-medium text-gray-500 bg-white border border-gray-600 rounded-lg "
                >
                    <svg
                        className="w-4 h-4 mr-2"
                        xmlns="http://www.w3.org/2000/svg"
                        fill="none"
                        viewBox="0 0 24 24"
                        strokeWidth={2}
                        stroke="currentColor"
                        aria-hidden="true"
                    >
                        <path
                            strokeLinecap="round"
                            strokeLinejoin="round"
                            d="M3 16.5v2.25A2.25 2.25 0 005.25 21h13.5A2.25 2.25 0 0021 18.75V16.5m-13.5-9L12 3m0 0l4.5 4.5M12 3v13.5"
                        />
                    </svg>
                    Export
                </button>
            </div>

            <div className='px-4 mx-auto max-w-screen-2xl lg:px-12 '>
                <table className="w-full text-sm text-left text-gray-500 border border-gray-200 rounded-xl shadow-md">
                    <thead className="text-xs text-gray-500 uppercase bg-gray-50 ">
                        <tr>
                            <th scope="col" className="p-4">
                                <div className="flex items-center">
                                    <label htmlFor="checkbox-all" className="sr-only">
                                        checkbox
                                    </label>
                                </div>
                            </th>
                            {Headers.map((header, index) => (
                                <th key={index} scope="col" className="px-4 py-3">
                                    {header}
                                </th>
                            ))}
                        </tr>
                    </thead>
                    <tbody>
                        {members.map((member) => (
                            <tr className="border-b text-gray-500 hover:bg-gray-100 ">
                                <td className="w-4 px-4 py-3">
                                    <div className="flex items-center">
                                        <input
                                            id="checkbox-table-search-1"
                                            type="checkbox"
                                            className="w-4 h-4 bg-gray-100 border-gray-300 rounded text-primary-600 focus:ring-primary-500 dark:focus:ring-primary-600  focus:ring-2  "
                                        />
                                        <label htmlFor="checkbox-table-search-1" className="sr-only">
                                            checkbox
                                        </label>
                                    </div>
                                </td>
                                <th
                                    scope="row"
                                    className="flex items-center px-4 py-2 font-medium  "
                                >
                                    {member.name}
                                </th>
                                <td className="px-4 py-2 ">
                                    {member.email}
                                </td>
                                <td className="px-4 py-2 font-medium  underline">
                                    {member.phone}
                                </td>
                                <td className="px-4 py-2 font-medium  ">
                                    {member.username}
                                </td>
                                <td className="px-4 py-2 font-medium  ">
                                    {member.studentId}
                                </td>
                                <td className="px-4 py-2 font-medium  underline">
                                    <Link href={member.CV}>Resume</Link>
                                </td>
                                <td className="px-4 py-2 font-medium  underline">
                                    <Link href={member.leetcode}>Leetcode</Link>
                                </td>
                                <td className="px-4 py-2  underline">
                                    <Link href={member.codeforce}>Codeforces</Link>
                                </td>
                                <td className="px-4 py-2 font-medium  underline">
                                    <Link href={member.github}>Github</Link>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </section>

    )
}

export default MembersTable
