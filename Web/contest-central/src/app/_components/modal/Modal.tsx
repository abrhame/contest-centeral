import React from "react";
import { IoMdClose } from "react-icons/io";

import { Dialog, Transition } from "@headlessui/react";
import { Fragment, useState } from "react";

type Props = {
  onClose: () => void;
  isOpen: boolean;
  // setVisible: (visible: boolean) => void;
};

const Modal = ({ onClose, isOpen }: Props) => {
  return (
    <Transition appear show={isOpen} as={Fragment}>
      <Dialog as="div" className="relative z-10" onClose={onClose}>
        <Transition.Child
          as={Fragment}
          enter="ease-out duration-300"
          enterFrom="opacity-0"
          enterTo="opacity-100"
          leave="ease-in duration-200"
          leaveFrom="opacity-100"
          leaveTo="opacity-0"
        >
          <div className="fixed inset-0 bg-black/25" />
        </Transition.Child>

        <div className="fixed inset-0 overflow-y-auto">
          <div className="flex min-h-full items-center justify-center p-4 text-center">
            <Transition.Child
              as={Fragment}
              enter="ease-out duration-300"
              enterFrom="opacity-0 scale-95"
              enterTo="opacity-100 scale-100"
              leave="ease-in duration-200"
              leaveFrom="opacity-100 scale-100"
              leaveTo="opacity-0 scale-95"
            >
              <Dialog.Panel className="w-full max-w-md transform overflow-hidden rounded-2xl bg-white p-6 text-left align-middle shadow-xl transition-all">
                <div className="">
                  <div className="  relative flex flex-col space-y-3 z-50">
                    <span
                      className="absolute top-2 right-2 cursor-pointer"
                      onClick={onClose}
                    >
                      <IoMdClose />
                    </span>
                    <h2 className="text-xl font-semibold text-left">
                      Register New User
                    </h2>
                    <div className="flex flex-col w-full items-start pt-7 text-sm">
                      <label className="block mb-2">Name:</label>
                      <input
                        type="text"
                        className="w-full border px-2 py-1.5 mb-2 outline-none rounded-md"
                      />

                      <label className="block mb-2">Email:</label>
                      <input
                        type="text"
                        className="w-full border p-2 mb-4 outline-none rounded-md"
                      />

                      <label className="block mb-2">Role:</label>
                      <select className="w-full border p-2 mb-4 outline-none rounded-md">
                        <option
                          value="contest_creater"
                          className="py-1.5 px-2 rounded-md outline-none"
                        >
                          Contest Creater
                        </option>
                        <option value="student">Student</option>
                      </select>
                    </div>
                  </div>
                </div>

                <div className="mt-4">
                  <button
                    type="button"
                    className="inline-flex justify-center rounded-md border border-transparent bg-blue-100 px-4 py-2 text-sm font-medium text-blue-900 hover:bg-blue-200 focus:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:ring-offset-2"
                    onClick={onClose}
                  >
                    Add User
                  </button>
                </div>
              </Dialog.Panel>
            </Transition.Child>
          </div>
        </div>
      </Dialog>
    </Transition>

    // <div className="fixed top-0 left-0 px-20 py-5 w-full h-full  flex justify-center items-center">
    // </div>
  );
};

export default Modal;
