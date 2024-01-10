import React from 'react'


type group = {
    group: string,
    attendance: string,
    conversion: string,
    time: string,
    overAll: string
}

const groupData: group[] = [
    {
        group: "Group 46",
        attendance: "92%",
        conversion: "0.7",
        time: '7hr',
        overAll: "85%"
    },
    {
        group: "Group 46",
        attendance: "92%",
        conversion: "0.7",
        time: '7hr',
        overAll: "85%"
    },
    {
        group: "Group 46",
        attendance: "92%",
        conversion: "0.7",
        time: '7hr',
        overAll: "85%"
    },
    {
        group: "Group 46",
        attendance: "92%",
        conversion: "0.7",
        time: '7hr',
        overAll: "85%"
    },
    {
        group: "Group 46",
        attendance: "92%",
        conversion: "0.7",
        time: '7hr',
        overAll: "85%"
    }
]

const Headers = ['Group', 'Attendance', 'Conversion', 'Time', 'OverAll']


const LeaderBoardTable = ({ headers, data }: { headers: string[], data: group[] }) => {
    return (
        <div className="relative overflow-x-auto  ">
            <table className="w-full mt-5 mx-auto border border-gray-200 max-w-screen-xl text-sm text-left rtl:text-right text-gray-500 font-poppins rounded-xl shadow-xl">
                <thead className="text-xs text-gray-500 uppercase bg-gray-50">
                    <tr>
                        {Headers.map((header, index) => (
                            <th key={index} scope="col" className="px-6 py-3">
                                {header}
                            </th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {
                        groupData.map((group, index) => (
                            <tr className="border-b ">
                                <th
                                    scope="row"
                                    className="px-6 py-4 font-medium  "
                                >
                                    {group.group}
                                </th>
                                <td className="px-6 py-4">
                                    {group.attendance}
                                </td>
                                <td className="px-6 py-4">
                                    {group.conversion}
                                </td>
                                <td className="px-6 py-4">
                                    {group.time}
                                </td>
                                <td className="px-6 py-4">
                                    {group.overAll}
                                </td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        </div>

    )
}

export default LeaderBoardTable
