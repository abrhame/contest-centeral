"use client";

import UsersTable from "@/app/_components/UsersTable";
import Modal from "@/app/_components/modal/Modal";
import React, { useState } from "react";
import { IoIosArrowForward } from "react-icons/io";
import { IoSearchOutline } from "react-icons/io5";
import { RiEqualizerLine } from "react-icons/ri";

type Props = {};
const tableData = [
  {
    name: "Ibsa Abrham",
    email: "ibsa.abrham@a2sv.com",
    role: "Head of Education",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "Ibsa Abrham",
    email: "ibsa.abrham@a2sv.com",
    role: "Head of Education",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "Ibsa Abrham",
    email: "ibsa.abrham@a2sv.com",
    role: "Head of Education",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "Ibsa Abrham",
    email: "ibsa.abrham@a2sv.com",
    role: "Head of Education",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "Ibsa Abrham",
    email: "ibsa.abrham@a2sv.com",
    role: "Head of Education",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "Ibsa Abrham",
    email: "ibsa.abrham@a2sv.com",
    role: "Head of Education",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "Ibsa Abrham",
    email: "ibsa.abrham@a2sv.com",
    role: "Head of Education",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "John Doe",
    email: "HlT3H@example.com",
    role: "Contest Creater",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "John Doe",
    email: "HlT3H@example.com",
    role: "Contest Creater",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "John Doe",
    email: "HlT3H@example.com",
    role: "Contest Creater",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "John Doe",
    email: "HlT3H@example.com",
    role: "Contest Creater",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "John Doe",
    email: "HlT3H@example.com",
    role: "Contest Creater",
    emailVerfication: "Head of Education",
    action: "",
  },
  {
    name: "John Doe",
    email: "HlT3H@example.com",
    role: "Contest Creater",
    emailVerfication: "Head of Education",
    action: "",
  },
];

const tableHeaders = ["Name", "Email", "Role", "Email Verification", "Actions"];

export default function page({}: Props) {
  const [modalIsOpen, setModalIsOpen] = useState(false);

  const openModal = () => {
    setModalIsOpen(true);
  };

  const closeModal = () => {
    setModalIsOpen(false);
  };

  return (
    <section>
      <div className="flex items-center justify-between py-2 pt-6 pb-2 px-6 w-4/5">
        <div className="relative">
          <input
            type="text"
            name="search"
            placeholder="Search"
            className="border border-primaryGray-300 pl-10 px-3 py-1.5 rounded-md outline-none focus:border-primaryBlue-400"
          />
          <IoSearchOutline className="absolute left-3 top-2 text-xl text-primaryBlue-400" />
        </div>
        <div className="flex gap-x-8 items-center">
          <button className="flex items-center gap-x-1.5 border border-primaryBlue-400 border-x-1 py-1.5 px-2 text-base bg-primaryBlue-400 text-white rounded-md font-medium">
            <RiEqualizerLine className="font-semibold" />
            <span className="font-medium">Filter</span>
            <IoIosArrowForward className="text-2xl font-semibold" />
          </button>
          <button
            className="border border-primaryBlue-400 border-x-1 py-1.5 px-2 text-base bg-primaryBlue-400 text-white rounded-md font-medium cursor-pointer"
            onClick={openModal}
          >
            Create User
          </button>
          {modalIsOpen && <Modal onClose={closeModal} isOpen={modalIsOpen} />}
        </div>
      </div>

      <div>
        <UsersTable data={tableData} headers={tableHeaders} />
      </div>
    </section>
  );
}
