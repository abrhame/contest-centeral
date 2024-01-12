"use client";

import React, { useEffect } from "react";
import { RxDashboard } from "react-icons/rx";
import { MdOutlineLeaderboard } from "react-icons/md";
import { RiLogoutBoxRLine, RiSettingsLine } from "react-icons/ri";
import { LuUsers } from "react-icons/lu";
import { FaRegUser } from "react-icons/fa";
import { FaRankingStar } from "react-icons/fa6";
import Link from "next/link";
import Image from "next/image";
import { useRouter, usePathname } from "next/navigation";
import { Url } from "next/dist/shared/lib/router/router";
import Router from "next/router";

type Props = {};

const menuItems = [
  {
    name: "Dashboard",
    Icon: <RxDashboard />,
    url: "/dashboard",
  },
  {
    name: "Contests",
    Icon: <FaRankingStar />,
    url: "/contests",
  },
  {
    name: "Users",
    Icon: <FaRegUser />,
    url: "/users",
  },
  // {
  //   name: "Settings",
  //   Icon: <RiSettingsLine />,
  //   url: "/settings",
  // },
  {
    name: "Leader Board",
    Icon: <MdOutlineLeaderboard />,
    url: "/leaderboard",
  },
  {
    name: "Members",
    Icon: <LuUsers />,
    url: "/members",
  },
];

const SideNav = (props: Props) => {
  const router = useRouter();

  const handleLogout = () => {
    // logout
    router.push("/signin");
  };
  const path = usePathname();

  return (
    <div className="py-3 px-6 h-screen max-h-screen font-base text-gray-900 font-normal top-0 bg-white">
      <div className="flex flex-col h-full space-y-6">
        <div className="px-6 py-4">
          <Image
            src="/images/logo.png"
            alt="logo"
            width={120}
            height={120}
            className="cursor-pointer"
          />
        </div>
        <div className="flex flex-col space-y-6 items-start justify-between pt-10 px-2 flex-grow">
          <div className="space-y-5">
            {menuItems.map((item, idx) => (
              <div
                className={`flex items-center space-x-4 cursor-pointer hover:bg-primaryBlue-400 transition duration-500 ease-in-out rounded-md hover:text-white px-6 py-1.5 ${
                  path === item.url ? "active" : ""
                }`}
                key={idx}
              >
                <Link
                  href={item.url as Url}
                  className="flex items-center gap-x-4"
                >
                  <div>{item.Icon}</div>
                  <div>{item.name}</div>
                </Link>
              </div>
            ))}
          </div>
          <div className="px-1 pb-10">
            <button
              className="flex items-center space-x-4 py-1 px-6 w-44 cursor-pointer hover:bg-primaryBlue-300 transition duration-500 ease-in-out rounded-md hover:text-white"
              onClick={handleLogout}
            >
              <RiLogoutBoxRLine />
              <span>Logout</span>
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SideNav;
