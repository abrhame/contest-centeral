"use client";

import SideNav from "@/app/_components/common/SideNav";
import TopNav from "@/app/_components/common/TopNav";
import React from "react";
import {
  Dialog,
  Transition,
  TransitionChildProps,
  TransitionRootProps,
} from "@headlessui/react";
import { TiThMenu } from "react-icons/ti";
import { IoClose } from "react-icons/io5";

type Props = {
  children: React.ReactNode;
};

export default function LoggedInLayout({ children }: Props) {
  const [isSidebarOpen, setSidebarOpen] = React.useState(false);

  const toggleSidebar = () => {
    setSidebarOpen(!isSidebarOpen);
  };

  return (
    <div>
      <div className={`grid grid-cols-6 h-screen overflow-hidden`}>
        <Transition.Root show={isSidebarOpen}>
          <Dialog
            as="div"
            className="relative lg:hidden z-50"
            onClose={() => {
              setSidebarOpen(false);
            }}
          >
            <div className=" fixed inset-0 flex">
              <Transition.Child
                enter="transition-opacity ease-linear duration-300"
                enter-from="opacity-0"
                enter-to="opacity-100"
                leave="transition-opacity ease-linear duration-300"
                leave-from="opacity-100"
                leave-to="opacity-0"
              >
                <Dialog.Panel className="relative flex flex-1 w-full max-w-xs mr-16">
                  <div className="flex flex-col pb-4 overflow-y-auto bg-white grow gap-y-5 ring-1">
                    <div className="absolute top-0 right-0 flex justify-center w-16 pt-5">
                      <button onClick={() => setSidebarOpen(false)}>
                        <IoClose className="text-3xl pl-2 text-slate-400" />
                      </button>
                    </div>
                    <SideNav />
                  </div>
                </Dialog.Panel>
              </Transition.Child>
            </div>
          </Dialog>
        </Transition.Root>
        <div
          className={`lg:block hidden col-span-1 transition-all duration-300 ease-in-out overflow-y-auto`}
        >
          <SideNav />
        </div>
        <div className="lg:col-span-5 col-span-full relative top-0 right-0 lg:px-3">
          <div className="z-50 w-full flex items-center justify-between lg:block sticky top-0 left-0 bg-white">
            <button onClick={toggleSidebar} className="lg:hidden z-50">
              {!isSidebarOpen && (
                <TiThMenu className="text-3xl pl-2 text-slate-400" />
              )}
            </button>
            <div className="flex-grow">
              <TopNav />
            </div>
          </div>
          <div className="w-full h-screen px-3 py-2 bg-[#f5f7fd81]">
            {children}
          </div>
        </div>
      </div>
    </div>
  );
}
