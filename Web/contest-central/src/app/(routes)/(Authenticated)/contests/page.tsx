import ContestTable from "@/app/_components/ContestTable";
import React from "react";

const contests = [
  {
    name: "contest 1",
    createdBy: "aman",
    questions: "3",
    allowedHours: "2:30",
    participant: "30",
    attendance: "52%",
    date: "Nov, 3, 2023",
    status: "completed",
  },
  {
    name: "contest 1",
    createdBy: "aman",
    questions: "3",
    allowedHours: "2:30",
    participant: "30",
    attendance: "52%",
    date: "Nov, 3, 2023",
    status: "completed",
  },
  {
    name: "contest 1",
    createdBy: "aman",
    questions: "3",
    allowedHours: "2:30",
    participant: "30",
    attendance: "52%",
    date: "Nov, 3, 2023",
    status: "upcoming",
  },
  {
    name: "contest 1",
    createdBy: "aman",
    questions: "3",
    allowedHours: "2:30",
    participant: "30",
    attendance: "52%",
    date: "Nov, 3, 2023",
    status: "completed",
  },
  {
    name: "contest 1",
    createdBy: "aman",
    questions: "3",
    allowedHours: "2:30",
    participant: "30",
    attendance: "52%",
    date: "Nov, 3, 2023",
    status: "completed",
  },
  {
    name: "contest 1",
    createdBy: "aman",
    questions: "3",
    allowedHours: "2:30",
    participant: "30",
    attendance: "52%",
    date: "Nov, 3, 2023",
    status: "completed",
  },
  {
    name: "contest 1",
    createdBy: "aman",
    questions: "3",
    allowedHours: "2:30",
    participant: "30",
    attendance: "52%",
    date: "Nov, 3, 2023",
    status: "completed",
  },
  {
    name: "contest 1",
    createdBy: "aman",
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

const page = () => {
  return (
    <div className="h-screen relative ">
      <ContestTable data={contests} headers={ContestHeaders} />
    </div>
  );
};

export default page;
