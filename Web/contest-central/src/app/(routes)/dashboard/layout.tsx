'use client';

import { useState } from "react";
import { IoMdClose } from "react-icons/io";

export default function LeaderBoardLayout(props: React.PropsWithChildren) {
  return (
    <div className="bg-primaryGray-100 h-screen">
      {props.children}
    </div>
  )
}