import React from "react";
import { FcGoogle } from "react-icons/fc";
const page = () => {
  return (
    <div className="h-screen flex">
      <div className="w-1/2 h-full flex flex-col items-center justify-center gap-8 ">
        <div className="flex w-1/2 ">
          <h1 className="text-3xl text-[#171923] font-bold   ">Sign in</h1>
        </div>
        <form className="flex flex-col gap-4 w-1/2">
          <div className="flex flex-col gap-2">
            <label htmlFor="email" className="text-[#757E8D] text-xs font-thin">
              Email
            </label>
            <input
              id="email"
              name="email"
              type="email"
              placeholder="example@gmail.com"
              className="rounded-lg border-[#CBD5E0] bg-[#F7FAFC] border-2 p-2 h-10"
            />
          </div>
          <div className="flex flex-col gap-2">
            <label
              htmlFor="password"
              className="text-[#757E8D] text-xs font-thin"
            >
              Password
            </label>
            <input
              id="password"
              name="password"
              type="password"
              placeholder="@#*%"
              className="rounded-lg border-[#CBD5E0] bg-[#F7FAFC] border-2 p-2 h-10"
            />
          </div>
          <div className="flex justify-between items-center">
            <div className="flex jutstify-between items-center gap-4">
              <label htmlFor="remember">Remember me</label>
              <input
                id="remember"
                name="remember"
                type="checkbox"
                className="w-4 h-4 border rounded-lg border-[#CFD9E0]"
              />
            </div>
            <div>
              <a href="#" className="text-[#264ECA] text-base underline">
                Forgot password?
              </a>
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
            <p className="text-xs text-[#757E8D]">OR</p>
            <div className="mx-4 bg-[#A0AEC0] w-1/2 h-[1px] opacity-30"></div>
          </div>
          <div className="w-full flex items-center justify-around text-[#67728A] border border-[#CBD5E0] rounded-[30px] h-12">
            <FcGoogle className="inline-block h-6 w-6" />
            <p className="text-sm">Continue with Google</p>
            <div></div>
          </div>
        </form>
      </div>
      <div className='bg-[url("/images/dashboard_login.jpg")] h-full w-1/2 bg-cover bg-center'></div>
    </div>
  );
};

export default page;
