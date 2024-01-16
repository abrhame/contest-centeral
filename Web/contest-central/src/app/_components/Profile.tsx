import React from 'react';

const Profile = () => {
    return (
        <div className="w-full lg:w-[95%]  h-28 lg:h-[400px] relative rounded shadow-md">
            <div className="w-full h-28 bg-white lg:h-[420px] top-0 left-0 absolute  rounded md:rounded-lg" />
            <img
                className="w-full h-28 md:h-[200px] lg:h-[300px] left-0 top-0 absolute rounded md:rounded-lg"
                src="/background.jpg"
            />
            <div className="w-24 h-24 md:w-30 z-10 md:h-30 lg:w-40 lg:h-40 absolute left-8 -bottom-10 md:left-20 md:-bottom-36 lg:left-16 lg:bottom-10 ">
                <img
                    className="w-24 h-24 md:w-30 md:h-30 lg:w-40 lg:h-40 lg:left-0 lg:top-0 lg:absolute rounded-full object-cover"
                    src="/images/avatar.jpg"
                />
            </div>
            <div className='hidden lg:block absolute bottom-2 left-60'>
                <h1 className='font-bold text-2xl text-blue-700 font-poppins'>John Doe</h1>
                <h2 className='text-lg text-primaryGray-300 font-poppins'>Head of Education</h2>
            </div>
        </div>
    );
};

export default Profile;