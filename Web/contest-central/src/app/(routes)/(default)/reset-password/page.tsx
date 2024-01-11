"use client";

import Link from "next/link";
import React, { useState } from "react";
import { FcGoogle } from "react-icons/fc";
import { IoEyeOffOutline, IoEyeOutline } from "react-icons/io5";

type Props = {};

const ResetPassword = (props: Props) => {
  const [showPassword, setShowPassword] = useState(false);
  const togglePasswordVisibility = (e: any) => {
    e.preventDefault();
    setShowPassword(!showPassword);
  };
  return (
    <div>
      <form className="flex flex-col gap-y-5 py-2">
        <h1 className="text-3xl text-[#171923] font-semibold pb-4 text-left">
          <span className="text-center">Reset password</span>
        </h1>
        <div className="flex flex-col gap-y-6">
          <div className="flex flex-col gap-y-[2px]">
            <label
              htmlFor="password"
              className="text-gray-600 font-normal text-sm"
            >
              New Password
            </label>
            <div className="relative">
              <input
                id="password"
                name="password"
                type={`${showPassword ? "text" : "password"}`}
                placeholder="@#*%"
                className="rounded-lg w-full border-[#CBD5E0] bg-[#F7FAFC] p-2 h-10 outline-none border-[1px] focus:border-primaryBlue-300 text-gray-600"
              />
              <button
                className="absolute right-2 top-1/2 -translate-y-1/2 border-l-2 h-7 border-gray-300 px-2"
                onClick={togglePasswordVisibility}
              >
                {showPassword ? <IoEyeOffOutline /> : <IoEyeOutline />}
              </button>
            </div>
          </div>
          <div className="flex flex-col gap-y-[2px]">
            <label
              htmlFor="password"
              className="text-gray-600 font-normal text-sm"
            >
              Confirm Password
            </label>
            <div className="relative">
              <input
                id="password"
                name="password"
                type={`${showPassword ? "text" : "password"}`}
                placeholder="@#*%"
                className="rounded-lg w-full border-[#CBD5E0] bg-[#F7FAFC] p-2 h-10 outline-none border-[1px] focus:border-primaryBlue-300 text-gray-600"
              />
              <button
                className="absolute right-2 top-1/2 -translate-y-1/2 border-l-2 h-7 border-gray-300 px-2"
                onClick={togglePasswordVisibility}
              >
                {showPassword ? <IoEyeOffOutline /> : <IoEyeOutline />}
              </button>
            </div>
          </div>
        </div>

        <button
          type="submit"
          className="w-full bg-[#264ECA] text-white rounded-[20px] h-12"
        >
          Reset Password
        </button>
      </form>
    </div>
  );
};

export default ResetPassword;
