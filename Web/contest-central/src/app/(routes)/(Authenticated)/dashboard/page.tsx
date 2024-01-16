"use client";

import ApexChart from "@/app/_components/ApexChart";
import ContestTable from "@/app/_components/ContestTable";
import DashboardContestTable from "@/app/_components/DashboardContestTable";
import TopContestants from "@/app/_components/TopContestants";
import TopGroupCard from "@/app/_components/TopGroupCard";
import TopGroups from "@/app/_components/TopGroups";
import TotalCards, { Information } from "@/app/_components/TotalCards";
import React, { useEffect } from "react";
import totalCandidates from "/public/totalCandidates.png";
import axios from "axios";

const page = () => {
  useEffect(() => {
    const fetchData = async () => {
      const res = await axios.get(
        "https://jsonplaceholder.typicode.com/todos/1"
      );
      console.log(res.data);
      // console.log(res.data);
    };
    try {
      fetchData();
    } catch (error) {
      console.log(error);
    }
  }, []);

  const contests = [
    {
      name: "contest 1",
      // createdBy: 'aman',
      questions: "3",
      allowedHours: "2:30",
      participant: "30",
      attendance: "52%",
      date: "Nov, 3, 2023",
      status: "completed",
    },
    {
      name: "contest 1",
      // createdBy: 'aman',
      questions: "3",
      allowedHours: "2:30",
      participant: "30",
      attendance: "52%",
      date: "Nov, 3, 2023",
      status: "completed",
    },
    {
      name: "contest 1",
      // createdBy: 'aman',
      questions: "3",
      allowedHours: "2:30",
      participant: "30",
      attendance: "52%",
      date: "Nov, 3, 2023",
      status: "upcoming",
    },
    {
      name: "contest 1",
      // createdBy: 'aman',
      questions: "3",
      allowedHours: "2:30",
      participant: "30",
      attendance: "52%",
      date: "Nov, 3, 2023",
      status: "completed",
    },
    {
      name: "contest 1",
      // createdBy: 'aman',
      questions: "3",
      allowedHours: "2:30",
      participant: "30",
      attendance: "52%",
      date: "Nov, 3, 2023",
      status: "completed",
    },
    {
      name: "contest 1",
      // createdBy: 'aman',
      questions: "3",
      allowedHours: "2:30",
      participant: "30",
      attendance: "52%",
      date: "Nov, 3, 2023",
      status: "completed",
    },
    {
      name: "contest 1",
      // createdBy: 'aman',
      questions: "3",
      allowedHours: "2:30",
      participant: "30",
      attendance: "52%",
      date: "Nov, 3, 2023",
      status: "upcoming",
    },
    {
      name: "contest 1",
      // createdBy: 'aman',
      questions: "3",
      allowedHours: "2:30",
      participant: "30",
      attendance: "52%",
      date: "Nov, 3, 2023",
      status: "completed",
    },
  ];

  const ContestHeaders = [
    "Contest Name",
    "Created By",
    "Questions",
    "Allowed Hours",
    "Total Participant",
    "Attendance",
    "Date",
    "Status",
  ];

  const info: Information[] = [
    {
      image: totalCandidates,
      text: "Total Contests",
      num: "200",
    },
    {
      image: totalCandidates,
      text: "Total Contests",
      num: "200",
    },
    {
      image: totalCandidates,
      text: "Total Contests",
      num: "200",
    },
    {
      image: totalCandidates,
      text: "Total Contests",
      num: "200",
    },
  ];

  return (
    <div className="py-7 flex flex-col gap-y-20">
      <div className="flex flex-wrap justify-center items-center gap-y-6 gap-x-3 md:justify-between md:items-center">
        {info.map((cur, idx) => (
          <TotalCards info={cur} key={idx} />
        ))}
      </div>

      <div className="w-full flex flex-col md:flex-row gap-x-8">
        <div className="md:w-8/12">
          <div>
            <ApexChart />
          </div>
          <div className="">
            <DashboardContestTable data={contests} headers={ContestHeaders} />
          </div>
        </div>

        <div className="md:w-4/12 flex flex-col justify-center items-center self-start gap-y-6">
          <TopGroups />
          <TopContestants />
        </div>
      </div>
    </div>
  );
};

export default page;
