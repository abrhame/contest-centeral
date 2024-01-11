import React from "react";
import { IoMdClose } from "react-icons/io";

type Props = {
  onClose: () => void;
};

const Modal = ({ onClose }: Props) => {
  return (
    <div className="fixed top-0 left-0 px-20 py-5 w-full h-full  flex justify-center items-center">
      {/* Your role options go here */}
      <div className="bg-gray-200 p-8 rounded relative flex flex-col space-y-3 w-[450px]">
        <span
          className="absolute top-2 right-2 cursor-pointer"
          onClick={onClose}
        >
          <IoMdClose />
        </span>
        <h2 className="text-xl font-semibold text-left">Register New User</h2>
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
            <option value="contest_creater">Contest Creater</option>
            <option value="student">Student</option>
          </select>
          <div className="w-full flex items-center justify-center mt-3">
            <button className="bg-blue-600 text-white px-4 py-2 rounded-md shadow-sm text-sm">
              Add User
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Modal;
