"use client";

import ApexChart from "@/app/_components/ApexChart";
import TopContestants from "@/app/_components/TopContestants";
import TopGroupCard from "@/app/_components/TopGroupCard";
import TopGroups from "@/app/_components/TopGroups";
import TotalCards from "@/app/_components/TotalCards";
import React from "react";

const Dashboard = () => {
  return (
    <div className="py-7 flex flex-col gap-y-20">
      <div className="flex justify-around items-center">
        <TotalCards />
        <TotalCards />
        <TotalCards />
        <TotalCards />
      </div>
      <div>
        <div>
          <ApexChart />
        </div>
        {/* <div>
        <TopContestants />
      </div> */}
      </div>
    </div>
  );
};

export default Dashboard;
