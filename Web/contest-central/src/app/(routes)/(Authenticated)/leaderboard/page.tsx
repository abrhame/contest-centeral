"use client"
import React, { useState } from 'react';

type HandlerType = {
  event: React.ChangeEvent<HTMLSelectElement>;
  setDropDown: React.Dispatch<React.SetStateAction<string>>;
};

const Page = () => {
  const [isGroup, setIsGroup] = useState(true)

  return (
    <div className=''>
      <div className="flex items-center gap-x-6">
        <button
          className={`px-10 py-1 rounded-t-xl ${isGroup ? 'bg-white text-primaryBlue-400' : 'bg-transparent text-primaryGray-300'}`}
          onClick={() => setIsGroup(true)}
        >
          Group
        </button>
        <button
          className={`px-10 py-1 rounded-t-xl ${!isGroup ? 'bg-white text-primaryBlue-400' : 'bg-transparent text-primaryGray-300'}`}
          onClick={() => setIsGroup(false)}
        >
          Individual
        </button>
      </div>

      <div>
        {
          isGroup && (
            <div className=''></div>
          )
        }
        {
          !isGroup && (
            <div className='bg-yellow-100 h-screen'></div>
          )
        }
      </div>
    </div>
  );
};

export default Page;
