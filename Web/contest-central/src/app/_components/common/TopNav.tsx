"use client";

import React, { useState } from "react";

import { FiHelpCircle } from "react-icons/fi";
import { MdKeyboardArrowDown, MdOutlinePowerSettingsNew } from "react-icons/md";
import { TbMessage2Question } from "react-icons/tb";
import { IoIosHelpCircleOutline, IoMdLogOut } from "react-icons/io";

import { CgProfile } from "react-icons/cg";

import Breadcrumbs from "./Breadcrumbs";
import { useRouter, usePathname } from "next/navigation";

import { IoNotificationsOutline, IoSettingsOutline } from "react-icons/io5";
import Image from "next/image";
import { RiLogoutBoxRLine } from "react-icons/ri";
import Link from "next/link";

type Props = {};

const TopNav = (props: Props) => {
  const router = useRouter();
  const pathname = usePathname();
  const isHome = pathname === "/";

  const [isProfileDropdownOpen, setIsProfileDropdownOpen] = useState(false);

  const handleClick = (e: React.MouseEvent<HTMLImageElement, MouseEvent>) => {
    e.preventDefault();
    router.push("/");
  };

  const handleLogout = () => {
    // logout
    router.push("/signin");
  };

  const handleHelp = () => {
    // help
  };
  const routeToProfile = () => {
    router.push("/profile");
    setIsProfileDropdownOpen(false);
  };

  const toggleProfileDropdown = () => {
    setIsProfileDropdownOpen(!isProfileDropdownOpen);
  };

  return (
    <div>
      <div className="py-3 px-6 w-full flex items-center justify-between">
        <div className="hidden lg:block">
          <Breadcrumbs
            homeElement={
              <button className="flex items-center gap-x-2">
                <img
                  src="/images/coins.svg"
                  alt="nav img"
                  className="w-[20px] h-[20px]"
                  onClick={handleClick}
                />
                <span className="flex items-center space-x-2">
                  {isHome ? (
                    <>
                      <span className="pr-2">/</span>
                      <p className="hover:bg-gray-100 rounded-sm p-1.5 duration-200 transition ease-in-out">
                        Dashboard
                      </p>
                    </>
                  ) : (
                    ""
                  )}
                </span>
              </button>
            }
            separator={<span> / </span>}
            activeClasses="text-amber-500"
            containerClasses="flex py-5 "
            listClasses=":hover:text-amber-500 text-lg"
            capitalizeLinks
          />
        </div>
        <div className="h-full w-full flex items-center justify-end gap-x-[30px] lg:gap-x-[65px] font-normal leading-normal">
          <div className="text-[#6C6C77] flex items-center gap-x-[21px] text-2xl">
            <TbMessage2Question className="cursor-pointer" />

            <div className="relative cursor-pointer">
              <span className="absolute top-1 left-4 bg-[#D8727D] rounded-full w-2 h-2 z-50"></span>
              <IoNotificationsOutline />
            </div>
          </div>
          <div className="flex items-center gap-2 text-[#04003D]">
            <div
              className="flex items-center gap-x-5 cursor-pointer hover:bg-slate-100 py-1.5 px-2.5 rounded-md transition duration-300 ease-in-out"
              onClick={toggleProfileDropdown}
            >
              <p className="text-base whitespace-nowrap hidden lg:block">
                Anima Agrawal
              </p>
              <img
                src="/images/avatar.png"
                className="object-cover rounded-full w-fit h-fit"
                alt=""
              />
              <MdKeyboardArrowDown className="text-2xl" />
            </div>
            {isProfileDropdownOpen && (
              <div className="absolute right-6 top-16 py-2 px-3 pr-1 mt-2 w-64 border border-gray-300 bg-white shadow-lg rounded-lg overflow-hidden z-10 transition-transform origin-top duration-300 ease-in-out">
                <div className="py-1">
                  <button
                    className="flex items-center gap-x-4 px-4 py-2 text-gray-600 hover:bg-primaryBlue-300 rounded-md hover:text-white w-full text-left"
                    onClick={routeToProfile}
                  >
                    <CgProfile className="text-xl " />
                    <span className="">Profile</span>
                  </button>
                  <button className="flex items-center gap-x-4 px-4 py-2 text-gray-600 hover:bg-primaryBlue-300 rounded-md hover:text-white w-full text-left">
                    <IoSettingsOutline className="text-xl font-medium" />
                    <span>Settings</span>
                  </button>
                  <button className="flex items-center gap-x-4 px-4 py-2 text-gray-600 hover:bg-primaryBlue-300 rounded-md hover:text-white w-full text-left">
                    <FiHelpCircle className="text-xl font-semibold" />
                    <span>Help Center</span>
                  </button>
                  <button
                    className="flex items-center gap-x-4 px-4 py-2 text-gray-600 hover:bg-primaryBlue-300 rounded-md hover:text-white w-full text-left"
                    onClick={handleLogout}
                  >
                    <IoMdLogOut className="text-xl font-medium" />
                    <span>Log Out</span>
                  </button>
                </div>
              </div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

export default TopNav;
