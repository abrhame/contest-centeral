import About from "@/app/_components/About";
import PasswordForm from "@/app/_components/PasswordForm";
import Profile from "@/app/_components/Profile";
import UserChart from "@/app/_components/UserChart";

const Page = () => {
    return (
        <div className='w-full p-5 py-2 flex flex-col gap-12 items-center '>
            <Profile />
            <div className='flex flex-col lg:flex-row justify-between w-full mt-0 md:mt-28 lg:mt-0 lg:w-[95%] gap-5'>
                <About />
                <UserChart />
                <PasswordForm />
            </div>
        </div>
    );
};

export default Page;