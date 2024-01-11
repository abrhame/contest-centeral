"use client";

import Link from "next/link";
import React, { useState } from "react";
import { FcGoogle } from "react-icons/fc";
import { IoMdEye } from "react-icons/io";
import { IoEyeOffOutline, IoEyeOutline } from "react-icons/io5";
const SignIn = () => {
  const [showPassword, setShowPassword] = useState(false);
  const togglePasswordVisibility = (e: any) => {
    e.preventDefault();
    setShowPassword(!showPassword);
  };
  return (
    <div>
      <form className="flex flex-col gap-y-5 py-2">
        <h1 className="text-3xl text-[#171923] font-semibold pb-4 text-left">
          <span className="text-center">Sign in</span>
        </h1>
        <div className="flex flex-col gap-y-3">
          <div className="flex flex-col gap-y-[2px]">
            <label
              htmlFor="email"
              className="text-gray-600 font-normal text-sm"
            >
              Email
            </label>
            <input
              id="email"
              name="email"
              type="email"
              placeholder="example@gmail.com"
              className="rounded-lg border-[#CBD5E0] bg-[#F7FAFC] outline-none border-[1px] p-2 h-10 text-gray-600 focus:border-primaryBlue-300 "
            />
          </div>
          <div className="flex flex-col gap-y-[2px]">
            <label
              htmlFor="password"
              className="text-gray-600 font-normal text-sm"
            >
              Password
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

        <div className="flex justify-between items-center">
          <div className="flex jutstify-between items-center w-full pt-4 text-xs">
            <div className="flex items-center gap-x-2 text-gray-200 w-full">
              <label htmlFor="remember" className="text-gray-600 font-normal">
                Remember me
              </label>
              <input
                id="remember"
                name="remember"
                type="checkbox"
                className="w-4 h-4 border rounded-lg border-[#CFD9E0] text-gray-600"
              />
            </div>
            <Link
              href="/forgot-password"
              className="text-gray-600 font-normal transition duration-300 ease-in-out hover:text-[#264ECA]  hover:underline whitespace-nowrap pr-3"
            >
              Forgot password?
            </Link>
          </div>
        </div>
        <button
          type="submit"
          className="w-full bg-[#264ECA] text-white rounded-[20px] h-12"
        >
          Sign in
        </button>
        <div className="flex justify-center items-center">
          <div className="mx-4 bg-[#A0AEC0] w-1/2 h-[1px] opacity-30"></div>
          <p className="text-xs text-[#757E8D]">or</p>
          <div className="mx-4 bg-[#A0AEC0] w-1/2 h-[1px] opacity-30"></div>
        </div>
        <div className="w-full flex items-center  px-4 text-[#67728A] border border-[#CBD5E0] rounded-[30px] h-12 cursor-pointer">
          <FcGoogle className="inline-block h-6 w-6 mr-20" />
          <p className="text-sm">Continue with Google</p>
        </div>
      </form>
    </div>
  );
};

export default SignIn;
