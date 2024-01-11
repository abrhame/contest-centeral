import React from "react";
import { FcGoogle } from "react-icons/fc";

type SignInProps = {
  children: React.ReactNode;
};

const SignIn: React.FC<SignInProps> = ({ children }) => {
  return (
    <div className="h-screen flex">
      <div className="w-1/2 h-full flex flex-col items-center justify-center  ">
        <div className="w-[50%] px-2.5 mx-auto">{children}</div>
      </div>
      <div className='bg-[url("/images/dashboard_login.jpg")] h-full w-1/2 bg-cover bg-center'></div>
    </div>
  );
};

export default SignIn;
