"use client";

import Link from "next/link";
import { useRouter } from "next/navigation";
import React from "react";
import { FcGoogle } from "react-icons/fc";

type Props = {};

const ForgotPassword = (props: Props) => {
  const router = useRouter();
  const handleSubmit = (e: any) => {
    e.preventDefault();
    console.log("submitted");

    router.push("/reset-password");
  };

  return (
    <div>
      <form
        onSubmit={(e) => handleSubmit(e)}
        className="flex flex-col gap-4 px-4"
      >
        <h1 className="text-3xl text-[#171923] font-semibold pb-4 text-left">
          <span className="text-center">Forgot Password</span>
        </h1>
        <div className="flex flex-col gap-y-6">
          <div className="w-full mb-6">
            <p className="text-gray-600 text-sm">
              Lorem ipsum dolor sit amet consectetur. Nascetur egestas dui velit
              quisque.
            </p>
          </div>
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
              className="rounded-lg border-[#CBD5E0] bg-[#F7FAFC] outline-none border-[1px] p-2 h-10 focus:border-primaryBlue-300 "
            />
          </div>
        </div>

        <button
          type="submit"
          className="w-full bg-[#264ECA] text-white rounded-[20px] py-3 px-4 mt-4"
        >
          Submit
        </button>
      </form>
    </div>
  );
};

export default ForgotPassword;
